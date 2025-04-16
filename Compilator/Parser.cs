using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Windows.Forms;

namespace Compilator
{

    public class Parser
    {
        private List<Token> tokens;
        private string input;
        public List<Error> errors;
        private int position;
        private int state;

        private Token CurrentToken => position < tokens.Count ? tokens[position] : tokens[tokens.Count - 1];
        private void NextToken() => position++;

        public Parser(List<Token> tokens, string input)
        {
            this.tokens = tokens;
            this.input = input;

            //this.tokens = tokens;
        }


        private void HandleError(string message, char first, string str, int startPos, int endPos)
        {
            var (line, column) = GetLineAndColumn(startPos);
            errors.Add(new Error
            {
                Start = startPos,
                End = endPos,
                Position = $"{startPos}-{endPos}",
                Line = line.ToString(),
                Column = column.ToString(),
                Message = $"{message} {str}"
            });
        }

        private bool tryStop()
        {
            if (CurrentToken.code == 12)
            {
                
                state = 13;
                return true;
            }
            if (CurrentToken.code == 11)
            {
                

                state = 1;
                NextToken();

                return true;
            }
            
            return false;
        }

        private (int line, int column) GetLineAndColumn(int pos)
        {
            int line = 1, column = 1;
            for (int i = 0; i < pos; i++)
            {
                if (input[i] == '\n')
                {
                    line++;
                    column = 1;
                }
                else
                {
                    column++;
                }
            }
            return (line, column);
        }


        public bool Parse()
        {
            position = 0;
            state = 1;
            errors = new List<Error>();


            while (state != 13) // 9 - конечное состояние
            {
                switch (state)
                {
                    case 1: state1(); break;
                    case 2: state2(); break;
                    case 3: state3(); break;
                    case 4: state4(); break;
                    case 5: state5(); break;
                    case 6: state6(); break;
                    case 7: state7(); break;
                    case 8: state8(); break;
                        //case 9: state9(); break;
                }

            }

            return errors.Count == 0;
        }




