using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Height = 50;
            ShowIcon = false;
            Text = "Примечание";
            
        }

        public void ShowRemark(string message)
        {
            var label = new Label()
            {
                AutoSize = true,
                BackColor = Color.AliceBlue,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                Location = new Point(0, 0),
                Size = new Size(Height, Width),
                Text = message,
                TextAlign = ContentAlignment.TopLeft
            };
            Controls.Add(label);
            ShowDialog();
        }
    }
}
