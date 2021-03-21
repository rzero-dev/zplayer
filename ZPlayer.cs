using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZPlayer_v0._1
{
    public partial class ZPlayer : Form
    {

        int cursor = 0;
        String[] archivosMP3;
        String[] rutaArchivosMP3;

        public ZPlayer()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog abrir = new OpenFileDialog();
                abrir.Multiselect = true;
               
                if (abrir.ShowDialog() == DialogResult.OK)
                {
                    archivosMP3 = abrir.SafeFileNames;
                    rutaArchivosMP3 = abrir.FileNames;
                    foreach (var mp3 in archivosMP3)
                    {
                        lbxLista.Items.Add(mp3);

                    }
                    axWindowsMediaPlayer1.URL = rutaArchivosMP3[0];
                    lbxLista.SelectedIndex = 0;
                }
            }
            catch (Exception error)
            {

                MessageBox.Show($"Se ha producido un error de tipo: {error.Message.ToLower()}");

            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = rutaArchivosMP3[lbxLista.SelectedIndex];

            cursor = lbxLista.SelectedIndex; //Actualiza la posición del cursor.
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            try
            {
                cursor--;

                if (cursor < 0)
                {
                    cursor = rutaArchivosMP3.Length -1;
                    axWindowsMediaPlayer1.URL = rutaArchivosMP3[cursor];
                }
                else
                {
                    axWindowsMediaPlayer1.URL = rutaArchivosMP3[cursor];
                }
            }
            catch (Exception error)
            {

                MessageBox.Show($"Se ha producido un error de tipo: {error.Message.ToLower()}");
            }
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            try
            {
                cursor++;

                if (cursor > rutaArchivosMP3.Length -1)
                {
                    cursor = 0;
                    axWindowsMediaPlayer1.URL = rutaArchivosMP3[cursor];
                    lbxLista.SelectedItem = cursor;
                }
                else
                {
                    axWindowsMediaPlayer1.URL = rutaArchivosMP3[cursor];
                }
            }
            catch (Exception error)
            {

                MessageBox.Show($"Se ha producido un error de tipo: {error.Message.ToLower()}");
            }
        }
    }
}
