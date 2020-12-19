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
        //private Player p2 = new Player(false);
        private AI ai = new AI();
        private bool againstAI = false;
        private bool ai_is_firstPlayer = false;

        private char[,] table = new char[3,3]{
            {'_','_','_'},
            {'_','_','_'},
            {'_','_','_'}
        }; 

        private int n = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            game(btn1.TabIndex); //menjamo tabelu na poziciji [0,0] sa igracem ciji potez
            if ((n % 2 != 0 && againstAI == true) || (ai_is_firstPlayer && againstAI == true))
                AIgame();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            game(btn2.TabIndex); //menjamo tabelu na poziciji [0,1] sa igracem ciji potez
            if ((n % 2 != 0 && againstAI == true) || (ai_is_firstPlayer && againstAI == true))
                AIgame();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            game(btn3.TabIndex); //menjamo tabelu na poziciji [0,2] sa igracem ciji potez
            if((n % 2 != 0 && againstAI == true) || (ai_is_firstPlayer && againstAI == true))
                AIgame();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            game(btn4.TabIndex); //menjamo tabelu na poziciji [1,0] sa igracem ciji potez
            if ((n % 2 != 0 && againstAI == true) || (ai_is_firstPlayer && againstAI == true))
                AIgame();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            game(btn5.TabIndex); //menjamo tabelu na poziciji [1,1] sa igracem ciji potez
            if ((n % 2 != 0 && againstAI == true) || (ai_is_firstPlayer && againstAI == true))
                AIgame();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            game(btn6.TabIndex); //menjamo tabelu na poziciji [1,2] sa igracem ciji potez
            if ((n % 2 != 0 && againstAI == true) || (ai_is_firstPlayer && againstAI == true))
                AIgame();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            game(btn7.TabIndex); //menjamo tabelu na poziciji [2,0] sa igracem ciji potez
            if ((n % 2 != 0 && againstAI == true) || (ai_is_firstPlayer && againstAI == true))
                AIgame();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            game(btn8.TabIndex); //menjamo tabelu na poziciji [2,1] sa igracem ciji potez
            if ((n % 2 != 0 && againstAI == true) || (ai_is_firstPlayer && againstAI == true))
                AIgame();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            game(btn9.TabIndex); //menjamo tabelu na poziciji [2,2] sa igracem ciji potez, tekst na tom dugmetu i njegovu funkcionalnost
            if ((n % 2 != 0 && againstAI == true) || (ai_is_firstPlayer && againstAI == true))
                AIgame();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            againstAI = true;
            lbl1.Text = "Playing against AI";
            if(ai.firstPlayer==true)
            {
                AIgame();

            }
        }
        private void cbn1_CheckedChanged(object sender, EventArgs e)
        {
            p1.firstPlayer = false;
            ai.firstPlayer = true;
            ai_is_firstPlayer = true;
            lbl2.Text = "AI is first player";
        }

        private Player check_whos_move()
        {
            if (n % 2 == 0 && !ai_is_firstPlayer)
                return p1; //player1 uvek igra prvi, tj. on uvek igra tokom poteza parnog indeksa

            else if (n % 2 != 0 && !ai_is_firstPlayer)
                return ai;

            else if (ai_is_firstPlayer && n % 2 == 0)
                return ai;

            else if (ai_is_firstPlayer && n % 2 != 0)
                return p1;

            else return null;
        }
        private void change_table(int polje) //menja polje u tabeli da bi se mogao proveriti kraj igre
        {
            switch (polje)
            {
                case 0:
                    btn1.Text = check_whos_move().x_or_o().ToString();
                    table[0, 0] = check_whos_move().x_or_o();
                    btn1.Enabled = false;
                    break;

                case 1:
                    btn2.Text = check_whos_move().x_or_o().ToString();
                    table[0, 1] = check_whos_move().x_or_o();
                    btn2.Enabled = false;
                    break;

                case 2:
                    btn3.Text = check_whos_move().x_or_o().ToString();
                    table[0, 2] = check_whos_move().x_or_o();
                    btn3.Enabled = false;
                    break;

                case 3:
                    btn4.Text = check_whos_move().x_or_o().ToString();
                    table[1, 0] = check_whos_move().x_or_o();
                    btn4.Enabled = false;
                    break;

                case 4:
                    btn5.Text = check_whos_move().x_or_o().ToString();
                    table[1, 1] = check_whos_move().x_or_o();
                    btn5.Enabled = false;
                    break;

                case 5:
                    btn6.Text = check_whos_move().x_or_o().ToString();
                    table[1, 2] = check_whos_move().x_or_o();
                    btn6.Enabled = false;
                    break;

                case 6:
                    btn7.Text = check_whos_move().x_or_o().ToString();
                    table[2, 0] = check_whos_move().x_or_o();
                    btn7.Enabled = false;
                    break;

                case 7:
                    btn8.Text = check_whos_move().x_or_o().ToString();
                    table[2, 1] = check_whos_move().x_or_o();
                    btn8.Enabled = false;
                    break;

                case 8:
                    btn9.Text = check_whos_move().x_or_o().ToString();
                    table[2, 2] = check_whos_move().x_or_o();
                    btn9.Enabled = false;
                    break;
            }
        }
        public int end_of_game()
        {
            for (int r = 0; r < 3; r++)
            {
                if ((table[r, 0] == table[r, 1]) && (table[r, 1] == table[r, 2]))
                {
                    if (table[r, 0] == p1.x_or_o())
                    {
                        return +10;
                    }
                    else if (table[r, 0] == ai.x_or_o())
                    {
                        return -10;
                    }
                }
            }

            for (int c = 0; c < 3; c++)
            {
                if ((table[0, c] == table[1, c]) && (table[1, c] == table[2, c]))
                {
                    if (table[0, c] == p1.x_or_o())
                    {
                        return +10;
                    }
                    else if (table[0, c] == ai.x_or_o())
                    {
                        return -10;
                    }
                }
            }
            if ((table[0, 0] == table[1, 1]) && (table[1, 1] == table[2, 2]))
            {
                if (table[0, 0] == p1.x_or_o())
                {
                    return +10;
                }
                else if (table[0, 0] == ai.x_or_o())
                {
                    return -10;
                }
            }

            else if ((table[0, 2] == table[1, 1]) && (table[1, 1] == table[2, 0]))
            {
                if (table[0, 2] == p1.x_or_o())
                {
                    return +10;
                }
                else if (table[0, 2] == ai.x_or_o())
                {
                    return -10;
                }
            }

            else if (n == 9)
                return 0;

            return -1;
        }
        public void game(int polje)
        {
            change_table(polje);
            n++;

            if (end_of_game() == 10)
            {
                MessageBox.Show($"Winner is '{p1.x_or_o()}'");
                Application.Exit();
            }

            else if (end_of_game() == -10)
            {
                MessageBox.Show($"Winner is '{ai.x_or_o()}'");
                Application.Exit();
            }

            else if (end_of_game() == 0)
            {
                MessageBox.Show("Tie!");
                Application.Exit();
            }
        }

        void AIgame()
        {
            ai.choose_move(table,p1,p1.firstPlayer);
            switch(ai.Row)
            {
                case 0:
                    switch (ai.Column)
                    {
                        case 0:
                            game(0);
                            break;
                        case 1:
                            game(1);
                            break;
                        case 2:
                            game(2);
                            break;
                    }
                    break;
                case 1:
                    switch (ai.Column)
                    {
                        case 0:
                            game(3);
                            break;
                        case 1:
                            game(4);
                            break;
                        case 2:
                            game(5);
                            break;
                    }
                    break;
                case 2:
                    switch (ai.Column)
                    {
                        case 0:
                            game(6);
                            break;
                        case 1:
                            game(7);
                            break;
                        case 2:
                            game(8);
                            break;
                    }
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}

