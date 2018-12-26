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
           
             
    }

       

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            fileopenName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileopenName = openFileDialog1.FileName;
                
                textBox1.Text = openFileDialog1.FileName;
                StreamReader fileopend = new StreamReader(fileopenName);
                datafromfile = fileopend.ReadToEnd();
                fileopend.Close();
            }
            else { textBox1.Text = "Файл не обраний"; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char [] mydata1 = new char[datafromfile.Length];
            string cleardara="";
            mydata1 = datafromfile.ToCharArray(0, datafromfile.Length);
            
            foreach (var oneChar1 in mydata1)
            {
                if (oneChar1=='1')
                {
                   cleardara += Convert.ToString(oneChar1);
                }

                else
                {
                    cleardara += Convert.ToString(oneChar1);
                }

                
            }

            BitArray datainBitArray =new BitArray(cleardara.Length);
            char[] mydata2 = new char[cleardara.Length];
            mydata2 = cleardara.ToCharArray(0, cleardara.Length);

            for (int i = 0; i < cleardara.Length; i++)
            {
               if (cleardara[i] == '1')
                {
                    datainBitArray[i]=true;
                }

               else
               {

                datainBitArray[i] = false;

               }
               
            }
            darainBytes =new byte[datainBitArray.Length/8];
            darainBytes = BitArrayToByteArray(datainBitArray);
            try
            {
                
                FileStream writefile = new FileStream(foldername+filewriteName, FileMode.OpenOrCreate);

                writefile.Write(darainBytes, 0, darainBytes.Length);

                writefile.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            
        }
        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            foldername = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    filewriteName = "1_.bin";
                    //string waytosave = folderBrowserDialog1.RootFolder = "D:\";
                    foldername = folderBrowserDialog1.SelectedPath+"\\";
                    textBox2.Text = foldername +"\\"+ filewriteName;
                   
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
                
                
                
            }
            
        }
    }
 }
   

