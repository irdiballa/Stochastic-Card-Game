namespace SeniorProject
{
    partial class NewGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGameForm));
            this.VS1AI = new System.Windows.Forms.RadioButton();
            this.Play = new System.Windows.Forms.GroupBox();
            this.VS3AI = new System.Windows.Forms.RadioButton();
            this.VS2AI = new System.Windows.Forms.RadioButton();
            this.Difficulty = new System.Windows.Forms.GroupBox();
            this.Hard = new System.Windows.Forms.RadioButton();
            this.Medium = new System.Windows.Forms.RadioButton();
            this.Easy = new System.Windows.Forms.RadioButton();
            this.Play.SuspendLayout();
            this.Difficulty.SuspendLayout();
            this.SuspendLayout();
            // 
            // VS1AI
            // 
            this.VS1AI.Appearance = System.Windows.Forms.Appearance.Button;
            this.VS1AI.AutoSize = true;
            this.VS1AI.BackColor = System.Drawing.Color.Black;
            this.VS1AI.Location = new System.Drawing.Point(33, 30);
            this.VS1AI.Name = "VS1AI";
            this.VS1AI.Size = new System.Drawing.Size(77, 30);
            this.VS1AI.TabIndex = 9;
            this.VS1AI.TabStop = true;
            this.VS1AI.Text = "vs 1 AI";
            this.VS1AI.UseVisualStyleBackColor = false;
            this.VS1AI.CheckedChanged += new System.EventHandler(this.VS1AI_CheckedChanged);
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.Color.Transparent;
            this.Play.Controls.Add(this.VS3AI);
            this.Play.Controls.Add(this.VS2AI);
            this.Play.Controls.Add(this.VS1AI);
            this.Play.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.Play.Location = new System.Drawing.Point(162, 148);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(155, 192);
            this.Play.TabIndex = 10;
            this.Play.TabStop = false;
            this.Play.Text = "PLAY";
            // 
            // VS3AI
            // 
            this.VS3AI.Appearance = System.Windows.Forms.Appearance.Button;
            this.VS3AI.AutoSize = true;
            this.VS3AI.BackColor = System.Drawing.Color.Black;
            this.VS3AI.Location = new System.Drawing.Point(33, 142);
            this.VS3AI.Name = "VS3AI";
            this.VS3AI.Size = new System.Drawing.Size(77, 30);
            this.VS3AI.TabIndex = 11;
            this.VS3AI.TabStop = true;
            this.VS3AI.Text = "vs 3 AI";
            this.VS3AI.UseVisualStyleBackColor = false;
            this.VS3AI.CheckedChanged += new System.EventHandler(this.VS3AI_CheckedChanged);
            // 
            // VS2AI
            // 
            this.VS2AI.Appearance = System.Windows.Forms.Appearance.Button;
            this.VS2AI.AutoSize = true;
            this.VS2AI.BackColor = System.Drawing.Color.Black;
            this.VS2AI.Location = new System.Drawing.Point(33, 86);
            this.VS2AI.Name = "VS2AI";
            this.VS2AI.Size = new System.Drawing.Size(77, 30);
            this.VS2AI.TabIndex = 10;
            this.VS2AI.TabStop = true;
            this.VS2AI.Text = "vs 2 AI";
            this.VS2AI.UseVisualStyleBackColor = false;
            this.VS2AI.CheckedChanged += new System.EventHandler(this.VS2AI_CheckedChanged);
            // 
            // Difficulty
            // 
            this.Difficulty.BackColor = System.Drawing.Color.Transparent;
            this.Difficulty.Controls.Add(this.Hard);
            this.Difficulty.Controls.Add(this.Medium);
            this.Difficulty.Controls.Add(this.Easy);
            this.Difficulty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Difficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Difficulty.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.Difficulty.Location = new System.Drawing.Point(470, 148);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(155, 192);
            this.Difficulty.TabIndex = 11;
            this.Difficulty.TabStop = false;
            this.Difficulty.Text = "DIFFICULTY";
            // 
            // Hard
            // 
            this.Hard.Appearance = System.Windows.Forms.Appearance.Button;
            this.Hard.AutoSize = true;
            this.Hard.BackColor = System.Drawing.Color.Black;
            this.Hard.Location = new System.Drawing.Point(33, 142);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(60, 30);
            this.Hard.TabIndex = 11;
            this.Hard.TabStop = true;
            this.Hard.Text = "Hard";
            this.Hard.UseVisualStyleBackColor = false;
            this.Hard.CheckedChanged += new System.EventHandler(this.Hard_CheckedChanged);
            // 
            // Medium
            // 
            this.Medium.Appearance = System.Windows.Forms.Appearance.Button;
            this.Medium.AutoSize = true;
            this.Medium.BackColor = System.Drawing.Color.Black;
            this.Medium.Location = new System.Drawing.Point(33, 86);
            this.Medium.Name = "Medium";
            this.Medium.Size = new System.Drawing.Size(84, 30);
            this.Medium.TabIndex = 10;
            this.Medium.TabStop = true;
            this.Medium.Text = "Medium";
            this.Medium.UseVisualStyleBackColor = false;
            this.Medium.CheckedChanged += new System.EventHandler(this.Medium_CheckedChanged);
            // 
            // Easy
            // 
            this.Easy.Appearance = System.Windows.Forms.Appearance.Button;
            this.Easy.AutoSize = true;
            this.Easy.BackColor = System.Drawing.Color.Black;
            this.Easy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Easy.Location = new System.Drawing.Point(33, 30);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(60, 30);
            this.Easy.TabIndex = 10;
            this.Easy.TabStop = true;
            this.Easy.Text = "Easy";
            this.Easy.UseVisualStyleBackColor = false;
            this.Easy.CheckedChanged += new System.EventHandler(this.Easy_CheckedChanged);
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(802, 503);
            this.Controls.Add(this.Difficulty);
            this.Controls.Add(this.Play);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XING";
            this.Play.ResumeLayout(false);
            this.Play.PerformLayout();
            this.Difficulty.ResumeLayout(false);
            this.Difficulty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton VS1AI;
        private System.Windows.Forms.GroupBox Play;
        private System.Windows.Forms.RadioButton VS3AI;
        private System.Windows.Forms.RadioButton VS2AI;
        private System.Windows.Forms.GroupBox Difficulty;
        private System.Windows.Forms.RadioButton Hard;
        private System.Windows.Forms.RadioButton Medium;
        private System.Windows.Forms.RadioButton Easy;
    }
}