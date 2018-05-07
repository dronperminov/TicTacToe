using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe {
    public struct Move {
        public int score;
        public int index;

        public Move(int score, int index = -1) {
            this.score = score;
            this.index = index;
        }
    }

    class Board {
        public string[] field;
        int n;

        public Board(int size) {
            n = size;
            field = new string[n * n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    field[i * n + j] = "";
        }

        public Board(DataGridView data, int size) {
            n = size;
            field = new string[n * n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    field[i * n + j] = string.IsNullOrEmpty(data[j, i].Value.ToString()) ? "" : data[j, i].Value.ToString();
        }

        public void Draw(DataGridView data) {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    data[j, i].Value = field[i * n + j];

            data.Update();
        }

        public void Clear() {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    field[i * n + j] = "";
        }

        public string this[int i] {
            get { return field[i]; }
            set { field[i] = value; }
        }
    }
}
