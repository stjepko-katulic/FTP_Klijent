using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPKlijent
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox(string tekst)
        {
            InitializeComponent();
            label1.Text = tekst;
        }
    }
}
