using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace threadDelegatte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

   

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread testOne = new Thread(new ThreadStart(testone));
            testOne.Start();

            Thread testTwo = new Thread(new ThreadStart(testtwo));
            testTwo.Start();
        }
        //textbox中显示从1到19的值，
        private void testone()
        {          
                for (int i = 0; i < 20; i++)
                {
                    if (this.textBox1.InvokeRequired)//判断是否调用Invoke方法
                    {
                        this.textBox1.Invoke(new Action<string>
                            (s => { this.textBox1.Text = s; }), i.ToString());
                    }

                Thread.Sleep(1000);
            }
        }

        //将textbox2的值赋给textbox3
        private void testtwo()
        {

            while (true)
            {
                if (this.textBox3.InvokeRequired)//判断是否调用Invoke方法
                {
                    this.textBox3.Invoke(new Action<string>
                        (s => { this.textBox3.Text = s; }), textBox2.Text);
                }

                Thread.Sleep(1000);
            }
        }



    }
}
