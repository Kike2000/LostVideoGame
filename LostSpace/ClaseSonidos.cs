using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace LostSpace
{
    class ClaseSonidos
    {
        //--------\\
        //Instancia.
        //--------\\
        WindowsMediaPlayer media_player = new WindowsMediaPlayer();

        //-----------------\\
        //Método Constructor.
        //-----------------\\
        public ClaseSonidos()
        {
            media_player.settings.autoStart = false;
        }

        //--------------------------\\
        //Método de música con switch.
        //--------------------------\\
        public void MusicaPerdedor(string Preferencia)
        {
            switch (Preferencia)
            {
                case "010592688_prev":
                    media_player.URL = "010592688_prev.mp3";
                    break;
                case "SpaceGun":
                    media_player.URL = "Space Gun 04.wav";
                    break;
                case "tutu":
                    media_player.URL = "bites-ta-da-winner.mp3";
                    break;
                case "depeche":
                    media_player.URL = "y2mate.com - depeche_mode_dangerous_instrumental_final_version_ZQoIhnqaN4U.mp3";
                    break;
                default:
                    break;
            }
        }

        //----------------------------\\
        //Método para reproducir musica.
        //----------------------------\\
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
