namespace SynthesisDesktop
{
    partial class MatchResultCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddResult = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMatch = new System.Windows.Forms.TextBox();
            this.tbPlayer1Score = new System.Windows.Forms.NumericUpDown();
            this.tbPlayer2Score = new System.Windows.Forms.NumericUpDown();
            this.btnUpdateResult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlayer1Score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlayer2Score)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(197, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Match Result Creation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label4.Location = new System.Drawing.Point(214, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Player 2 Score:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label5.Location = new System.Drawing.Point(214, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Player 1 Score:";
            // 
            // btnAddResult
            // 
            this.btnAddResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(100)))));
            this.btnAddResult.FlatAppearance.BorderSize = 0;
            this.btnAddResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddResult.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddResult.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddResult.Location = new System.Drawing.Point(49, 316);
            this.btnAddResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddResult.Name = "btnAddResult";
            this.btnAddResult.Size = new System.Drawing.Size(223, 50);
            this.btnAddResult.TabIndex = 36;
            this.btnAddResult.Text = "Add Result";
            this.btnAddResult.UseVisualStyleBackColor = false;
            this.btnAddResult.Click += new System.EventHandler(this.btnAddResult_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(526, 316);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(223, 50);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label2.Location = new System.Drawing.Point(122, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 44;
            this.label2.Text = "Match";
            // 
            // tbMatch
            // 
            this.tbMatch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbMatch.Location = new System.Drawing.Point(197, 132);
            this.tbMatch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMatch.Name = "tbMatch";
            this.tbMatch.ReadOnly = true;
            this.tbMatch.Size = new System.Drawing.Size(448, 26);
            this.tbMatch.TabIndex = 45;
            // 
            // tbPlayer1Score
            // 
            this.tbPlayer1Score.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbPlayer1Score.Location = new System.Drawing.Point(390, 180);
            this.tbPlayer1Score.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPlayer1Score.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.tbPlayer1Score.Name = "tbPlayer1Score";
            this.tbPlayer1Score.Size = new System.Drawing.Size(208, 27);
            this.tbPlayer1Score.TabIndex = 46;
            // 
            // tbPlayer2Score
            // 
            this.tbPlayer2Score.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbPlayer2Score.Location = new System.Drawing.Point(390, 222);
            this.tbPlayer2Score.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPlayer2Score.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.tbPlayer2Score.Name = "tbPlayer2Score";
            this.tbPlayer2Score.Size = new System.Drawing.Size(208, 27);
            this.tbPlayer2Score.TabIndex = 47;
            // 
            // btnUpdateResult
            // 
            this.btnUpdateResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.btnUpdateResult.FlatAppearance.BorderSize = 0;
            this.btnUpdateResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateResult.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateResult.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateResult.Location = new System.Drawing.Point(288, 316);
            this.btnUpdateResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateResult.Name = "btnUpdateResult";
            this.btnUpdateResult.Size = new System.Drawing.Size(223, 50);
            this.btnUpdateResult.TabIndex = 48;
            this.btnUpdateResult.Text = "Update Result";
            this.btnUpdateResult.UseVisualStyleBackColor = false;
            this.btnUpdateResult.Click += new System.EventHandler(this.btnUpdateResult_Click);
            // 
            // MatchResultCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(802, 410);
            this.Controls.Add(this.btnUpdateResult);
            this.Controls.Add(this.tbPlayer2Score);
            this.Controls.Add(this.tbPlayer1Score);
            this.Controls.Add(this.tbMatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MatchResultCreation";
            this.Text = "UserUpdate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MatchResultCreation_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tbPlayer1Score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlayer2Score)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label5;
        private Button btnAddResult;
        private Button btnCancel;
        private Label label2;
        private TextBox tbMatch;
        private NumericUpDown tbPlayer1Score;
        private NumericUpDown tbPlayer2Score;
        private Button btnUpdateResult;
    }
}