using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LostSpace
{
    public class ClaseCronometro
    {
        //--------\\
        //Variables.
        //--------\\
        int Segundos = 225;

        //----------\\
        //Constructor.
        //----------\\
        public ClaseCronometro()
        {
        }

        //------------------------\\
        //Método para el cronometro.
        //------------------------\\
        public void decremento(Panel Total,Label crono,Timer eme, Button BtnSumaRes3, Button BtnSumaRes2, Button BtnSumaRes1, Button BtnSuma, PictureBox PicAzul3, PictureBox PicAzul2, PictureBox PicAzul1, Button BtnRestaRes3, Button BtnRestaRes2, Button BtnRestaRes1, Button BtnResta, PictureBox PicRojo3, PictureBox PicRojo2, PictureBox PicRojo1, Button BtnMultiRes3, Button BtnMultiRes2, Button BtnMultiRes1, Button BtnMulti, PictureBox PicPiel3, PictureBox PicPiel2, PictureBox PicPiel1, Button BtnParRes3, Button BtnParRes2, Button BtnParRes1, Button BtnPar, PictureBox PicVerde3, PictureBox PicVerde2, PictureBox PicVerde1)
        {
            Segundos--;
            crono.Text = Segundos.ToString();

            //-----------------------------------\\
            //Condición si el cronometro llega a 0.
            //-----------------------------------\\
            if (crono.Text == "-1")
            {
                //----------------------------------\\
                //Las imagenes dejan de verse visible.
                //----------------------------------\\
                Total.Visible = true;
                eme.Enabled = false;
                BtnSumaRes2.Visible = false;
                BtnSumaRes1.Visible = false;
                BtnSuma.Visible = false;
                BtnSumaRes3.Visible = false;
                PicAzul1.Visible = false;
                PicAzul2.Visible = false;
                PicAzul3.Visible = false;

                BtnResta.Visible = false;
                BtnRestaRes1.Visible = false;
                BtnRestaRes2.Visible = false;
                BtnRestaRes3.Visible = false;
                PicRojo1.Visible = false;
                PicRojo2.Visible = false;
                PicRojo3.Visible = false;

                BtnMulti.Visible = false;
                BtnMultiRes1.Visible = false;
                BtnMultiRes2.Visible = false;
                BtnMultiRes3.Visible = false;
                PicPiel1.Visible = false;
                PicPiel2.Visible = false;
                PicPiel3.Visible = false;

                BtnPar.Visible = false;
                BtnParRes1.Visible = false;
                BtnParRes2.Visible = false;
                BtnParRes3.Visible = false;
                PicVerde1.Visible = false;
                PicVerde2.Visible = false;
                PicVerde3.Visible = false;

                crono.Text = "10";
                Segundos = 10;
            }
        }

        /*public void decremento2(Label crono, Timer eme, Button BtnMultiRes3, Button BtnMultiRes2, Button BtnMultiRes1, Button BtnMulti, PictureBox PicPiel3, PictureBox PicPiel2, PictureBox PicPiel1, Button BtnSumaRes3, Button BtnSumaRes2, Button BtnSumaRes1, Button BtnSuma, PictureBox PicAzul3, PictureBox PicAzul2, PictureBox PicAzul1)
        {
            crono.Visible = true;
            eme.Enabled = true;
            Segundos--;
            crono.Text = Segundos.ToString();

            if (crono.Text == "-1")
            {
                BtnSumaRes2.Visible = false;
                BtnSumaRes1.Visible = false;
                BtnSuma.Visible = false;
                BtnSumaRes3.Visible = false;
                PicAzul1.Visible = false;
                PicAzul2.Visible = false;
                PicAzul3.Visible = false;
                eme.Enabled = true;

                crono.Text = "10";
                Segundos = 10;
                PicPiel1.Visible = true;
                PicPiel2.Visible = true;
                PicPiel3.Visible = true;

            crono.Visible=false;
                BtnMulti.Visible = true;
                BtnMultiRes1.Visible = true;
                BtnMultiRes2.Visible = true;
                BtnMultiRes3.Visible = true;
            }
        }

        public void Regresar(Label crono, Timer eme,Button BtnMultiRes3, Button BtnMultiRes2, Button BtnMultiRes1, Button BtnMulti, PictureBox PicPiel3, PictureBox PicPiel2, PictureBox PicPiel1)
        {

            eme.Enabled = false; ;
            crono.Text = "10";

            PicPiel1.Visible = true;
            PicPiel2.Visible = true;
            PicPiel3.Visible = true;

            BtnMulti.Visible = true;
            BtnMultiRes1.Visible = true;
            BtnMultiRes2.Visible = true;
            BtnMultiRes3.Visible = true;
        }

        public void Regresar2(Label crono, Timer eme, Button BtnParRes3, Button BtnParRes2, Button BtnParRes1, Button BtnPar, PictureBox PicVerde3, PictureBox PicVerde2, PictureBox PicVerde1)
        {
            eme.Enabled = false; ;
            crono.Text = "10";

            PicVerde1.Visible = true;
            PicVerde2.Visible = true;
            PicVerde3.Visible = true;

            BtnPar.Visible = true;
            BtnParRes1.Visible = true;
            BtnParRes2.Visible = true;
            BtnParRes3.Visible = true;
        }*/
    }
}
    

