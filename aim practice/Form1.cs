using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aim_practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int click;
        private int total;

        private int s;
        private int f;
        //form size
        private int w;
        private int h;

        private int count;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("10%");
            comboBox1.Items.Add("30%");
            comboBox1.Items.Add("50%");
            comboBox1.Items.Add("75%");
            comboBox1.Items.Add("100%");
            comboBox1.SelectedIndex = 3;

            comboBox2.Items.Add("1");
            comboBox2.Items.Add("5");
            comboBox2.Items.Add("10");
            comboBox2.Items.Add("20");
            comboBox2.Items.Add("30");
            comboBox2.Items.Add("50");
            comboBox2.Items.Add("70");
            comboBox2.Items.Add("100");

            comboBox2.SelectedIndex = 3;
            //初期設定
            w = 675;
            h = 340;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            s = comboBox1.SelectedIndex;
            switch (s)
            {
                case 0:
                    this.button1.Size = new Size(25, 23);
                    break;
                case 1:
                    this.button1.Size = new Size(50, 45);
                    break;
                case 2:
                    this.button1.Size = new Size(125, 90);
                    break;
                case 3:
                    this.button1.Size = new Size(200, 180);
                    break;
                case 4:
                    this.button1.Size = new Size(300, 250);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f = comboBox2.SelectedIndex;
            switch (f)
            {
                case 0:
                    click = 1;
                    break;
                case 1:
                    click = 5;
                    break;
                case 2:
                    click = 10;
                    break;
                case 3:
                    click = 20;
                    break;
                case 4:
                    click = 30;
                    break;
                case 5:
                    click = 50;
                    break;
                case 6:
                    click = 70;
                    break;
                case 7:
                    click = 100;
                    break;
            }
            button1.Text = click.ToString();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //System.Drawing.Size tSize = this.ClientSize;
            switch (s)
            {
                case 0:
                    //this.button1.Size = new Size(25, 23);
                    w = ClientSize.Width - 53;
                    h = ClientSize.Height - 74;
                    break;
                case 1:
                    //this.button1.Size = new Size(50, 45);
                    w = ClientSize.Width - 78;
                    h = ClientSize.Height - 96;
                    break;
                case 2:
                    //this.button1.Size = new Size(125, 90);
                    w = ClientSize.Width - 153;
                    h = ClientSize.Height - 141;
                    break;
                case 3:
                    //this.button1.Size = new Size(200, 180);
                    w = ClientSize.Width - 228;
                    h = ClientSize.Height - 231;
                    break;
                case 4:
                    //this.button1.Size = new Size(300, 250);
                    w = ClientSize.Width - 328;
                    h = ClientSize.Height - 301;
                    break;
            }
            button2.Location = new Point(ClientSize.Width - 54, 1);

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            total++;
            toolStripStatusLabel5.Text = total.ToString();
            if (count != 0 && total != 0)
            {
                double percent = Math.Floor(((double)count / total) * 100);
                toolStripStatusLabel9.Text = percent.ToString() + "%";
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            total++;
            count++;
            toolStripStatusLabel5.Text = total.ToString();
            toolStripStatusLabel7.Text = count.ToString();

            click--;
            button1.Text = click.ToString();
            if (click == 0)
            {
                System.Random r = new System.Random();
                int left = r.Next(12, w);
                int top = r.Next(25, h);

                this.button1.Location = new Point(left, top);
                int f = comboBox2.SelectedIndex;
                switch (f)
                {
                    case 0:
                        click = 1;
                        break;
                    case 1:
                        click = 5;
                        break;
                    case 2:
                        click = 10;
                        break;
                    case 3:
                        click = 20;
                        break;
                    case 4:
                        click = 30;
                        break;
                    case 5:
                        click = 50;
                        break;
                    case 6:
                        click = 70;
                        break;
                    case 7:
                        click = 100;
                        break;
                }
                button1.Text = click.ToString();
            }
            if (count != 0 && total != 0)
            {
                double percent = Math.Floor(((double)count / total) * 100);
                toolStripStatusLabel9.Text = percent.ToString() + "%";
            }
            toolStripStatusLabel11.Text = click.ToString();
        }

        private void toolStripStatusLabel11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
        "記録をリセットしますか？",
        "Aim practice",
        MessageBoxButtons.YesNo,  // ボタンの一覧は MessageBoxButtons 参照
        MessageBoxIcon.Question   // アイコンの一覧は  MessageBoxIcon 参照
    )
    == DialogResult.Yes)
            {
                total = 0;
                count = 0;
                toolStripStatusLabel5.Text = total.ToString();
                toolStripStatusLabel7.Text = count.ToString();
                toolStripStatusLabel9.Text = "0%";
            }
        }
    }
}
