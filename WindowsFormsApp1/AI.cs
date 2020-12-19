using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class AI : Player
    {
        private int row;
        private int column;
        public AI() : base(false)
        {
            row = 0;
            column = 0;
        }
    }
}
