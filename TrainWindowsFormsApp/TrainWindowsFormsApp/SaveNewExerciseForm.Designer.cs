namespace TrainWindowsFormsApp
{
    partial class SaveNewExerciseForm
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
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.repeatTextBox = new System.Windows.Forms.TextBox();
            this.loadTextBox = new System.Windows.Forms.TextBox();
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exercisesTypeListBox = new System.Windows.Forms.ListBox();
            this.exerciseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textTextBox
            // 
            this.textTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textTextBox.Location = new System.Drawing.Point(333, 406);
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(1208, 53);
            this.textTextBox.TabIndex = 0;
            this.textTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // repeatTextBox
            // 
            this.repeatTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repeatTextBox.Location = new System.Drawing.Point(868, 549);
            this.repeatTextBox.Name = "repeatTextBox";
            this.repeatTextBox.Size = new System.Drawing.Size(136, 53);
            this.repeatTextBox.TabIndex = 0;
            this.repeatTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loadTextBox
            // 
            this.loadTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadTextBox.Location = new System.Drawing.Point(570, 787);
            this.loadTextBox.Name = "loadTextBox";
            this.loadTextBox.Size = new System.Drawing.Size(768, 53);
            this.loadTextBox.TabIndex = 0;
            this.loadTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.remarkTextBox.Location = new System.Drawing.Point(333, 928);
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(1208, 53);
            this.remarkTextBox.TabIndex = 0;
            this.remarkTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(658, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(554, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сохранение нового вопроса";
            // 
            // exercisesTypeListBox
            // 
            this.exercisesTypeListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exercisesTypeListBox.ColumnWidth = 200;
            this.exercisesTypeListBox.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exercisesTypeListBox.FormattingEnabled = true;
            this.exercisesTypeListBox.ItemHeight = 39;
            this.exercisesTypeListBox.Location = new System.Drawing.Point(37, 12);
            this.exercisesTypeListBox.MultiColumn = true;
            this.exercisesTypeListBox.Name = "exercisesTypeListBox";
            this.exercisesTypeListBox.Size = new System.Drawing.Size(1800, 160);
            this.exercisesTypeListBox.TabIndex = 2;
            this.exercisesTypeListBox.SelectedIndexChanged += new System.EventHandler(this.exercisesTypeListBox_SelectedIndexChanged);
            // 
            // exerciseBindingSource
            // 
            this.exerciseBindingSource.DataSource = typeof(TrainWindowsFormsApp.Exercise);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(868, 1070);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(136, 99);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SaveNewExercise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1873, 1528);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.exercisesTypeListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remarkTextBox);
            this.Controls.Add(this.loadTextBox);
            this.Controls.Add(this.repeatTextBox);
            this.Controls.Add(this.textTextBox);
            this.Name = "SaveNewExercise";
            this.Text = "Сохранение нового вопроса";
            this.Load += new System.EventHandler(this.SaveNewExercise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exerciseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.TextBox repeatTextBox;
        private System.Windows.Forms.TextBox loadTextBox;
        private System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox exercisesTypeListBox;
        private System.Windows.Forms.BindingSource exerciseBindingSource;
        private System.Windows.Forms.Button saveButton;
    }
}