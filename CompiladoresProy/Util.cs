using CompiladoresProy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Globaless;
using System.Windows;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using Microsoft.Win32;
using System.IO;

namespace Palabras
{

    class Util
    {
        private const string V = "Palabra Reservada: ";

        public static void printToken(Globals.Global.TokenType token, string tokenString,StreamWriter writer)
        {

            //MessageBox.Show(""+Globals.Global.MAXRESERVED);
            switch (token)
            {
                case Globals.Global.TokenType.IF:
                    
                case Globals.Global.TokenType.THEN:
                    
                case Globals.Global.TokenType.ELSE:
                    
                case Globals.Global.TokenType.END:
                   
                case Globals.Global.TokenType.REPEAT:

                case Globals.Global.TokenType.UNTIL:

                case Globals.Global.TokenType.MAIN:

                case Globals.Global.TokenType.DO:
                
                case Globals.Global.TokenType.WHILE:
                
                case Globals.Global.TokenType.CIN:

                case Globals.Global.TokenType.COUT:

                case Globals.Global.TokenType.BOOLEAN:

                case Globals.Global.TokenType.FLOAT:

                case Globals.Global.TokenType.INT:

                    //imprimir a pantalla la palabra reservada
                    //File.WriteAllText(openSalida.FileName, "Palabra Reservada: "+tokenString);
                    writer.WriteLine("Reserved Word: "+tokenString+"\n");
                    break;

                case Globals.Global.TokenType.SUMA:
                    writer.WriteLine("+\n");
                    break;
                case Globals.Global.TokenType.RESTA:
                    writer.WriteLine("-\n");
                    break;
                case Globals.Global.TokenType.MULTI:
                    writer.WriteLine("*\n");
                    break;
                case Globals.Global.TokenType.DIV:
                    writer.WriteLine("/\n");
                    break;
                case Globals.Global.TokenType.RES:
                    writer.WriteLine("%\n");
                    break;
                case Globals.Global.TokenType.MENOR:
                    writer.WriteLine("<\n");
                    break;
                case Globals.Global.TokenType.MENOREQ:
                    writer.WriteLine("<=\n");
                    break;
                case Globals.Global.TokenType.MAYOR:
                    writer.WriteLine(">\n");
                    break;
                case Globals.Global.TokenType.MAYOREQ:
                    writer.WriteLine(">=\n");
                    break;
                case Globals.Global.TokenType.IGUALDAD:
                    writer.WriteLine("==\n");
                    break;
                case Globals.Global.TokenType.DIFERENTEDE:
                    writer.WriteLine("!=\n");
                    break;
                case Globals.Global.TokenType.ASIGNACION:
                    writer.WriteLine(":=\n");
                    break;
                case Globals.Global.TokenType.PARENIZQ:
                    writer.WriteLine("(\n");
                    break;
                case Globals.Global.TokenType.PARENDERE:
                    writer.WriteLine(")\n");
                    break;
                case Globals.Global.TokenType.LLAVEIZQ:
                    writer.WriteLine("{\n");
                    break;
                case Globals.Global.TokenType.LLAVEDER:
                    writer.WriteLine("}\n");
                    break;
                case Globals.Global.TokenType.COMMENT:
                    writer.WriteLine("//\n");
                    break;
                case Globals.Global.TokenType.MULTICOMMENT:
                    writer.WriteLine("/**/\n");
                    break;
                case Globals.Global.TokenType.PLUSPLUS:
                    writer.WriteLine("++\n");
                    break;
                case Globals.Global.TokenType.MENOSMENOS:
                    writer.WriteLine("--\n");
                    break;
                case Globals.Global.TokenType.COMA:
                    writer.WriteLine(",\n");
                    break;
                case Globals.Global.TokenType.PUNTOCOMA:
                    writer.WriteLine(";\n");
                    break;

                case Globals.Global.TokenType.ID:
                    writer.WriteLine("ID, name= %s\n",tokenString);
                    break;

                case Globals.Global.TokenType.REAL:
                    writer.WriteLine("REAL, val= %s\n", tokenString);
                    break;

                case Globals.Global.TokenType.ENTERO:
                    writer.WriteLine("ENTERO, val= %s\n", tokenString);
                    break;

                case Globals.Global.TokenType.ERROR:
                    writer.WriteLine("ERROR: %s\n",tokenString);
                    break;

                default:
                    writer.WriteLine("Unknown token: %d\n",token);
                    break;

            }
        }
    }
}
