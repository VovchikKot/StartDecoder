using System;
using System.Collections;
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
        string fileopenName, foldername, datafromfile, filewriteName;
        private byte[] darainBytes;
        
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3_filename.Enabled = false;
           // button2.Enabled = false;
            button3.Enabled = false;

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            datafromfile = "";
            textBox1.Enabled = true;
            textBox1.Text = "";
            
            textBox3_filename.Text = "";
            fileopenName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileopenName = openFileDialog1.FileName;
                textBox1.Text = openFileDialog1.FileName;
                StreamReader fileopend = new StreamReader(fileopenName);
                datafromfile = fileopend.ReadToEnd();
                fileopend.Close();
                textBox3_filename.Enabled = true;
            }
            else { textBox1.Text = "Choose File to Open"; }
        }

        private void textBox3_filename_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            filewriteName = textBox3_filename.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "" && folderBrowserDialog1.SelectedPath!="")

            {
                char[] mydata1 = new char[datafromfile.Length];
                string cleardara = "";
                mydata1 = datafromfile.ToCharArray(0, datafromfile.Length);

                foreach (var oneChar1 in mydata1)
                {
                    if (oneChar1 == '1')
                    {
                        cleardara += Convert.ToString(oneChar1);
                    }

                    if (oneChar1 == '0')
                    {
                        cleardara += Convert.ToString(oneChar1);
                    }


                }

                BitArray datainBitArray = new BitArray(cleardara.Length);
                char[] mydata2 = new char[cleardara.Length];
                mydata2 = cleardara.ToCharArray(0, cleardara.Length);

                for (int i = 0; i < cleardara.Length; i++)
                {
                    if (mydata2[i] == '1')
                    {
                        datainBitArray[i] = true;
                    }

                    if (mydata2[i] == '0')
                    {

                        datainBitArray[i] = false;

                    }

                }

                darainBytes = new byte[datainBitArray.Length / 8];
                darainBytes = BitArrayToByteArray(datainBitArray);
                try
                {
                    filewriteName = textBox3_filename.Text+".bin";
                    FileStream writefile = new FileStream(foldername + filewriteName, FileMode.OpenOrCreate);

                    writefile.Write(darainBytes, 0, darainBytes.Length);

                    writefile.Close();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }

            else
            {
                MessageBox.Show("Chose Folder to Open/Seve");
            }
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
           
            textBox2.Text = "";
            foldername = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    
                    //string waytosave = folderBrowserDialog1.RootFolder = "D:\";
                    foldername = folderBrowserDialog1.SelectedPath+"\\";
                    textBox2.Text = foldername;
                    textBox3_filename.Text = filewriteName;
                    button2.Enabled = true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
                
                
                
            }
            else
            {
                textBox2.Text = "Choose Plase to Save";
            }
            
            
        }

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }



    }
 }
   

