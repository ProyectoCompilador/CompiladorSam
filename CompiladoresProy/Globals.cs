using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Globaless
{
    class Globals
    {
        public static int MAXRESERVED = 8;
        public static int FALSE = 0;
        public static int TRUE = 1;

        public static int lineno;
        public static int EchoSource;

        public static class Global
        {
            

            public enum TokenType
            {
                //book-keeping tokens
                ENDFILE,
                ERROR,
                //reserved words 
                IF,
                THEN,
                ELSE,
                END,
                REPEAT,
                UNTIL,
                MAIN,
                DO,
                WHILE,
                CIN,
                COUT,
                BOOLEAN,
                INT,
                FLOAT,
                //multicharacter tokens 
                ID,
                REAL,
                ENTERO,
               
                //special symbols
                SUMA,
                RESTA,
                MULTI,
                DIV,
                RES, //%
                MENOR, //<
                MENOREQ, //<=
                MAYOR, //>
                MAYOREQ, //>=
                IGUALDAD, //==
                DIFERENTEDE, //!=
                ASIGNACION, //:=
                PARENIZQ, //(
                PARENDERE, //)
                LLAVEDER, //}
                LLAVEIZQ, //{
                PLUSPLUS, //++
                MENOSMENOS, //--
                COMA,
                PUNTOCOMA,
                COMMENT,
                MULTICOMMENT

            }
        }
        
        //public const int MAXRESERVED = 8;
      

    }
}
