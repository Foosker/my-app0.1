
namespace TrainWindowsFormsApp
{
    partial class FastTrainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastTrainForm));
            this.quitButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quitButton.Location = new System.Drawing.Point(1512, 1361);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(123, 43);
            this.quitButton.TabIndex = 0;
            this.quitButton.Text = "QUIT";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(1512, 1312);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(123, 43);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "CLOSE";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // FastTrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1721, 1474);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.quitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FastTrainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FastTrainForm";
            this.Load += new System.EventHandler(this.FastTrainForm_Load);
            this.SizeChanged += new System.EventHandler(this.FastTrainForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button closeButton;
    }
}