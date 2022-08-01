using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace B22_Ex05_Noga_206696759_Ron_206214470
{
    public class Logic
    {
        public static bool IsLogicValidMove(Point i_Origin, Point i_Dest, Game i_Game)
        {
            int currentRow = i_Origin.X;
            int currentCol = i_Origin.Y;
            int nextRow = i_Dest.X;
            int nextCol = i_Dest.Y;
            int soldierType = i_Game.Board.Matrix[currentRow, currentCol].Symbol;
            bool flag;
            int boardSize = i_Game.Board.TableSize;
            
            if (nextCol >= boardSize || nextRow >= boardSize || nextCol < 0 || nextRow < 0) // out of bound
            {
                flag = false;
            }
            else
            {
                Board.Tile nextTile = i_Game.Board.Matrix[nextRow, nextCol];
                if (nextTile.Symbol != 0) // if next tile is  not empty
                {
                    flag = false;
                }
                else if (soldierType == 0 || soldierType == 5) // if this tile is empty
                {
                    flag = false;
                }
                else if ((soldierType != i_Game.CurrentPlayer.Sign) && (soldierType != i_Game.CurrentPlayer.Sign + 2))
                {
                    flag = false;
                }
                else if (soldierType == 1 && (nextCol == currentCol - 1) && ((nextRow == currentRow + 1) || (nextRow == currentRow - 1))) //X
                {
                    flag = true;
                }
                else if (soldierType == 2 && (nextCol == currentCol + 1) && ((nextRow == currentRow + 1) || (nextRow == currentRow - 1))) //O
                {
                    flag = true;
                }
                else if ((soldierType == 3 || soldierType == 4) && ((nextCol == currentCol + 1) || (nextCol == currentCol - 1)) && ((nextRow == currentRow + 1) || (nextRow == currentRow - 1))) // X_king or O_King
                {
                    flag = true;
                }
                else
                {
                    flag = IsCapture(i_Origin, i_Dest, i_Game);
                }
            }

            return flag;
        }

        public static bool IsCapture(Point i_Origin, Point i_Dest, Game i_Game)
        {
            bool flag = false;
            int currentRow = i_Origin.X;
            int currentCol = i_Origin.Y;
            int nextRow = i_Dest.X;
            int nextCol = i_Dest.Y;
            int soldierType = i_Game.Board.Matrix[currentRow, currentCol].Symbol;
            int boardSize = i_Game.Board.TableSize;

            if (nextCol >= boardSize || nextRow >= boardSize || nextCol < 0 || nextRow < 0) // out of bound
            {
                flag = false;
            } 
            else if (i_Game.Board.Matrix[nextRow, nextCol].Symbol != 0)
            {
                flag = false;
            }
            else
            {
                if (soldierType == 1) // X
                {
                    if (nextCol == currentCol - 2 && nextRow == currentRow + 2 && (i_Game.Board.Matrix[currentRow + 1, currentCol - 1].Symbol == 2 || i_Game.Board.Matrix[currentRow + 1, currentCol - 1].Symbol == 4))
                    {
                        flag = true;
                    }
                    else if (nextCol == currentCol - 2 && nextRow == currentRow - 2 && (i_Game.Board.Matrix[currentRow - 1, currentCol - 1].Symbol == 2 || i_Game.Board.Matrix[currentRow - 1, currentCol - 1].Symbol == 4))
                    {
                        flag = true;
                    }
                }
                else if (soldierType == 2) //O
                {
                    if (nextCol == currentCol + 2 && nextRow == currentRow + 2 && (i_Game.Board.Matrix[currentRow + 1, currentCol + 1].Symbol == 1 || i_Game.Board.Matrix[currentRow + 1, currentCol + 1].Symbol == 3))
                    {
                        flag = true;
                    }
                    else if (nextCol == currentCol + 2 && nextRow == currentRow - 2 && (i_Game.Board.Matrix[currentRow - 1, currentCol + 1].Symbol == 1 || i_Game.Board.Matrix[currentRow - 1, currentCol + 1].Symbol == 3))
                    {
                        flag = true;
                    }
                }
                else if (soldierType == 3) //X_king
                {
                    if (nextCol == currentCol - 2 && nextRow == currentRow + 2 && (i_Game.Board.Matrix[currentRow + 1, currentCol - 1].Symbol == 2 || i_Game.Board.Matrix[currentRow + 1, currentCol - 1].Symbol == 4))
                    {
                        flag = true;
                    }
                    else if (nextCol == currentCol - 2 && nextRow == currentRow - 2 && (i_Game.Board.Matrix[currentRow - 1, currentCol - 1].Symbol == 2 || i_Game.Board.Matrix[currentRow - 1, currentCol - 1].Symbol == 4))
                    {
                        flag = true;
                    }
                    else if (nextCol == currentCol + 2 && nextRow == currentRow + 2 && (i_Game.Board.Matrix[currentRow + 1, currentCol + 1].Symbol == 2 || i_Game.Board.Matrix[currentRow + 1, currentCol + 1].Symbol == 4))
                    {
                        flag = true;
                    }
                    else if (nextCol == currentCol + 2 && nextRow == currentRow - 2 && (i_Game.Board.Matrix[currentRow - 1, currentCol + 1].Symbol == 2 || i_Game.Board.Matrix[currentRow - 1, currentCol + 1].Symbol == 4))
                    {
                        flag = true;
                    }
                }
                else if (soldierType == 4) //O_king
                {
                    if (nextCol == currentCol - 2 && nextRow == currentRow + 2 && (i_Game.Board.Matrix[currentRow + 1, currentCol - 1].Symbol == 1 || i_Game.Board.Matrix[currentRow + 1, currentCol - 1].Symbol == 3))
                    {
                        flag = true;
                    }
                    else if (nextCol == currentCol - 2 && nextRow == currentRow - 2 && (i_Game.Board.Matrix[currentRow - 1, currentCol - 1].Symbol == 1 || i_Game.Board.Matrix[currentRow - 1, currentCol - 1].Symbol == 3))
                    {
                        flag = true;
                    }
                    else if (nextCol == currentCol + 2 && nextRow == currentRow + 2 && (i_Game.Board.Matrix[currentRow + 1, currentCol + 1].Symbol == 1 || i_Game.Board.Matrix[currentRow + 1, currentCol + 1].Symbol == 3))
                    {
                        flag = true;
                    }
                    else if (nextCol == currentCol + 2 && nextRow == currentRow - 2 && (i_Game.Board.Matrix[currentRow - 1, currentCol + 1].Symbol == 1 || i_Game.Board.Matrix[currentRow - 1, currentCol + 1].Symbol == 3))
                    {
                        flag = true;
                    }
                }
            }

            return flag;
        }

        public static bool MoreCapture(Board.Tile i_LocationAfterCapture, Game i_Game)
        {
            Point origin = new Point(i_LocationAfterCapture.Row, i_LocationAfterCapture.Colunm);
            Point dest = new Point(i_LocationAfterCapture.Row, i_LocationAfterCapture.Colunm);
            bool flag = false;

            for (int i = 0; i < 4; i++)
            {
                int rowMove = 2;
                int colMove = 2;

                switch (i)
                {
                    case 0:
                        rowMove = 2;
                        colMove = 2;
                        break;

                    case 1:
                        rowMove = -2;
                        colMove = -2;
                        break;

                    case 2:
                        rowMove = 2;
                        colMove = -2;
                        break;

                    case 3:
                        rowMove = -2;
                        colMove = 2;
                        break;
                }

                dest.X = origin.X + rowMove;
                dest.Y = origin.Y + colMove;
                if (IsCapture(origin, dest, i_Game))
                {
                    flag = true;
                    break;
                }       
            }

            return flag;
        }

        public static void IsKing(Point i_Dest, Game i_Game)
        {
            int symbol = i_Game.Board.Matrix[i_Dest.X, i_Dest.Y].Symbol;
            bool isKing = false;
            int nextRow = i_Dest.Y;

            if ((nextRow == (i_Game.Board.TableSize - 1)) && (symbol == 2)) //O
            {
                isKing = true;
            }

            if ((nextRow == 0) && (symbol == 1)) //X
            {
                isKing = true;
            }

            if (isKing)
            {
                i_Game.Board.Matrix[i_Dest.X, i_Dest.Y].Symbol = symbol + 2;
            }
        }

        public static bool IsPlayerWin(Game i_Game)
        {
            bool isCurrentPlayerWin = true;
            int validMoveCounter = 0;

            if (i_Game.CurrentPlayer.Soliders.Count == 0)
            {
                isCurrentPlayerWin = true;
            }
            else
            {
                foreach (Board.Tile solider in i_Game.CurrentPlayer.Soliders)
                {
                    Point origin = new Point(solider.Row, solider.Colunm);
                    Point dest = new Point(solider.Row, solider.Colunm);

                    for (int i = 0; i < 8; i++)
                    {
                        int rowMove = 1;
                        int colMove = 1;

                        switch (i)
                        {
                            case 0:
                                rowMove = -1;
                                colMove = -1;
                                break;

                            case 1:
                                rowMove = -1;
                                colMove = 1;
                                break;

                            case 2:
                                rowMove = 1;
                                colMove = -1;
                                break;

                            case 3:
                                rowMove = 1;
                                colMove = 1;
                                break;

                            case 4:
                                rowMove = 2;
                                colMove = 2;
                                break;

                            case 5:
                                rowMove = -2;
                                colMove = -2;
                                break;

                            case 6:
                                rowMove = 2;
                                colMove = -2;
                                break;

                            case 7:
                                rowMove = -2;
                                colMove = 2;
                                break;
                        }

                        dest.X = origin.X + rowMove;
                        dest.Y = origin.Y + colMove;
                        if (IsLogicValidMove(origin, dest, i_Game))
                        {
                           validMoveCounter++;
                        }
                    }
                }
            }

            if(validMoveCounter > 0)
            {
                isCurrentPlayerWin = false;
            }

            return isCurrentPlayerWin;
        }

        public static bool IsTie(Game i_Game)
        {
            bool isTie = false;

            if (IsPlayerWin(i_Game))
            {
                i_Game.ChangePlayer();
                if (IsPlayerWin(i_Game))
                {
                    isTie = true;  
                }

                i_Game.ChangePlayer();
            }

            return isTie;
        }
    }
}
