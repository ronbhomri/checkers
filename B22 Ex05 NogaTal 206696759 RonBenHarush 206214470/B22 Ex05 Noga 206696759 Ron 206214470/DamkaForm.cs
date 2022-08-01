using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace B22_Ex05_Noga_206696759_Ron_206214470
{
    public class DamkaForm : Form
    {
        private PictureBox[,] m_PictureBoxMatrix;
        private Label m_LabelPlayer1;
        private Label m_LabelPlayer2;
        private Label m_LabelPoints1;
        private Label m_LabelPoints2;
        private Panel m_PanelBoard;
        private Label m_LabelCurrentPlayer;
        private Game m_Game;
        private const int k_PictureBoxTileSize = 50;
        private int m_MatrixSize;
        private bool m_CaptureMade;

        public DamkaForm(Game i_Game)
        {
            m_Game = i_Game;
            m_MatrixSize = m_Game.Board.TableSize;
            InitializeComponent();
            buildMatrix();
        }

        private void InitializeComponent()
        {
            this.m_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_LabelPlayer2 = new System.Windows.Forms.Label();
            this.m_LabelPoints1 = new System.Windows.Forms.Label();
            this.m_LabelPoints2 = new System.Windows.Forms.Label();
            this.m_PanelBoard = new System.Windows.Forms.Panel();
            this.m_LabelCurrentPlayer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            int location;

            // 
            // m_PanelBoard
            // 
            this.m_PanelBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            m_PanelBoard.Width = k_PictureBoxTileSize * m_MatrixSize;
            m_PanelBoard.Height = m_PanelBoard.Width;
            this.m_PanelBoard.Location = new System.Drawing.Point(30, 42);
            this.m_PanelBoard.Name = "m_PanelBoard";
            this.m_PanelBoard.TabIndex = 4;
            // 
            // m_LabelPoints1
            // 
            this.m_LabelPoints1.AutoSize = true;
            this.m_LabelPoints1.Name = "m_LabelPoints1";
            this.m_LabelPoints1.Size = new System.Drawing.Size(10, 20);
            this.m_LabelPoints1.TabIndex = 2;
            this.m_LabelPoints1.Text = "0";
            location = (m_PanelBoard.Width / 2) - k_PictureBoxTileSize;
            this.m_LabelPoints1.Location = new System.Drawing.Point(location, 19);
            // 
            // m_LabelPlayer1
            // 
            this.m_LabelPlayer1.AutoSize = true;
            this.m_LabelPlayer1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_LabelPlayer1.Name = "m_LabelPlayer1";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(60, 20);
            this.m_LabelPlayer1.Text = m_Game.Player1.Name + ": ";
            location = m_LabelPoints1.Left - m_LabelPlayer1.Width;
            this.m_LabelPlayer1.Location = new System.Drawing.Point(location, 19);
            // 
            // m_LabelPlayer2
            // 
            this.m_LabelPlayer2.AutoSize = true;
            this.m_LabelPlayer2.Name = "m_LabelPlayer2";
            this.m_LabelPlayer2.Size = new System.Drawing.Size(60, 20);
            this.m_LabelPlayer2.TabIndex = 1;
            this.m_LabelPlayer2.Text = m_Game.Player2.Name + ": ";
            location = (m_PanelBoard.Width / 2) + k_PictureBoxTileSize;
            this.m_LabelPlayer2.Location = new System.Drawing.Point(location, 19);
            // 
            // m_LabelPoints2
            // 
            this.m_LabelPoints2.AutoSize = true;
            this.m_LabelPoints2.Name = "m_LabelPoints2";
            this.m_LabelPoints2.Size = new System.Drawing.Size(10, 20);
            this.m_LabelPoints2.TabIndex = 3;
            this.m_LabelPoints2.Text = "0";
            location = m_LabelPlayer2.Right;
            this.m_LabelPoints2.Location = new System.Drawing.Point(location, 19);
            // 
            // m_LabelCurrentPlayer
            // 
            this.m_LabelCurrentPlayer.AutoSize = true;
            this.m_LabelCurrentPlayer.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_LabelCurrentPlayer.Name = "m_CurrentPlayer";
            this.m_LabelCurrentPlayer.Size = new System.Drawing.Size(109, 20);
            this.m_LabelCurrentPlayer.TabIndex = 6;
            this.m_LabelCurrentPlayer.Text = String.Format("current player: {0}", m_Game.CurrentPlayer.Name);
            int locationWidth = (m_PanelBoard.Width / 2) - 20;
            int locationHeight = m_PanelBoard.Height + m_PanelBoard.Left + m_LabelCurrentPlayer.Height + 5;
            this.m_LabelCurrentPlayer.Location = new System.Drawing.Point(locationWidth, locationHeight);
            // 
            // DamkaForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(m_PanelBoard.Width + 60, m_PanelBoard.Height + 30);
            this.Controls.Add(this.m_LabelCurrentPlayer);
            this.Controls.Add(this.m_PanelBoard);
            this.Controls.Add(this.m_LabelPoints2);
            this.Controls.Add(this.m_LabelPoints1);
            this.Controls.Add(this.m_LabelPlayer2);
            this.Controls.Add(this.m_LabelPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DamkaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.SizeChanged += damkaForm_changed;
        }

        private void damkaForm_changed(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(m_PanelBoard.Width + 60, m_PanelBoard.Height + 30);
        }

        private void buildMatrix()
        {
            m_PictureBoxMatrix = new PictureBox[m_MatrixSize, m_MatrixSize];

            for (int j = 0; j < m_MatrixSize; j++)
            {
                for (int i = 0; i < m_MatrixSize; i++)
                {
                    m_PictureBoxMatrix[i, j] = new PictureBox();
                    m_PictureBoxMatrix[i, j].Height = k_PictureBoxTileSize;
                    m_PictureBoxMatrix[i, j].Width = k_PictureBoxTileSize;
                    m_PictureBoxMatrix[i, j].Location = new Point(i * k_PictureBoxTileSize, j * k_PictureBoxTileSize);
                    m_PictureBoxMatrix[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    m_PictureBoxMatrix[i, j].Click += matrixPictureBox_Click;
                    m_PanelBoard.Controls.Add(m_PictureBoxMatrix[i, j]);
                    m_PictureBoxMatrix[i, j].Tag = new Point(i, j);                     
                    
                    switch (m_Game.Board.Matrix[i, j].Symbol)
                    {
                        case 0:
                            m_PictureBoxMatrix[i, j].Image = null;
                            break;
                        case 1:
                            m_PictureBoxMatrix[i, j].Image = global::B22_Ex05_Noga_206696759_Ron_206214470.Properties.Resources.black_01;
                            break;
                        case 2:
                            m_PictureBoxMatrix[i, j].Image = global::B22_Ex05_Noga_206696759_Ron_206214470.Properties.Resources.white_03;
                            break;
                        case 3:
                            m_PictureBoxMatrix[i, j].Image = global::B22_Ex05_Noga_206696759_Ron_206214470.Properties.Resources.blackKing_02;
                            break;
                        case 4:
                            m_PictureBoxMatrix[i, j].Image = global::B22_Ex05_Noga_206696759_Ron_206214470.Properties.Resources.whiteKing_04;
                            break;
                        case 5:
                            m_PictureBoxMatrix[i, j].BackColor = Color.Black;
                            m_PictureBoxMatrix[i, j].Enabled = false;
                            break;
                    }
                }
            }
        }

        private void matrixPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBoxClicked = (PictureBox)sender;

            if (pictureBoxClicked.Image == null)
            {
                isValidMove(pictureBoxClicked);
            }
            else
            {
                foreach (PictureBox pictureBox in m_PictureBoxMatrix)
                {
                    if (pictureBox.BackColor == Color.LightBlue && pictureBox != pictureBoxClicked)
                    {
                        DialogResult unvalidMoveError = MessageBox.Show("You can move one soldier at a time");
                        pictureBox.BackColor = Color.White;
                        pictureBox.Click -= matrixPictureBox_SecondClick;
                        pictureBox.Click += matrixPictureBox_Click;
                    }
                }

                pictureBoxClicked.BackColor = Color.LightBlue;
                pictureBoxClicked.Click -= matrixPictureBox_Click;
                pictureBoxClicked.Click += matrixPictureBox_SecondClick;
            }
        }

        private void matrixPictureBox_SecondClick(object sender, EventArgs e)
        {
            PictureBox pictureBoxClicked = (PictureBox)sender;
            pictureBoxClicked.BackColor = Color.White;
            pictureBoxClicked.Click -= matrixPictureBox_SecondClick;
            pictureBoxClicked.Click += matrixPictureBox_Click;
        }

        private void updateLabelCurrentPlayer()
        {
            m_LabelCurrentPlayer.Text = String.Format("current player: {0}", m_Game.CurrentPlayer.Name);
        }

        private void isValidMove(PictureBox i_PictureBoxClicked)
        {
            Point buttonClickedLocation = (Point)i_PictureBoxClicked.Tag;

            foreach (PictureBox originPictureBoxClicked in m_PictureBoxMatrix)
            {
                if (originPictureBoxClicked.BackColor == Color.LightBlue && originPictureBoxClicked != i_PictureBoxClicked)
                {
                    Point originButtonLocation = (Point)originPictureBoxClicked.Tag;
                    if (!Logic.IsLogicValidMove(originButtonLocation, buttonClickedLocation, m_Game))
                    {
                        DialogResult unvalidMoveError = MessageBox.Show("Unvalid Move!");
                    }
                    else
                    {
                        doMove(originButtonLocation, buttonClickedLocation);
                    }

                    originPictureBoxClicked.BackColor = Color.White;
                    originPictureBoxClicked.Click -= matrixPictureBox_SecondClick;
                    originPictureBoxClicked.Click += matrixPictureBox_Click;
                }
            }
        }

        private void doMove(Point i_OriginButtonLocation, Point i_DestButtonLocation)
        {
            if (!(m_Game.CurrentPlayerWin() || m_Game.Tie()))
            {
                if (m_Game.CurrentPlayer.IsHumen)
                {
                    bool moreCaptures = false;
                    if (m_CaptureMade)
                    {
                        string message = "Unvalid Move - next move must be capture.";
                        message += Environment.NewLine;
                        message += string.Format("It's still {0} turn.", m_Game.CurrentPlayer.Name);
                        
                        if (!m_Game.CaptureTurn(i_OriginButtonLocation, i_DestButtonLocation, out moreCaptures))
                        {
                           
                            DialogResult unvalidMoveError = MessageBox.Show(message);
                        }
                        else
                        {
                            m_CaptureMade = moreCaptures;
                        }
                    }
                    else
                    {
                        m_Game.Turn(i_OriginButtonLocation, i_DestButtonLocation, out moreCaptures);
                        m_CaptureMade = moreCaptures;
                    }
                }

                updateBoard();
            }

            round();
        }

        private void round()
        {
            bool moreCaptureFlag = false;

            if (m_Game.TurnOver)
            {
                m_Game.ChangePlayer();
                if (!(m_Game.CurrentPlayerWin() || m_Game.Tie()))
                {
                    updateLabelCurrentPlayer();
                    if ((m_Game.State == Game.eGameState.Continue) && (!m_Game.CurrentPlayer.IsHumen))
                    {
                        m_Game.ComputerTurn(out moreCaptureFlag);
                        updateBoard();
                        while (moreCaptureFlag)
                        {
                            m_Game.CaptureComputerTurn(out moreCaptureFlag);
                            updateBoard();
                        }

                        m_Game.ChangePlayer();
                        updateLabelCurrentPlayer();
                    }
                }
            }

            if (m_Game.State != Game.eGameState.Continue)
            {
                string message = "";

                switch (m_Game.State)
                {
                    case Game.eGameState.WinPlayer1:
                        message = string.Format("{0} Won!", m_Game.Player1.Name);
                        break;

                    case Game.eGameState.WinPlayer2:
                        message = string.Format("{0} Won!", m_Game.Player2.Name);
                        break;

                    case Game.eGameState.Tie:
                        message = "Tie!";
                        break;
                }

                message += Environment.NewLine;
                message += "Another Round?";
                DialogResult endRoundmessage = MessageBox.Show(message, "Damka", MessageBoxButtons.YesNo);
                if(endRoundmessage == DialogResult.Yes)
                {
                    resetDamkaGame();
                }

                if (endRoundmessage == DialogResult.No)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void resetDamkaGame()
        {
            m_Game.UpdateScore();
            m_LabelPoints1.Text = m_Game.Player1.Score.ToString();
            m_LabelPoints2.Text = m_Game.Player2.Score.ToString();
            m_Game.ResetGame();
            updateBoard();
        }

        private void updateBoard()
        {
            for (int i = 0; i < m_MatrixSize; i++)
            {
                for (int j = 0; j < m_MatrixSize; j++)
                {
                    Point buttonLocation = (Point)m_PictureBoxMatrix[i, j].Tag;
                    if (m_PictureBoxMatrix[i,j].Image != convertTileToImage(m_Game.Board.Matrix[i, j]))
                    {
                        m_PictureBoxMatrix[i, j].Image = convertTileToImage(m_Game.Board.Matrix[i,j]);
                    }
                }
            }
        }

        private Image convertTileToImage(Board.Tile i_TileToString)
        {
            Image image = null;

            switch (i_TileToString.Symbol)
            {
                case 0:
                    image = null;
                    break;
                case 1:
                    image = global::B22_Ex05_Noga_206696759_Ron_206214470.Properties.Resources.black_01;
                    break;
                case 2:
                    image = global::B22_Ex05_Noga_206696759_Ron_206214470.Properties.Resources.white_03;
                    break;
                case 3:
                    image = global::B22_Ex05_Noga_206696759_Ron_206214470.Properties.Resources.blackKing_02;
                    break;
                case 4:
                    image = global::B22_Ex05_Noga_206696759_Ron_206214470.Properties.Resources.whiteKing_04;
                    break;
            }

            return image;
        }
    }
}
