using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LostSpace
{
    public partial class Instrucciones : Form
    {
        //--------------------\\
        //Variables e instacias.
        //--------------------\\
        Thread menu;
        Thread play;
        Thread ins;
        
        public Instrucciones()
        {
            InitializeComponent();
        }

        //Click al boton Lost In Maths
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            menu = new Thread(pes);
            menu.TrySetApartmentState(ApartmentState.STA);
            menu.Start();
        }

        //Click al botón Lost In Game.
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            play = new Thread(pez);
            play.TrySetApartmentState(ApartmentState.STA);
            play.Start();
        }

        //--------------------\\
        //Muestra Instrucciones.
        //--------------------\\
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ins = new Thread(pees);
            ins.TrySetApartmentState(ApartmentState.STA);
            ins.Start();
        }

        //--------------\\
        //Muestra Portada.
        //--------------\\
        private void pes()
        {
            Application.Run(new Game());
        }

        //--------------\\
        //Muestra Portada.
        //--------------\\
        private void pez()
        {
            Application.Run(new Juego());
        }

        //------------------------\\
        //Método para instrucciones.
        //------------------------\\
        private void pees()
        {
            Application.Run(new Instruc());
        }
    }
}
