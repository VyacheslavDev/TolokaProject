using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Collections;




namespace TolokaProject
{
    public partial class Form1 : Form
    {
        HtmlElementCollection elmCol;
        HtmlElementCollection elmSpan;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (button1.Text == "Старт")
            { button1.Text = "Стоп"; numericUpDown1.Enabled = false; }
            else if(button1.Text == "Стоп")
            {
                button1.Text = "Старт"; numericUpDown1.Enabled = true; 
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Browser.Navigate("https://toloka.yandex.ru/tasks");
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Prossess(sender, e);
        }

        private void Prossess(object sender, EventArgs e)
        {
            timer1.Interval = 6000;
            elmCol = Browser.Document.GetElementsByTagName("div");
            elmSpan = Browser.Document.GetElementsByTagName("span");
            foreach (HtmlElement elmBtnl in elmSpan)
                    {
                        if (elmBtnl.GetAttribute("className") == "tasks__itm__titl__name")
                        {
                           
                        }
                    }
            
            foreach (HtmlElement elmBtn in elmCol)
            {
                if ((elmBtn.GetAttribute("className") == "button button_size_L button_type_action tasks__itm__take tasks__itm__take_l"))
                {
                    elmBtn.InvokeMember("Click");
                    SoundPlayer player = new SoundPlayer(@"C:\Windows\Media\Ring03.wav");
                    player.Play();
                    button1_Click(sender,e);
                }
            }
            timer1.Interval = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
