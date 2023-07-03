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
    public partial class Incorrecto : Form
    {
        //---------\\
        //Instancias.
        //---------\\
        ClaseSonidos musica1 = new ClaseSonidos();
        public Incorrecto()
        {
            musica1.MusicaPerdedor("010592688_prev");
            musica1.Play();
            InitializeComponent();
        }

        //--------------------------\\
        //Música deja de reproducirse.
        //--------------------------\\
        private void Button1_Click(object sender, EventArgs e)
        {
            musica1.Stop();
            this.Close();
        }
    }
}
