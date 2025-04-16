using Compilator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilator
{
    public class Document
    {
        public string filename;
        public string full_path;
        public string rtb1_text;
        public List<Token> tokens;
        public List<Error> errors;
        public string rtb3_text;
        public bool saved;
        public bool savedAs;

    }
}
