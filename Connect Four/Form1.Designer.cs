namespace New_Connect_Four
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.labelStats = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSimGames = new System.Windows.Forms.Button();
            this.buttonPlayerOne = new System.Windows.Forms.Button();
            this.buttonPlayerTwo = new System.Windows.Forms.Button();
            this.labelPlayerOne = new System.Windows.Forms.Label();
            this.labelPlayerTwo = new System.Windows.Forms.Label();
            this.trackBarPlayerOne = new System.Windows.Forms.TrackBar();
            this.trackBarPlayerTwo = new System.Windows.Forms.TrackBar();
            this.numericUpDownSimGames = new System.Windows.Forms.NumericUpDown();
            this.labelSimGames = new System.Windows.Forms.Label();
            this.listBoxBrain = new System.Windows.Forms.ListBox();
            this.listBoxWrite = new System.Windows.Forms.ListBox();
            this.labelBrain = new System.Windows.Forms.Label();
            this.labelWrite = new System.Windows.Forms.Label();
            this.buttonClearTestDB = new System.Windows.Forms.Button();
            this.buttonTimer = new System.Windows.Forms.Button();
            this.checkBoxRandomize = new System.Windows.Forms.CheckBox();
            this.buttonX0 = new System.Windows.Forms.Button();
            this.buttonX1 = new System.Windows.Forms.Button();
            this.buttonX2 = new System.Windows.Forms.Button();
            this.buttonX5 = new System.Windows.Forms.Button();
            this.buttonX4 = new System.Windows.Forms.Button();
            this.buttonX3 = new System.Windows.Forms.Button();
            this.buttonX6 = new System.Windows.Forms.Button();
            this.labelHuman = new System.Windows.Forms.Label();
            this.textBoxGameState = new System.Windows.Forms.TextBox();
            this.numericUpDownRandChance = new System.Windows.Forms.NumericUpDown();
            this.labelRandomChance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlayerOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlayerTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSimGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRandChance)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStats
            // 
            this.labelStats.AutoSize = true;
            this.labelStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStats.Location = new System.Drawing.Point(401, 23);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(0, 24);
            this.labelStats.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // buttonSimGames
            // 
            this.buttonSimGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimGames.Location = new System.Drawing.Point(402, 436);
            this.buttonSimGames.Name = "buttonSimGames";
            this.buttonSimGames.Size = new System.Drawing.Size(227, 45);
            this.buttonSimGames.TabIndex = 2;
            this.buttonSimGames.Text = "Simulate";
            this.buttonSimGames.UseVisualStyleBackColor = true;
            this.buttonSimGames.Click += new System.EventHandler(this.buttonSimulateGames);
            // 
            // buttonPlayerOne
            // 
            this.buttonPlayerOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayerOne.Location = new System.Drawing.Point(137, 436);
            this.buttonPlayerOne.Name = "buttonPlayerOne";
            this.buttonPlayerOne.Size = new System.Drawing.Size(104, 45);
            this.buttonPlayerOne.TabIndex = 3;
            this.buttonPlayerOne.Text = "Human";
            this.buttonPlayerOne.UseVisualStyleBackColor = true;
            this.buttonPlayerOne.Click += new System.EventHandler(this.buttonPlayerOne_Click);
            // 
            // buttonPlayerTwo
            // 
            this.buttonPlayerTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayerTwo.Location = new System.Drawing.Point(137, 487);
            this.buttonPlayerTwo.Name = "buttonPlayerTwo";
            this.buttonPlayerTwo.Size = new System.Drawing.Size(104, 45);
            this.buttonPlayerTwo.TabIndex = 4;
            this.buttonPlayerTwo.Text = "Human";
            this.buttonPlayerTwo.UseVisualStyleBackColor = true;
            this.buttonPlayerTwo.Click += new System.EventHandler(this.buttonPlayerTwo_Click);
            // 
            // labelPlayerOne
            // 
            this.labelPlayerOne.AutoSize = true;
            this.labelPlayerOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerOne.Location = new System.Drawing.Point(12, 445);
            this.labelPlayerOne.Name = "labelPlayerOne";
            this.labelPlayerOne.Size = new System.Drawing.Size(104, 24);
            this.labelPlayerOne.TabIndex = 5;
            this.labelPlayerOne.Text = "Player One";
            // 
            // labelPlayerTwo
            // 
            this.labelPlayerTwo.AutoSize = true;
            this.labelPlayerTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerTwo.Location = new System.Drawing.Point(12, 496);
            this.labelPlayerTwo.Name = "labelPlayerTwo";
            this.labelPlayerTwo.Size = new System.Drawing.Size(104, 24);
            this.labelPlayerTwo.TabIndex = 6;
            this.labelPlayerTwo.Text = "Player Two";
            // 
            // trackBarPlayerOne
            // 
            this.trackBarPlayerOne.Enabled = false;
            this.trackBarPlayerOne.Location = new System.Drawing.Point(259, 436);
            this.trackBarPlayerOne.Maximum = 2;
            this.trackBarPlayerOne.Name = "trackBarPlayerOne";
            this.trackBarPlayerOne.Size = new System.Drawing.Size(104, 45);
            this.trackBarPlayerOne.TabIndex = 7;
            this.trackBarPlayerOne.TabStop = false;
            this.trackBarPlayerOne.Value = 1;
            this.trackBarPlayerOne.ValueChanged += new System.EventHandler(this.trackBarPlayerOne_ValueChanged);
            // 
            // trackBarPlayerTwo
            // 
            this.trackBarPlayerTwo.Enabled = false;
            this.trackBarPlayerTwo.Location = new System.Drawing.Point(259, 487);
            this.trackBarPlayerTwo.Maximum = 2;
            this.trackBarPlayerTwo.Name = "trackBarPlayerTwo";
            this.trackBarPlayerTwo.Size = new System.Drawing.Size(104, 45);
            this.trackBarPlayerTwo.TabIndex = 8;
            this.trackBarPlayerTwo.TabStop = false;
            this.trackBarPlayerTwo.Value = 1;
            this.trackBarPlayerTwo.ValueChanged += new System.EventHandler(this.trackBarPlayerTwo_ValueChanged);
            // 
            // numericUpDownSimGames
            // 
            this.numericUpDownSimGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSimGames.Location = new System.Drawing.Point(509, 487);
            this.numericUpDownSimGames.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownSimGames.Name = "numericUpDownSimGames";
            this.numericUpDownSimGames.Size = new System.Drawing.Size(120, 32);
            this.numericUpDownSimGames.TabIndex = 9;
            this.numericUpDownSimGames.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownSimGames.ValueChanged += new System.EventHandler(this.numericUpDownSimGames_ValueChanged);
            // 
            // labelSimGames
            // 
            this.labelSimGames.AutoSize = true;
            this.labelSimGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSimGames.Location = new System.Drawing.Point(398, 490);
            this.labelSimGames.Name = "labelSimGames";
            this.labelSimGames.Size = new System.Drawing.Size(105, 24);
            this.labelSimGames.TabIndex = 10;
            this.labelSimGames.Text = "# of Games";
            // 
            // listBoxBrain
            // 
            this.listBoxBrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxBrain.FormattingEnabled = true;
            this.listBoxBrain.ItemHeight = 24;
            this.listBoxBrain.Location = new System.Drawing.Point(650, 436);
            this.listBoxBrain.Name = "listBoxBrain";
            this.listBoxBrain.Size = new System.Drawing.Size(151, 100);
            this.listBoxBrain.TabIndex = 12;
            this.listBoxBrain.SelectedValueChanged += new System.EventHandler(this.listBoxBrain_SelectedValueChanged);
            // 
            // listBoxWrite
            // 
            this.listBoxWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxWrite.FormattingEnabled = true;
            this.listBoxWrite.ItemHeight = 24;
            this.listBoxWrite.Location = new System.Drawing.Point(820, 436);
            this.listBoxWrite.Name = "listBoxWrite";
            this.listBoxWrite.Size = new System.Drawing.Size(151, 100);
            this.listBoxWrite.TabIndex = 13;
            this.listBoxWrite.SelectedValueChanged += new System.EventHandler(this.listBoxWrite_SelectedValueChanged);
            // 
            // labelBrain
            // 
            this.labelBrain.AutoSize = true;
            this.labelBrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBrain.Location = new System.Drawing.Point(646, 409);
            this.labelBrain.Name = "labelBrain";
            this.labelBrain.Size = new System.Drawing.Size(53, 24);
            this.labelBrain.TabIndex = 14;
            this.labelBrain.Text = "Brain";
            // 
            // labelWrite
            // 
            this.labelWrite.AutoSize = true;
            this.labelWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWrite.Location = new System.Drawing.Point(816, 409);
            this.labelWrite.Name = "labelWrite";
            this.labelWrite.Size = new System.Drawing.Size(53, 24);
            this.labelWrite.TabIndex = 15;
            this.labelWrite.Text = "Write";
            // 
            // buttonClearTestDB
            // 
            this.buttonClearTestDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearTestDB.Location = new System.Drawing.Point(820, 361);
            this.buttonClearTestDB.Name = "buttonClearTestDB";
            this.buttonClearTestDB.Size = new System.Drawing.Size(151, 45);
            this.buttonClearTestDB.TabIndex = 16;
            this.buttonClearTestDB.Text = "Clear Write DB";
            this.buttonClearTestDB.UseVisualStyleBackColor = true;
            this.buttonClearTestDB.Click += new System.EventHandler(this.buttonClearTestDB_Click);
            // 
            // buttonTimer
            // 
            this.buttonTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTimer.Location = new System.Drawing.Point(438, 385);
            this.buttonTimer.Name = "buttonTimer";
            this.buttonTimer.Size = new System.Drawing.Size(151, 45);
            this.buttonTimer.TabIndex = 17;
            this.buttonTimer.Text = "Start Timer";
            this.buttonTimer.UseVisualStyleBackColor = true;
            this.buttonTimer.Click += new System.EventHandler(this.buttonTimer_Click);
            // 
            // checkBoxRandomize
            // 
            this.checkBoxRandomize.AutoSize = true;
            this.checkBoxRandomize.Location = new System.Drawing.Point(268, 529);
            this.checkBoxRandomize.Name = "checkBoxRandomize";
            this.checkBoxRandomize.Size = new System.Drawing.Size(85, 17);
            this.checkBoxRandomize.TabIndex = 18;
            this.checkBoxRandomize.Text = "Randomize?";
            this.checkBoxRandomize.UseVisualStyleBackColor = true;
            this.checkBoxRandomize.CheckedChanged += new System.EventHandler(this.checkBoxRandomize_CheckedChanged);
            // 
            // buttonX0
            // 
            this.buttonX0.Location = new System.Drawing.Point(2, 57);
            this.buttonX0.Name = "buttonX0";
            this.buttonX0.Size = new System.Drawing.Size(35, 35);
            this.buttonX0.TabIndex = 19;
            this.buttonX0.Text = "v";
            this.buttonX0.UseVisualStyleBackColor = true;
            this.buttonX0.Click += new System.EventHandler(this.buttonX0_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.Location = new System.Drawing.Point(42, 57);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(35, 35);
            this.buttonX1.TabIndex = 20;
            this.buttonX1.Text = "v";
            this.buttonX1.UseVisualStyleBackColor = true;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.Location = new System.Drawing.Point(82, 57);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(35, 35);
            this.buttonX2.TabIndex = 21;
            this.buttonX2.Text = "v";
            this.buttonX2.UseVisualStyleBackColor = true;
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.Location = new System.Drawing.Point(202, 57);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(35, 35);
            this.buttonX5.TabIndex = 24;
            this.buttonX5.Text = "v";
            this.buttonX5.UseVisualStyleBackColor = true;
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.Location = new System.Drawing.Point(162, 57);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(35, 35);
            this.buttonX4.TabIndex = 23;
            this.buttonX4.Text = "v";
            this.buttonX4.UseVisualStyleBackColor = true;
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.Location = new System.Drawing.Point(122, 57);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(35, 35);
            this.buttonX3.TabIndex = 22;
            this.buttonX3.Text = "v";
            this.buttonX3.UseVisualStyleBackColor = true;
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.Location = new System.Drawing.Point(242, 57);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(35, 35);
            this.buttonX6.TabIndex = 25;
            this.buttonX6.Text = "v";
            this.buttonX6.UseVisualStyleBackColor = true;
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // labelHuman
            // 
            this.labelHuman.AutoSize = true;
            this.labelHuman.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHuman.Location = new System.Drawing.Point(401, 159);
            this.labelHuman.Name = "labelHuman";
            this.labelHuman.Size = new System.Drawing.Size(0, 24);
            this.labelHuman.TabIndex = 26;
            // 
            // textBoxGameState
            // 
            this.textBoxGameState.Location = new System.Drawing.Point(42, 12);
            this.textBoxGameState.Name = "textBoxGameState";
            this.textBoxGameState.Size = new System.Drawing.Size(235, 20);
            this.textBoxGameState.TabIndex = 27;
            // 
            // numericUpDownRandChance
            // 
            this.numericUpDownRandChance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownRandChance.Location = new System.Drawing.Point(509, 525);
            this.numericUpDownRandChance.Name = "numericUpDownRandChance";
            this.numericUpDownRandChance.Size = new System.Drawing.Size(120, 32);
            this.numericUpDownRandChance.TabIndex = 28;
            this.numericUpDownRandChance.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownRandChance.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelRandomChance
            // 
            this.labelRandomChance.AutoSize = true;
            this.labelRandomChance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRandomChance.Location = new System.Drawing.Point(398, 528);
            this.labelRandomChance.Name = "labelRandomChance";
            this.labelRandomChance.Size = new System.Drawing.Size(102, 24);
            this.labelRandomChance.TabIndex = 29;
            this.labelRandomChance.Text = "% Random";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 559);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelRandomChance);
            this.Controls.Add(this.numericUpDownRandChance);
            this.Controls.Add(this.textBoxGameState);
            this.Controls.Add(this.labelHuman);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.buttonX5);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX0);
            this.Controls.Add(this.checkBoxRandomize);
            this.Controls.Add(this.buttonTimer);
            this.Controls.Add(this.buttonClearTestDB);
            this.Controls.Add(this.labelWrite);
            this.Controls.Add(this.labelBrain);
            this.Controls.Add(this.listBoxWrite);
            this.Controls.Add(this.listBoxBrain);
            this.Controls.Add(this.labelStats);
            this.Controls.Add(this.labelSimGames);
            this.Controls.Add(this.numericUpDownSimGames);
            this.Controls.Add(this.trackBarPlayerTwo);
            this.Controls.Add(this.trackBarPlayerOne);
            this.Controls.Add(this.labelPlayerTwo);
            this.Controls.Add(this.labelPlayerOne);
            this.Controls.Add(this.buttonPlayerTwo);
            this.Controls.Add(this.buttonPlayerOne);
            this.Controls.Add(this.buttonSimGames);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlayerOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlayerTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSimGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRandChance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label labelStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSimGames;
        private System.Windows.Forms.Button buttonPlayerOne;
        private System.Windows.Forms.Button buttonPlayerTwo;
        private System.Windows.Forms.Label labelPlayerOne;
        private System.Windows.Forms.Label labelPlayerTwo;
        private System.Windows.Forms.TrackBar trackBarPlayerOne;
        private System.Windows.Forms.TrackBar trackBarPlayerTwo;
        private System.Windows.Forms.NumericUpDown numericUpDownSimGames;
        private System.Windows.Forms.Label labelSimGames;
        private System.Windows.Forms.ListBox listBoxBrain;
        private System.Windows.Forms.ListBox listBoxWrite;
        private System.Windows.Forms.Label labelBrain;
        private System.Windows.Forms.Label labelWrite;
        private System.Windows.Forms.Button buttonClearTestDB;
        private System.Windows.Forms.Button buttonTimer;
        private System.Windows.Forms.CheckBox checkBoxRandomize;
        private System.Windows.Forms.Button buttonX0;
        private System.Windows.Forms.Button buttonX1;
        private System.Windows.Forms.Button buttonX2;
        private System.Windows.Forms.Button buttonX5;
        private System.Windows.Forms.Button buttonX4;
        private System.Windows.Forms.Button buttonX3;
        private System.Windows.Forms.Button buttonX6;
        private System.Windows.Forms.Label labelHuman;
        private System.Windows.Forms.TextBox textBoxGameState;
        private System.Windows.Forms.NumericUpDown numericUpDownRandChance;
        private System.Windows.Forms.Label labelRandomChance;
        private System.Windows.Forms.Label label2;
    }
}

