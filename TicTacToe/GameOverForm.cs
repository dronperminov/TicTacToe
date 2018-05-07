using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe { 
    public partial class GameOverForm: Form
    {
        public GameOverForm(int status) {
            InitializeComponent();

            if (status == 1) {
                pictureBox.Image = Properties.Resources.ai_wins;
            }
            else if (status == 0) {
                pictureBox.Image = Properties.Resources.no_wins;
            }
            else {
                pictureBox.Image = Properties.Resources.hu_wins;
            }
        }

        private void okBtn_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void exitBtn_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.None;
            Close();
        }
    }
}
