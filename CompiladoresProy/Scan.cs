using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CompiladoresProy;
using Globaless;
using Microsoft.VisualBasic.ApplicationServices;
using Palabras;
using static Globaless.Globals.Global;

namespace Scann
{
    class Scan
    {
        public static class Scaan
        {
            public static int BUFLEN = 256;

            public static char[] lineBuf = new char[BUFLEN];
            public static int linepos = 0;
            public static int colpos = 0;
            public static int bufsize = 0;
            

            public static int MAXTOKENLEN = 40;
            public static List<char> tokenString = new List<char>();
            
            public static string linea;



            public enum StateType
            {
                INICIO, //estado inicial
                ECOMENTARIO,//estado de comentario
                ECOMENMULTIPLE, //estado de comentario multiple
                ECOMENSIMPLE, //estado de comentario simple
                EPOSIBLECOMMULTIPLE, //estado de posible comentario multiple
                EENTEROS, //estado de enteros
                EPOSIBLENUMREAL, //estado de posible numero real
                EENTEROREAL, //estado de entero real
                EIDENTIFICADOR, //estado de identificador
                EASIGNACION, //estado de asignacion
                ESIGNOMAS, //estado de signo mas
                EINCREMENTABLE, //estado incrementable
                ESIGNOMENOS, //estado de signo menos
                EDECREMENTABLE, //estado decrementable
                ESIGNOMAYOREQ, //estado de signo mayor que
                EMAYORIGUAL, //estado de mayor igual
                ESIGNOMENOREQ, //estado de signo menor que
                EMENORIGUAL, //estado de menor igual
                EDIFERENTEDE, //estado de diferente de
                HECHO //estado terminal
            }

            public static char getNextChar()
            {
                char c;
                //////////
                string ruta = "C:\\Users\\itzia\\OneDrive\\Escritorio\\sam.txt";

                string[] vecLine = File.ReadAllLines(ruta);
                int count = 0;
                string[] v = new string[vecLine.Length];
                using (StreamReader reader = File.OpenText(ruta))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        v[count] = line;
                        count++;
                    }
                    reader.Close();
                }
                //reader.Close();

                if (!(linepos < bufsize))
                {
                    Globals.lineno = 0;
                    linea = vecLine[Globals.lineno];
                    if (linea != null)
                    {
                        Globals.lineno++;
                        bufsize = linea.Length;
                        colpos = 0;
                        c = linea[colpos];
                        colpos++;
                        return c;


                    }
                    else
                    {
                        return 'E';
                    }

                }
                else
                {
                    c = linea[colpos];
                    colpos++;
                    return (c);
                }
            }

            //public static Globals.Global.TokenType reservedWords[Globals.MAXRESERVED]
            public static Dictionary<string, Globals.Global.TokenType> reservedWords = new Dictionary<string, TokenType>()
            {
                {"if",Globals.Global.TokenType.IF},
                {"then",Globals.Global.TokenType.THEN},
                {"else",Globals.Global.TokenType.ELSE},
                {"end",Globals.Global.TokenType.END},
                {"repeat",Globals.Global.TokenType.REPEAT},
                {"until",Globals.Global.TokenType.UNTIL},
                {"main",Globals.Global.TokenType.MAIN},
                {"do",Globals.Global.TokenType.DO},
                {"while",Globals.Global.TokenType.WHILE},
                {"cin",Globals.Global.TokenType.CIN},
                {"cout",Globals.Global.TokenType.COUT},
                {"boolean",Globals.Global.TokenType.BOOLEAN},
                {"int",Globals.Global.TokenType.INT},
                {"float",Globals.Global.TokenType.FLOAT}
            };

            

            public static Globals.Global.TokenType reservedLookup(string s)
            {

                foreach(KeyValuePair<string, Globals.Global.TokenType> rw in reservedWords)
                {
                    if (String.Equals(s, rw.Key))
                    {
                        return rw.Value;    
                    }
                }

                return Globals.Global.TokenType.ID;
            }

            public static void ungetNextChar()
            {
                colpos--;   
            }

