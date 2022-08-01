using System;
using System.Collections.Generic;
namespace B22_Ex05_Noga_206696759_Ron_206214470
{
    public class Player
    {
        private readonly ePlayerSymbol r_Sign;
        private readonly string r_Name;
        private int m_Score;
        private readonly bool r_IsHumen;
        private readonly List<Board.Tile> r_Soliders = new List<Board.Tile>();

        public Player(int i_Sign, string i_Name, bool i_IsHumen)
        {
            r_Sign = (ePlayerSymbol)i_Sign;
            r_Name = i_Name;
            r_IsHumen = i_IsHumen;
            m_Score = 0;
            r_Soliders = new List<Board.Tile>();
        }

        public int Sign
        {
            get
            {
                return (int)r_Sign;
            }
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public bool IsHumen
        {
            get
            {
                return r_IsHumen;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public List<Board.Tile> Soliders
        {
            get
            {
                return this.r_Soliders;
            }
        }

        public enum ePlayerSymbol
        {
            X = 1,
            O,
        }

        public void ResetSolidersList()
        {
            r_Soliders.RemoveRange(0, r_Soliders.Count);
        }
    }
}
