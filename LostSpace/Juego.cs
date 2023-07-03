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
    public partial class Juego : Form
    { 
        //----------\\
        //Atributos.
        //----------\\
        int Puntaje = 0;
        PictureBox[] asteroides = new PictureBox[6];
        PictureBox[] cometas = new PictureBox[5];
        PictureBox[] ovni = new PictureBox[4];
        PictureBox[] laser = new PictureBox[4];
        int  p, i, j, z;

        //---------\\
        //Instancias.
        //---------\\
        ClaseMusica musica2 = new ClaseMusica();
        ClaseMusica musica4 = new ClaseMusica();
        ClaseMusica musica1 = new ClaseMusica();
        ClaseSonidos musica3 = new ClaseSonidos();
        ClaseVidas Decremento = new ClaseVidas();
        ClaseVidas mis = new ClaseVidas();
        ClaseVidas ne = new ClaseVidas();
        ClaseVidasOvnis fin = new ClaseVidasOvnis();
        ClaseSonidos musica5 = new ClaseSonidos();
        ClaseVidas se = new ClaseVidas();
        Ganador ganar = new Ganador();
        Thread Menu;
        Thread cerrar;

        //----------\\
        //Constructor.
        //----------\\
        public Juego()
        {
            InitializeComponent();

            //---------------------\\
            //Se reproduce la musica.
            //---------------------\\
            musica2.ElegirMusica("maintheme");
            musica2.Play();

            //--------------------------------------------------\\
            //Si el label vidas es igual a cero la música se para.
            //--------------------------------------------------\\
            if (LbVidas.Text == "0")
            {
                musica2.Stop();
            }

            //----------------------------------------------------\\
            //Se guardan las imagenes de los meteoros en un arreglo.
            //----------------------------------------------------\\
            asteroides[0] = PicMeteoro;
            asteroides[1] = PicMeteoro2;
            asteroides[2] = PicMeteoro1;
            asteroides[3] = PicMeteoro3;
            asteroides[4] = PicMeteoro4;
            asteroides[5] = PicMeteoro5;

            //---------------------------------------------------\\
            //Se guardan las imagenes de los cometas en un arreglo.
            //---------------------------------------------------\\
            cometas[0] = PicCometa1;
            cometas[1] = PicCometa2;
            cometas[2] = PicCometa3;
            cometas[3] = PicCometa4;
            cometas[4] = PicCometa5;

            //---------------------------------------------------\\
            //Se guardan las imagenes de los ovnis en un arreglo.
            //---------------------------------------------------\\
            ovni[0] = PicOvni1;
            ovni[1] = PicOvni2;
            ovni[2] = PicOvni3;
            ovni[3] = PicOvni4;

            //--------------------------------------------------------------\\
            //Se guardan las imagenes de los laser de los ovnis en un arreglo.
            //--------------------------------------------------------------\\
            laser[0] = LaserOvni1;
            laser[1] = LaserOvni2;
            laser[2] = LaserOvni3;
            laser[3] = LaserOvni4;

            //---------------------------------------------------------------------------------------\\
            //Las imágenes del cometa no son visibles al principio y el TimerNivel2 está deshabilitado.
            //---------------------------------------------------------------------------------------\\
            PicCometa1.Visible = false;
            PicCometa2.Visible = false;
            PicCometa3.Visible = false;
            PicCometa4.Visible = false;
            PicCometa5.Visible = false;
            PicExplosion.Visible = false;
            TimerNivel2.Enabled=false;

            //-----------------------------------------------------------------------------------------------------\\
            //Las imágenes de los ovnis y sus laser no son visibles al principio y el TimerNivel3 está deshabilitado.
            //-----------------------------------------------------------------------------------------------------\\
            PicOvni1.Visible = false;
            PicOvni2.Visible = false;
            PicOvni3.Visible = false;
            PicOvni4.Visible = false;
            LaserOvni1.Visible = false;
            LaserOvni2.Visible = false;
            LaserOvni3.Visible = false;
            LaserOvni4.Visible = false;
            TimerNivel3.Enabled = false;

            //--------------------------------------\\
            //Labels contadores de vidas de los ovnis.
            //--------------------------------------\\
            LbVidaOvni1.Visible = false;
            LbVidaOvni2.Visible = false;
            LbVidaOvni3.Visible = false;
            LbVidaOvni4.Visible = false;
                 
        }

        //---------------------------------\\
        //Timer Laser con varias condiciones.
        //---------------------------------\\
        private void Timerlaser_Tick(object sender, EventArgs e)
        {
            //----------------------------------------------------------\\
            //Dirección que tendrá el laser de la nave cuando sea lanzado.
            //----------------------------------------------------------\\
            PicLaser.Top = PicLaser.Top - 15;

            //-------------------------------------------------------------------\\
            //El arrelo donde se almacenaron los meteoros se utiliza en este bucle.
            //-------------------------------------------------------------------\\
            for (p = 0; p < 6; p++)
            {
                //----------------------------------------------------------------\\
                //Condición donde si el laser de la nave intersecta algún cometeoro:
                //----------------------------------------------------------------\\
                if (PicLaser.Bounds.IntersectsWith(asteroides[p].Bounds) && asteroides[p].Visible)
                {
                    //-------------------------------------------------\\
                    //El Laser se deshabilita.
                    //-------------------------------------------------\\
                    PicLaser.Visible = false;

                    //-----------------------------------------------------------------\\
                    //Se oculta el meteoro que fue intersectado y el puntaje aumenta a 1.
                    //-----------------------------------------------------------------\\
                    asteroides[p].Hide();
                    Puntaje += 1;
                    LbPuntaje.Text = Puntaje.ToString();
                    Timerlaser.Enabled = false;
                }
            }

            //------------------------------------------------------------------\\
            //El arrelo donde se almacenaron los cometas se utiliza en este bucle.
            //------------------------------------------------------------------\\
            for (z = 0; z < 5; z++)
            {
                //-------------------------------------------------------------\\
                //Condición donde si el laser de la nave intersecta algún cometa:
                //-------------------------------------------------------------\\
                if (PicLaser.Bounds.IntersectsWith(cometas[z].Bounds) && cometas[z].Visible)
                {
                    //-------------------------------------------------\\
                    //El TimerLaser se deshabilita al igual que el laser.
                    //-------------------------------------------------\\
                    Timerlaser.Enabled = false;
                    PicLaser.Visible = false;

                    //----------------------------------------------------------------\\
                    //Se oculta el cometa que fue intersectado y el puntaje aumenta a 1.
                    //----------------------------------------------------------------\\
                    cometas[z].Hide();
                    Puntaje += 1;
                    LbPuntaje.Text = Puntaje.ToString();
                }
                
            }

            //-------------------------------------------------------------------\\
            //El arrelo donde se almacenaron los ovnis se utiliza en este bucle.
            //-------------------------------------------------------------------\\
            for (int  t= 0; t < 4; t++)
            {
                //-------------------------------------------------------------\\
                //Condición donde si el laser de la nave intersecta algún ovno:
                //-------------------------------------------------------------\\
                if (PicLaser.Bounds.IntersectsWith(ovni[t].Bounds) && ovni[t].Visible)
            {
                //-------------------------------------------------\\
                //El TimerLaser se deshabilita al igual que el laser.
                //-------------------------------------------------\\
                Timerlaser.Enabled = false;
                PicLaser.Visible = false;

                //----------------------------------------------------------------\\
                //Se oculta el ovni que fue intersectado y el puntaje aumenta a 1.
                //----------------------------------------------------------------\\
                ovni[t].Hide();
                Puntaje += 1;
                LbPuntaje.Text = Puntaje.ToString();
            }
        }
                
            //------------------------------------------------------------------------------\\
            //El arrelo donde se almacenaron los  laser de los ovnis se utiliza en este bucle.
            //------------------------------------------------------------------------------\\
            for (int s = 0; s < 4; s++)
            {
                //-----------------------------------------------------------------\\
                //Condición donde si el laser de la nave intersecta algún laser-ovni:
                //-----------------------------------------------------------------\\
                if (PicLaser.Bounds.IntersectsWith(laser[s].Bounds) && laser[s].Visible)
                {
                    //-------------------------------------------------\\
                    //El TimerLaser se deshabilita al igual que el laser.
                    //-------------------------------------------------\\
                    Timerlaser.Enabled = false;
                    PicLaser.Visible = false;

                    //---------------------------------------------------------------\\
                    //Se oculta el laser que fue intersectado y el puntaje aumenta a 1.
                    //---------------------------------------------------------------\\
                    laser[s].Hide();
                    LbPuntaje.Text = Puntaje.ToString();
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------\\
            //Para que no se vea el laser en el menuStrip, coloqué un panel al momento de que sea lanzado el laser, y cuando este intersecte el menuStrip deje de ser visible.
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------\\
            if (PicLaser.Bounds.IntersectsWith(panel1.Bounds) && panel1.Visible)
            {
                PicLaser.Visible = false;
            }

            //-----------------------------------------------------------------------------------------------------------------\\
            //Si el Label es igual a cero el laser no aparece para que no aparezca denuevo al momento de presionar tecla espacio.
            //-----------------------------------------------------------------------------------------------------------------\\
            if (LbVidas.Text == "0")
            {
                PicLaser.Visible = false;
            }
        }

        //------------------------------------\\
        //Timer para movimiento de los meteoros.
        //------------------------------------\\
        private void TimerMeteoros_Tick(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------\\
            //Función random que dara una nueva posición a cada uno de los meteoros.
            //--------------------------------------------------------------------\\
            Random rdn = new Random();
            int a = rdn.Next(15, 450);
            int b = rdn.Next(16, 450);
            int c = rdn.Next(17, 450);
            int d = rdn.Next(18, 450);
            int f = rdn.Next(19, 450);
            int h = rdn.Next(20, 450);

            //--------------------------------------------------------------------------------\\
            //Al momento de que los asteroides bajen menos a  la posición x , estos irán rapido.
            //--------------------------------------------------------------------------------\\
            if (PicMeteoro.Top < 1000)
            {
                PicMeteoro.Top = PicMeteoro.Top + 5;
            }
            if (PicMeteoro1.Top < 800)
            {
                PicMeteoro1.Top = PicMeteoro1.Top + 5;
            }
            if (PicMeteoro2.Top < 750)
            {
                PicMeteoro2.Top = PicMeteoro2.Top + 5;
            }
            if (PicMeteoro3.Top < 700)
            {
                PicMeteoro3.Top = PicMeteoro3.Top + 5;
            }
            if (PicMeteoro4.Top < 600)
            {
                PicMeteoro4.Top = PicMeteoro4.Top + 4;
            }
            if (PicMeteoro5.Top < 600)
            {
                PicMeteoro5.Top = PicMeteoro5.Top + 4;
            }

            else
            {
                PicMeteoro.Visible = true;
                PicMeteoro1.Visible = true;
                PicMeteoro2.Visible = true;
                PicMeteoro3.Visible = true;
                PicMeteoro4.Visible = true;
                PicMeteoro5.Visible = true;

                //---------------------------------------------\\
                //Asignación de nuevas posiciones a los meteoros.
                //---------------------------------------------\\
                PicMeteoro.Location = new Point(a, 10);
                PicMeteoro1.Location = new Point(b + 15, 10);
                PicMeteoro2.Location = new Point(c + 5, 10);
                PicMeteoro3.Location = new Point(d, 20);
                PicMeteoro4.Location = new Point(f + 8, 10);
                PicMeteoro5.Location = new Point(h + 2, 10);
            }

            //---------------------------------------------------------------------------------------------------------------------------------\\
            //Condiciones que hacen que el respectivo meteoro que la nave intersecte, pierda una vida y se oculte el meteoro que fue intersectado.
            //---------------------------------------------------------------------------------------------------------------------------------\\
            if (PicMeteoro.Visible == true)
            {
                //--------------------------------------------------\\
                //Si el usuario intersecta al meteroro este se oculta.
                //--------------------------------------------------\\
                if (PicAstro.Bounds.IntersectsWith(PicMeteoro.Bounds))
                {
                    PicMeteoro.Hide();

                    //---------------------------------------------\\
                    //Uso de la clase decremento con el método Salir.
                    //---------------------------------------------\\
                    Decremento.Salir(LbVidas,TimerNivel3, TimerNivel2, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                }
            }
            if (PicMeteoro1.Visible == true)
            {
                //---------------------------------------------------\\
                //Si el usuario intersecta al meteroro1 este se oculta.
                //---------------------------------------------------\\
                if (PicAstro.Bounds.IntersectsWith(PicMeteoro1.Bounds))
                {
                    PicMeteoro1.Hide();

                    //---------------------------------------------\\
                    //Uso de la clase decremento con el método Salir.
                    //---------------------------------------------\\
                    Decremento.Salir(LbVidas, TimerNivel2, TimerNivel3, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                }
            }
            if (PicMeteoro2.Visible == true)
            {
                //---------------------------------------------------\\
                //Si el usuario intersecta al meteroro2 este se oculta.
                //---------------------------------------------------\\
                if (PicAstro.Bounds.IntersectsWith(PicMeteoro2.Bounds))
                {
                    PicMeteoro2.Hide();

                    //---------------------------------------------\\
                    //Uso de la clase decremento con el método Salir.
                    //---------------------------------------------\\
                    Decremento.Salir(LbVidas, TimerNivel3, TimerNivel2, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser,PicCometa1,PicCometa2,PicCometa3,PicCometa4,PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);  
                }
            }
            if (PicMeteoro3.Visible == true)
            {
                //---------------------------------------------------\\
                //Si el usuario intersecta al meteroro3 este se oculta.
                //---------------------------------------------------\\
                if (PicAstro.Bounds.IntersectsWith(PicMeteoro3.Bounds))
                {
                    PicMeteoro3.Hide();

                    //---------------------------------------------\\
                    //Uso de la clase decremento con el método Salir.
                    //---------------------------------------------\\
                    Decremento.Salir(LbVidas, TimerNivel3,TimerNivel2, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                }
            }
            if (PicMeteoro4.Visible == true)
            {
                //---------------------------------------------------\\
                //Si el usuario intersecta al meteroro4 este se oculta.
                //---------------------------------------------------\\
                if (PicAstro.Bounds.IntersectsWith(PicMeteoro4.Bounds))
                {
                    PicMeteoro4.Hide();

                    //---------------------------------------------\\
                    //Uso de la clase decremento con el método Salir.
                    //---------------------------------------------\\
                    Decremento.Salir(LbVidas, TimerNivel3,TimerNivel2, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                }
            }
            if (PicMeteoro5.Visible == true)
            {
                //---------------------------------------------------\\
                //Si el usuario intersecta al meteroro5 este se oculta.
                //---------------------------------------------------\\
                if (PicAstro.Bounds.IntersectsWith(PicMeteoro5.Bounds))
                {
                    PicMeteoro5.Hide();

                    //---------------------------------------------\\
                    //Uso de la clase decremento con el método Salir.
                    //---------------------------------------------\\
                    Decremento.Salir(LbVidas, TimerNivel2, TimerNivel3, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                }
            }

            //-------------------------------------------------\\
            //Condición al momento de que Puntaje sea mayor a 30.
            //-------------------------------------------------\\
            if (Puntaje == 8 || Puntaje ==9)
            {
                musica2.Stop();

                //------------------------------------------------\\
                //Los imagenes de los mateoros se hacen no visibles.
                //------------------------------------------------\\
                PicMeteoro.Visible = false;
                PicMeteoro1.Visible = false;
                PicMeteoro2.Visible = false;
                PicMeteoro3.Visible = false;
                PicMeteoro4.Visible = false;
                PicMeteoro5.Visible = false;
               
                //--------------------------------------------\\
                //Las imagenes del los cometas se hace visibles.
                //--------------------------------------------\\
                PicCometa1.Visible = true;
                PicCometa2.Visible = true;
                PicCometa3.Visible = true;
                PicCometa4.Visible = true;
                PicCometa5.Visible = true;

                //Se reproduce nueva música sacada de la clase musica.
                musica4.ElegirMusica("je");
                musica4.Play();

                //----------------------------------------------------------------------------\\
                //El Timer de los meteoros se deshabilita y el Timer de los cometas se habilita.
                //----------------------------------------------------------------------------\\
                TimerMeteoros.Enabled=false;
                TimerNivel3.Enabled = false;
                TimerNivel2.Enabled=true;
            }
        } 

        //-------------------------------------------------------\\
        //Cierra ventana del juego LOST IN SPACE y abre la portada.
        //-------------------------------------------------------\\
        private void MenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();          //Cierra la ventana en la que esta.
            Menu = new Thread(menu);
            Menu.TrySetApartmentState(ApartmentState.STA);
            Menu.Start();
        }

        //----------------------------------------\\
        //Método para abrir la ventana de la portada.
        //----------------------------------------\\
        private void menu()
        {
            Application.Run(new Game());
        }

        //------------------------------------------\\
        //Evento que realiza el movimiento de la nave.
        //------------------------------------------\\
        private void Juego_MouseMove(object sender, MouseEventArgs e)
        {
            //-----------------\\
            //Métodos para X y Y.
            //-----------------\\
            MoverNaveX(e.X);
            MoverNaveY(e.Y);

            //------------------------------------------------------------\\
            //Asignando valores a otras variables de la posición de la nave.
            //------------------------------------------------------------\\
            int x = PicAstro.Location.X;
            int y = PicAstro.Location.Y;
            PicAstro.Location = new System.Drawing.Point(x, y);
            i = x;
            j = y;

            //-----------------------------------------------------------------------------------------------------------\\
            //La imagen explosión es no es visible pero sigue el mismo paso que la nave ya que tien las mismas coordenadas.
            //-----------------------------------------------------------------------------------------------------------\\
            PicExplosion.Visible = false;
            PicExplosion.Location = new System.Drawing.Point(i , j);
        }

        //-----------------------------------\\
        //Evento para el lanzamiento del laser.
        //-----------------------------------\\
        private void Juego_KeyDown(object sender, KeyEventArgs e)
        {
            int x = PicAstro.Location.X;
            int y = PicAstro.Location.Y;

            PicAstro.Location = new System.Drawing.Point(x, y);
            i = x;
            j = y;

            //-------------------------------------------------------------\\
            //Condición que evalua si se está oprimiento el boton de espacio.
            //-------------------------------------------------------------\\
            if (e.KeyCode == Keys.Space)
            {
                //-------------------------------------------------------------------\\
                //Cada que el usuario oprima el botón espacio se reproducirá un sonido.
                //-------------------------------------------------------------------\\
                musica3.MusicaPerdedor("SpaceGun");
                musica3.Play();
                if (LbVidas.Text == "0")
                {
                    musica3.Stop();
                }

                //--------------------------------------------------------------\\
                //La imagen del laser se hace visible cuando se oprime esta tecla.
                //--------------------------------------------------------------\\
                PicLaser.Visible = true;
                Timerlaser.Enabled = true;

                //-----------------------------------------------------------\\
                //La imagen del laser toma una posicions cerca a la de la nave.
                //-----------------------------------------------------------\\
                PicLaser.Location = new System.Drawing.Point(i + 28, j);
                
                //--------------------------------------------------\\
                //Se activa el timer laser (Es el que lanza el laser).
                //--------------------------------------------------\\
                Timerlaser.Start();
            }   
        }

        //----------------------------\\
        //Timer donde aparece los Ovnis.
        //----------------------------\\
        private void TimerNivel3_Tick(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------\\
            //Función random que dara una nueva posición a cada uno de los meteoros.
            //--------------------------------------------------------------------\\
            Random rdn2 = new Random();
            int r = rdn2.Next(15, 450);
            int s = rdn2.Next(10, 450);
            int t = rdn2.Next(18, 450);
            int u = rdn2.Next(16, 450);

            if (PicOvni1.Top < 600)
            {
                PicOvni1.Top = PicOvni1.Top + 6;
            }
            if (PicOvni2.Top < 700)
            {
                PicOvni2.Top = PicOvni2.Top + 5;
            }
            if (PicOvni3.Top < 800)
            {
                PicOvni3.Top = PicOvni3.Top + 7;
            }
            if (PicOvni4.Top < 700)
            {
                PicOvni4.Top = PicOvni4.Top + 6;
            }

            //-----------------------------------------------------------------------------\\
            //Si los laser de los ovnis es menor a la coordena Y estos tendrán una velocidad.
            //-----------------------------------------------------------------------------\\
            if (LaserOvni1.Top < 1000)
            {
                LaserOvni1.Top = LaserOvni1.Top + 10;
            }
            if (LaserOvni2.Top < 1000)
            {
                LaserOvni2.Top = LaserOvni2.Top + 8;
            }
            if (LaserOvni3.Top < 1000)
            {
                LaserOvni3.Top = LaserOvni3.Top + 11;
            }
            if (LaserOvni4.Top < 1000)
            {
                LaserOvni4.Top = LaserOvni4.Top + 10;
            }

            else
            {
                PicOvni1.Visible = true;
                PicOvni2.Visible = true;
                PicOvni3.Visible = true;
                PicOvni4.Visible = true;

                LaserOvni1.Visible = true;
                LaserOvni2.Visible = true;
                LaserOvni3.Visible = true;
                LaserOvni4.Visible = true;

                //------------------------------------------\\
                //Asignación de nuevas posiciones a los ovnis.
                //------------------------------------------\\
                PicOvni1.Location = new Point(r, 10);
                PicOvni2.Location = new Point(s , 10);
                PicOvni3.Location = new Point(t , 10);
                PicOvni4.Location = new Point(u, 20);

                //-------------------------------------------------------------\\
                //Los laser de los ovnis tendrán la misma posición que los ovnis.
                //-------------------------------------------------------------\\
                LaserOvni1.Location = new Point(r+23, 10);
                LaserOvni2.Location = new Point(s + 23, 10);
                LaserOvni3.Location = new Point(t + 14, 10);
                LaserOvni4.Location = new Point(u+28, 20);
            }

            //---------------------------------------------------------------------------------------------------------------------------------\\
            //Condiciones que hacen que el respectivo meteoro que la nave intersecte pierda una vida y se oculte el meteoro que fue intersectado.
            //---------------------------------------------------------------------------------------------------------------------------------\\
            if (LaserOvni1.Visible == true)
            {
                //-------------------------------------\\
                //Si el laser-Ovni1 intersecta a la nave:
                //-------------------------------------\\
                if (LaserOvni1.Bounds.IntersectsWith(PicAstro.Bounds))
                {
                    //-----------------------------------------------\\
                    //La nave perderá una vida mediante la clase Vidas.
                    //-----------------------------------------------\\
                    Decremento.Salir(LbVidas, TimerNivel2, TimerNivel3, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion,PicOvni1,PicOvni2,PicOvni3,PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    LaserOvni1.Visible = false;
                }
            }
            if (LaserOvni2.Visible == true)
            {
                //-------------------------------------\\
                //Si el laser-Ovni2 intersecta a la nave:
                //-------------------------------------\\
                if (LaserOvni2.Bounds.IntersectsWith(PicAstro.Bounds))
                {
                    Decremento.Salir(LbVidas, TimerNivel2, TimerNivel3, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    LaserOvni2.Visible = false;
                }
            }
            if (LaserOvni3.Visible == true)
            {
                //-------------------------------------\\
                //Si el laser-Ovni2 intersecta a la nave:
                //-------------------------------------\\
                if (LaserOvni3.Bounds.IntersectsWith(PicAstro.Bounds))
                {
                    LaserOvni3.Hide();
                    Decremento.Salir(LbVidas, TimerNivel2, TimerNivel3, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                }
            }
            if (LaserOvni4.Visible == true)
            {
                //-------------------------------------\\
                //Si el laser-Ovni2 intersecta a la nave:
                //-------------------------------------\\
                if (LaserOvni4.Bounds.IntersectsWith(PicAstro.Bounds))
                {
                    LaserOvni4.Hide();
                    Decremento.Salir(LbVidas, TimerNivel2, TimerMeteoros, TimerNivel3, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4,LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    
                }
            }
            if (PicOvni1.Visible == true)
            {
                //-------------------------------\\
                //Si el Ovni1 intersecta a la nave:
                //-------------------------------\\
                if (PicOvni1.Bounds.IntersectsWith(PicAstro.Bounds))
                {
                    Decremento.Salir(LbVidas, TimerNivel2, TimerNivel3, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    PicOvni1.Visible = false;
                }
            }
            if (PicOvni2.Visible == true)
            {
                //-------------------------------\\
                //Si el Ovni2 intersecta a la nave:
                //-------------------------------\\
                if (PicOvni2.Bounds.IntersectsWith(PicAstro.Bounds))
                {
                    Decremento.Salir(LbVidas, TimerNivel2, TimerNivel3, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    PicOvni2.Visible = false;
                }
            }
            if (PicOvni3.Visible == true)
            {
                //-------------------------------\\
                //Si el Ovni3 intersecta a la nave:
                //-------------------------------\\
                if (PicOvni3.Bounds.IntersectsWith(PicAstro.Bounds))
                {
                    PicOvni3.Hide();
                    Decremento.Salir(LbVidas, TimerNivel2, TimerNivel3, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                }
            }
            if (PicOvni4.Visible == true)
            {
                //-------------------------------\\
                //Si el Ovni4 intersecta a la nave:
                //-------------------------------\\
                if (PicOvni4.Bounds.IntersectsWith(PicAstro.Bounds))
                {
                    PicOvni4.Hide();
                    Decremento.Salir(LbVidas, TimerNivel2, TimerMeteoros, TimerNivel3, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                }
            }

            //----------------------------------------------------------------------------------------------------\\
            //Clase que contiene las vidas de los ovnis, si estos son intersectados por el laser, no serán visibles.
            //----------------------------------------------------------------------------------------------------\\
            fin.Vidaovni(LbVidaOvni1, LbVidaOvni2, LbVidaOvni3, LbVidaOvni4, TimerNivel3, PicOvni1, PicOvni2, PicOvni3, PicOvni4, PicLaser);

            //------------------------------\\
            //Condición para el label Puntaje.
            //------------------------------\\
            if (LbPuntaje.Text == "80" || LbPuntaje.Text=="80")
            {
                //-----------------------------\\
                //La música deja de reproducirse.
                //-----------------------------\\
                musica1.Stop();
                musica5.MusicaPerdedor("tutu");
                musica5.Play();

                //-------------------------------------------\\
                //Los Ovnis y sus lasers dejan de ser visibles.
                //-------------------------------------------\\
                PicOvni1.Visible = false;
                PicOvni2.Visible = false;
                PicOvni3.Visible = false;
                PicOvni4.Visible = false;
                LaserOvni1.Visible = false;
                LaserOvni2.Visible = false;
                LaserOvni3.Visible = false;
                LaserOvni4.Visible = false;

                //--------------------------------------------------------------------------\\
                //Si el jugador pasa todos los niveles se mostrará en pantalla un nuevo Forms.
                //--------------------------------------------------------------------------\\
                PicAstro.Visible = false;
                TimerMeteoros.Enabled = false;
                TimerNivel2.Enabled = false;
                TimerNivel3.Enabled = false;
                ganar.Show();
            }
        }

        //-------------------\\
        //Click al Botón Reset.
        //-------------------\\
        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //-----------------------------------------------------------\\
            //La música para y se vuelve a abrir el forms de Lost In Space.
            //-----------------------------------------------------------\\
            musica2.Stop();
            this.Close();          //Cierra la ventana en la que esta.
            cerrar = new Thread(pes);
            cerrar.TrySetApartmentState(ApartmentState.STA);
            cerrar.Start();
        }

        //-------------------\\
        //Timer de los cometas.
        //-------------------\\
        private void TimerNivel2_Tick(object sender, EventArgs e)
        { 
            //--------------------------------------------------------------------\\
            //Función random que dara una nueva posición a cada uno de los meteoros.
            //--------------------------------------------------------------------\\
            Random rdn2 = new Random();
            int r = rdn2.Next(15, 450);
            int s = rdn2.Next(15, 450);
            int t = rdn2.Next(15, 450);
            int u = rdn2.Next(15, 450);
            int v = rdn2.Next(15, 450);

            if (PicCometa1.Top < 600)
            {
            PicCometa1.Top = PicCometa1.Top + 8;
            }
            if (PicCometa2.Top < 600)
            {
            PicCometa2.Top = PicCometa2.Top + 6;
            }   
            if (PicCometa3.Top < 700)
            {
            PicCometa3.Top = PicCometa3.Top + 7;
            }
            if (PicCometa4.Top < 700)
            {
            PicCometa4.Top = PicCometa4.Top + 7;
            }
            if (PicCometa5.Top < 750)
            {
                PicCometa5.Top = PicCometa5.Top + 8;
            }
            else
            {
                PicCometa1.Visible = true;
                PicCometa2.Visible = true;
                PicCometa3.Visible = true;
                PicCometa4.Visible = true;
                PicCometa5.Visible = true;
                
                //--------------------------------------------\\
                //Asignación de nuevas posiciones a los meteoros.
                //--------------------------------------------\\
                PicCometa1.Location = new Point(r, 10);
                PicCometa2.Location = new Point(s + 15, 10);
                PicCometa3.Location = new Point(t + 5, 10);
                PicCometa4.Location = new Point(u, 20);
                PicCometa5.Location = new Point(v + 8, 10);    
            }

            //---------------------------------------------------------------------------------------------------------------------------------\\
            //Condiciones que hacen que el respectivo meteoro que la nave intersecte pierda una vida y se oculte el meteoro que fue intersectado.
            //---------------------------------------------------------------------------------------------------------------------------------\\
            if (PicCometa1.Visible == true)
            {
                if (PicAstro.Bounds.IntersectsWith(PicCometa1.Bounds))
                {
                    Decremento.Salir(LbVidas, TimerNivel2, TimerNivel3, TimerMeteoros, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    PicCometa1.Visible = false;
                    se.getNumVidas(LbVidas);
                }
            }
            if (PicCometa2.Visible == true)
            {
                if (PicAstro.Bounds.IntersectsWith(PicCometa2.Bounds))
                {
                    Decremento.Salir(LbVidas, TimerNivel2, TimerMeteoros, TimerNivel3, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    PicCometa2.Visible = false;
                    se.getNumVidas(LbVidas);
                }
            }
            if (PicCometa3.Visible == true)
            {
                if (PicAstro.Bounds.IntersectsWith(PicCometa3.Bounds))
                {
                    PicCometa3.Hide();
                    Decremento.Salir(LbVidas, TimerNivel2, TimerMeteoros, TimerNivel3, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    se.getNumVidas(LbVidas);
                }
            }
            if (PicCometa4.Visible == true)
            {
                if (PicAstro.Bounds.IntersectsWith(PicCometa4.Bounds))
                {
                    PicCometa4.Hide();
                    Decremento.Salir(LbVidas, TimerNivel2, TimerMeteoros, TimerNivel3, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser, PicCometa1, PicCometa2, PicCometa3, PicCometa4, PicCometa5,PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    se.getNumVidas(LbVidas);
                }
            }
        
            if (PicCometa5.Visible == true)
            {
                if (PicAstro.Bounds.IntersectsWith(PicCometa5.Bounds))
                {
                    PicCometa5.Hide();
                    Decremento.Salir(LbVidas, TimerNivel2, TimerMeteoros, TimerNivel3, Timerlaser, PicAstro, PicMeteoro, PicMeteoro1, PicMeteoro2, PicMeteoro3, PicMeteoro4, PicMeteoro5, PicExplosion, PicLaser,PicCometa1,PicCometa2,PicCometa3,PicCometa4,PicCometa5, PicExplosion, PicOvni1, PicOvni2, PicOvni3, PicOvni4, LaserOvni1, LaserOvni2, LaserOvni3, LaserOvni4);
                    se.getNumVidas(LbVidas);
                }
            }

            //----------------------------------------------\\
            //Condición cuando el Puntaje sea igual a 60 ó 61.
            //----------------------------------------------\\
            if (LbPuntaje.Text == "20" || LbPuntaje.Text == "20")
            {
                musica4.Stop();
                musica1.ElegirMusica("spaceship");
                musica1.Play();

                //--------------------------------\\
                //Los Cometas dejan de ser visibles.
                //--------------------------------\\
                PicCometa1.Visible = false;
                PicCometa2.Visible = false;
                PicCometa3.Visible = false;
                PicCometa4.Visible = false;
                PicCometa5.Visible = false;
                PicExplosion.Visible = false;
                TimerMeteoros.Enabled = false;
                TimerNivel2.Enabled = false;

                //------------------------------------------------------------------------------\\
                //Los ovnis y sus laser se hacen visibles al igual que el Timer al que pertenecen.
                //------------------------------------------------------------------------------\\
                PicOvni1.Visible = true;
                PicOvni2.Visible = true;
                PicOvni3.Visible = true;
                PicOvni4.Visible = true;
                LaserOvni1.Visible = true;
                LaserOvni2.Visible = true;
                LaserOvni3.Visible = true;
                LaserOvni4.Visible = true;
                TimerNivel3.Enabled = true;
            }
        }

        //-------------------------\\
        //Mover nave en coordenada X.
        //-------------------------\\
        public void MoverNaveX(int newXPos)
            {
                if (newXPos < 0)
                    newXPos = 0;
                else if (newXPos > ClientRectangle.Width - PicAstro.Width)
                    newXPos = ClientRectangle.Width - PicAstro.Width;
                PicAstro.Left = newXPos;
            }

            //-------------------------\\
            //Mover nave en coordenada Y.
            //-------------------------\\
            public void MoverNaveY(int newYPos)
            {
                if (newYPos < 300)
                    newYPos = 300;
                else if (newYPos > ClientRectangle.Height - PicAstro.Height)
                    newYPos = ClientRectangle.Height - PicAstro.Height;
                PicAstro.Top = newYPos;
            }

        //---------------------------------------------------------------------------------------\\
        //Función para abrir la pestaña de juego en caso de que el usuario oprima el botón de Menú.
        //---------------------------------------------------------------------------------------\\
        private void pes()
        {
            Application.Run(new Juego());
        }

    }
    }
