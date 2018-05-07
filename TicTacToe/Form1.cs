using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Properties;

namespace TicTacToe {
    public partial class MainForm : Form {
        const int n = 3; // размер поля
        const int size = 99; // размер клетки поля

        const string X = "✕"; // символ крестика
        const string O = "O"; // символ нолика

        const int aiWin = 1;
        const int huWin = -1;
        const int noWin = 0;

        string huPlayer = ""; // символ пользователя
        string aiPlayer = ""; // символ AI

        bool isUserFirst = Settings.Default.isUserFirst; // ходит ли пользователь первым

        Board board = null;
        Random rnd = null;

        int total = 0; // всего игр
        int fails = 0; // поражений пользователя
        int wins = 0; // побед пользователя

        int[,] winsComb = {
            { 0, 1, 2 }, { 3, 4, 5 }, {6, 7, 8 }, // строки
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // столбцы
            { 0, 4, 8 }, { 2, 4, 6 } // диагонали
        };

        // получение списка свободных мест на поле
        List<int> getEmptyndices(Board board) {
            List<int> indices = new List<int>();

            for (int i = 0; i < n * n; i++)
                if (board[i] == "")
                    indices.Add(i);

            return indices;
        }

        // проверка, что игрок player выйграл
        bool Winning(Board board, string player) {
            for (int i = 0; i < winsComb.GetLength(0); i++)
                if (board[winsComb[i, 0]] == player && board[winsComb[i, 1]] == player && board[winsComb[i, 2]] == player)
                    return true;            

            return false;
        }

        Move minimax(Board newBoard, string player) {
            List<int> availSpots = getEmptyndices(newBoard);

            if (Winning(newBoard, huPlayer))
                return new Move(huWin);

            if (Winning(newBoard, aiPlayer))
                return new Move(aiWin);

            if (availSpots.Count == 0)
                return new Move(noWin);

            Move[] moves = new Move[availSpots.Count];

            for (int i = 0; i < moves.Length; i++) {
                moves[i] = new Move();
                moves[i].index = availSpots[i];

                newBoard[availSpots[i]] = player;                
                moves[i].score = minimax(newBoard, player == aiPlayer ? huPlayer : aiPlayer).score;
                newBoard[availSpots[i]] = "";
            }

            int maxScoreI = 0;
            int minScoreI = 0;

            for (int i = 1; i < moves.Length; i++) {
                if (moves[i].score > moves[maxScoreI].score)
                    maxScoreI = i;

                if (moves[i].score < moves[minScoreI].score)
                    minScoreI = i;
            }

            return player == aiPlayer ? moves[maxScoreI] : moves[minScoreI];
        }

        void InitGrid() {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToOrderColumns = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;

            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;

            for (int i = 0; i < n; i++) {
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                cell.Style.SelectionBackColor = Color.WhiteSmoke;
                cell.Style.SelectionForeColor = Color.Black;
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                cell.Style.Font = new Font("Arial", 50, FontStyle.Bold);

                DataGridViewColumn col = new DataGridViewColumn(cell);
                col.Width = size;

                grid.Columns.Add(col);
            }

            for (int i = 0; i < n; i++) {
                grid.Rows.Add();
                grid.Rows[i].Height = size;

                for (int j = 0; j < n; j++) {
                    grid[j, i].Value = "";
                    grid[j, i].ReadOnly = true;
                }
            }
        }

        void InitGame(bool isUserFirst) {
            board = new Board(n);

            huPlayer = isUserFirst ? X : O;
            aiPlayer = isUserFirst ? O : X;

            if (!isUserFirst) {
                if (Settings.Default.randomAIfirst) {
                    board[rnd.Next(0, n * n)] = aiPlayer;
                }
                else {
                    Move move = minimax(board, aiPlayer);
                    board[move.index] = aiPlayer;
                }
            }

            board.Draw(grid);
            statusLabel.Text = "Ход пользователя (" + huPlayer + ")";
        }

        void Game() {
            board.Draw(grid);

            if (Winning(board, huPlayer)) {
                gameOver(huWin);
                return;
            }

            if (getEmptyndices(board).Count == 0) {
                gameOver();
                return;
            }

            statusLabel.Text = "Ход компьютера (" + aiPlayer + ")";

            Move move = minimax(board, aiPlayer);
            board[move.index] = aiPlayer;
            board.Draw(grid);

            if (Winning(board, aiPlayer)) {
                gameOver(aiWin);
                return;
            }

            if (getEmptyndices(board).Count == 0) {
                gameOver();
                return;
            }

            statusLabel.Text = "Ход пользователя (" + huPlayer + ")";
        }

        void gameOver(int status = noWin) {
            if (status == huWin) {
                wins++;
            }
            else if (status == aiWin) {
                fails++;
            }

            total++;

            winsL.Text = "Побед: " + wins + "/" + total;
            failsL.Text = "Поражений: " + fails + "/" + total;

            GameOverForm over = new GameOverForm(status);

            if (over.ShowDialog() == DialogResult.Retry) {
                InitGame(isUserFirst = !isUserFirst);
            }
            else {
                Close();
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (grid[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
                return;

            board[e.RowIndex * n + e.ColumnIndex] = huPlayer;

            Game();
        }

        public MainForm() {
            InitializeComponent();
            InitGrid();

            rnd = new Random();

            if (Settings.Default.askWhoFirst)
                isUserFirst = MessageBox.Show("Нажмите \"Да\", чтобы начать играть крестиками или \"Нет\" в противном случае.", "Хотите делать первый ход?", MessageBoxButtons.YesNo) == DialogResult.Yes;

            InitGame(isUserFirst);
        }

        private void Settings_Click(object sender, EventArgs e) {
            new SettingsForm().ShowDialog();
        }
    }
}
