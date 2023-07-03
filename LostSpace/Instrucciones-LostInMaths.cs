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
    public partial class Instrucciones_LostInMaths : Form
    {
        Thread menu;
        Thread play;
        Thread ins;

        public Instrucciones_LostInMaths()
        {
            InitializeComponent();
        }

        //-----------------\\
        //Mostrar la Portada.
        //-----------------\\
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            menu = new Thread(pes);
            menu.TrySetApartmentState(ApartmentState.STA);
            menu.Start();
        }

        //--------------\\
        //Muestra Portada.
        //--------------\\
        private void pes()
        {
            Application.Run(new Game());
        }

        //--------------------\\
        //Muestra Instrucciones.
        //--------------------\\
        private void pez()
        {
            Application.Run(new Instruc());
        }

        //--------------\\
        //Inicia Juego .
        //--------------\\
        private void pees()
        {
            Application.Run(new JuegoEducativo());
        }

        //Click al botón Lost In Game.
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            play = new Thread(pez);
            play.TrySetApartmentState(ApartmentState.STA);
            play.Start();
        }

        //---------------------------\\
        //Click al boton Iniciar juego.
        //---------------------------\\
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            ins = new Thread(pees);
            ins.TrySetApartmentState(ApartmentState.STA);
            ins.Start();
        }
    }
}
