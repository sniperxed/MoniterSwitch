using System;
using Tesseract;
namespace WinFormsApp1
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
                Bitmap bitmap = new Bitmap(openFile.FileName);
                TesseractOCR(bitmap);
            }
        }

        private static string TesseractOCR(Bitmap image)
        {
            //Tesseract.Page    chi_sim为中文训练数据包  
            var engine = new TesseractEngine(AppDomain.CurrentDomain.BaseDirectory + @"\tessdata", "chi_sim", EngineMode.Default));
            //释放程序对图片的占用
            image.Dispose();

            //打印识别率
            Console.WriteLine(String.Format("{0:P}", engine.GetMeanConfidence()));

            //打印识别文本 //替换'/n'为'(空)'//替换'(空格)'为'(空)'
            string s = engine.GetText().Replace("\n", "").Replace(" ", "");
            Console.WriteLine(s);
            return s;
        }
    }
}