using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Compilator
{
    public class Scaner
    {
        public string input;
        private int position = 0;
        public List<Token> tokens;
        //public List<Error> errors;

        private static readonly Dictionary<string, int> Keywords = new Dictionary<string, int>()
        {
            { "const", 1 },
            { "integer", 3 }
        };

        public Scaner(string input, List<Token> tokens)
        {
            this.input = input;
            //this.input = input.Trim();
            this.tokens = tokens;
        }

        private char CurrentChar => position < input.Length ? input[position] : '\0';

        private void NextChar() => position++;

        public void Analyze()
        {
            while (position < input.Length)
            {
                char ch = CurrentChar;
                int startPos = position;
                int endPos = position;

                switch (ch)
                {
                    case char c when char.IsLetterOrDigit(c):
                        ProcessIdentifier(startPos);
                        break;
                    case ' ':
                        //if(tokens.Count == 1) AddToken(4, "Разделитель", "_", startPos+" - "+endPos);
                        NextChar();
                        break;
                    case ':':
                        AddToken(5, "Двоеточие", ":", startPos + " - " + endPos, startPos, endPos);
                        NextChar();
                        break;
                    case '=':
                        AddToken(6, "Присваивание", "=", startPos + " - " + endPos, startPos, endPos);
                        NextChar();
                        break;
                    case '-':
                        AddToken(7, "Минус", "-", startPos + " - " + endPos, startPos, endPos);
                        NextChar();
                        break;
                    case '+':
                        AddToken(8, "Плюс", "+", startPos + " - " + endPos, startPos, endPos);
                        NextChar();
                        break;
                    /*case char c when char.IsDigit(c):
                        ProcessNumber(startPos);
                        break;*/
                    case ';':
                        AddToken(10, "Конец оператора", ";", startPos + " - " + endPos, startPos, endPos);
                        NextChar();
                        break;
                    case '\n':
                    case '\r':
                        AddToken(11, "Перенос строки", "ENTER", startPos + " - " + endPos, startPos, endPos);
                        NextChar();
                        break;
                    
                    default:
                        ProcessError(startPos);
                        //AddToken(-1, "Ошибка", ch.ToString(), startPos + " - " + endPos);
                        //NextChar();
                        break;
                }
            }
            //input += '\0';
            AddToken(12, "Конец строки", "END", input.Length + 1 + " - " + input.Length + 1, input.Length, input.Length);
        }

        private void ProcessError(int startPos)
        {
            string lexeme = "";
            while (CurrentChar != ' ' && CurrentChar != '\n' && CurrentChar != '\0' && CurrentChar != ':' && CurrentChar != ';')
            {
                lexeme += CurrentChar;
                NextChar();
            }

            int endPos = startPos + lexeme.Length;

            AddToken(-1, "Ошибка", lexeme, startPos + " - " + endPos, startPos, endPos);


        }

        private void ProcessIdentifier(int startPos)
        {
            string lexeme = "";
            int endPos = 0;
            while (CurrentChar != ' ' 
                && CurrentChar != '\n' 
                && CurrentChar != '\0' 
                && CurrentChar != ':' 
                && CurrentChar != ';' 
                && CurrentChar != '=')
            {
                lexeme += CurrentChar;
                NextChar();
                
            }

            endPos = startPos + lexeme.Length;

            int countDigit = 0;
            for(int i = 0; i < lexeme.Length; i++)
            {
                char ch = lexeme[i];
                if (char.IsDigit(ch))
                {
                    countDigit++;
                }

            }

            int countLetterDigit = 0;
            for (int i = 0; i < lexeme.Length; i++)
            {
                char ch = lexeme[i];
                if (char.IsLetterOrDigit(ch))
                {
                    countLetterDigit++;
                }

            }

            if (countDigit == lexeme.Length)
            {
                endPos = startPos + lexeme.Length;
                AddToken(9, "Целое число", lexeme, startPos + " - " + endPos, startPos, endPos);
                return;
            }
            else if (countLetterDigit == lexeme.Length)
            {
                if (char.IsDigit(lexeme[0]))
                {
                    AddToken(-1, "Ошибка", lexeme, startPos + " - " + endPos, startPos, endPos);
                    return;
                }

                string lex = lexeme.ToUpper();

                bool ru = false;
                for (int i = 0; i < lex.Length; i++)
                {
                    char c = lex[i];
                    if ((c >= 'А') && (c <= 'Я'))
                    {
                        ru = true;
                        break;
                    }
                }

                if (Keywords.TryGetValue(lexeme, out int code))
                {
                    if(code == 1)
                    {
                        AddToken(code, "Ключевое слово const", lexeme, startPos + " - " + endPos, startPos, endPos);
                    }
                    else if(code == 3)
                    {
                        AddToken(code, "Ключевое слово integer", lexeme, startPos + " - " + endPos, startPos, endPos);
                    }
                    
                    if (endPos != input.Length)
                    {
                        if (code == 1 && input[endPos] == ' ')
                        {
                            //AddToken(4, "Разделитель", "_", endPos + " - " + endPos, endPos, endPos);
                        }
                    }


                }
                else
                {
                    if (!ru)
                    {

                        AddToken(2, "Идентификатор", lexeme, startPos + " - " + endPos, startPos, endPos);
                    }
                    else
                    {
                        AddToken(-1, "Ошибка", lexeme, startPos + " - " + endPos, startPos, endPos);
                        ru = false;
                    }
                }
            }
            else
            {
                AddToken(-1, "Ошибка", lexeme, startPos + " - " + endPos, startPos, endPos);
                return;

            }


            


        }

        

        private void AddToken(int code, string type, string lexeme, string position, int start, int end)
        {
            tokens.Add(new Token {startPos = start, endPos = end, index = tokens.Count, code = code, token_type = type, token = lexeme, location = position });
        }
    }
}
