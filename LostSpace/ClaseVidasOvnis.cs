using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LostSpace
{
    class ClaseVidasOvnis
    {
        int vida1 = 1;
        int vida2 = 1;
        int vida3 = 1;
        int vida4 = 1;

        public ClaseVidasOvnis()
        {

        }
        public void Vidaovni(Label LbVidaOvni1, Label LbVidaOvni2, Label LbVidaOvni3, Label LbVidaOvni4, System.Windows.Forms.Timer Timerlaser, PictureBox PicOvni1, PictureBox PicOvni2, PictureBox PicOvni3, PictureBox PicOvni4, PictureBox PicLaser)
        {
            if (PicOvni1.Visible == true)
            {
                if (PicLaser.Bounds.IntersectsWith(PicOvni1.Bounds) && PicOvni1.Visible)
                {
                    vida1 = vida1 - 1;
                    LbVidaOvni1.Text = vida1.ToString();
                    if (vida1 <= 0)
                    {
                        PicOvni1.Visible = false;
                    }
                }
            }

            if (PicOvni2.Visible == true)
            {
                if (PicLaser.Bounds.IntersectsWith(PicOvni2.Bounds) && PicOvni2.Visible)
                {
                    vida2 = vida2 - 1;
                    LbVidaOvni2.Text = vida2.ToString();
                    if (vida2 <= 0)
                    {
                        PicOvni2.Visible = false;
                    }
                }
            }

            if (PicOvni3.Visible == true)
            {
                if (PicLaser.Bounds.IntersectsWith(PicOvni3.Bounds) && PicOvni3.Visible)
                {
                    vida3 = vida3 - 1;
                    LbVidaOvni3.Text = vida3.ToString();
                    if (vida3 <= 0)
                    {
                        PicOvni3.Visible = false;
                    }
                }
            }

            if (PicOvni4.Visible == true)
            {
                if (PicLaser.Bounds.IntersectsWith(PicOvni4.Bounds) && PicOvni4.Visible)
                {
                    vida4 = vida4 - 1;
                    LbVidaOvni4.Text = vida1.ToString();
                    if (vida4 <= 0)
                    {
                        PicOvni4.Visible = false;
                    }
                }
            }
        }
    }
}