        private void state1()
        {

            if (tryStop()) {

                return;
            }

            if(CurrentToken.code == 2)
            {
                state = 2;
                
                HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидалось ключевое слово const", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                if (tokens[position+1]?.code != 2)
                {
                    //position--;
                }
                
                return;
            }


            if (CurrentToken.code == 1)
            {
                state = 2;
            }
            else if (CurrentToken.code == -1)
            {
                state = 2;
                HandleError("Неизвестная лексема. Ожидалось ключевое слово const", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
            }
            else
            {
                state = 2;
                HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидалось ключевое слово const", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
            }
        }

        private void state2()
        {
            NextToken();

            if (tryStop())
            {
                //position--;
                HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                return;
            }

            if (CurrentToken.code == 2)
            {
                state = 3;
            }
            else
            {
                bool HasIdent = false;
                bool HasSym = false;
                bool HasInteger = false;
                bool HasEqual = false;
                bool isErr = false;
                int p = position;

                for(int i = p; i < tokens.Count; i++)
                {
                    if(tokens[i].code == 11 || tokens[i].code == 12)
                    {
                        break;

                    }
                    if (tokens[i].code == 2)
                    {
                        HasIdent = true;
                        break;
                    }
                }
                p = position;
                for (int i = p; i < tokens.Count; i++)
                {
                    if (tokens[i].code == 11 || tokens[i].code == 12)
                    {
                        break;

                    }
                    if (tokens[i].code == 5)
                    {
                        HasSym = true;
                        break;
                    }
                }
                p = position;
                for (int i = p; i < tokens.Count; i++)
                {
                    if (tokens[i].code == 11 || tokens[i].code == 12)
                    {
                        break;

                    }
                    if (tokens[i].code == 3)
                    {
                        HasInteger = true;
                        break;
                    }
                }
                p = position;
                for (int i = p; i < tokens.Count; i++)
                {
                    if (tokens[i].code == 11 || tokens[i].code == 12)
                    {
                        break;

                    }
                    if (tokens[i].code == 6)
                    {
                        HasEqual = true;
                        break;
                    }
                }


                if (HasIdent)
                {
                    while(CurrentToken.code != 2)
                    {
                        if (CurrentToken.code == -1)
                        {
                            
                            HandleError("Неизвестная лексема. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                        }
                        else
                        {
                            
                            HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                        }
                        NextToken();
                    }
                    state = 3;
                    return;
                    
                    
                }

                if (HasSym && !HasIdent)
                {
                    
                    while (CurrentToken.code != 5)
                    {
                        if (CurrentToken.code == -1)
                        {
                            isErr = true;
                            HandleError("Неизвестная лексема. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                        }
                        else
                        {
                            isErr = true;
                            HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                        }
                        NextToken();
                    }
                }
                if (HasInteger && !HasIdent && !HasSym)
                {

                    while (CurrentToken.code != 3)
                    {
                        if (CurrentToken.code == -1)
                        {
                            isErr = true;
                            HandleError("Неизвестная лексема. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                        }
                        else
                        {
                            isErr = true;
                            HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                        }
                        NextToken();
                    }
                }

                if (HasEqual && !HasIdent && !HasSym && !HasInteger)
                {

                    while (CurrentToken.code != 6)
                    {
                        if (CurrentToken.code == -1)
                        {
                            isErr = true;
                            HandleError("Неизвестная лексема. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                        }
                        else
                        {
                            isErr = true;
                            HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                        }
                        NextToken();
                    }
                }








                while (CurrentToken.code != 2)
                {
                    if (tryStop()) break;



                    if(CurrentToken.code == 5)
                    {
                        state = 3;
                        if (!isErr) {
                            HandleError($"Ожидался идентификатор", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        }
                        
                        position--;
                        return;
                    }
                    if(CurrentToken.code == 3)
                    {
                        state = 4;
                        if (!isErr)
                        {
                            HandleError($"Ожидался идентификатор", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                            
                        }
                        HandleError($"Ожидался символ ':' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        position--;
                        return;

                    }

                    if (CurrentToken.code == 6)
                    {
                        state = 5;
                        if (!isErr)
                        {
                            HandleError($"Ожидался идентификатор", ' ', "", CurrentToken.startPos, CurrentToken.endPos);

                        }
                        HandleError($"Ожидался символ ':' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        HandleError($"Ожидалось ключевое слово integer ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        position--;
                        return;

                    }

                    if (CurrentToken.code == 7 || CurrentToken.code == 8 || CurrentToken.code == 9)
                    {
                        state = 6;
                        if (!isErr)
                        {
                            HandleError($"Ожидался идентификатор", ' ', "", CurrentToken.startPos, CurrentToken.endPos);

                        }
                        //HandleError($"Ожидался символ ':' ", ' ', "_", CurrentToken.startPos, CurrentToken.endPos);
                        //HandleError($"Ожидалось ключевое слово integer ", ' ', "_", CurrentToken.startPos, CurrentToken.endPos);
                        //HandleError($"Ожидался символ '=' ", ' ', "_", CurrentToken.startPos, CurrentToken.endPos);
                        position--;
                        return;

                    }

                    if (CurrentToken.code == 10)
                    {
                        state = 7;
                        if (!isErr)
                        {
                            HandleError($"Ожидался идентификатор", ' ', "", CurrentToken.startPos, CurrentToken.endPos);

                        }
                        
                        position--;
                        return;

                    }

                    if (CurrentToken.code == -1)
                    {
                        isErr = true;
                        HandleError("Неизвестная лексема. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }
                    else
                    {
                        isErr = true;
                        HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался идентификатор", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }

                    
                    NextToken();

                }
                state = 3;
            }


        }

        private void state3()
        {
            NextToken();
            if (tryStop())
            {
                HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался символ ':' ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                return;
            }

            if (CurrentToken.code == 5)
            {
                state = 4;
            }
            else
            {
                bool isErr = false;
                while (CurrentToken.code != 5)
                {
                    if (tryStop()) break;

                    if (CurrentToken.code == 3)
                    {
                        state = 4;
                        if (!isErr)
                        {
                            HandleError($"Ожидался символ ':' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        }

                        position--;
                        return;
                    }

                    if (CurrentToken.code == 6)
                    {
                        state = 5;
                        if (!isErr)
                        {
                            HandleError($"Ожидался символ ':' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);

                        }
                        
                        HandleError($"Ожидалось ключевое слово integer ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        position--;
                        return;

                    }

                    if (CurrentToken.code == 7 || CurrentToken.code == 8 || CurrentToken.code == 9)
                    {
                        state = 6;
                        if (!isErr)
                        {
                            HandleError($"Ожидался символ ':' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);

                        }
                        
                        HandleError($"Ожидалось ключевое слово integer ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        HandleError($"Ожидался символ '=' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        position--;
                        return;

                    }

                    if (CurrentToken.code == 10)
                    {
                        state = 7;
                        if (!isErr)
                        {
                            HandleError($"Ожидался символ ':' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);

                        }
                        
                        HandleError($"Ожидалось ключевое слово integer ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        HandleError($"Ожидался символ '=' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        HandleError($"Ожидалось целое число ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        position--;
                        return;

                    }

                    


                    if (CurrentToken.code == -1)
                    {
                        isErr = true;
                        HandleError("Неизвестная лексема. Ожидался символ ':' ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }
                    else
                    {
                        isErr = true;
                        HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался символ ':' ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }


                    NextToken();

                }
                state = 4;
            }

        }

        private void state4()
        {
            NextToken();
            if (tryStop())
            {
                HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидалось ключевое слово integer", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                return;
            }

            if (CurrentToken.code == 3)
            {
                state = 5;
            }
            else
            {
                bool isErr = false;
                while (CurrentToken.code != 3)
                {
                    if (tryStop()) return;

                    if (CurrentToken.code == 6)
                    {
                        state = 5;
                        if (!isErr)
                        {
                            HandleError($"Ожидалось ключевое слово integer ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        }

                        position--;
                        return;
                    }

                    

                    if (CurrentToken.code == 7 || CurrentToken.code == 8 || CurrentToken.code == 9)
                    {
                        state = 6;
                        if (!isErr)
                        {
                            HandleError($"Ожидалось ключевое слово integer ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);

                        }

                        
                        HandleError($"Ожидался символ '=' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        position--;
                        return;

                    }

                    if (CurrentToken.code == 10)
                    {
                        state = 7;
                        if (!isErr)
                        {
                            HandleError($"Ожидалось ключевое слово integer ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);

                        }

                        
                        HandleError($"Ожидался символ '=' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        HandleError($"Ожидалось целое число ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        position--;
                        return;

                    }

                    if (CurrentToken.code == -1)
                    {
                        isErr = true;
                        HandleError("Неизвестная лексема. Ожидалось ключевое слово integer", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }
                    else
                    {
                        isErr = true;
                        HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидалось ключевое слово integer ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }


                    NextToken();

                }
                state = 5;
            }
        }

        private void state5()
        {
            NextToken();
            if (tryStop())
            {
                HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался символ '=' ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                return;
            }

            if (CurrentToken.code == 6)
            {
                state = 6;
            }
            else
            {
                bool isErr = false;
                while (CurrentToken.code != 6)
                {
                    if (tryStop()) break;

                    if (CurrentToken.code == 7 || CurrentToken.code == 8 || CurrentToken.code == 9)
                    {
                        state = 6;
                        if (!isErr)
                        {
                            HandleError($"Ожидался символ '=' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        }

                        position--;
                        return;
                    }
                    

                    if (CurrentToken.code == 10)
                    {
                        state = 7;
                        if (!isErr)
                        {
                            HandleError($"Ожидался символ '=' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);

                        }


                        
                        HandleError($"Ожидалось целое число ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        position--;
                        return;

                    }

                    if (CurrentToken.code == -1)
                    {
                        isErr = true;
                        HandleError("Неизвестная лексема. Ожидался символ '=' ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }
                    else
                    {
                        isErr = true;
                        HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался символ '=' ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }


                    NextToken();

                }
                state = 6;
            }
        }

        private void state6()
        {
            NextToken();
            if (tryStop())
            {
                HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидалось целое число ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                return;
            }

            if(CurrentToken.code == 7 || CurrentToken.code == 8)
            {
                NextToken();
            }

            if(CurrentToken.code == 9)
            {
                state = 7;
            }
            else
            {
                bool isErr = false;
                while (CurrentToken.code != 9)
                {
                    if(CurrentToken.code == 11)
                    {
                        HandleError($" Ожидался символ ';' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        state = 1;
                        return;
                    }
                    
                    if (tryStop()) return;

                    if (CurrentToken.code == 10)
                    {
                        state = 7;
                        if (!isErr)
                        {
                            HandleError($"Ожидалось целое число ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        }

                        position--;
                        return;
                    }

                    if (CurrentToken.code == -1)
                    {
                        isErr = true;
                        HandleError("Неизвестная лексема. Ожидалось целое число", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }
                    else
                    {
                        isErr = true;
                        HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидалось целое число", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }


                    NextToken();

                }
                state = 7;
            }

        }

        private void state7()
        {
            NextToken();
            if (tryStop())
            {
                HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался символ ';' ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                return;
            }
            if (CurrentToken.code == 10)
            {
                state = 8;
            }
            else
            {
                bool isErr = false;
                while (CurrentToken.code != 10)
                {
                    if (tryStop()) break;

                    if (CurrentToken.code == 12)
                    {
                        state = 7;
                        if (!isErr)
                        {
                            HandleError($" Ожидался символ ';' ", ' ', "", CurrentToken.startPos, CurrentToken.endPos);
                        }

                        position--;
                        return;
                    }

                    if (CurrentToken.code == -1)
                    {
                        isErr = true;
                        HandleError("Неизвестная лексема. Ожидался символ ';' ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }
                    else
                    {
                        isErr = true;
                        HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался символ ';' ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);
                    }


                    NextToken();

                }
                state = 8;
            }
        }

        private void state8()
        {
            while (true)
            {
                NextToken();
                if(tryStop())return;
                HandleError($"Неожиданная лексема {CurrentToken.token_type}. Ожидался перенос строки ", CurrentToken.token[0], CurrentToken.token, CurrentToken.startPos, CurrentToken.endPos);


            }
        }
    }

}


        /*public class Parser
        {
            private List<Token> tokens;
            private int position;
            private int state;
            private string input;
            public List<Error> errors;
            private string id;

            public Parser(string input)
            {
                this.input = input.Trim();

                //this.tokens = tokens;
            }

            public List<Error> GetErrors()
            {
                return errors;
            }

            public bool Parse()
            {
                position = 0;
                state = 1;
                errors = new List<Error>();

                id = "";

                while (state != 13) // 9 - конечное состояние
                {
                    switch (state)
                    {
                        case 1: state1(); break;
                        case 2: state2(); break;
                        case 3: state3(); break;
                        case 4: state4(); break;
                        case 5: state5(); break;
                        case 6: state6(); break;
                        case 7: state7(); break;
                        case 8: state8(); break;
                        case 9: state9(); break;
                    }

                }

                return errors.Count == 0;
            }

            private char CurrentChar => position < input.Length ? input[position] : '\0';
            private void NextChar() => position++;


            private (int line, int column) GetLineAndColumn(int pos)
            {
                int line = 1, column = 1;
                for (int i = 0; i < pos; i++)
                {
                    if (input[i] == '\n')
                    {
                        line++;
                        column = 1;
                    }
                    else
                    {
                        column++;
                    }
                }
                return (line, column);
            }


            private void HandleError(string message, char first, string str)
            {
                errors.Add(new Error { Position = "", Line = "", Column = "", Message = message + "' " + str + " '"});
                //NextChar(); // Пропускаем ошибочный токен
            }

            private void HandleError(string message, char first, string str, int startPos, int endPos)
            {
                var (line, column) = GetLineAndColumn(startPos);
                errors.Add(new Error
                {
                    Start = startPos,
                    End = endPos,
                    Position = $"{startPos}-{endPos}",
                    Line = line.ToString(),
                    Column = column.ToString(),
                    Message = $"{message}: {str}"
                });
            }

            public bool IsLatinLetter(char c)
            {
                return char.IsLetter(c) && c >= 'A' && c <= 'z' && (c <= 'Z' || c >= 'a');
            }

            public bool IsLatinLetterOrDigit(char c)
            {
                return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');
            }


            private bool tryStop()
            {
                if(CurrentChar == '\0')
                {
                    state = 13;
                    return true;
                }
                if( CurrentChar == '\n')
                {
                    state = 1;
                    NextChar();
                    while (CurrentChar == ' ') NextChar();
                    return true;
                }
                if(CurrentChar == ';')
                {

                    NextChar();
                    while (CurrentChar == ' ') NextChar();

                    if (CurrentChar != '\0')
                    {
                        state = 1;
                        if (CurrentChar == '\n')
                        {
                            NextChar();


                            while (CurrentChar == ' ') NextChar();
                        }
                    }
                    else
                    {
                        state = 13;
                    }




                    return true;
                }
                return false;
            }
            private void state1()
            {



                id = "";
                char c = CurrentChar;

                if(tryStop())return;
                c = CurrentChar;
                if(c == '\n')return;

                if (IsLatinLetter(c))
                {
                    state = 2;
                    id += c;
                }

                else
                {
                    String remStr = "";

                    char firstIncorrect = c;
                    int startPos = position;
                    while(!IsLatinLetter(c))
                    {
                        remStr += c;
                        NextChar();
                        c = CurrentChar;
                        if (tryStop()) break;
                    }
                    int endPos = position;
                    HandleError("Неожиданный символ s1", firstIncorrect, remStr, startPos, endPos);


                }
            }


            private void state2()
            {
                NextChar();
                char c = CurrentChar;
                if (IsLatinLetter(c))
                {
                    state = 2;
                    id += c;
                }
                else if (c == ' ')
                {
                    state = 3;

                    if (!id.Equals("const"))
                    {
                        HandleError("Ожидалось ключевое слово const s2.", id[0], id);
                    }

                    while (true)
                    {
                        if (IsLatinLetterOrDigit(c)) {
                            position--;
                            break;
                        } 
                        if(c == ':')
                        {
                            state = 5;
                            HandleError("Ожидался идентификатор s2",' ',"");
                            break;
                        }
                        NextChar();
                        c = CurrentChar;
                        if (c != ' ' && !IsLatinLetter(c) && c!= ':' && !char.IsDigit(c))
                        {
                            String remStr = "";
                            char firstIncorrect = c;
                            int startPos = position;
                            while (c != ' ' && !IsLatinLetter(c) && c != ':' && !char.IsDigit(c))
                            {
                                remStr += c;
                                NextChar();
                                c = CurrentChar;
                                if (tryStop()) break;
                            }
                            int endPos = position;
                            HandleError("Неожиданный символ s2", firstIncorrect, remStr, startPos, endPos);



                        }

                    }


                }
                else
                {

                    String remStr = "";
                    char firstIncorrect = c;
                    int startPos = position;
                    while (!IsLatinLetter(c))
                    {
                        if (c == '\n' || c == '\t' || c == '\0') remStr += "<конец строки>";
                        remStr += c;
                        NextChar();
                        c = CurrentChar;

                        if (tryStop()) break;
                    }
                    int endPos = position;
                    position --;
                    HandleError("Неожиданный символ s2", firstIncorrect, remStr, startPos, endPos);
                }

            }
            private void state3()
            {
                NextChar();
                char c = CurrentChar;
                if (IsLatinLetter(c))
                {
                    state = 4;
                }
                else if (c == ':')
                {
                    state = 5;
                    HandleError("Ожидался идентификатор s3", ' ', "");
                }
                else if (char.IsDigit(c))
                {
                    state = 4;   
                    String remStr = "";
                    char firstIncorrect = c;
                    int startPos = position;
                    int endPos = position;
                    remStr += c;
                    HandleError("Неожиданный символ s3", firstIncorrect, remStr, startPos, endPos);
                    tryStop();

                }
                else
                {
                    *//*String remStr = "";
                    char firstIncorrect = c;

                    remStr += c;
                    HandleError("Неожиданный символ s3: '" + firstIncorrect
                   + "'.");*//*
                    tryStop();
                }
            }

            private void state4()
            {
                NextChar();
                char c = CurrentChar;


                if (c == ':')
                {
                    state = 5;
                }
                else if (IsLatinLetterOrDigit(c))
                {
                    state = 4;

                }
                else if (c == ' ')
                {
                    state = 5;
                    while (true)
                    {

                        if (c == ':')
                        {
                            //position--;

                            break;
                        }
                        *//*if (char.IsLetterOrDigit(c))
                        {
                            state = 5;
                            position--;
                            break;
                        }*//*

                        NextChar();
                        c = CurrentChar;
                        //if (c != ' ' && c != ':' && !char.IsLetterOrDigit(c))
                        if (c != ' ' && c != ':')
                        {
                            String remStr = "";
                            char firstIncorrect = c;
                            int startPos = position;
                            int endPos = position;
                            while (c != ' ' && c != ':')
                            {
                                if (c == '\n' || c == '\t' || c == '\0') remStr += "<конец строки>";
                                remStr += c;
                                NextChar();
                                c = CurrentChar;

                                if (tryStop()) 
                                {
                                    endPos = position;
                                    HandleError("Неожиданный символ s4", firstIncorrect, remStr, startPos, endPos);
                                    return;

                                } 
                            }
                            endPos = position;
                            HandleError("Неожиданный символ s4", firstIncorrect, remStr, startPos, endPos);


                        }

                    }
                }
                else
                {
                    String remStr = "";
                    char firstIncorrect = c;
                    int startPos = position;
                    while (!IsLatinLetterOrDigit(c) && c != ' ' && c != ':')
                    {
                        if (c == '\n' || c == '\t' || c == '\0') remStr += "<конец строки>";
                        remStr += c;
                        NextChar();
                        c = CurrentChar;

                        if (tryStop()) break;
                    }
                    int endPos = position;
                    position--;
                    HandleError("Неожиданный символ s4", firstIncorrect, remStr, startPos, endPos);
                }
            }


            private void state5()
            {
                id = "";
                NextChar();
                char c = CurrentChar;


                if (IsLatinLetter(c))
                {
                    state = 6;
                    id += c;
                }
                else if (c == ' ')
                {
                    state = 6;
                    while (true)
                    {

                        if (IsLatinLetter(c))
                        {
                            //position--;

                            id += c;
                            break;
                        }
                        if(c == '=')
                        {
                            position--;
                            state = 6;
                            break;
                        }

                        NextChar();
                        c = CurrentChar;
                        if (c != ' ' && !IsLatinLetter(c) && c != '=')
                        {
                            String remStr = "";
                            char firstIncorrect = c;
                            int startPos = position;
                            while (c != ' ' && !IsLatinLetter(c) && c != '=')
                            {
                                remStr += c;
                                NextChar();
                                c = CurrentChar;

                                if (tryStop()) break;
                            }
                            int endPos = position;
                            HandleError("Неожиданный символ s5", firstIncorrect, remStr, startPos, endPos);

                        }

                    }
                }
                else
                {
                    String remStr = "";
                    char firstIncorrect = c;
                    int startPos = position;
                    while (!IsLatinLetter(c) && c != ' ')
                    {
                        remStr += c;
                        NextChar();
                        c = CurrentChar;

                        if (tryStop()) break;
                    }
                    int endPos = position;
                    position--;
                    HandleError("Неожиданный символ s5", firstIncorrect, remStr, startPos, endPos);


                }
            }



            private void state6()
            {
                NextChar();
                char c = CurrentChar;
                if (IsLatinLetter(c))
                {
                    state = 6;
                    id += c;
                }
                else if (c == ' ')
                    {
                    if (!id.Equals("integer"))
                    {

                        HandleError("Ожидалось ключевое слово integer s6.", id[0], id);
                        tryStop();
                    }

                    while (c != '=')
                    {
                        NextChar();
                        c = CurrentChar;
                        if (c != ' ' && c != '=')
                        {
                            String remStr = "";
                            char firstIncorrect = c;
                            int startPos = position;
                            int endPos = position;
                            while (c != ' ' && c != '=')
                            {
                                remStr += c;
                                NextChar();
                                c = CurrentChar;

                                if (tryStop())
                                {
                                    endPos = position;
                                    HandleError("Неожиданный символ s6", firstIncorrect, remStr, startPos, endPos);
                                    return;
                                }
                            }
                            endPos = position;
                            HandleError("Неожиданный символ s6", firstIncorrect, remStr, startPos, endPos);

                        }

                    }
                    if (state == 13) return; //!!!!!!!!!!!!!!
                    while (true)
                    {
                        if (char.IsDigit(c) || c == '-' || c == '+') { 
                            position--;
                            break;
                        }
                        NextChar();
                        c = CurrentChar;
                        if (c != ' ' && c != '-' && c != '+' && !char.IsDigit(c))
                        {
                            //if (tryStop()) break;
                            String remStr = "";
                            char firstIncorrect = c;
                            int startPos = position;
                            int endPos = position;
                            while (c != ' ' && c != '-' && c != '+' && !char.IsDigit(c))
                            {
                                remStr += c;
                                NextChar();
                                c = CurrentChar;

                                if (tryStop()) 
                                {
                                    endPos = position;
                                    HandleError("Неожиданный символ s6", firstIncorrect, remStr, startPos, endPos);
                                    return;
                                }

                            }
                            endPos = position;
                            HandleError("Неожиданный символ s6", firstIncorrect, remStr, startPos, endPos);

                        }

                    }
                    if(state != 1 && state != 13)state = 7;
                    //this.input = input.Replace(" ", "");

                }
                else if (c == '=')
                {
                    state = 7;
                    if (!id.Equals("integer"))
                    {
                        HandleError("Ожидалось ключевое слово integer s6.", id[0], id);
                    }

                    while (true)
                    {
                        if (char.IsDigit(c) || c == '-' || c == '+') 
                        {
                            position--;
                            break;
                        } 
                        NextChar();
                        c = CurrentChar;
                        if (c != ' ' && c != '-' && c != '+' && !char.IsDigit(c))
                        {
                            //if (tryStop()) break;
                            String remStr = "";
                            char firstIncorrect = c;
                            int startPos = position;
                            int endPos = position;
                            while (c != ' ' && c != '-' && c != '+' && !char.IsDigit(c))
                            {
                                remStr += c;
                                NextChar();
                                c = CurrentChar;

                                if (tryStop())
                                {
                                    endPos = position;
                                    HandleError("Неожиданный символ s6", firstIncorrect, remStr, startPos, endPos);
                                    return;
                                }
                            }
                            endPos = position;
                            HandleError("Неожиданный символ s6", firstIncorrect, remStr, startPos, endPos);
                        }

                    }
                }
                else
                {
                    String remStr = "";
                    char firstIncorrect = c;
                    int startPos = position;
                    int endPos = position;
                    while (c != ' ' && c != '=' && !IsLatinLetter(c))
                    {
                        remStr += c;
                        NextChar();
                        c = CurrentChar;

                        if (tryStop())
                        {
                            endPos = position;
                            HandleError("Неожиданный символ s6", firstIncorrect, remStr, startPos, endPos);
                            return;
                        }
                    }
                    endPos = position;
                    position--;

                    HandleError("Неожиданный символ s6", firstIncorrect, remStr, startPos, endPos);
                }
            }
            private void state7()
            {
                NextChar();
                char c = CurrentChar;




                if (char.IsDigit(c))
                {
                    state = 8;
                }
                else if (c == '-' || c == '+')
                {
                    state = 8;
                }
                else
                {
                    String remStr = "";
                    char firstIncorrect = c;
                    int startPos = position;
                    while (!(c == '-' || c == '+') && !char.IsDigit(c))
                    {
                        remStr += c;
                        NextChar();
                        c = CurrentChar;

                        if (tryStop()) break;
                    }
                    int endPos = position;
                    HandleError("Неожиданный символ s7", firstIncorrect, remStr, startPos, endPos);
                }
            }

            private void state8()
            {
                NextChar();
                char c = CurrentChar;

                String remStr;
                char firstIncorrect;

                if (char.IsDigit(c))
                {
                    state = 8;
                }

                else 
                if (c == ';')
                {
                    //NextChar();
                    //c = CurrentChar;

                    tryStop();
                    return;
                    //state = 13;
                }
                else
                {
                    if(c == ' ')
                    {
                        while (true)
                        {

                            if (c == ';') 
                            {
                                tryStop();
                                //state = 13;
                                return;
                            } 
                            NextChar();
                            c = CurrentChar;
                            if (c != ' ' && c != ';' && !char.IsDigit(c))
                            {
                                remStr = "";
                                firstIncorrect = c;
                                int startPos = position;
                                while (c != ' ' && c != ';' && !char.IsDigit(c))
                                {
                                    if (c == '\n' || c == '\t' || c == '\0') remStr += "<конец строки>";
                                    remStr += c;
                                    NextChar();
                                    c = CurrentChar;

                                    if (tryStop()) break;
                                }
                                int endPos = position;
                                HandleError("Неожиданный символ s8", firstIncorrect, remStr, startPos, endPos);
                            }

                        }
                    }
                    else
                    {
                        remStr = "";
                        firstIncorrect = c;
                        int startPos = position;
                        int endPos = position;
                        while (c != ' ')
                        {
                            if (c == '\n' || c == '\t' || c == '\0') remStr += "<конец строки>";
                            if (tryStop())
                            {
                                endPos = position;
                                HandleError("Неожиданный символ s8", firstIncorrect, remStr, startPos, endPos);
                                return;
                            }
                            remStr += c;
                            NextChar();
                            c = CurrentChar;


                        }
                        endPos = position;
                        HandleError("Неожиданный символ s8", firstIncorrect, remStr, startPos, endPos);
                    }

                }
            }

            private void state9()
            {

            }

        }*/