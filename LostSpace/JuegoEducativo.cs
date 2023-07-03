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
    public partial class JuegoEducativo : Form
    {
        //----------------------------------------------\\
        //Atributos, Instacias y declaración de variables.
        //----------------------------------------------\\
        int PuntajeEducativo =0;
        int i, j;
        public int Vidas = 3;
        ClaseCronometro Hola = new ClaseCronometro();
        ClaseMusica musica3 = new ClaseMusica();
        ClaseSonidos musica2 = new ClaseSonidos();
        ClaseSonidos musica1 = new ClaseSonidos();
        Thread menu;
        Thread play;

        public JuegoEducativo()
        {
            InitializeComponent();

            //La música se reproduce.
            musica3.ElegirMusica("outthere");
            musica3.Play();

            //Todas las flechas se desactivan.
            PanelTotal.Visible = false;
            TimerDecremento.Enabled = true;
            PicRojo1.Visible = false;
            PicRojo2.Visible = false;
            PicRojo3.Visible = false;
            PicPiel1.Visible = false;
            PicPiel2.Visible = false;
            PicPiel3.Visible = false;
            PicVerde1.Visible = false;
            PicVerde2.Visible = false;
            PicVerde3.Visible = false;
            PicMora1.Visible = false;
            PicMora2.Visible = false;
            PicMora3.Visible = false;
            PicRoj1.Visible = false;
            PicRoj2.Visible = false;
            PicPieles1.Visible = false;
            PicPieles2.Visible = false;
            PicVer1.Visible = false;
            PicVer2.Visible = false;
            PicMor1.Visible = false;
            PicMor2.Visible = false;
            PicAz1.Visible = false;
            PicAz2.Visible = false;

            //Todas las respuestas y preguntas no son visibles.
            BtnResta.Visible = false;
            BtnRestaRes1.Visible = false;
            BtnRestaRes2.Visible = false;
            BtnRestaRes3.Visible = false;
            BtnMulti.Visible = false;
            BtnMultiRes1.Visible = false;
            BtnMultiRes2.Visible = false;
            BtnMultiRes3.Visible = false;
            BtnPar.Visible = false;
            BtnParRes1.Visible = false;
            BtnParRes2.Visible = false;
            BtnParRes3.Visible = false;
            BtnImpar.Visible = false;
            BtnImparRes1.Visible = false;
            BtnImparRes2.Visible = false;
            BtnImparRes3.Visible = false;
            BtnAngulo.Visible = false;
            BtnAnguloRes1.Visible = false;
            BtnAnguloRes2.Visible = false;
            BtnAnguloRes3.Visible = false;
            BtnHora.Visible = false;
            BtnHoraRes1.Visible = false;
            BtnHoraRes2.Visible = false;
            BtnHoraRes3.Visible = false;
            BtnDivi.Visible = false;
            BtnDiviRes1.Visible = false;
            BtnDiviRes2.Visible = false;
            BtnDiviRes3.Visible = false;
            BtnArea.Visible = false;
            BtnAreaRes1.Visible = false;
            BtnAreaRes2.Visible = false;
            BtnAreaRes3.Visible = false;
            BtnConv.Visible = false;
            BtnConvRes1.Visible = false;
            BtnConvRes2.Visible = false;
            BtnConvRes3.Visible = false;
            BtnJuan.Visible = false;
            BtnJuanRes1.Visible = false;
            BtnJuanRes2.Visible = false;
            BtnPara.Visible = false;
            BtnParaRes1.Visible = false;
            BtnParaRes2.Visible = false;
            BtnPenta.Visible = false;
            BtnPentaRes1.Visible = false;
            BtnPentaRes2.Visible = false;
            BtnFraccRes1.Visible = false;
            BtnFracc.Visible = false;
            BtnFraccRes2.Visible = false;
            BtnDece.Visible = false;
            BtnDeceRes2.Visible = false;
            BtnDeceRes1.Visible = false;

            //Todas las imagenes de los astronautas no son visibles.
            PicAstro1.Visible = false;
            PicAstro2.Visible = false;
            PicAstro3.Visible = false;
            PicAstro4.Visible = false;
            PicAstro5.Visible = false;
            PicAs1.Visible = false;
            PicAs2.Visible = false;
            PicAs3.Visible = false;
            PicAs4.Visible = false;
            PicAs5.Visible = false;
            PicAs6.Visible = false;
            PicAs7.Visible = false;
            PicAs8.Visible = false;
            PicAs9.Visible = false;
            PicAs10.Visible = false;
        }

        //Evento con métodos para mover la nave 
        private void JuegoEducativo_MouseMove(object sender, MouseEventArgs e)
        {
            MoverNaveX(e.X);
            MoverNaveY(e.Y);
        }
        //Método para mover la nave en X
        public void MoverNaveX(int newXPos)
        {
            if (newXPos < 0)
                newXPos = 0;
            else if (newXPos > ClientRectangle.Width - PicAstroEducativo.Width)
                newXPos = ClientRectangle.Width - PicAstroEducativo.Width;
            PicAstroEducativo.Left = newXPos;
        }

        //----------------------\\
        //Mover nave la nave en Y.
        //----------------------\\
        public void MoverNaveY(int newYPos)
        {
            if (newYPos < 600)
                newYPos = 600;
            else if (newYPos > ClientRectangle.Height - PicAstroEducativo.Height)
                newYPos = ClientRectangle.Height - PicAstroEducativo.Height;
            PicAstroEducativo.Top = newYPos;
        }

        //Evento para disparar el laser.
        private void JuegoEducativo_KeyDown(object sender, KeyEventArgs e)
        {
            int x = PicAstroEducativo.Location.X;
            int y = PicAstroEducativo.Location.Y;

            PicAstroEducativo.Location = new System.Drawing.Point(x, y);
            i = x;
            j = y;

            //Click al boton Espacio.
            if (e.KeyCode == Keys.Space)
            {
                //Se reproduce un sonido
                musica1.MusicaPerdedor("SpaceGun");
                musica1.Play();

                //El laser se hace visible.
                PicLaser2.Visible = true;
                PicLaser2.Location = new System.Drawing.Point(i + 13, j);
                TimerLasser.Enabled = true;
            }
        }

        //Timer para el cronometro.
        private void TimerDecremento_Tick(object sender, EventArgs e)
        {
            Hola.decremento(PanelTotal, LbDecremento, TimerDecremento, BtnSumaRes3, BtnSumaRes2, BtnSumaRes1, BtnSuma, PicAzul1, PicAzul2, PicAzul3, BtnResta, BtnRestaRes1, BtnRestaRes2, BtnRestaRes3, PicRojo1, PicRojo2, PicRojo3, BtnMultiRes3, BtnMultiRes2, BtnMultiRes1, BtnMulti,PicPiel1,PicPiel2,PicPiel3,BtnPar,BtnParRes1,BtnParRes2,BtnParRes3,PicVerde1,PicVerde2,PicVerde3);
            if (LbDecremento.Text ==" 0")
            {
                PuntajeObtenido.Text = PuntajeEducativo.ToString();
                PanelTotal.Show();
            }
        }

        //Click al dar al botón Menú.
        private void MenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();          //Cierra la ventana en la que esta.
            menu = new Thread(menus);
            menu.TrySetApartmentState(ApartmentState.STA);
            menu.Start();
        }

        //Método para el botón Menú
        private void menus()
        {
            Application.Run(new Game());
        }

        //Panel Total.
        private void PanelTotal_Paint(object sender, PaintEventArgs e)
        {
            //Muestra en pantalla tu puntaje total.
            PuntajeObtenido.Text = PuntajeEducativo.ToString();

            //Condición para reproducir sonido.
            if (PuntajeEducativo > 0)
            {
                musica2.MusicaPerdedor("tutu");
                musica2.Play();
            }

            if (PanelTotal.Visible == true)
            {
                //Tods las preguntas y respuestas no son visibles.
                musica3.Stop();
                musica2.Play();
                TimerDecremento.Stop();
                PicAstroEducativo.Visible = false;
                PicLaser2.Visible = false;
                PicRojo1.Visible = false;
                PicRojo2.Visible = false;
                PicRojo3.Visible = false;
                PicPiel1.Visible = false;
                PicPiel2.Visible = false;
                PicPiel3.Visible = false;
                PicVerde1.Visible = false;
                PicVerde2.Visible = false;
                PicVerde3.Visible = false;
                PicMora1.Visible = false;
                PicMora2.Visible = false;
                PicMora3.Visible = false;
                PicRoj1.Visible = false;
                PicRoj2.Visible = false;
                PicPieles1.Visible = false;
                PicPieles2.Visible = false;
                PicVer1.Visible = false;
                PicVer2.Visible = false;
                PicMor1.Visible = false;
                PicMor2.Visible = false;
                PicAz1.Visible = false;
                PicAz2.Visible = false;
                BtnResta.Visible = false;
                BtnRestaRes1.Visible = false;
                BtnRestaRes2.Visible = false;
                BtnRestaRes3.Visible = false;
                BtnMulti.Visible = false;
                BtnMultiRes1.Visible = false;
                BtnMultiRes2.Visible = false;
                BtnMultiRes3.Visible = false;
                BtnPar.Visible = false;
                BtnParRes1.Visible = false;
                BtnParRes2.Visible = false;
                BtnParRes3.Visible = false;
                BtnImpar.Visible = false;
                BtnImparRes1.Visible = false;
                BtnImparRes2.Visible = false;
                BtnImparRes3.Visible = false;
                BtnAngulo.Visible = false;
                BtnAnguloRes1.Visible = false;
                BtnAnguloRes2.Visible = false;
                BtnAnguloRes3.Visible = false;
                BtnHora.Visible = false;
                BtnHoraRes1.Visible = false;
                BtnHoraRes2.Visible = false;
                BtnHoraRes3.Visible = false;
                BtnDivi.Visible = false;
                BtnDiviRes1.Visible = false;
                BtnDiviRes2.Visible = false;
                BtnDiviRes3.Visible = false;
                BtnArea.Visible = false;
                BtnAreaRes1.Visible = false;
                BtnAreaRes2.Visible = false;
                BtnAreaRes3.Visible = false;
                BtnConv.Visible = false;
                BtnConvRes1.Visible = false;
                BtnConvRes2.Visible = false;
                BtnConvRes3.Visible = false;
                BtnJuan.Visible = false;
                BtnJuanRes1.Visible = false;
                BtnJuanRes2.Visible = false;
                BtnPara.Visible = false;
                BtnParaRes1.Visible = false;
                BtnParaRes2.Visible = false;
                BtnPenta.Visible = false;
                BtnPentaRes1.Visible = false;
                BtnPentaRes2.Visible = false;
                BtnFraccRes1.Visible = false;
                BtnFracc.Visible = false;
                BtnFraccRes2.Visible = false;
                BtnDece.Visible = false;
                BtnDeceRes2.Visible = false;
                BtnDeceRes1.Visible = false;
                PicAstro1.Visible = false;
                PicAstro2.Visible = false;
                PicAstro3.Visible = false;
                PicAstro4.Visible = false;
                PicAstro5.Visible = false;
                PicAs1.Visible = false;
                PicAs2.Visible = false;
                PicAs3.Visible = false;
                PicAs4.Visible = false;
                PicAs5.Visible = false;
                PicAs6.Visible = false;
                PicAs7.Visible = false;
                PicAs8.Visible = false;
                PicAs9.Visible = false;
                PicAs10.Visible = false;
            }
        }
        //Al hacer click al botón menú.
        private void MenúToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            menu = new Thread(pes);
            menu.TrySetApartmentState(ApartmentState.STA);
            menu.Start();
        }

        //Timer para mover el laser
        private void TimerLasser_Tick_1(object sender, EventArgs e)
        {
            if (PicLaser2.Bounds.IntersectsWith(PanelSeparar.Bounds)&& PanelSeparar.Visible)
            {
                PicLaser2.Visible = false;
            }
            
            PicLaser2.Top = PicLaser2.Top - 15;

            //Condición que hace visible las imagenes de la suma.
            if (BtnSumaRes1.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnSumaRes1.Bounds))
                {
                    TimerLasser.Enabled = false;
                    PicLaser2.Visible = false;
                    BtnSumaRes1.Visible = false;
                }
            }
            
            //Condición que hace visible la Respuesta num.2 de la operación de suma.
            if (BtnSumaRes2.Visible == true)
            {
                
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnSumaRes2.Bounds))
                {
                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    TimerLasser.Enabled = false;
                    PicLaser2.Visible = false;

                    //Las preguntas y respuestas  dejan de ser visibles.
                    BtnSumaRes2.Visible = false;
                    BtnSumaRes1.Visible = false;
                    BtnSuma.Visible = false;
                    BtnSumaRes3.Visible = false;
                    PicAzul1.Visible = false;
                    PicAzul2.Visible = false;
                    PicAzul3.Visible = false;
                    PicAs1.Visible = false;

                    //Las preguntas y respuesas de la sig pregunta se hacen visibles.
                    PicRojo1.Visible = true;
                    PicRojo2.Visible = true;
                    PicRojo3.Visible = true;
                    BtnResta.Visible = true;
                    BtnRestaRes1.Visible = true;
                    BtnRestaRes2.Visible = true;
                    BtnRestaRes3.Visible = true;
                }
            }

            if (BtnSumaRes3.Visible == true)
            {
                //Condición al momento que el laser intersecta a respuesta.
                if (PicLaser2.Bounds.IntersectsWith(BtnSumaRes3.Bounds))
                {
                    PicAs1.Visible = true;
                    TimerLasser.Enabled = false;
                    //Todas las imagenes de la suma se hacen falsas.
                    BtnSumaRes3.Visible = false;
                    PicLaser2.Visible = false;
                    
                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();
                }
            }

            if (BtnRestaRes1.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnRestaRes1.Bounds))
                {        
                    TimerLasser.Enabled = false;
                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Las preguntas y respuestas dejan de ser visibles.
                    BtnRestaRes1.Visible = false;
                    BtnRestaRes2.Visible = false;
                    BtnResta.Visible = false;
                    BtnRestaRes3.Visible = false;
                    PicRojo1.Visible = false;
                    PicRojo2.Visible = false;
                    PicRojo3.Visible = false;
                    BtnResta.Visible = false;
                    PicAs2.Visible = false;

                    //El laser se oculta y las imágenes de la sig. pregunta se hacen visibles.
                    PicLaser2.Visible = false;
                    PicPiel1.Visible = true;
                    PicPiel2.Visible = true;
                    PicPiel3.Visible = true;
                    BtnMulti.Visible = true;
                    BtnMultiRes1.Visible = true;
                    BtnMultiRes2.Visible = true;
                    BtnMultiRes3.Visible = true;
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Resta.
            if (BtnRestaRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagen.
                if (PicLaser2.Bounds.IntersectsWith(BtnRestaRes2.Bounds))
                {
                    PicAs2.Visible = true;
                    TimerLasser.Enabled = false;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //El laser se oculta.
                    BtnRestaRes2.Visible = false;
                    PicLaser2.Visible = false;
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Resta.
            if (BtnRestaRes3.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnRestaRes3.Bounds))
                {
                    //El laser se oculta.
                    PicAs1.Enabled = false;
                    BtnRestaRes3.Visible = false;
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;
                }
            }

            //Condición que hace visible las imagenes de la Multiplicación.
            if (BtnMultiRes1.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnMultiRes1.Bounds))
                {
                    PicAs3.Visible = true;
                    BtnMultiRes1.Visible = false;
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Multiplicación.
            if (BtnMultiRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnMultiRes2.Bounds))
                {
                    PicAs2.Enabled = false;

                    //El laser se oculta al igua que la imagen.
                    TimerLasser.Enabled = false;
                    PicLaser2.Visible = false;
                    BtnMultiRes2.Visible = false;
                }
            }

            if (BtnMultiRes3.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnMultiRes3.Bounds))
                {
                    TimerLasser.Enabled = false;
                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan de ser visibles.
                    BtnMultiRes1.Visible = false;
                    BtnMultiRes2.Visible = false;
                    BtnMulti.Visible = false;
                    BtnMultiRes3.Visible = false;
                    PicPiel1.Visible = false;
                    PicPiel2.Visible = false;
                    PicPiel3.Visible = false;
                    PicAs3.Visible = false;

                    //El laser se oculta al igua que la imagen.
                    PicLaser2.Visible = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    PicVerde1.Visible = true;
                    PicVerde2.Visible = true;
                    PicVerde3.Visible = true;
                    BtnPar.Visible = true;
                    BtnParRes1.Visible = true;
                    BtnParRes2.Visible = true;
                    BtnParRes3.Visible = true;
                }
            }
            
            //Condición que hace visible las imagenes de Par.
            if (BtnParRes1.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnParRes1.Bounds))
                {
                    PicAs3.Enabled = false;
                    PicAs4.Visible = true;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    TimerLasser.Enabled = false;
                    PicLaser2.Visible = false;
                    BtnParRes1.Visible = false;
                }
            }

            if (BtnParRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnParRes2.Bounds))
                {
                    TimerLasser.Enabled = false;

                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan de ser visibles.
                    BtnParRes1.Visible = false;
                    BtnParRes2.Visible = false;
                    BtnPar.Visible = false;
                    BtnParRes3.Visible = false;
                    PicVerde1.Visible = false;
                    PicVerde2.Visible = false;
                    PicVerde3.Visible = false;
                    PicAs4.Visible = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    PicLaser2.Visible = false;

                    PicMora1.Visible = true;
                    PicMora2.Visible = true;
                    PicMora3.Visible = true;
                    BtnImpar.Visible = true;
                    BtnImparRes1.Visible = true;
                    BtnImparRes2.Visible = true;
                    BtnImparRes3.Visible = true;
                }
            }

            if (BtnParRes3.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnParRes3.Bounds))
                {
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;
                    BtnParRes3.Visible = false;
                }
            }

            if (BtnImparRes1.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnImparRes1.Bounds))
                {
                    PicAs4.Enabled = false;

                    //El laser se oculta al igua que la imagen.
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;

                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan de ser visibles.
                    BtnImparRes1.Visible = false;
                    BtnImparRes2.Visible = false;
                    BtnImpar.Visible = false;
                    BtnImparRes3.Visible = false;
                    PicMora1.Visible = false;
                    PicMora2.Visible = false;
                    PicMora3.Visible = false;
                    PicAs5.Visible = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    BtnAngulo.Visible = true;
                    BtnAnguloRes1.Visible = true;
                    BtnAnguloRes2.Visible = true;
                    BtnAnguloRes3.Visible = true;
                    PicAzul1.Visible = true;
                    PicAzul2.Visible = true;
                    PicAzul3.Visible = true;
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Impar.
            if (BtnImparRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnImparRes2.Bounds))
                {
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;
                    BtnImparRes2.Visible = false;
                    PicAs5.Visible = true;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();
                }
            }

            if (BtnImparRes3.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta ImparRes3.
                if (PicLaser2.Bounds.IntersectsWith(BtnImparRes3.Bounds))
                {
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;
                    BtnImparRes3.Visible = false;
                }
            }

            if (BtnAnguloRes1.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnAnguloRes1.Bounds))
                {
                    //Todas las imagenes de la suma se hacen falsas.
                    PicLaser2.Visible = false;
                    BtnAnguloRes1.Visible = false;
                    TimerLasser.Enabled = false;
                    PicLaser2.Visible = false;
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Resta.
            if (BtnAnguloRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnAnguloRes2.Bounds))
                {
                    PicAs5.Enabled = false;
                    PicAs6.Visible = true;

                    //El laser se oculta al igua que la imagen.
                    BtnAnguloRes2.Visible = false;
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();
                }
            }
            if (BtnAnguloRes3.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnAnguloRes3.Bounds))
                {
                    TimerLasser.Enabled = false;

                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan visibles.
                    BtnAnguloRes1.Visible = false;
                    BtnAnguloRes2.Visible = false;
                    BtnAngulo.Visible = false;
                    BtnAnguloRes3.Visible = false;
                    PicAzul1.Visible = false;
                    PicAzul2.Visible = false;
                    PicAzul3.Visible = false;
                    PicAs6.Visible = false;
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    BtnHoraRes1.Visible = true;
                    BtnHoraRes2.Visible = true;
                    BtnHoraRes3.Visible = true;
                    BtnHora.Visible = true;
                    PicRojo1.Visible = true;
                    PicRojo2.Visible = true;
                    PicRojo3.Visible = true;
                }
            }
            //Condición que hace visible la Respuesta num.2 de la operación de Resta.
            if (BtnHoraRes1.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnHoraRes1.Bounds))
                {
                    TimerLasser.Enabled = false;

                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan visibles.
                    BtnHoraRes1.Visible = false;
                    BtnHoraRes2.Visible = false;
                    BtnHora.Visible = false;
                    BtnHoraRes3.Visible = false;
                    PicRojo1.Visible = false;
                    PicRojo2.Visible = false;
                    PicRojo3.Visible = false;
                    PicAs7.Visible = false;
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    BtnDivi.Visible = true;
                    BtnDiviRes1.Visible = true;
                    BtnDiviRes2.Visible = true;
                    BtnDiviRes3.Visible = true;
                    PicPiel1.Visible = true;
                    PicPiel2.Visible = true;
                    PicPiel3.Visible = true;
                }
            }

            //Condición que hace visible las imagenes de la Fracción.
            if (BtnHoraRes2.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnHoraRes2.Bounds))
                {
                    PicAs7.Visible = true;
                    PicAs6.Enabled = false;
                    BtnHoraRes2.Visible = false;
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();
                }
            }
            //Condición que hace visible las imagenes de la Fracción.
            if (BtnHoraRes3.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnHoraRes3.Bounds))
                {
                    BtnHoraRes3.Visible = false;
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;
                }
            }

            //Condición que hace visible las imagenes de la Fracción.
            if (BtnDiviRes1.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnDiviRes1.Bounds))
                {
                    PicAs8.Visible = true;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    TimerLasser.Enabled = false;
                    PicLaser2.Visible = false;
                    BtnDiviRes1.Visible = false;
                }
            }

            if (BtnDiviRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnDiviRes2.Bounds))
                {
                    PicAs8.Visible = false;
                    PicAs7.Enabled = false;
                    TimerLasser.Enabled = false;

                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan visibles.
                    BtnDiviRes1.Visible = false;
                    BtnDiviRes2.Visible = false;
                    BtnDivi.Visible = false;
                    BtnDiviRes3.Visible = false;
                    PicPiel1.Visible = false;
                    PicPiel2.Visible = false;
                    PicPiel3.Visible = false;
                    PicLaser2.Visible = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    BtnArea.Visible = true;
                    BtnAreaRes1.Visible = true;
                    BtnAreaRes2.Visible = true;
                    BtnAreaRes3.Visible = true;
                    PicVerde1.Visible = true;
                    PicVerde2.Visible = true;
                    PicVerde3.Visible = true;
                }
            }

            if (BtnDiviRes3.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnDiviRes3.Bounds))
                {
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;
                    BtnDiviRes3.Visible = false;
                }
            }

            if (BtnAreaRes1.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnAreaRes1.Bounds))
                {
                    TimerLasser.Enabled = false;

                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan visibles.
                    BtnAreaRes1.Visible = false;
                    BtnAreaRes2.Visible = false;
                    BtnArea.Visible = false;
                    BtnAreaRes3.Visible = false;
                    BtnParRes3.Visible = false;
                    PicVerde1.Visible = false;
                    PicVerde2.Visible = false;
                    PicVerde3.Visible = false;
                    PicAs9.Visible = false;
                    PicLaser2.Visible = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    PicMora1.Visible = true;
                    PicMora2.Visible = true;
                    PicMora3.Visible = true;
                    BtnConv.Visible = true;
                    BtnConvRes1.Visible = true;
                    BtnConvRes2.Visible = true;
                    BtnConvRes3.Visible = true;
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Area.
            if (BtnAreaRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnAreaRes2.Bounds))
                {
                    PicAs9.Visible = true;
                    PicAs8.Enabled = false;
                    TimerLasser.Enabled = false;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //El laser se oculta.
                    BtnAreaRes2.Visible = false;
                    PicLaser2.Visible = false;
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Resta.
            if (BtnAreaRes3.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnAreaRes3.Bounds))
                {
                    //El laser se oculta.
                    BtnAreaRes3.Visible = false;
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;
                }
            }

            if (BtnConvRes1.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnConvRes1.Bounds))
                {
                    PicAs10.Visible = true;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    TimerLasser.Enabled = false;
                    PicLaser2.Visible = false;
                    BtnConvRes1.Visible = false;
                }
            }

            if (BtnConvRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnConvRes2.Bounds))
                {
                    PicAs10.Visible = false;
                    PicAs9.Enabled = false;
                    TimerLasser.Enabled = false;

                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan visibles.
                    BtnConvRes1.Visible = false;
                    BtnConvRes2.Visible = false;
                    BtnConv.Visible = false;
                    BtnConvRes3.Visible = false;
                    PicMora1.Visible = false;
                    PicMora2.Visible = false;
                    PicMora3.Visible = false;
                    PicLaser2.Visible = false;


                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    PicAz1.Visible = true;
                    PicAz2.Visible = true;
                    BtnJuan.Visible = true;
                    BtnJuanRes1.Visible = true;
                    BtnJuanRes2.Visible = true;
                }
            }

            if (BtnConvRes3.Visible == true)
            {
                //Condición al momento que el laser intersecta a la imagen con la respuesta correcta.
                if (PicLaser2.Bounds.IntersectsWith(BtnConvRes3.Bounds))
                {
                    PicLaser2.Visible = false;
                    TimerLasser.Enabled = false;
                    BtnConvRes3.Visible = false;
                }
            }
            if (BtnJuanRes1.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnJuanRes1.Bounds))
                {
                    TimerLasser.Enabled = false;
                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan visibles.
                    BtnJuanRes1.Visible = false;
                    BtnJuanRes2.Visible = false;
                    BtnJuan.Visible = false;
                    PicAstro1.Visible = false;
                    PicAz1.Visible = false;
                    PicAz2.Visible = false;
                    PicLaser2.Visible = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    PicRoj1.Visible = true;
                    PicRoj2.Visible = true;
                    BtnPara.Visible = true;
                    BtnParaRes1.Visible = true;
                    BtnParaRes2.Visible = true;              
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Resta.
            if (BtnJuanRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnJuanRes2.Bounds))
                {
                    PicAstro1.Visible = true;   
                    TimerLasser.Enabled = false;
                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //El laser se oculta.
                    BtnJuanRes2.Visible = false;
                    PicLaser2.Visible = false;
                }
            }
            if (BtnParaRes1.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnParaRes1.Bounds))
                {
                    PicAstro1.Enabled = false;
                    PicAstro2.Visible = true;
                    TimerLasser.Enabled = false;
                    
                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //El laser se oculta.
                    BtnParaRes1.Visible = false;
                    PicLaser2.Visible = false;
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Para.
            if (BtnParaRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnParaRes2.Bounds))
                {
                    PicAstro2.Visible = false;
                    TimerLasser.Enabled = false;
                    
                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan visibles.
                    BtnParaRes1.Visible = false;
                    BtnParaRes2.Visible = false;
                    BtnPara.Visible = false;
                    PicRoj1.Visible = false;
                    PicRoj2.Visible = false;

                    //El laser se oculta al igua que la imagen.
                    PicLaser2.Visible = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    PicPieles1.Visible = true;
                    PicPieles2.Visible = true;
                    BtnPenta.Visible = true;
                    BtnPentaRes1.Visible = true;
                    BtnPentaRes2.Visible = true;
                }
            }

            if (BtnPentaRes1.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnPentaRes1.Bounds))
                {
                    PicAstro2.Enabled = false;
                    PicAstro3.Visible = true;
                    TimerLasser.Enabled = false;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //El laser se oculta.
                    BtnPentaRes1.Visible = false;
                    PicLaser2.Visible = false;
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Penta.
            if (BtnPentaRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnPentaRes2.Bounds))
                {
                    //El Puntaje aumenta.
                    TimerLasser.Enabled = false;
                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan visibles.
                    BtnPentaRes1.Visible = false;
                    BtnPentaRes2.Visible = false;
                    BtnPenta.Visible = false;
                    PicAstro3.Visible = false;
                    PicPieles1.Visible = false;
                    PicPieles2.Visible = false;
                    PicLaser2.Visible = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    PicVer1.Visible = true;
                    PicVer2.Visible = true;
                    BtnFraccRes1.Visible = true;
                    BtnFracc.Visible = true;
                    BtnFraccRes2.Visible = true;
                }
            }

            if (BtnFraccRes1.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnFraccRes1.Bounds))
                {
                    TimerLasser.Enabled = false;
                    
                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();
                    
                    //Imagenes y respuestas dejan visibles.
                    BtnFraccRes1.Visible = false;
                    BtnFraccRes2.Visible = false;
                    BtnFracc.Visible = false;
                    PicAstro4.Visible = false;
                    PicVer1.Visible = false;
                    PicVer2.Visible = false;

                    //Imagenes y respuestas de la sig pregunta se hacen visibles.
                    PicLaser2.Visible = false;
                    PicMor1.Visible = true;
                    PicMor2.Visible = true;
                    BtnDece.Visible = true;
                    BtnDeceRes2.Visible = true;
                    BtnDeceRes1.Visible = true;
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Resta.
            if (BtnFraccRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnFraccRes2.Bounds))
                {
                    PicAstro3.Enabled = false;
                    PicAstro4.Visible = true;
                    TimerLasser.Enabled = false;

                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //El laser se oculta.
                    BtnFraccRes2.Visible = false;
                    PicLaser2.Visible = false;
                }
            }

            if (BtnDeceRes1.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnDeceRes1.Bounds))
                {
                    TimerLasser.Enabled = false;
                    
                    //El Puntaje aumenta.
                    PuntajeEducativo = PuntajeEducativo + 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //Imagenes y respuestas dejan de ser visibles.
                    BtnDeceRes2.Visible = false;
                    BtnDeceRes1.Visible = false;
                    BtnDece.Visible = false;
                    PicAstro5.Visible = false;
                    PicMor1.Visible = false;
                    PicMor2.Visible = false;
                    PicLaser2.Visible = false;

                    //Muestra en pantalla el Puntaje y para el cronometro.
                    PanelTotal.Visible = true;
                    PuntajeObtenido.Text = PuntajeEducativo.ToString();
                    TimerDecremento.Stop();
                    PicAstroEducativo.Visible = false;
                    musica3.Stop();
                    if (PuntajeEducativo > 0)
                    {
                        musica2.MusicaPerdedor("tutu");
                        musica2.Play();
                    }
                    //El laser se oculta al igua que la imagen.
                }
            }

            //Condición que hace visible la Respuesta num.2 de la operación de Decenas.
            if (BtnDeceRes2.Visible == true)
            {
                //Condición al momento de que el laser intersecte está imagenes.
                if (PicLaser2.Bounds.IntersectsWith(BtnDeceRes2.Bounds))
                {
                    PicAstro4.Visible = false;
                    PicAstro5.Visible = true;
                    TimerLasser.Enabled = false;
                    
                    //El Puntaje disminuye.
                    PuntajeEducativo = PuntajeEducativo - 10;
                    LbPuntaje.Text = PuntajeEducativo.ToString();

                    //El laser se oculta.
                    BtnDeceRes2.Visible = false;
                    PicLaser2.Visible = false;                   
                }
            }
        }

        //Método para el botón Menú.
        private void pes()
        {
            Application.Run(new Game());
        }

        //Click al botón Reset.
        private void ResetToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            play = new Thread(peez);
            play.TrySetApartmentState(ApartmentState.STA);
            play.Start();

        }

        private void pez()
        {
            Application.Run(new Juego());
        }

        private void peez()
        {
            Application.Run(new JuegoEducativo());
        }
    }
    }

