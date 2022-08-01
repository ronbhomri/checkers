using System;
using System.Collections.Generic;
using System.Drawing;

namespace B22_Ex05_Noga_206696759_Ron_206214470
{
    public class Board
    {
        private readonly int r_TableSize;
        private readonly Tile[,] r_BoardMatrix;

        public int TableSize
        {
            get
            {
                return r_TableSize;
            }
        }

        public Tile[,] Matrix
        {
            get
            {
                return r_BoardMatrix;
            }
        }

        public Board(int i_Size)
        {
            r_TableSize = i_Size;
            r_BoardMatrix = new Tile[r_TableSize, r_TableSize];
            buildBoard();
        }

        private void buildBoard()
        {
            for (int j = 0; j < r_TableSize; j++)
            {
                for (int i = 0; i < r_TableSize; i++)
                {
                    if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                    {
                        if (j < ((r_TableSize / 2) - 1))
                        {
                            r_BoardMatrix[i, j] = new Tile(2, i, j);
                        }
                        else if (j > (r_TableSize / 2))
                        {
                            r_BoardMatrix[i, j] = new Tile(1, i, j);
                        }
                        else
                        {
                            r_BoardMatrix[i, j] = new Tile(0, i, j);
                        }
                    }
                    else
                    {
                        r_BoardMatrix[i, j] = new Tile(5, i, j);
                    }
                }
            }
        }

        public class Tile
        {
            private readonly Point r_Location;
            private eSymbol m_Value;

            public enum eSymbol
            {
                Empty,
                X,
                O,
                XKing,
                OKing,
                Ilegal
            }

            public Tile(int i_Value, int i_Row, int i_Col)
            {
                m_Value = (eSymbol)i_Value;
                r_Location = new Point(i_Row, i_Col);
            }

            public int Symbol
            {
                get
                {
                    return (int)m_Value;
                }
                set
                {
                    m_Value = (eSymbol)value;
                }
            }

            public Point Location
            {
                get 
                { 
                    return r_Location; 
                }
            }

            public int Row
            {
                get
                {
                    return r_Location.X;
                }
            }

            public int Colunm
            {
                get
                {
                    return r_Location.Y;
                }
            }
        }

        public void ResetBoard()
        {
            for (int j = 0; j < r_TableSize; j++)
            {
                for (int i = 0; i < r_TableSize; i++)
                {
                    if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                    {
                        if (j < ((r_TableSize / 2) - 1))
                        {
                            r_BoardMatrix[i, j].Symbol = 2;
                        }
                        else if (j > (r_TableSize / 2))
                        {
                            r_BoardMatrix[i, j].Symbol = 1;
                        }
                        else
                        {
                            r_BoardMatrix[i, j].Symbol = 0;
                        }
                    }
                    else
                    {
                        r_BoardMatrix[i, j].Symbol = 5;
                    }
                }
            }
        }

        public void UpdateBoardAccordingToMove(Tile i_Origin, Tile i_Dest)
        {
            int manToMove = i_Origin.Symbol;

            i_Origin.Symbol = 0;
            i_Dest.Symbol = manToMove;

            if (Math.Abs(i_Origin.Colunm - i_Dest.Colunm) != 1)
            {
                if (i_Origin.Row < i_Dest.Row)
                {
                    if (i_Origin.Colunm < i_Dest.Colunm)
                    {
                        Matrix[i_Origin.Row + 1, i_Origin.Colunm + 1].Symbol = 0;
                    }
                    else
                    {
                        Matrix[i_Origin.Row + 1, i_Origin.Colunm - 1].Symbol = 0;
                    }
                }
                else
                {
                    if (i_Origin.Colunm < i_Dest.Colunm)
                    {
                        Matrix[i_Origin.Row - 1, i_Origin.Colunm + 1].Symbol = 0;
                    }
                    else
                    {
                        Matrix[i_Origin.Row - 1, i_Origin.Colunm - 1].Symbol = 0;
                    }
                }
            }
        }
    }
}

