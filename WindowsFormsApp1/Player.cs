using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Player
    {
        private bool first_player;
        public bool firstPlayer
        {
            get { return first_player; }
            set { first_player = value; }
        }
        public Player(bool first_player)
        {
            this.first_player = first_player;
        }

        public char x_or_o()
        {
            if (first_player)
                return 'X';
            else
                return 'O';
        }
    }
}
