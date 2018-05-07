namespace TicTacToe {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.askWhoFirst = new System.Windows.Forms.CheckBox();
            this.randomAIfirst = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.isUserFirst = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // askWhoFirst
            // 
            this.askWhoFirst.AutoSize = true;
            this.askWhoFirst.Checked = true;
            this.askWhoFirst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.askWhoFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.askWhoFirst.Location = new System.Drawing.Point(12, 39);
            this.askWhoFirst.Name = "askWhoFirst";
            this.askWhoFirst.Size = new System.Drawing.Size(233, 21);
            this.askWhoFirst.TabIndex = 0;
            this.askWhoFirst.Text = "Спрашивать, кто ходит первым";
            this.askWhoFirst.UseVisualStyleBackColor = true;
            this.askWhoFirst.CheckedChanged += new System.EventHandler(this.askWhoFirst_CheckedChanged);
            // 
            // randomAIfirst
            // 
            this.randomAIfirst.AutoSize = true;
            this.randomAIfirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.randomAIfirst.Location = new System.Drawing.Point(12, 12);
            this.randomAIfirst.Name = "randomAIfirst";
            this.randomAIfirst.Size = new System.Drawing.Size(264, 21);
            this.randomAIfirst.TabIndex = 1;
            this.randomAIfirst.Text = "Случайный первый ход компьютера";
            this.randomAIfirst.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveBtn.Location = new System.Drawing.Point(116, 120);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(90, 34);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // isUserFirst
            // 
            this.isUserFirst.AutoSize = true;
            this.isUserFirst.Checked = true;
            this.isUserFirst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isUserFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isUserFirst.Location = new System.Drawing.Point(12, 66);
            this.isUserFirst.Name = "isUserFirst";
            this.isUserFirst.Size = new System.Drawing.Size(200, 21);
            this.isUserFirst.TabIndex = 3;
            this.isUserFirst.Text = "Первый ход пользователя";
            this.isUserFirst.UseVisualStyleBackColor = true;
            this.isUserFirst.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 169);
            this.Controls.Add(this.isUserFirst);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.randomAIfirst);
            this.Controls.Add(this.askWhoFirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox askWhoFirst;
        private System.Windows.Forms.CheckBox randomAIfirst;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.CheckBox isUserFirst;
    }
}