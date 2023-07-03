using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace LostSpace
{
    public partial class Game : Form
    {
        Thread cerrar;
        Thread edu;
        Thread ins;

        ClaseMusica musica = new ClaseMusica();
        Instrucciones hola = new Instrucciones();
        
        public Game()
        {
            InitializeComponent();
            musica.ElegirMusica("Futurista");
            musica.Play();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            musica.Stop();
            this.Close();          //Cierra la ventana en la que esta.
            edu = new Thread(pez);
            edu.TrySetApartmentState(ApartmentState.STA);
            edu.Start();
        }

        private void BtnAbrir_Click_1(object sender, EventArgs e)
        {
            musica.Stop();
            this.Close();          //Cierra la ventana en la que esta.
            cerrar = new Thread(pes);
            cerrar.TrySetApartmentState(ApartmentState.STA);
            cerrar.Start();
        }

        private void pes()
        {
            Application.Run(new Juego());
        }
        private void pez()
        {
            Application.Run(new JuegoEducativo());
        }
        private void pee()
        {
            Application.Run(new Instruc());
        }

        public void BtnInstrucciones_Click(object sender, EventArgs e)
        {
            this.Close();
            musica.Stop();
            ins = new Thread(pee);
            ins.TrySetApartmentState(ApartmentState.STA);
            ins.Start();
            musica.Stop();
            hola.Show();
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }   
}

