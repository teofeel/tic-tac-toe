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

        public int Row
        {
            get { return row; }
            set { row = value; }
        }


        private int column;

        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        private char[,] board = new char[3,3];
        public AI() : base(false)
        {
            row = 0;
            column = 0;
        }

        private bool no_moves_left()
        {
            for(int r=0;r<3;r++)
            {
                for(int c=0;c<3;c++)
                {
                    if (board[r, c] == '_')
                        return true;
                }
            }
            return false;
        }
        private int check_end(Player p)
        {
            for(int r=0;r<3;r++)
            {
                if ((board[r, 0] == board[r, 1]) && (board[r, 1] == board[r, 2]))
                {
                    if (board[r, 0] == x_or_o())
                    {
                        return +10;
                    }
                    else if (board[r, 0] == p.x_or_o())
                    {
                        return -10;
                    }
                }
            }

            for(int c=0;c<3;c++)
            {

                if ((board[0, c] == board[1, c]) && (board[1, c] == board[2, c]))
                {
                    if (board[0, c] == x_or_o())
                    {
                        return +10;
                    }
                    else if (board[0, c] == p.x_or_o())
                    {
                        return -10;
                    }
                }
            }

            if ((board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2]))
            {
                if (board[0, 0] == x_or_o())
                {
                    return +10;
                }
                else if (board[0, 0] == p.x_or_o())
                {
                    return -10;
                }
            }
            else if ((board[0, 2] == board[1, 1]) && (board[1, 1] == board[2, 0]))
            {
                if (board[0, 2] == x_or_o())
                {
                    return +10;
                }
                else if (board[0, 2] == p.x_or_o())
                {
                    return -10;
                }
            }

            return 0;
        }
        public void choose_move(char[,] b, Player p,bool fp)
        {
            this.board = b;
            int best = -1000;

            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    if(board[i,j]=='_')
                    {
                        board[i, j] = x_or_o();
                        int move = minimax(0,fp,p); //ako je fp == true, bot nam je drugi igrac
                        board[i, j] = '_';
                        if(move > best)
                        {
                            best = move;
                            row = i;
                            column = j;
                        }
                    }
                }
            }
        }

        public int minimax(int depth, bool ismax, Player p)
        {
            int end = check_end(p);

            if (end == 10)
                return end;
            else if (end == -10)
                return end;
            else if (no_moves_left() == false)
                return 0;

            if (p.firstPlayer)
            {
                if (ismax)
                {
                    int best = -1000;
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (board[r, c] == '_')
                            {
                                board[r, c] = p.x_or_o();
                                int score = minimax(depth + 1, false, p);
                                board[r, c] = '_';
                                best = Math.Max(score, best);
                            }
                        }
                    }
                    return best;
                }
                else
                {
                    int best = 1000;
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (board[r, c] == '_')
                            {
                                board[r, c] = x_or_o();
                                int score = minimax(depth + 1, true, p);
                                board[r, c] = '_';
                                best = Math.Min(score, best);
                            }
                        }
                    }
                    return best;
                }
            }

            else
            {
                if (ismax)
                {
                    int best = -1000;
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (board[r, c] == '_')
                            {
                                board[r, c] = x_or_o();
                                int score = minimax(depth + 1, false, p);
                                board[r, c] = '_';
                                best = Math.Max(score, best);
                            }
                        }
                    }
                    return best;
                }
                else
                {
                    int best = 1000;
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (board[r, c] == '_')
                            {
                                board[r, c] = p.x_or_o();
                                int score = minimax(depth + 1, true, p);
                                board[r, c] = '_';
                                best = Math.Min(score, best);
                            }
                        }
                    }
                    return best;
                }
            }
        }
    }
}
