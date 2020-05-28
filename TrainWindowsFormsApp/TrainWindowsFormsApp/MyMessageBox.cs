using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainWindowsFormsApp
{
    public class MyMessageBox : Form
    {
        public MyMessageBox(string message)
        {
            Font = new System.Drawing.Font("Lucida Handwriting", 15F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            ShowIcon = false;
            Text = "Примечание";
        }
    }
}
