namespace SpaceInvaders
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxSpaceship = new System.Windows.Forms.PictureBox();
            this.timerFighter = new System.Windows.Forms.Timer(this.components);
            this.timerProjectile = new System.Windows.Forms.Timer(this.components);
            this.timerHideBullets = new System.Windows.Forms.Timer(this.components);
            this.labelScore = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpaceship)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSpaceship
            // 
            this.pictureBoxSpaceship.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSpaceship.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSpaceship.Image")));
            this.pictureBoxSpaceship.Location = new System.Drawing.Point(369, 354);
            this.pictureBoxSpaceship.Name = "pictureBoxSpaceship";
            this.pictureBoxSpaceship.Size = new System.Drawing.Size(83, 84);
            this.pictureBoxSpaceship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSpaceship.TabIndex = 0;
            this.pictureBoxSpaceship.TabStop = false;
            // 
            // timerFighter
            // 
            this.timerFighter.Interval = 1;
            this.timerFighter.Tick += new System.EventHandler(this.timerSpaceShip_Tick);
            // 
            // timerProjectile
            // 
            this.timerProjectile.Tick += new System.EventHandler(this.timerProjectile_Tick);
            // 
            // timerHideBullets
            // 
            this.timerHideBullets.Interval = 30;
            this.timerHideBullets.Tick += new System.EventHandler(this.timerHideBullets_Tick);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelScore.Location = new System.Drawing.Point(12, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(53, 16);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Score: ";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLevel.Location = new System.Drawing.Point(172, 9);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(50, 16);
            this.labelLevel.TabIndex = 2;
            this.labelLevel.Text = "Level: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pictureBoxSpaceship);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "WWII battle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpaceship)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxSpaceship;
        private System.Windows.Forms.Timer timerFighter;
        private System.Windows.Forms.Timer timerProjectile;
        private System.Windows.Forms.Timer timerHideBullets;
        private Label labelScore;
        private Label labelLevel;
    }
}