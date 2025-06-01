namespace IPT__Fianls_Lab_Exam
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtPlayer1Name = new System.Windows.Forms.TextBox();
            this.cmbPlayer1Char = new System.Windows.Forms.ComboBox();
            this.txtPlayer2Name = new System.Windows.Forms.TextBox();
            this.cmbPlayer2Char = new System.Windows.Forms.ComboBox();
            this.btnStartBattle = new System.Windows.Forms.Button();
            this.pnlBattleScene = new System.Windows.Forms.Panel();
            this.lblP1NameDisplay = new System.Windows.Forms.Label();
            this.lblP2NameDisplay = new System.Windows.Forms.Label();
            this.lstAttackChoices = new System.Windows.Forms.ListBox();
            this.lblAttackDescription = new System.Windows.Forms.Label();
            this.btnExecuteAttack = new System.Windows.Forms.Button();
            this.lstBattleLog = new System.Windows.Forms.ListBox();
            this.lblWinner = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.hitEffectTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtPlayer1Name
            // 
            this.txtPlayer1Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.txtPlayer1Name.ForeColor = System.Drawing.Color.White;
            this.txtPlayer1Name.Location = new System.Drawing.Point(95, 30);
            this.txtPlayer1Name.Name = "txtPlayer1Name";
            this.txtPlayer1Name.Size = new System.Drawing.Size(130, 22);
            this.txtPlayer1Name.TabIndex = 0;
            this.txtPlayer1Name.Text = "Player 1";
            // 
            // cmbPlayer1Char
            // 
            this.cmbPlayer1Char.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.cmbPlayer1Char.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer1Char.ForeColor = System.Drawing.Color.White;
            this.cmbPlayer1Char.FormattingEnabled = true;
            this.cmbPlayer1Char.Location = new System.Drawing.Point(95, 55);
            this.cmbPlayer1Char.Name = "cmbPlayer1Char";
            this.cmbPlayer1Char.Size = new System.Drawing.Size(130, 21);
            this.cmbPlayer1Char.TabIndex = 1;
            // 
            // txtPlayer2Name
            // 
            this.txtPlayer2Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.txtPlayer2Name.ForeColor = System.Drawing.Color.White;
            this.txtPlayer2Name.Location = new System.Drawing.Point(455, 30);
            this.txtPlayer2Name.Name = "txtPlayer2Name";
            this.txtPlayer2Name.Size = new System.Drawing.Size(130, 22);
            this.txtPlayer2Name.TabIndex = 2;
            this.txtPlayer2Name.Text = "Player 2";
            // 
            // cmbPlayer2Char
            // 
            this.cmbPlayer2Char.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.cmbPlayer2Char.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer2Char.ForeColor = System.Drawing.Color.White;
            this.cmbPlayer2Char.FormattingEnabled = true;
            this.cmbPlayer2Char.Location = new System.Drawing.Point(455, 54);
            this.cmbPlayer2Char.Name = "cmbPlayer2Char";
            this.cmbPlayer2Char.Size = new System.Drawing.Size(130, 21);
            this.cmbPlayer2Char.TabIndex = 3;
            // 
            // btnStartBattle
            // 
            this.btnStartBattle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnStartBattle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.btnStartBattle.FlatAppearance.BorderSize = 1;
            this.btnStartBattle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartBattle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartBattle.ForeColor = System.Drawing.Color.White;
            this.btnStartBattle.Location = new System.Drawing.Point(240, 23);
            this.btnStartBattle.Name = "btnStartBattle";
            this.btnStartBattle.Size = new System.Drawing.Size(120, 35);
            this.btnStartBattle.TabIndex = 4;
            this.btnStartBattle.Text = "Start Battle!";
            this.btnStartBattle.UseVisualStyleBackColor = false;
            this.btnStartBattle.Click += new System.EventHandler(this.btnStartBattle_Click);
            this.btnStartBattle.MouseEnter += new System.EventHandler(this.btnStartBattle_MouseEnter);
            this.btnStartBattle.MouseLeave += new System.EventHandler(this.btnStartBattle_MouseLeave);
            // 
            // pnlBattleScene
            // 
            this.pnlBattleScene.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBattleScene.Location = new System.Drawing.Point(15, 82);
            this.pnlBattleScene.Name = "pnlBattleScene";
            this.pnlBattleScene.Size = new System.Drawing.Size(570, 261);
            this.pnlBattleScene.TabIndex = 5;
            this.pnlBattleScene.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBattleScene_Paint);
            // 
            // lblP1NameDisplay
            // 
            this.lblP1NameDisplay.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1NameDisplay.ForeColor = System.Drawing.Color.White;
            this.lblP1NameDisplay.Location = new System.Drawing.Point(12, 355);
            this.lblP1NameDisplay.Name = "lblP1NameDisplay";
            this.lblP1NameDisplay.Size = new System.Drawing.Size(250, 14);
            this.lblP1NameDisplay.TabIndex = 13;
            this.lblP1NameDisplay.Text = "Player 1";
            // 
            // lblP2NameDisplay
            // 
            this.lblP2NameDisplay.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2NameDisplay.ForeColor = System.Drawing.Color.White;
            this.lblP2NameDisplay.Location = new System.Drawing.Point(335, 355);
            this.lblP2NameDisplay.Name = "lblP2NameDisplay";
            this.lblP2NameDisplay.Size = new System.Drawing.Size(250, 14);
            this.lblP2NameDisplay.TabIndex = 14;
            this.lblP2NameDisplay.Text = "Player 2";
            this.lblP2NameDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lstAttackChoices
            // 
            this.lstAttackChoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.lstAttackChoices.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAttackChoices.ForeColor = System.Drawing.Color.White;
            this.lstAttackChoices.FormattingEnabled = true;
            this.lstAttackChoices.Location = new System.Drawing.Point(15, 381);
            this.lstAttackChoices.Name = "lstAttackChoices";
            this.lstAttackChoices.Size = new System.Drawing.Size(270, 82);
            this.lstAttackChoices.TabIndex = 19;
            this.lstAttackChoices.SelectedIndexChanged += new System.EventHandler(this.lstAttackChoices_SelectedIndexChanged);
            // 
            // lblAttackDescription
            // 
            this.lblAttackDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.lblAttackDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAttackDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttackDescription.ForeColor = System.Drawing.Color.White;
            this.lblAttackDescription.Location = new System.Drawing.Point(290, 381);
            this.lblAttackDescription.Name = "lblAttackDescription";
            this.lblAttackDescription.Padding = new System.Windows.Forms.Padding(3);
            this.lblAttackDescription.Size = new System.Drawing.Size(170, 82);
            this.lblAttackDescription.TabIndex = 20;
            this.lblAttackDescription.Text = "Attack Details...";
            // 
            // btnExecuteAttack
            // 
            this.btnExecuteAttack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(30)))), ((int)(((byte)(100)))));
            this.btnExecuteAttack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnExecuteAttack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteAttack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteAttack.ForeColor = System.Drawing.Color.White;
            this.btnExecuteAttack.Location = new System.Drawing.Point(465, 381);
            this.btnExecuteAttack.Name = "btnExecuteAttack";
            this.btnExecuteAttack.Size = new System.Drawing.Size(120, 82);
            this.btnExecuteAttack.TabIndex = 21;
            this.btnExecuteAttack.Text = "ATTACK!";
            this.btnExecuteAttack.UseVisualStyleBackColor = false;
            this.btnExecuteAttack.Click += new System.EventHandler(this.btnExecuteAttack_Click);
            this.btnExecuteAttack.MouseEnter += new System.EventHandler(this.btnExecuteAttack_MouseEnter);
            this.btnExecuteAttack.MouseLeave += new System.EventHandler(this.btnExecuteAttack_MouseLeave);
            // 
            // lstBattleLog
            // 
            this.lstBattleLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.lstBattleLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBattleLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBattleLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lstBattleLog.FormattingEnabled = true;
            this.lstBattleLog.Location = new System.Drawing.Point(15, 478);
            this.lstBattleLog.Name = "lstBattleLog";
            this.lstBattleLog.Size = new System.Drawing.Size(570, 93);
            this.lstBattleLog.TabIndex = 9;
            // 
            // lblWinner
            // 
            this.lblWinner.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.Gold;
            this.lblWinner.Location = new System.Drawing.Point(15, 583);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(570, 26);
            this.lblWinner.TabIndex = 10;
            this.lblWinner.Text = "Winner: ";
            this.lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "P1 Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "P1 Character:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(372, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "P2 Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(372, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "P2 Character:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "PLAYER 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(521, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "PLAYER 2";
            // 
            // hitEffectTimer
            // 
            this.hitEffectTimer.Interval = 250;
            this.hitEffectTimer.Tick += new System.EventHandler(this.hitEffectTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(600, 620);
            this.Controls.Add(this.pnlBattleScene);
            this.Controls.Add(this.btnExecuteAttack);
            this.Controls.Add(this.lblAttackDescription);
            this.Controls.Add(this.lstAttackChoices);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblP2NameDisplay);
            this.Controls.Add(this.lblP1NameDisplay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.lstBattleLog);
            this.Controls.Add(this.btnStartBattle);
            this.Controls.Add(this.cmbPlayer2Char);
            this.Controls.Add(this.txtPlayer2Name);
            this.Controls.Add(this.cmbPlayer1Char);
            this.Controls.Add(this.txtPlayer1Name);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sailor Moon: Cosmic Champions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.TextBox txtPlayer1Name;
        private System.Windows.Forms.ComboBox cmbPlayer1Char;
        private System.Windows.Forms.TextBox txtPlayer2Name;
        private System.Windows.Forms.ComboBox cmbPlayer2Char;
        private System.Windows.Forms.Button btnStartBattle;
        private System.Windows.Forms.ListBox lstBattleLog;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblP1NameDisplay;
        private System.Windows.Forms.Label lblP2NameDisplay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstAttackChoices;
        private System.Windows.Forms.Label lblAttackDescription;
        private System.Windows.Forms.Button btnExecuteAttack;
        private System.Windows.Forms.Panel pnlBattleScene;
        private System.Windows.Forms.Timer hitEffectTimer;
    }
}