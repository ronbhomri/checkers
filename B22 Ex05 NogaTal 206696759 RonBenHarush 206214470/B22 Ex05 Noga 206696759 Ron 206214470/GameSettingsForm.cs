using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace B22_Ex05_Noga_206696759_Ron_206214470
{
    public class GameSettingsForm : Form
    {
        private RadioButton m_RadioButton6X6;
        private RadioButton m_RadioButton8X8;
        private RadioButton m_RadioButton10X10;
        private Label m_LabelBoardSize;
        private Label m_LabelPlayers;
        private Label m_LabelPlayer1;
        private TextBox m_TextBoxPlayer1;
        private CheckBox m_CheckBoxPlayer2;
        private TextBox m_TextBoxPlayer2;
        private Button m_ButtonDone;
        private Board m_Board;

        public Game newGame { get; set; }

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.m_RadioButton6X6 = new System.Windows.Forms.RadioButton();
            this.m_RadioButton8X8 = new System.Windows.Forms.RadioButton();
            this.m_RadioButton10X10 = new System.Windows.Forms.RadioButton();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_LabelPlayers = new System.Windows.Forms.Label();
            this.m_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.m_ButtonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_RadioButton6X6
            // 
            this.m_RadioButton6X6.Location = new System.Drawing.Point(61, 57);
            this.m_RadioButton6X6.Name = "m_RadioButton6X6";
            this.m_RadioButton6X6.Size = new System.Drawing.Size(88, 24);
            this.m_RadioButton6X6.TabIndex = 1;
            this.m_RadioButton6X6.TabStop = true;
            this.m_RadioButton6X6.Text = "6 x 6";
            this.m_RadioButton6X6.CheckedChanged += new System.EventHandler(this.m_RadioButton6X6_CheckedChanged);
            // 
            // m_RadioButton8X8
            // 
            this.m_RadioButton8X8.Location = new System.Drawing.Point(155, 57);
            this.m_RadioButton8X8.Name = "m_RadioButton8X8";
            this.m_RadioButton8X8.Size = new System.Drawing.Size(88, 24);
            this.m_RadioButton8X8.TabIndex = 1;
            this.m_RadioButton8X8.TabStop = true;
            this.m_RadioButton8X8.Text = "8 x 8";
            this.m_RadioButton8X8.CheckedChanged += new System.EventHandler(this.m_RadioButton8X8_CheckedChanged);
            // 
            // m_RadioButton10X10
            // 
            this.m_RadioButton10X10.Location = new System.Drawing.Point(256, 57);
            this.m_RadioButton10X10.Name = "m_RadioButton10X10";
            this.m_RadioButton10X10.Size = new System.Drawing.Size(88, 24);
            this.m_RadioButton10X10.TabIndex = 1;
            this.m_RadioButton10X10.TabStop = true;
            this.m_RadioButton10X10.Text = "10 x 10";
            this.m_RadioButton10X10.CheckedChanged += new System.EventHandler(this.m_RadioButton10X10_CheckedChanged);
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Location = new System.Drawing.Point(31, 26);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.m_LabelBoardSize.TabIndex = 0;
            this.m_LabelBoardSize.Text = "Board Size:";
            // 
            // m_LabelPlayers
            // 
            this.m_LabelPlayers.AutoSize = true;
            this.m_LabelPlayers.Location = new System.Drawing.Point(31, 102);
            this.m_LabelPlayers.Name = "m_LabelPlayers";
            this.m_LabelPlayers.Size = new System.Drawing.Size(64, 20);
            this.m_LabelPlayers.TabIndex = 2;
            this.m_LabelPlayers.Text = "Players:";
            // 
            // m_LabelPlayer1
            // 
            this.m_LabelPlayer1.AutoSize = true;
            this.m_LabelPlayer1.Location = new System.Drawing.Point(57, 137);
            this.m_LabelPlayer1.Name = "m_LabelPlayer1";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.m_LabelPlayer1.TabIndex = 2;
            this.m_LabelPlayer1.Text = "Player 1:";
            // 
            // m_TextBoxPlayer1
            // 
            this.m_TextBoxPlayer1.Location = new System.Drawing.Point(184, 131);
            this.m_TextBoxPlayer1.Name = "m_TextBoxPlayer1";
            this.m_TextBoxPlayer1.Size = new System.Drawing.Size(160, 26);
            this.m_TextBoxPlayer1.TabIndex = 2;
            // 
            // m_CheckBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(61, 183);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(95, 24);
            this.m_CheckBoxPlayer2.TabIndex = 3;
            this.m_CheckBoxPlayer2.Text = "Player 2:";
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.m_CheckBoxPlayer2_CheckedChanged);
            // 
            // m_TextBoxPlayer2
            // 
            this.m_TextBoxPlayer2.BackColor = System.Drawing.SystemColors.Control;
            this.m_TextBoxPlayer2.Enabled = false;
            this.m_TextBoxPlayer2.Location = new System.Drawing.Point(184, 181);
            this.m_TextBoxPlayer2.Name = "m_TextBoxPlayer2";
            this.m_TextBoxPlayer2.Size = new System.Drawing.Size(160, 26);
            this.m_TextBoxPlayer2.TabIndex = 4;
            this.m_TextBoxPlayer2.Text = "[Computer]";
            // 
            // m_ButtonDone
            // 
            this.m_ButtonDone.Location = new System.Drawing.Point(240, 235);
            this.m_ButtonDone.Name = "m_ButtonDone";
            this.m_ButtonDone.Size = new System.Drawing.Size(104, 30);
            this.m_ButtonDone.TabIndex = 5;
            this.m_ButtonDone.Text = "Done";
            this.m_ButtonDone.UseVisualStyleBackColor = true;
            this.m_ButtonDone.Click += new System.EventHandler(this.m_ButtonDone_Click);
            // 
            // GameSettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(373, 289);
            this.Controls.Add(this.m_ButtonDone);
            this.Controls.Add(this.m_TextBoxPlayer2);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.Controls.Add(this.m_TextBoxPlayer1);
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_LabelPlayers);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_RadioButton6X6);
            this.Controls.Add(this.m_RadioButton8X8);
            this.Controls.Add(this.m_RadioButton10X10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void m_CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (m_CheckBoxPlayer2.Checked)
            {
                m_TextBoxPlayer2.Enabled = true;
                m_TextBoxPlayer2.BackColor = Color.White;
            }
            else
            {
                m_TextBoxPlayer2.Enabled = false;
                m_TextBoxPlayer2.BackColor = this.BackColor;
                m_TextBoxPlayer2.Text = "[Computer]";
            }
        }

        private void m_RadioButton6X6_CheckedChanged(object sender, EventArgs e)
        {
            m_Board = new Board(6);
        }

        private void m_RadioButton8X8_CheckedChanged(object sender, EventArgs e)
        {
            m_Board = new Board(8);
        }

        private void m_RadioButton10X10_CheckedChanged(object sender, EventArgs e)
        {
            m_Board = new Board(10);
        }
        private void m_ButtonDone_Click(object sender, EventArgs e)
        {
            bool isChecked = false;
            bool isNotEmpty = true;

            foreach (var control in this.Controls)
            {
                if (control is RadioButton)
                {
                    if (((RadioButton)control).Checked)
                    {
                        isChecked = true;
                    }
                }

                if (control is TextBox)
                {
                    if (String.IsNullOrEmpty(((TextBox)control).Text))
                    {
                        isNotEmpty = false;
                    }
                }
            }

            if (!isChecked)
            {
                DialogResult uncheckedError = MessageBox.Show("You must select board size.");
            }
            else if (!isNotEmpty)
            {
                DialogResult unnamedError = MessageBox.Show("You must enter player name.");
            }
            else
            {
                createNewGame();
                this.Close();
            }
        }

        private void createNewGame()
        {
            Player player1 = new Player(1, m_TextBoxPlayer1.Text, true);
            Player player2 = new Player(2, m_TextBoxPlayer2.Text, m_CheckBoxPlayer2.Checked);
            newGame = new Game(player1, player2, m_Board);
        }
    }
}
