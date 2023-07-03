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
    public partial class Instruc : Form
    {
        //--------------------\\
        //Variables e instacias.
        //--------------------\\
        Thread space;
        Thread Edu;
        Thread men;
        ClaseMusica music = new ClaseMusica();

        //----------\\
        //Constructor.
        //----------\\
        public Instruc()
        {
            music.ElegirMusica("depeche");
            music.Play();
            InitializeComponent();
        }

        //-----------------------------------------\\
        //Muestra las instrucciones de Lost In Maths.
        //-----------------------------------------\\
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Edu = new Thread(pes);
            Edu.TrySetApartmentState(ApartmentState.STA);
            Edu.Start();
        }

        //-----------------------------------------\\
        //Muestra las instrucciones de Lost In Space.
        //-----------------------------------------\\
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            space = new Thread(pez);
            space.TrySetApartmentState(ApartmentState.STA);
            space.Start();
        }

        //------------------------------------------\\
        //Método para mostrar instrucc. Lost In Maths.
        //------------------------------------------\\
        private void pes()
        {
            Application.Run(new Instrucciones_LostInMaths());
        }

        //---------------------------\\
        //Método para mostrar instrucc.
        //---------------------------\\
        private void pez()
        {
            Application.Run(new Instrucciones());
        }

        //--------------------------\\
        //Método para mostrar Portada.
        //--------------------------\\
        private void pee()
        {
            Application.Run(new Game());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            men = new Thread(pee);
            men.TrySetApartmentState(ApartmentState.STA);
            men.Start();
        }
    }
}
