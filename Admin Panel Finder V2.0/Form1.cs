using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;

namespace Admin_Panel_Finder_V2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread islem;

        void Tarama()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = listBox1.Items.Count;

            int kactane = listBox1.Items.Count;
            for (int i = 0; i < kactane; i++)
            {
               

                try
                {
                    HttpWebRequest istek = (HttpWebRequest)HttpWebRequest.Create(textBox1.Text + listBox1.Items[i].ToString());
                    HttpWebResponse cevap = (HttpWebResponse)istek.GetResponse();
                    string durum = cevap.StatusCode.ToString();

                    if (durum == "OK")
                    {
                        listBox2.Items.Add(listBox1.Items[i].ToString() + " ||    SUCCESSFUL ");
                        listBox3.Items.Add(textBox1.Text+listBox1.Items[i].ToString());
                        int adet = listBox3.Items.Count;
                        label4.Text = Convert.ToString(adet);
                    }
                    else
                    {

                    }
                }
                catch
                {

                    listBox2.Items.Add(listBox1.Items[i].ToString() + " ||   UNSUCCESSFUL ");
                }
                progressBar1.Value=i;
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            islem = new Thread(new ThreadStart(Tarama));
            islem.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            islem.Abort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This program is written by TurKLoJeN", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StreamReader oku = new StreamReader(Application.StartupPath + "/Wordlist.txt");
            string metin = oku.ReadLine();
            while (metin != null)
            {
                listBox1.Items.Add(metin);
                metin = oku.ReadLine();
            }
            CheckForIllegalCrossThreadCalls = false;

            int adet = listBox1.Items.Count;

            label3.Text = Convert.ToString(adet);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
