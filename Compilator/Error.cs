using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilator
{
    public class Error
    {
        public int Start;
        public int End;
        public string Position;
        public string Line;
        public string Column;
        public string Message;
    }
}
