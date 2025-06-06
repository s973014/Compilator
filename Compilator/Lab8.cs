using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilator
{
    public enum TokType
    {
        ID, Plus, Minus, Multiply, Divide, Power, EOF, Unknown
    }

    public class Tok
    {
        public TokType Type { get; }
        public string Value { get; }
        public int Position { get; }

        public Tok(TokType type, string value, int position)
        {
            Type = type;
            Value = value;
            Position = position;
        }
    }

    public class Lexer
    {
        private readonly string _text;
        private int _pos;

        public Lexer(string text)
        {
            _text = text.Replace(" ", "");
            _pos = 0;
        }

        private char Current => _pos < _text.Length ? _text[_pos] : '\0';

        public Tok GetNextToken()
        {
            while (char.IsWhiteSpace(Current)) _pos++;

            int start = _pos;

            if (char.IsLetter(Current))
            {
                _pos++;
                while (char.IsLetterOrDigit(Current)) _pos++;
                return new Tok(TokType.ID, _text.Substring(start, _pos - start), start);
            }

            switch (Current)
            {
                case '+': _pos++; return new Tok(TokType.Plus, "+", start);
                case '-': _pos++; return new Tok(TokType.Minus, "-", start);
                case '*': _pos++; return new Tok(TokType.Multiply, "*", start);
                case '/': _pos++; return new Tok(TokType.Divide, "/", start);
                case '^': _pos++; return new Tok(TokType.Power, "^", start);
                case '\0': return new Tok(TokType.EOF, "", _pos);
                default: return new Tok(TokType.Unknown, Current.ToString(), _pos++);
            }
        }
    }

    public class ParserError
    {
        public string Message { get; set; }
        public int Position { get; set; }

        public ParserError(string message, int position)
        {
            Message = message;
            Position = position;
        }
    }

    public class Pars
    {
        private readonly Lexer _lexer;
        private Tok _currentToken;
        public List<ParserError> Errors { get; }
        public string TraceString { get; private set; } // строка трассировки

        public Pars(string input)
        {
            _lexer = new Lexer(input);
            _currentToken = _lexer.GetNextToken();
            Errors = new List<ParserError>();
            TraceString = "";
        }

        private void AddTrace(string step)
        {
            if (!string.IsNullOrEmpty(TraceString))
                TraceString += " => ";
            TraceString += step;
        }

        private void Eat(TokType type)
        {
            if (_currentToken.Type == type)
            {
                if(_currentToken.Type.ToString() == "ID")
                {
                    AddTrace(_currentToken.Type.ToString());
                }
                else
                {
                    AddTrace(_currentToken.Value.ToString());
                }
                
                _currentToken = _lexer.GetNextToken();
            }
            else
            {
                //Errors.Add(new ParserError($"Ожидался токен {type}, найден {_currentToken.Type}", _currentToken.Position));
                _currentToken = _lexer.GetNextToken(); // Пропуск ошибки
            }
        }

        public void Parse()
        {
            Expression();
            if (_currentToken.Type != TokType.EOF)
            {
                //Errors.Add(new ParserError("Лишний ввод после конца выражения", _currentToken.Position));
            }
            Errors.Add(new ParserError(TraceString, 0));
        }

        private void Expression()
        {
            AddTrace("expression");
            AddSub();
        }

        private void AddSub()
        {
            //AddTrace("addsub");
            MultExpr();
            while (_currentToken.Type == TokType.Plus || _currentToken.Type == TokType.Minus)
            {
                TokType op = _currentToken.Type;
                Eat(op);
                MultExpr();
            }
        }

        private void MultExpr()
        {
            AddTrace("multexpr");
            PowExpr();
            while (_currentToken.Type == TokType.Multiply || _currentToken.Type == TokType.Divide)
            {
                TokType op = _currentToken.Type;
                Eat(op);
                PowExpr();
            }
        }

        private void PowExpr()
        {
            AddTrace("powexpr");
            Primary();
            if (_currentToken.Type == TokType.Power)
            {
                Eat(TokType.Power);
                PowExpr(); // правоассоциативность
            }
        }

        private void Primary()
        {
            //AddTrace("primary");
            if (_currentToken.Type == TokType.ID)
            {
                Eat(TokType.ID);
            }
            else
            {
                //Errors.Add(new ParserError("Ожидался идентификатор", _currentToken.Position));
                _currentToken = _lexer.GetNextToken(); // восстановление
            }
        }
    }




}
