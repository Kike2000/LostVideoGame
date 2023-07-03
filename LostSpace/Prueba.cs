using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LostSpace
{
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
            //timer1.Start();
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            //claseDiseño1.BottomColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            //claseDiseño1.Invalidate();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Prueba_Load(object sender, EventArgs e)
        {

        }
    }
}
