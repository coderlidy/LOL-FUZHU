using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using testdm;
using System.IO;
using System.Diagnostics;

namespace LOL挂机刷金币
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int 发送文本间隔时间 = 100;//s 循环一次大概1.2s
        int 横坐标 = -1;
        int 纵坐标 = -1;
        bool 停止按钮 = false;
        bool 第一次进游戏 = true;
        double i = 0;
        public List<string> 文本 = new List<string>();
        Random 随机数 = new Random();
        CDmSoft dm = new CDmSoft();
        Rectangle 英雄联盟窗口 = new Rectangle(0, 0, 1280, 720);//ldy Screen.PrimaryScreen.Bounds.Width获得屏幕宽度
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "停止状态";
        }
        public void 循环找图主进程()
        {
            i = 0;
            while (true)
            {
                Stopwatch 运行时间 = new Stopwatch();
                运行时间.Start();
                foreach(String 图片 in 截图.需要点击的)
                {
                    查找图片点击(图片+ ".bmp");
                }

                if (!查找图片点击(截图.人机对战))
                {
                    查找图片点击(截图.模式确认);
                }
                

                //查找图片点击(截图.锁定英雄);
                if (查找图片(截图.回城技能, out 横坐标, out 纵坐标))//游戏中----回城技能截图改成了左上角图标
                {
                    My.Computer.MouseMoveToPixel(横坐标 + 1170 + 随机数.Next(0, 5) - 随机数.Next(0, 5), 纵坐标 +650 + 随机数.Next(0, 5) - 随机数.Next(0, 5));
                    dm.KeyDown(65);//"a"键
                    Delay(20 + 随机数.Next(0, 20));
                    My.Computer.MouseLeftClick();
                    Delay(30 + 随机数.Next(0, 20));
                    dm.KeyUp(65);
                    Delay(500 + 随机数.Next(0, 20));
                    dm.KeyPressChar("space");

                    My.Computer.MouseMoveToPixel(600 + 随机数.Next(0, 50) - 随机数.Next(0, 50), 300 + 随机数.Next(0, 50) - 随机数.Next(0, 50));
                    Delay(100 + 随机数.Next(100, 200));

                    //if (查找图片(截图.聊天框, out 横坐标, out 纵坐标))
                    //{
                    //    dm.KeyPress(13);
                    //}
                }
                else if (My.Computer.FindWindow("League of Legends (TM) Client").Width != 0)
                {
                    //横坐标 = 1191;
                    //纵坐标 = 629;
                    this.Text = "第二种查找方式(固定的XY坐标而不是按查找图片来寻找)";
                    My.Computer.MouseMoveToPixel(1191 + 随机数.Next(0, 5) - 随机数.Next(0, 5), 629 + 随机数.Next(0, 5) - 随机数.Next(0, 5));
                    dm.KeyDown(65);//"a"键
                    Delay(20 + 随机数.Next(0, 20));
                    My.Computer.MouseLeftClick();
                    Delay(30 + 随机数.Next(0, 20));
                    dm.KeyUp(65);
                    Delay(500 + 随机数.Next(0, 20));
                    My.Computer.MouseMoveToPixel(1191 + 随机数.Next(0, 5) - 随机数.Next(0, 5), 629 + 随机数.Next(0, 5) - 随机数.Next(0, 5));
                    dm.KeyDown(65);//"a"键
                    Delay(20 + 随机数.Next(0, 20));
                    My.Computer.MouseLeftClick();
                    Delay(30 + 随机数.Next(0, 20));
                    dm.KeyUp(65);
                    Delay(500 + 随机数.Next(0, 20));
                    My.Computer.MouseMoveToPixel(600 + 随机数.Next(0, 50) - 随机数.Next(0, 50), 300 + 随机数.Next(0, 50) - 随机数.Next(0, 50));
                    Delay(100 + 随机数.Next(100, 200));
                    My.Computer.MouseMoveToPixel(600 + 随机数.Next(0, 50) - 随机数.Next(0, 50), 300 + 随机数.Next(0, 50) - 随机数.Next(0, 50));
                    Delay(100 + 随机数.Next(100, 200));

                    dm.KeyPress(13);
                    Delay(200 + 随机数.Next(0, 50));
                    Delay(300 + 随机数.Next(0, 50));
                    dm.KeyPress(13);
                }



                if (查找图片(截图.再玩一次, out 横坐标, out 纵坐标))
                {
                    第一次进游戏 = true;
                    if (checkBox1.Checked)
                    {
                        this.Text = "停止状态";
                        运行时间.Stop();
                        break;
                    }
                    else
                    {
                        Delay(50);
                        鼠标移动左键单击(横坐标, 纵坐标);
                    }
                }
                if (查找图片(截图.锁定视角, out 横坐标, out 纵坐标))
                {
                    Delay(50);
                    dm.KeyPress(89);//Y键
                }
                if (dm.FindWindow("RiotWindowClass", "") != 0)
                {
                    dm.GetClientRect(dm.FindWindow("RiotWindowClass", ""), out object x1, out object y1, out object x2, out object y2);
                    if ((int)x1 != 0 || (int)y1 != 0)
                    {
                        dm.MoveWindow(dm.FindWindow("RiotWindowClass", ""), 0, 0);
                    }
                }
                if (i > (发送文本间隔时间 * 1000) && 查找图片(截图.回城技能, out 横坐标, out 纵坐标))
                {
                    //if (第一次进游戏 == true)
                    //{
                    //    第一次进游戏 = false;
                    //}
                    //else
                    //{
                    //    发送文本();
                    //}
                    发送文本();
                    i = 0;
                }
                //if (My.Computer.KeyBeingPressed(Keys.D) || 停止按钮)
                if (停止按钮)
                {
                    this.Text = "停止状态";
                    运行时间.Stop();
                    break;
                }
                运行时间.Stop();
                TimeSpan 时间间隔 = 运行时间.Elapsed;
                this.Text = (时间间隔.TotalMilliseconds/1000.00).ToString()+"s";
                i += 时间间隔.TotalMilliseconds;
            }
        }
        public bool 保存截图图片()
        {
            try
            {
                Bitmap 截图图片 = My.Computer.SaveScreen();
                截图图片.Save(".\\截图图片\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + 随机数.Next(0, 100).ToString("00") + ".bmp", ImageFormat.Bmp);
                截图图片.Dispose();//释放资源
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public void 鼠标移动左键单击(int X, int Y)
        {
            My.Computer.MouseMoveToPixel(X + 随机数.Next(0, 5) - 随机数.Next(0, 5), Y + 随机数.Next(0, 5) - 随机数.Next(0, 5));
            My.Computer.MouseLeftClick();
            Delay(100 + 随机数.Next(100, 200));
            My.Computer.MouseMoveToPixel(X + 随机数.Next(0, 5) - 随机数.Next(0, 5), Y + 随机数.Next(0, 5) - 随机数.Next(0, 5));
            My.Computer.MouseLeftClick();
            Delay(1000 + 随机数.Next(100, 500));
            My.Computer.MouseMoveToPixel(600 + 随机数.Next(0, 50) - 随机数.Next(0, 50), 300 + 随机数.Next(0, 50) - 随机数.Next(0, 50));
            Delay(100 + 随机数.Next(100, 200));
            My.Computer.MouseMoveToPixel(600 + 随机数.Next(0, 50) - 随机数.Next(0, 50), 300 + 随机数.Next(0, 50) - 随机数.Next(0, 50));

        }


        public bool 查找图片点击(string 图片名称)//out 多个返回值的用法
        {
            dm.FindPic(0, 0, 2000, 1000, ".\\用于查找图片\\" + 图片名称, "000000", 0.8, 0, out object intX, out object intY);
            int X = (int)intX;
            int Y = (int)intY;
            if (X >= 0 && Y >= 0)
            {
                this.Text = 图片名称;
                Delay(50+ 随机数.Next(0, 50));
                鼠标移动左键单击(X, Y);
                Delay(1500 + 随机数.Next(100, 500));
                return true;
            }
            else
            {
                Delay(50 + 随机数.Next(0, 50));
                return false;
            }
        }
        public bool 查找图片(string 图片名称, out int X, out int Y)//out 多个返回值的用法
        {
            dm.FindPic(0, 0, 2000, 1000, ".\\用于查找图片\\" + 图片名称, "000000", 0.8, 0, out object intX, out object intY);
            X = (int)intX;
            Y = (int)intY;
            if (X >= 0 && Y >= 0)
            {
                this.Text = 图片名称;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void 发送文本()
        {
            
            string 发送文本 = 文本[随机数.Next(0, 文本.Count-1)];
            this.Text = "发:" + 发送文本;
            dm.KeyPress(13);
            Delay(200 + 随机数.Next(0, 50));
            //dm.SendString2(hwnd, "范德萨发浮点数阿范德萨发发的撒都是");
            //dm.SendString(hwnd, "范德萨发浮点数阿范德萨发发的撒都是");
            纯字母用按键发送文本(发送文本);
            Delay(300 + 随机数.Next(0, 50));
            dm.KeyPress(13);
            
        }
        public void 纯字母用按键发送文本(String 文本)
        {
            char[] wbs=文本.ToCharArray();
            foreach(char wb in wbs)
            {
                if(" " == wb.ToString())
                {
                    dm.KeyPressChar("space");
                    continue;
                }
                dm.KeyPressChar(wb.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(查找图片(截图.回城技能, out 横坐标, out 纵坐标));
            第一次进游戏 = true;
            停止按钮 = false;
            打开文本txt();
            Delay(3000);
            this.Text = "请显示游戏窗口";
            循环找图主进程();
        }
        public void 打开文本txt()
        {
            try
            {
                文本.Clear();
                StreamReader File = new StreamReader(".\\文本.txt", Encoding.Default);//连续读取文件类
                string Line = string.Empty;
                while ((Line = File.ReadLine()) != null)//读取每一行(每次读取都会使file减少一行)
                {
                    文本.Add(Line);//把每一行添加到list list类
                }
                File.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            停止按钮 = true;
        }
        public static void Delay(int mm)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
