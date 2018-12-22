using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace StartDecoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // openFileDialog1.ShowDialog();


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "";
                textBox1.Text = openFileDialog1.FileName;
                StreamReader fileopend = new StreamReader(openFileDialog1.FileName);
                MessageBox.Show(fileopend.ReadToEnd());
                fileopend.Close();
            }
            else { textBox1.Text = "Файл не обраний"; }
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
   
}
