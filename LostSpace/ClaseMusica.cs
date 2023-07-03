using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace LostSpace
{
    public class ClaseMusica
    {
        //--------\\
        //Instancia.
        //--------\\
        WindowsMediaPlayer media_player = new WindowsMediaPlayer();

        //----------\\
        //Constructor.
        //----------\\
        public ClaseMusica()
        {
            media_player.settings.autoStart = false;
            media_player.settings.setMode("loop", true);
        }

        //-----\\
        //Método.
        //-----\\
        public void ElegirMusica(string eleccion)
        {
            switch (eleccion)
            {
                case "maintheme":
                    media_player.URL = "retro.wav";
                    break;
                case "spaceship":
                    media_player.URL = "spaceship.wav";
                    break;
                case "outthere":
                    media_player.URL = "outthere.wav";
                    break;
                case "Futurista":
                    media_player.URL = "Futuristic_ambient_1.mp3";
                    break;
                case "je":
                    media_player.URL = "DST-ReturnOfTowerDefenseTheme.mp3";
                    break;
                case "depeche":
                    media_player.URL = "y2mate.com - depeche_mode_dangerous_instrumental_final_version_ZQoIhnqaN4U.mp3";
                    break;
                default:
                    break;
            }
        }

        //-------------------------------\\
        //Método para reproducir la música.
        //-------------------------------\\
        public void Play()
        {
            media_player.controls.play();
        }

        //-----------------------\\
        //Método para parar música.
        //-----------------------\\
        public void Stop()
        {
            media_player.controls.stop();
        }
    }
}
