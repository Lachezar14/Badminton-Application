namespace SynthesisDesktop
{
    partial class TournamentManagement
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
            this.tbTournamentDesc = new System.Windows.Forms.TextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTournament_Id = new System.Windows.Forms.TextBox();
            this.btnUpdateTournament = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeleteTournament = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cbTournamentType = new System.Windows.Forms.ComboBox();
            this.cbSportType = new System.Windows.Forms.ComboBox();
            this.tbMaxPlayers = new System.Windows.Forms.NumericUpDown();
            this.tbMinPlayers = new System.Windows.Forms.NumericUpDown();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(194, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tournament Modification";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbTournamentDesc
            // 
            this.tbTournamentDesc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbTournamentDesc.Location = new System.Drawing.Point(200, 147);
            this.tbTournamentDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTournamentDesc.Name = "tbTournamentDesc";
            this.tbTournamentDesc.Size = new System.Drawing.Size(208, 26);
            this.tbTournamentDesc.TabIndex = 3;
            // 
            // tbLocation
            // 
            this.tbLocation.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbLocation.Location = new System.Drawing.Point(200, 222);
            this.tbLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(208, 26);
            this.tbLocation.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label2.Location = new System.Drawing.Point(14, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label3.Location = new System.Drawing.Point(14, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Sport Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label4.Location = new System.Drawing.Point(14, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label5.Location = new System.Drawing.Point(14, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Tournament Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label7.Location = new System.Drawing.Point(429, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 25);
            this.label7.TabIndex = 30;
            this.label7.Text = "Start Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label8.Location = new System.Drawing.Point(429, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 25);
            this.label8.TabIndex = 31;
            this.label8.Text = "End Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label9.Location = new System.Drawing.Point(432, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 25);
            this.label9.TabIndex = 32;
            this.label9.Text = "Min:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label10.Location = new System.Drawing.Point(432, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 25);
            this.label10.TabIndex = 33;
            this.label10.Text = "Max:";
            // 
            // tbTournament_Id
            // 
            this.tbTournament_Id.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbTournament_Id.Location = new System.Drawing.Point(200, 113);
            this.tbTournament_Id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTournament_Id.Name = "tbTournament_Id";
            this.tbTournament_Id.ReadOnly = true;
            this.tbTournament_Id.Size = new System.Drawing.Size(208, 26);
            this.tbTournament_Id.TabIndex = 35;
            // 
            // btnUpdateTournament
            // 
            this.btnUpdateTournament.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(100)))));
            this.btnUpdateTournament.FlatAppearance.BorderSize = 0;
            this.btnUpdateTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTournament.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateTournament.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateTournament.Location = new System.Drawing.Point(39, 322);
            this.btnUpdateTournament.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateTournament.Name = "btnUpdateTournament";
            this.btnUpdateTournament.Size = new System.Drawing.Size(223, 50);
            this.btnUpdateTournament.TabIndex = 36;
            this.btnUpdateTournament.Text = "Update Tournament";
            this.btnUpdateTournament.UseVisualStyleBackColor = false;
            this.btnUpdateTournament.Click += new System.EventHandler(this.btnUpdateTournament_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(539, 322);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(223, 50);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeleteTournament
            // 
            this.btnDeleteTournament.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.btnDeleteTournament.FlatAppearance.BorderSize = 0;
            this.btnDeleteTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTournament.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteTournament.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteTournament.Location = new System.Drawing.Point(286, 322);
            this.btnDeleteTournament.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteTournament.Name = "btnDeleteTournament";
            this.btnDeleteTournament.Size = new System.Drawing.Size(223, 50);
            this.btnDeleteTournament.TabIndex = 38;
            this.btnDeleteTournament.Text = "Delete Tournament";
            this.btnDeleteTournament.UseVisualStyleBackColor = false;
            this.btnDeleteTournament.Click += new System.EventHandler(this.btnDeleteTournament_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.label12.Location = new System.Drawing.Point(14, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 25);
            this.label12.TabIndex = 39;
            this.label12.Text = "Tournament ID:";
            // 
            // cbTournamentType
            // 
            this.cbTournamentType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbTournamentType.FormattingEnabled = true;
            this.cbTournamentType.Items.AddRange(new object[] {
            "RoundRobin",
            "DoubleRoundRobin"});
            this.cbTournamentType.Location = new System.Drawing.Point(200, 261);
            this.cbTournamentType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTournamentType.Name = "cbTournamentType";
            this.cbTournamentType.Size = new System.Drawing.Size(208, 27);
            this.cbTournamentType.TabIndex = 40;
            // 
            // cbSportType
            // 
            this.cbSportType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbSportType.FormattingEnabled = true;
            this.cbSportType.Items.AddRange(new object[] {
            "Badminton"});
            this.cbSportType.Location = new System.Drawing.Point(200, 184);
            this.cbSportType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSportType.Name = "cbSportType";
            this.cbSportType.Size = new System.Drawing.Size(208, 27);
            this.cbSportType.TabIndex = 42;
            // 
            // tbMaxPlayers
            // 
            this.tbMaxPlayers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbMaxPlayers.Location = new System.Drawing.Point(554, 263);
            this.tbMaxPlayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMaxPlayers.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.tbMaxPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.tbMaxPlayers.Name = "tbMaxPlayers";
            this.tbMaxPlayers.Size = new System.Drawing.Size(208, 25);
            this.tbMaxPlayers.TabIndex = 43;
            this.tbMaxPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tbMinPlayers
            // 
            this.tbMinPlayers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbMinPlayers.Location = new System.Drawing.Point(554, 223);
            this.tbMinPlayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMinPlayers.Maximum = new decimal(new int[] {
            49,
            0,
            0,
            0});
            this.tbMinPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.tbMinPlayers.Name = "tbMinPlayers";
            this.tbMinPlayers.Size = new System.Drawing.Size(208, 25);
            this.tbMinPlayers.TabIndex = 44;
            this.tbMinPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtStartDate.Location = new System.Drawing.Point(554, 145);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(208, 25);
            this.dtStartDate.TabIndex = 45;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtEndDate.Location = new System.Drawing.Point(554, 186);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(208, 25);
            this.dtEndDate.TabIndex = 46;
            // 
            // TournamentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(802, 410);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.tbMinPlayers);
            this.Controls.Add(this.tbMaxPlayers);
            this.Controls.Add(this.cbSportType);
            this.Controls.Add(this.cbTournamentType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnDeleteTournament);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdateTournament);
            this.Controls.Add(this.tbTournament_Id);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.tbTournamentDesc);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TournamentManagement";
            this.Text = "UserUpdate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TournamentManagement_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbTournamentDesc;
        private TextBox tbLocation;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox tbTournament_Id;
        private Button btnUpdateTournament;
        private Button btnCancel;
        private Button btnDeleteTournament;
        private Label label12;
        private ComboBox cbTournamentType;
        private ComboBox cbSportType;
        private NumericUpDown tbMaxPlayers;
        private NumericUpDown tbMinPlayers;
        private DateTimePicker dtStartDate;
        private DateTimePicker dtEndDate;
    }
}