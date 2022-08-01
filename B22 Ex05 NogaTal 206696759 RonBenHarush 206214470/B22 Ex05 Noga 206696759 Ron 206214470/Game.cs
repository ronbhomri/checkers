using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B22_Ex05_Noga_206696759_Ron_206214470
{
    public class Game
    {
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Player m_CurrentPlayer;
        private readonly Board r_Board;
        private eGameState m_State;
        private bool m_TurnOver;

        public Game(Player i_Player1, Player i_Player2, Board i_Board)
        {
            r_Player1 = i_Player1;
            r_Player2 = i_Player2;
            r_Board = i_Board;
            m_State = eGameState.Continue;
            m_CurrentPlayer = i_Player1;
            SetSolidersList();
        }

        public Board Board
        {
            get
            {
                return r_Board;
            }
        }

        public eGameState State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
            }
        }

        public Player Player1
        {
            get
            {
                return r_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return r_Player2;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
            set
            {
                m_CurrentPlayer = value;
            }
        }

        public enum eGameState
        {
            Continue,
            WinPlayer1,
            WinPlayer2,
            Tie
        }

        public bool TurnOver
        {
            get 
            { 
                return m_TurnOver;
            }  
            set 
            { 
                m_TurnOver = value; 
            } 
        }

        public void Turn(Point i_Origin, Point i_Dest, out bool o_MoreCaptureFlag)
        {
            Board.Tile currentTile = r_Board.Matrix[i_Origin.X, i_Origin.Y];
            Board.Tile nextTile = r_Board.Matrix[i_Dest.X, i_Dest.Y];
            o_MoreCaptureFlag = false;
            m_TurnOver = true;
            if (Logic.IsCapture(i_Origin, i_Dest, this))
            {
                nextTile.Symbol = currentTile.Symbol;
                if (Logic.MoreCapture(nextTile, this))
                {
                    o_MoreCaptureFlag = true;
                    m_TurnOver = false;
                }
            }
            r_Board.UpdateBoardAccordingToMove(currentTile, nextTile);
            UpdateSolidersList(i_Origin, i_Dest);
            Logic.IsKing(i_Dest, this);
        }

        public bool CaptureTurn(Point i_Origin, Point i_Dest, out bool o_MoreCaptureFlag)
        {
            o_MoreCaptureFlag = false;
            bool isCaptureMade;

            if (!Logic.IsCapture(i_Origin, i_Dest, this))
            {
                isCaptureMade =  false;
            }
            else
            {
                Turn(i_Origin, i_Dest, out o_MoreCaptureFlag);
                isCaptureMade = true;
            }

            return isCaptureMade;
        }

        public void ComputerTurn(out bool o_MoreCaptureFlag)
        {
            o_MoreCaptureFlag = false;
            Point origin, dest;
            bool isPossible = ComputerNextMove(out origin, out dest);

            while(!isPossible)
            {
                isPossible = ComputerNextMove(out origin, out dest);
            }

            Turn(origin, dest, out o_MoreCaptureFlag);
        }

        public void CaptureComputerTurn(out bool o_MoreCaptureFlag)
        {
            o_MoreCaptureFlag = false;
            Point origin, dest;
            bool isPossible = ComputerNextMove(out origin, out dest);

            while (!isPossible)
            {
                isPossible = ComputerNextMove(out origin, out dest);
                if (Logic.IsCapture(origin, dest, this))
                {
                    break;
                }
            }

            Turn(origin, dest, out o_MoreCaptureFlag);
        }

        public void ChangePlayer()
        {
            if (m_CurrentPlayer == r_Player1)
            {
                m_CurrentPlayer = r_Player2;
            }
            else
            {
                m_CurrentPlayer = r_Player1;
            }
        }

        public void ResetGame()
        {
            r_Board.ResetBoard();
            m_CurrentPlayer = r_Player1;
            m_TurnOver = false;
            r_Player1.ResetSolidersList();
            r_Player2.ResetSolidersList();
            SetSolidersList();
            State = eGameState.Continue;
        }

        public bool CurrentPlayerWin()
        {
            bool playerWins = false;

            if (Logic.IsPlayerWin(this))
            {
                if (m_CurrentPlayer == r_Player1)
                {
                    m_State = eGameState.WinPlayer2;
                    playerWins = true;
                }
                else
                {
                    m_State = eGameState.WinPlayer1;
                    playerWins = true;
                }
            }

            return playerWins;
        }

        public bool Tie()
        {
            bool tie = false;

            if (Logic.IsTie(this))
            {
                m_State = eGameState.Tie;
                tie = true;
            }

            return tie;
        }

        public void SetSolidersList()
        {
            for (int i = 0; i < r_Board.TableSize; i++)
            {
                for (int j = 0; j < r_Board.TableSize; j++)
                {
                    if (r_Board.Matrix[i, j].Symbol == 2)
                    {
                        r_Player2.Soliders.Add(r_Board.Matrix[i, j]);
                    }
                    else if (r_Board.Matrix[i, j].Symbol == 1)
                    {
                        r_Player1.Soliders.Add(r_Board.Matrix[i, j]);
                    }
                }
            }
        }

        public void UpdateSolidersList(Point i_Origin, Point i_Dest)
        {
            m_CurrentPlayer.Soliders.Remove(r_Board.Matrix[i_Origin.X, i_Origin.Y]);
            m_CurrentPlayer.Soliders.Add(r_Board.Matrix[i_Dest.X, i_Dest.Y]);
            Player capture;

            if (m_CurrentPlayer == r_Player1)
            {
                capture = r_Player2;
            }
            else
            {
                capture = r_Player1;
            }

            foreach (Board.Tile solider in capture.Soliders)
            {
                if (solider.Symbol == 0)
                {
                    capture.Soliders.Remove(solider);
                    break;
                }
            }
        }

        private int pointCount(Player i_PlayerPointsToCheck)
        {
            int playerPoints = 0;

            foreach (Board.Tile solider in i_PlayerPointsToCheck.Soliders)
            {
                if (solider.Symbol == (int)Board.Tile.eSymbol.OKing || solider.Symbol == (int)Board.Tile.eSymbol.XKing)
                {
                    playerPoints += 4;
                }
                else
                {
                    playerPoints++;
                }
            }

            return playerPoints;
        }

        public void UpdateScore()
        {
            switch (State)
            {
                case eGameState.WinPlayer1:
                    r_Player1.Score += Math.Abs(pointCount(r_Player1) - pointCount(r_Player2));
                    break;

                case eGameState.Tie:
                    r_Player1.Score += Math.Abs(pointCount(r_Player1) - pointCount(r_Player2));
                    r_Player2.Score += Math.Abs(pointCount(r_Player1) - pointCount(r_Player2));
                    break;

                case eGameState.WinPlayer2:
                    r_Player2.Score += Math.Abs(pointCount(r_Player1) - pointCount(r_Player2));
                    break;
            }
        }

        public bool ComputerNextMove(out Point o_Origin, out Point o_Dest)
        {
            var random = new Random();
            var soliders = this.Player2.Soliders;
            int indexToMove = random.Next(soliders.Count);
            bool thereIsNextMove = false;
            o_Origin = new Point(soliders[indexToMove].Row, soliders[indexToMove].Colunm);
            o_Dest = new Point(soliders[indexToMove].Row, soliders[indexToMove].Colunm);

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
                        rowMove = -2;
                        colMove = -2;
                        break;

                    case 5:
                        rowMove = -2;
                        colMove = 2;
                        break;

                    case 6:
                        rowMove = 2;
                        colMove = -2;
                        break;

                    case 7:
                        rowMove = 2;
                        colMove = 2;
                        break;
                }

                o_Dest.X = soliders[indexToMove].Row + rowMove;
                o_Dest.Y = soliders[indexToMove].Colunm + colMove;
                if (Logic.IsLogicValidMove(o_Origin, o_Dest, this))
                {
                    thereIsNextMove = true;
                    break;
                }
            }

            return thereIsNextMove;
        }
    }
}

