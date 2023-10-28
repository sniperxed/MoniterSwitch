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
            //Tesseract.Page    chi_simΪ����ѵ�����ݰ�  
            var engine = new TesseractEngine(AppDomain.CurrentDomain.BaseDirectory + @"\tessdata", "chi_sim", EngineMode.Default));
            //�ͷų����ͼƬ��ռ��
            image.Dispose();

            //��ӡʶ����
            Console.WriteLine(String.Format("{0:P}", engine.GetMeanConfidence()));

            //��ӡʶ���ı� //�滻'/n'Ϊ'(��)'//�滻'(�ո�)'Ϊ'(��)'
            string s = engine.GetText().Replace("\n", "").Replace(" ", "");
            Console.WriteLine(s);
            return s;
        }
    }
}