using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace TesseractDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //创建位图对象
                Bitmap image = new Bitmap(openFile.FileName);
                TesseractOCR(image);
            }
        }

       
        public string TesseractOCR(Bitmap image)
        {
            //Tesseract.Page    chi_sim为中文训练数据包  
            Page page = new TesseractEngine(AppDomain.CurrentDomain.BaseDirectory + @"\tessdata", "chi_sim", EngineMode.Default).Process(PixConverter.ToPix(image));
            //释放程序对图片的占用
            image.Dispose();

            string text = page.GetText();
            textBox1.Text = text;

            //打印识别率
            string shibie = String.Format("{0:P}", page.GetMeanConfidence());
            textBox2.Text = shibie;
            return shibie;
            //Console.WriteLine(String.Format("{0:P}", page.GetMeanConfidence()));

            //打印识别文本 //替换'/n'为'(空)'//替换'(空格)'为'(空)'
            //string s = page.GetText().Replace("\n", "").Replace(" ", "");
            //Console.WriteLine(s);
            //return s;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                textBox1.Clear();
                textBox2.Clear();
           
        }
    }
}