            public static Globals.Global.TokenType getToken()
            {
                
                int tokenStringIndex = 0;
                Globals.Global.TokenType currentToken;
                StateType state = StateType.INICIO;
                
                int save= Globals.TRUE; 
                char c=' ';

                while( state != StateType.HECHO )
                {
                    
                    if (save == Globals.TRUE)
                    {
                        c = getNextChar();
                    }

                    switch (state)
                    {
                        case StateType.INICIO:
                            if (Char.IsDigit(c))
                            {
                                state = StateType.EENTEROS;


                            } else if (Char.IsLetter(c)||c=='_')
                            {
                                state = StateType.EIDENTIFICADOR;
                            } else if ((c == ' ') || (c == '\t') || (c == '\n'))
                            {
                                save = Globals.FALSE;
                            } else if (c == ':')
                            {
                                state = StateType.EASIGNACION;
                            } else if (c == '+')
                            {
                                state = StateType.ESIGNOMAS;
                            } else if (c == '-')
                            {
                                state = StateType.ESIGNOMENOS;
                            } else if (c == '>')
                            {
                                state = StateType.ESIGNOMAYOREQ;
                            } else if (c == '<')
                            {
                                state = StateType.ESIGNOMENOREQ;
                            } else if (c == '/')
                            {
                                state = StateType.ECOMENTARIO;
                            }else if (c=='=')
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.IGUALDAD;
                            }
                            else if (c == '*')
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.MULTI;
                            }
                            else if (c == '(')
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.PARENIZQ;
                            }
                            else if (c == ')')
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.PARENDERE;
                            }
                            else if (c == '{')
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.LLAVEIZQ;
                            }else if (c == '}')
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.LLAVEDER;
                            }
                            else if (c == ',')
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.COMA;
                            }
                            else if (c == ';')
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.PUNTOCOMA;
                            }
                            else if (c == '%')
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.RES;
                            }
                            break;

                        case StateType.EENTEROS:
                            if (Char.IsDigit(c))
                            {
                                //state = StateType.EENTEROS;
                                tokenString.Add(c);
                            }
                            else if (c == '.')
                            {
                                state = StateType.EPOSIBLENUMREAL;
                                tokenString.Add(c);
                                save = Globals.TRUE;
                            }
                            else
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.ENTERO;
                                save = Globals.FALSE;
                                //concatenar c
                                tokenString.Add(c);
                            }
                            break;

                        case StateType.EPOSIBLENUMREAL:
                            if (Char.IsDigit(c)) {
                                state = StateType.EENTEROREAL;
                                //concatenar c
                                tokenString.Add(c);
                            }
                            else
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.ERROR;
                            }
                            break;

                        case StateType.EENTEROREAL:
                            if (Char.IsDigit(c))
                            {
                                state = StateType.EENTEROREAL;
                                //concatenar c
                                tokenString.Add(c);
                            }
                            else
                            {
                                state = StateType.HECHO;
                                save = Globals.FALSE;
                                currentToken = Globals.Global.TokenType.FLOAT;
                            }
                            break;

                        case StateType.EIDENTIFICADOR:
                            if (Char.IsLetter(c) || c == '_'||Char.IsDigit(c))
                            {
                                state=StateType.EIDENTIFICADOR;
                                //concatenar c
                                tokenString.Add(c);
                            }
                            else 
                            {
                                //currentToken = reservedLookup(tokenString);
                                save = Globals.FALSE;
                                currentToken = Globals.Global.TokenType.ID;
                                state = StateType.HECHO;
                            }
                            break;

                        case StateType.EASIGNACION:
                            if (c == '=')
                            {
                                state= StateType.HECHO;
                                //concatenar c
                                currentToken = Globals.Global.TokenType.ASIGNACION;
                                tokenString.Add(c);

                            }
                            else
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.ERROR;
                            }
                            break;

                        case StateType.ESIGNOMAS:
                            if (c == '+')
                            {
                                state = StateType.HECHO;
                                //concatenar c
                                tokenString.Add(c);
                                currentToken = Globals.Global.TokenType.PLUSPLUS;
                            }
                            else
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.SUMA;
                                save = Globals.FALSE;

                            }
                            break;

                        case StateType.ESIGNOMENOS:
                            if (c == '-')
                            {
                                state= StateType.HECHO;
                                //concatenar c
                                tokenString.Add(c);
                                currentToken = Globals.Global.TokenType.MENOSMENOS;
                            }
                            else
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.RES;
                                save = Globals.FALSE;
                            }
                            break;

                        case StateType.ESIGNOMAYOREQ:
                            if (c == '=')
                            {
                                state = StateType.EMAYORIGUAL;
                                //concatenar c
                                tokenString.Add(c);
                                currentToken = Globals.Global.TokenType.MAYOREQ;
                            }
                            else
                            {
                                state=StateType.HECHO;
                                currentToken = Globals.Global.TokenType.MAYOR;
                                save = Globals.FALSE;
                            }
                            break;

                        case StateType.ESIGNOMENOREQ:
                            if (c == '=')
                            {
                                state = StateType.HECHO;
                                //concatenar c
                                tokenString.Add(c);
                                currentToken = Globals.Global.TokenType.MENOREQ;
                            }
                            else if(c=='>')
                            {
                                state = StateType.HECHO;
                                //concatenar c
                                tokenString.Add(c);
                                currentToken = Globals.Global.TokenType.DIFERENTEDE;
                            }
                            else
                            {
                                currentToken = Globals.Global.TokenType.MENOR;
                                state = StateType.HECHO;
                                save = Globals.FALSE;
                            }
                            break;

                        case StateType.ECOMENTARIO:
                            if (c == '*')
                            {
                                state = StateType.ECOMENMULTIPLE;

                            }else if (c == '/')
                            {
                                state = StateType.ECOMENSIMPLE;
                            }
                            else
                            {
                                state = StateType.HECHO;
                                currentToken = Globals.Global.TokenType.DIV;
                                save = Globals.FALSE;
                            }
                            break;

                        default:
                                currentToken = Globals.Global.TokenType.ERROR;
                                state = StateType.HECHO;
                            break;
                        
                    }




                }

                return Globals.Global.TokenType.END;
            }


        }


    }

}
