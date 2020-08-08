namespace TrainWindowsFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьНовоеУпражнениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закончитьТренировкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходБезСохраненияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьРазминкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьНовоеУпражнениеToolStripMenuItem,
            this.выходБезСохраненияToolStripMenuItem,
            this.закончитьТренировкуToolStripMenuItem,
            this.сформироватьРазминкуToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1920, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьНовоеУпражнениеToolStripMenuItem
            // 
            this.сохранитьНовоеУпражнениеToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.сохранитьНовоеУпражнениеToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.сохранитьНовоеУпражнениеToolStripMenuItem.Name = "сохранитьНовоеУпражнениеToolStripMenuItem";
            this.сохранитьНовоеУпражнениеToolStripMenuItem.Size = new System.Drawing.Size(275, 29);
            this.сохранитьНовоеУпражнениеToolStripMenuItem.Text = "Сохранить новое упражнение";
            this.сохранитьНовоеУпражнениеToolStripMenuItem.Click += new System.EventHandler(this.сохранитьНовоеУпражнениеToolStripMenuItem_Click);
            // 
            // закончитьТренировкуToolStripMenuItem
            // 
            this.закончитьТренировкуToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.закончитьТренировкуToolStripMenuItem.BackColor = System.Drawing.Color.SeaGreen;
            this.закончитьТренировкуToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.закончитьТренировкуToolStripMenuItem.Name = "закончитьТренировкуToolStripMenuItem";
            this.закончитьТренировкуToolStripMenuItem.Size = new System.Drawing.Size(215, 29);
            this.закончитьТренировкуToolStripMenuItem.Text = "Закончить тренировку";
            this.закончитьТренировкуToolStripMenuItem.Click += new System.EventHandler(this.закончитьТренировкуToolStripMenuItem_Click);
            // 
            // выходБезСохраненияToolStripMenuItem
            // 
            this.выходБезСохраненияToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выходБезСохраненияToolStripMenuItem.BackColor = System.Drawing.Color.Firebrick;
            this.выходБезСохраненияToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.выходБезСохраненияToolStripMenuItem.Name = "выходБезСохраненияToolStripMenuItem";
            this.выходБезСохраненияToolStripMenuItem.Size = new System.Drawing.Size(212, 29);
            this.выходБезСохраненияToolStripMenuItem.Text = "Выход без сохранения";
            this.выходБезСохраненияToolStripMenuItem.Click += new System.EventHandler(this.выходБезСохраненияToolStripMenuItem_Click);
            // 
            // сформироватьРазминкуToolStripMenuItem
            // 
            this.сформироватьРазминкуToolStripMenuItem.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.сформироватьРазминкуToolStripMenuItem.Name = "сформироватьРазминкуToolStripMenuItem";
            this.сформироватьРазминкуToolStripMenuItem.Size = new System.Drawing.Size(237, 29);
            this.сформироватьРазминкуToolStripMenuItem.Text = "Сформировать разминку";
            this.сформироватьРазминкуToolStripMenuItem.Click += new System.EventHandler(this.сформироватьРазминкуToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(20, 0);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Let\'s Rock";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходБезСохраненияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьНовоеУпражнениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закончитьТренировкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьРазминкуToolStripMenuItem;
    }
}

