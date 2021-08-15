using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Nagito
{
    public partial class Form1 : Form
    {
        SoundPlayer Sound;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Nagito main code

        // Add music
        private void Add_Click(object sender, EventArgs e)
        {
            // Open File
            string pathFile = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "WAV|*.wav";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog.FileName;
            }

            SoundList.Items.Add(pathFile.ToString());
        }

        // Add folder
        private void AddFolder_Click(object sender, EventArgs e)
        {
            // Open File
            string filepath = string.Empty;
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();

            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = openFolderDialog.SelectedPath;
            }

            foreach (string file in Directory.GetFiles(filepath, "*.wav", SearchOption.AllDirectories))
            {
                SoundList.Items.Add(file);
            }
        }


            // Play music
            private void Play_Click(object sender, EventArgs e)
        {
            try
            {
                object SelectedSound = SoundList.SelectedItem;

                Sound = new SoundPlayer(@SelectedSound.ToString());

                if (LoopCheckbox.Checked == true)
                {
                    Sound.PlayLooping();
                }

                else
                {
                    Sound.Play();
                }
            }

            catch
            {
                MessageBox.Show("No file selected");
            }
        }


        // Stop Music
        private void Stop_Click(object sender, EventArgs e)
        {
            Sound.Stop();
        }

        // Remove Music
        private void Remove_Click(object sender, EventArgs e)
        {
            int SelectedSound = SoundList.SelectedIndex;

            if(SelectedSound != -1)
            {
                SoundList.Items.RemoveAt(SelectedSound);
            }
        }


        // Clear list
        private void ClearList_Click(object sender, EventArgs e)
        {
            SoundList.Items.Clear();
        }



        // Close Button
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        // Move Window
        int m, mx, my;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }
    }
}
