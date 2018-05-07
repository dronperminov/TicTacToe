using System;
using System.Windows.Forms;
using TicTacToe.Properties;

namespace TicTacToe {
    public partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();

            randomAIfirst.Checked = Settings.Default.randomAIfirst;
            askWhoFirst.Checked = Settings.Default.askWhoFirst;
            isUserFirst.Checked = Settings.Default.isUserFirst;

            isUserFirst.Visible = !askWhoFirst.Checked;
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            Settings.Default.randomAIfirst = randomAIfirst.Checked;
            Settings.Default.askWhoFirst = askWhoFirst.Checked;
            Settings.Default.isUserFirst = isUserFirst.Checked;
            Settings.Default.Save();
            Close();
        }

        private void askWhoFirst_CheckedChanged(object sender, EventArgs e) {
            isUserFirst.Visible = !askWhoFirst.Checked;
        }
    }
}
