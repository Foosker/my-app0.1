using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainWindowsFormsApp
{
    public class MyMessageBox : Form
    {
        public MyMessageBox()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            StartPosition = FormStartPosition.Manual;
            Location = new Point(MousePosition.X, MousePosition.Y);

            FormBorderStyle = FormBorderStyle.None;  // None - yбирает шапку формы
            ShowIcon = false;

            KeyPress += MyMessageBox_KeyPress;            
        }

        private void MyMessageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Close();
        }

        public void ShowText(string message)
        {
            var label = new Label()
            {
                Location = new Point(0, 0),
                Size = new Size(Height, Width),
                AutoSize = true,

                BackColor = Color.Ivory,
                Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                Text = message,
                TextAlign = ContentAlignment.TopLeft
            };
            Controls.Add(label);
            ShowDialog();
        }
    }
}
