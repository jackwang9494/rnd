using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Rnd
{
    public partial class Form1 : Form
    {
        static Dictionary<int, string> planDic = new Dictionary<int, string>();
        int num_click;
        string filepath;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;

            int rndmax = this.textBox1.Lines.Count() - 1;
            Console.WriteLine(rndmax);
            Random rnd = new Random();
            int num_select = rnd.Next(0, rndmax);

            label2.Text = textBox1.Lines[num_select];
            Console.WriteLine(num_select);

            DownLabel.Text = "总计：" + rndmax + " " + "选择第" + (num_select + 1) + "项";

            num_click++;
            label3.Text = "第:" + num_click + "次";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            label2.Text = "";

            num_click = 0;
        }

        //讲代办事件写入本地txt文件
        private void Writeplan(string Filepath)
        {
            string filepaht = Filepath;
            StreamWriter sw = new StreamWriter(filepath);
            for (int i = 0; i < this.textBox1.Lines.Count() - 1; i++)
            {
                sw.WriteLine(textBox1.Lines[i]);
            }
            //sw.Write(textBox1.Lines[textBox1.Lines.Count() - 1]);
            sw.Close();
        }

        //初始化时,txt文件写入textbox
        private void SetTextbot(string FilePath)
        {
            textBox1.Clear();
            StreamReader reader = new StreamReader(FilePath, false);
            while (!reader.EndOfStream)
            {
                string plan = reader.ReadLine();
                //this.textBox1.Text += plan + "\r\n";
                //this.textBox1.AppendText(plan);
                //this.textBox1.AppendText("\r\n");     
                this.textBox1.AppendText(plan + Environment.NewLine);
                
            }
            reader.Close();

            //减去textbox最后多的空行            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //设置
            filepath = Application.StartupPath;

            Directory.SetCurrentDirectory(Directory.GetParent(filepath).FullName);
            filepath = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(Directory.GetParent(filepath).FullName);
            filepath = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(Directory.GetParent(filepath).FullName);
            filepath = Directory.GetCurrentDirectory() + @"\plan.txt";
            // Console.WriteLine(path);

            
             SetTextbot(filepath);
             DownLabel.Text = "总计：" + (textBox1.Lines.Count() - 1) + " ";

             num_click = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Writeplan(filepath);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int k = textBox1.Text.Length;
            textBox1.Width = k * 4;
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            int[] testdata = { -2, 2, 1, -5, 3, 0, 4, -2, 2, 1};
            IList<int> testList = new List<int>();
            

            foreach (int i in testList)
            {
                textBox2.AppendText(i.ToString());
                textBox2.AppendText("\r\n");
            }
            //textBox2.AppendText(testdata[0].ToString());

        }
    }
}
