using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
namespace LostSpace
{
    class ClaseVidas
    {
        //--------\\
        //Variables.
        //--------\\
        int vidas = 10;

        //----------\\
        //Constructor.
        //----------\\
        public ClaseVidas()
        {

        }

        //-----------------------\\
        //Método para restar vidas.
        //-----------------------\\
        public void Salir(Label Vidas,System.Windows.Forms.Timer Nivel3, System.Windows.Forms.Timer velo, System.Windows.Forms.Timer velos, System.Windows.Forms.Timer solo, PictureBox este, PictureBox oeste, PictureBox ses, PictureBox aste1, PictureBox aste2, PictureBox aste3, PictureBox aste4, PictureBox aste5, PictureBox aste6, PictureBox come1, PictureBox come2, PictureBox come3, PictureBox come4, PictureBox come5, PictureBox explosion,PictureBox PicOvni1,PictureBox PicOvni2,PictureBox PicOvni3,PictureBox PicOvni4, PictureBox LaserOvni1, PictureBox LaserOvni2, PictureBox LaserOvni3, PictureBox LaserOvni4)
        {
            vidas = vidas - 1;
            Vidas.Text = vidas.ToString();

            //-----------------------------------------\\
            //Condición si vidas es menos ó igual a cero.
            //-----------------------------------------\\
            if (vidas <= 0)
            {
                //------------------\\
                //Timer se desactivan.
                //------------------\\
                velo.Stop();
                solo.Stop();
                velos.Stop();
                Nivel3.Stop();

                //--------------------------------------\\
                //Todas la imagenes dejan de ser visibles.
                //--------------------------------------\\
                aste1.Visible = false;
                aste2.Visible = false;
                aste3.Visible = false;
                aste4.Visible = false;
                aste5.Visible = false;
                aste6.Visible = false;
                ses.Visible = false;
                este.Visible = false;
                este.Enabled = false;
                oeste.Visible = false;
                come1.Visible = false;
                come2.Visible = false;
                come3.Visible = false;
                come4.Visible = false;
                come5.Visible = false;
                PicOvni1.Visible = false;
                PicOvni2.Visible = false;
                PicOvni3.Visible = false;
                PicOvni4.Visible = false;
                LaserOvni1.Visible = false;
                LaserOvni2.Visible = false;
                LaserOvni3.Visible = false;
                LaserOvni4.Visible = false;

                //-------------------------------------\\
                //La imagen de explosión se hace visible.
                //-------------------------------------\\
                explosion.Visible = true;

                //----------------------------\\
                //Muestra en pantalla Game Over.
                //----------------------------\\
                Incorrecto inco = new Incorrecto();
                inco.Show();
            }

            
        }
        public int getNumVidas(Label LbVidas)
        {
            return vidas;
        }
    }
}
