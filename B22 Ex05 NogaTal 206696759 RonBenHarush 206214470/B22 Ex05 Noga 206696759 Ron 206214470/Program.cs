using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex05_Noga_206696759_Ron_206214470
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameSettingsForm gameSettingsForm = new GameSettingsForm();
            gameSettingsForm.ShowDialog();
            if (gameSettingsForm.newGame != null)
            {
                DamkaForm damkaForm = new DamkaForm(gameSettingsForm.newGame);
                damkaForm.ShowDialog();
            }
        }
    }
}
