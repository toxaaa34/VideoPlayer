using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Video our_video;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (our_video.Playing == false)
            {
                our_video.Play();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Video Files (*.wmv)|*.wmv|All Files(*.*)|*.*";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                our_video = new Video(openFileDialog1.FileName);
                our_video.Open(openFileDialog1.FileName);
                our_video.Play();
                our_video.Owner = splitContainer1.Panel1;
            }

            trackBar1.Minimum = -5000;
            trackBar1.Maximum = 0;
            trackBar1.TickFrequency = 200;
            trackBar1.Value = -1000;
            our_video.Audio.Volume = trackBar1.Value;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (our_video.Playing == true)
            {
                our_video.Pause();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (our_video.Stopped == false)
            {
                our_video.Stop();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            our_video.Audio.Volume = trackBar1.Value;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
