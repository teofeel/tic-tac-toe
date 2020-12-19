using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Player p1 = new Player(true);
        private Player p2 = new Player(false);
        private Player ai = new AI();

        private char[,] table = {
            {'_','_','_'},
            {'_','_','_'},
            { '_','_','_'}
        }; 

        private int n = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.Text = char.ToString(check_whos_move().x_or_o()); //menjamo tekst buttona
            game(0); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn2.Text = char.ToString(check_whos_move().x_or_o()); //menjamo tekst buttona
            game(1); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn3.Text = char.ToString(check_whos_move().x_or_o()); //menjamo tekst buttona
            game(2); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btn4.Text = char.ToString(check_whos_move().x_or_o()); //menjamo tekst buttona
            game(3); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btn5.Text = char.ToString(check_whos_move().x_or_o()); //menjamo tekst buttona
            game(4); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btn6.Text = char.ToString(check_whos_move().x_or_o()); //menjamo tekst buttona
            game(5); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btn7.Text = char.ToString(check_whos_move().x_or_o()); //menjamo tekst buttona
            game(6); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btn8.Text = char.ToString(check_whos_move().x_or_o()); //menjamo tekst buttona
            game(7); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btn9.Text = char.ToString(check_whos_move().x_or_o()); //menjamo tekst buttona
            game(8); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
        }

        private Player check_whos_move()
        {
            if (n % 2 == 0)
                return p1; //player1 uvek igra prvi, tj. on uvek igra tokom poteza parnog indeksa

            else
                return p2;
        }
        private void change_table(int polje) //menja polje u tabeli da bi se mogao proveriti kraj igre
        {
            switch(polje)
            {
                case 0:
                    table[0, 0] = check_whos_move().x_or_o();
                    break;
                case 1:
                    table[0, 1] = check_whos_move().x_or_o();
                    break;
                case 2:
                    table[0, 2] = check_whos_move().x_or_o();
                    break;
                case 3:
                    table[1, 0] = check_whos_move().x_or_o();
                    break;
                case 4:
                    table[1, 1] = check_whos_move().x_or_o();
                    break;
                case 5:
                    table[1, 2] = check_whos_move().x_or_o();
                    break;
                case 6:
                    table[2, 0] = check_whos_move().x_or_o();
                    break;
                case 7:
                    table[2, 1] = check_whos_move().x_or_o();
                    break;
                case 8:
                    table[2, 2] = check_whos_move().x_or_o();
                    break;
            }
        }
        public int end_of_game()
        {
            for (int r = 0; r < 3; r++)
            {
                if (table[r, 1] == table[r, 2] && table[r, 2] == table[r, 0])
                {
                    if (table[r, 0] == p1.x_or_o())
                    {
                        return +10;
                    }
                    else if (table[r, 0] == p2.x_or_o())
                    {
                        return -10;
                    }
                }
            }

            for (int c = 0; c < 3; c++)
            {
                if (table[1, c] == table[2, c] && table[2, c] == table[0, c])
                {
                    if (table[0, c] == p1.x_or_o())
                    {
                        return +10;
                    }
                    else if (table[0, c] == p2.x_or_o())
                    {
                        return -10;
                    }
                }
            }

            if (table[1, 1] == table[2, 2] && table[2, 2] == table[3, 3])
            {
                if (table[1, 1] == p1.x_or_o())
                {
                    return +10;
                }
                else if (table[1, 1] == p2.x_or_o())
                {
                    return -10;
                }
            }

            else if (n != 8)
                return -1;

            return 0;
        }
        void game(int polje)
        {
            change_table(polje);
            n++;

            if (end_of_game() == 10)
                MessageBox.Show($"Winner is '{p1.x_or_o()}'");

            else if (end_of_game() == -10)
                MessageBox.Show($"Winner is '{p2.x_or_o()}'");

            else if (end_of_game() == 0)
                MessageBox.Show("Tie!");
        }

        
    }
}

