namespace TrainWindowsFormsApp
{
    partial class SetNewLoadForm
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
            this.currentExerciseLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newLoadTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentExerciseLabel
            // 
            this.currentExerciseLabel.AutoSize = true;
            this.currentExerciseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentExerciseLabel.Location = new System.Drawing.Point(354, 266);
            this.currentExerciseLabel.Name = "currentExerciseLabel";
            this.currentExerciseLabel.Size = new System.Drawing.Size(316, 37);
            this.currentExerciseLabel.TabIndex = 0;
            this.currentExerciseLabel.Text = "Текущее упражнение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(187, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(682, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ввод следующего уровня нагрузки";
            // 
            // newLoadTextBox
            // 
            this.newLoadTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newLoadTextBox.Location = new System.Drawing.Point(361, 470);
            this.newLoadTextBox.Name = "newLoadTextBox";
            this.newLoadTextBox.Size = new System.Drawing.Size(309, 44);
            this.newLoadTextBox.TabIndex = 2;
            this.newLoadTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(434, 615);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(167, 100);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SetNewLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 985);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newLoadTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentExerciseLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetNewLoadForm";
            this.Text = "Запись следующего уровня нагрузки";
            this.Load += new System.EventHandler(this.SetNewLoadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentExerciseLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newLoadTextBox;
        private System.Windows.Forms.Button saveButton;
    }
}