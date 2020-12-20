namespace TrainWindowsFormsApp
{
    partial class SetNewProgramForm
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
            this.exercisesTypesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // exercisesTypesListBox
            // 
            this.exercisesTypesListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exercisesTypesListBox.ColumnWidth = 200;
            this.exercisesTypesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exercisesTypesListBox.FormattingEnabled = true;
            this.exercisesTypesListBox.ItemHeight = 37;
            this.exercisesTypesListBox.Location = new System.Drawing.Point(12, 39);
            this.exercisesTypesListBox.MultiColumn = true;
            this.exercisesTypesListBox.Name = "exercisesTypesListBox";
            this.exercisesTypesListBox.Size = new System.Drawing.Size(2451, 263);
            this.exercisesTypesListBox.TabIndex = 0;
            this.exercisesTypesListBox.SelectedIndexChanged += new System.EventHandler(this.setProgramListBox_SelectedIndexChanged);
            // 
            // SetNewProgramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2475, 1655);
            this.Controls.Add(this.exercisesTypesListBox);
            this.Name = "SetNewProgramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetNewProgramForm";
            this.Load += new System.EventHandler(this.SetNewProgramForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox exercisesTypesListBox;
    }
}