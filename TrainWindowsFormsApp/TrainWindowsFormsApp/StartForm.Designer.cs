
namespace TrainWindowsFormsApp
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.startTrainButton = new System.Windows.Forms.Button();
            this.fastTrainButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.saveNewExercisesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startTrainButton
            // 
            this.startTrainButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startTrainButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startTrainButton.BackgroundImage")));
            this.startTrainButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startTrainButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.startTrainButton.FlatAppearance.BorderSize = 0;
            this.startTrainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startTrainButton.Font = new System.Drawing.Font("MS Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTrainButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startTrainButton.Location = new System.Drawing.Point(192, 383);
            this.startTrainButton.Name = "startTrainButton";
            this.startTrainButton.Size = new System.Drawing.Size(140, 145);
            this.startTrainButton.TabIndex = 0;
            this.startTrainButton.TabStop = false;
            this.startTrainButton.Text = "Regular Train";
            this.startTrainButton.UseVisualStyleBackColor = false;
            this.startTrainButton.Click += new System.EventHandler(this.startTrainButton_Click);
            // 
            // fastTrainButton
            // 
            this.fastTrainButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fastTrainButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fastTrainButton.BackgroundImage")));
            this.fastTrainButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fastTrainButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.fastTrainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fastTrainButton.Font = new System.Drawing.Font("MS Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fastTrainButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fastTrainButton.Location = new System.Drawing.Point(959, 383);
            this.fastTrainButton.Name = "fastTrainButton";
            this.fastTrainButton.Size = new System.Drawing.Size(140, 145);
            this.fastTrainButton.TabIndex = 1;
            this.fastTrainButton.TabStop = false;
            this.fastTrainButton.Text = "Fast Train";
            this.fastTrainButton.UseVisualStyleBackColor = false;
            this.fastTrainButton.Click += new System.EventHandler(this.fastTrainButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.quitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitButton.BackgroundImage")));
            this.quitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("MS Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quitButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quitButton.Location = new System.Drawing.Point(798, 971);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(140, 145);
            this.quitButton.TabIndex = 2;
            this.quitButton.TabStop = false;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // saveNewExercisesButton
            // 
            this.saveNewExercisesButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveNewExercisesButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveNewExercisesButton.BackgroundImage")));
            this.saveNewExercisesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveNewExercisesButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.saveNewExercisesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNewExercisesButton.Font = new System.Drawing.Font("MS Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveNewExercisesButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveNewExercisesButton.Location = new System.Drawing.Point(343, 976);
            this.saveNewExercisesButton.Name = "saveNewExercisesButton";
            this.saveNewExercisesButton.Size = new System.Drawing.Size(140, 145);
            this.saveNewExercisesButton.TabIndex = 3;
            this.saveNewExercisesButton.TabStop = false;
            this.saveNewExercisesButton.Text = "Save New Exercises";
            this.saveNewExercisesButton.UseVisualStyleBackColor = false;
            this.saveNewExercisesButton.Click += new System.EventHandler(this.saveNewExercisesButton_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 1280);
            this.Controls.Add(this.saveNewExercisesButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.fastTrainButton);
            this.Controls.Add(this.startTrainButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startTrainButton;
        private System.Windows.Forms.Button fastTrainButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button saveNewExercisesButton;
    }
}