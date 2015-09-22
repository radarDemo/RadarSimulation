using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;
using System.Collections;
using System.IO;

//　　System.Text;
namespace radarsystem
{
    public partial class Form1 : Form
    {
      

        List<PointD> list = new List<PointD>();
        List<Point> list_trace = new List<Point>();
        Point screenpoint_pic4;
        private bool isDragging = false; //拖中
        private int currentX = 0, currentY = 0; //原来鼠标X,Y坐标
        bool flag_thread2 = false;
        bool flag_thread1 = false;
        Thread t2;
        Thread t1;
     //用pictureBox4 的左上角坐标表示雷达的中心点坐标
   
      
        public Form1()
        {
            InitializeComponent();
            textBox_doppler.Visible = false;
            button_goback.Visible = false;
            pictureBox4.Visible = false;
            button_update_config.Visible = false;
            label_sel_radartype.Visible = false;
            buttonDectecModeling.Visible = false;
            buttonModelDone.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //连接数据库
            string ConStr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;
                            Data source="+Application.StartupPath+"\\database\\whut\\RecognitionAid.mdb");
            //MessageBox.Show(ConStr);
            OleDbConnection oleCon = new OleDbConnection(ConStr);
            OleDbDataAdapter oleDap = new OleDbDataAdapter("select * from TargetTrailPoints", oleCon);
            DataSet ds = new DataSet();
            oleDap.Fill(ds, "目标轨迹");
           
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)          //循环取出ds.table中的值
            {

                PointD s = new PointD();                  // 实例化Point对象
                s.X= Convert.ToDouble(ds.Tables[0].Rows[i]["X"]);
                s.Y = Convert.ToDouble(ds.Tables[0].Rows[i]["Y"]);            

                list.Add(s);    // 将取出的对象保存在LIST中  以上是获得值。


            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)          //循环取出ds.table中的值
            {

                Point s = new Point();                  // 实例化Point对象
                s.X = Convert.ToInt32(ds.Tables[0].Rows[i]["X"]);
                s.Y = Convert.ToInt32(ds.Tables[0].Rows[i]["Y"]);

                list_trace.Add(s);    // 将取出的对象保存在LIST中  以上是获得值。


            }
            foreach (Point p in list_trace)
            {
                Console.WriteLine(p.X);
             
                Console.WriteLine(p.Y);
            }
            screenpoint_pic4 =PointToScreen(pictureBox4.Location);
            Console.WriteLine(screenpoint_pic4.X);
            Console.WriteLine(screenpoint_pic4.Y);
          //  list.ForEach()
            //     ds.
            // this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            oleCon.Close();
            oleCon.Dispose();

        }
        private void drawtrace()
        {
            //Thread t1 = new Thread(new ThreadStart(TestMethod));
            //t1.IsBackground = true;
            //if(!t1.IsAlive)
            //    t1.Start();
            if (!flag_thread1)
            {
                //  t2.Abort();
                //   t2 = new Thread(new ThreadStart(thread2));
                //  t2 = new Thread(new ThreadStart(thread2));
                //  t2.IsBackground = true;
                t1 = new Thread(new ThreadStart(TestMethod));
                t1.IsBackground = true;
                t1.Start();
                flag_thread1 = true;
            }
            else
            {

                t1.Abort();
                t1 = new Thread(new ThreadStart(TestMethod));
                t1.IsBackground = true;
                t1.Start();
            }
            //   t2.Start();

           
        }
        public void TestMethod()
        {
            Graphics g;
            
            g =pictureBox3.CreateGraphics();
    //        g.s
            Pen p = new Pen(Color.Red, 2);
            //Point[] p1 = new Point[100];
            //Random ran = new Random();
            //p1[0].X = 70;
            //p1[0].Y = 70;
            //for (int i = 1; i < 100; i++)
            //{
            //    p1[i].X = ran.Next(p1[i - 1].X - 50, p1[i - 1].X + 50);
            //    p1[i].Y = ran.Next(p1[i - 1].Y - 50, p1[i - 1].Y + 50);
            //}
            //Point one, two;
            //for (int i = 0; i < 99; i++)
            //{
            //    one = p1[i];
            //    two = p1[i + 1];
            //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //    g.DrawLine(p, one, two);
            //    System.Threading.Thread.Sleep(500);
            //}
            //foreach (PointD p1 in AL)
            //{
            //    Console.WriteLine(p1.X);

            //    Console.WriteLine(p1.Y);
            //}
            Point one, two;
            for (int i = 0; i < list_trace.Count-1; i++)
            {
                one = list_trace[i];
                two = list_trace[i + 1];
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawLine(p, one, two);
                System.Threading.Thread.Sleep(200);
            }
            //for(int pos=0;pos<list.Count;pos++)
            //{
            //}
            g.Dispose();
        }
        private void draw_monitor_trace()
        {
           // Graphics g;
           // Pen p = new Pen(Color.Red, 2);
           // g = panel1.CreateGraphics();
           // Point point;
           // Point point_diff;
           // Point cir_Point = new Point(0, 0);
           // Point one = new Point(0, 0);
           // Point two = new Point(0, 0);
           // cir_Point.X = panel1.Width / 10 * 5;
           // cir_Point.Y = panel1.Height / 10 * 5;
           // //  point_diff.X = 300;
           // //  point_diff.Y = 300;
           // //point.X=pictureBox4.Top;
           // //MessageBox.Show("3");
        
           // for (int i = 0; i < list_trace.Count - 1; i++)
           // {
           //     point = list_trace[i];
           //     point_diff = point;
           //     point_diff.X = point.X - pictureBox4.Left;
           //     point_diff.Y = point.Y - pictureBox4.Top;
           //     SolidBrush myBrush = new SolidBrush(System.Drawing.Color.Red);//画刷
           //     g.FillEllipse(myBrush, new Rectangle(cir_Point.X + point_diff.X - 3, cir_Point.Y + point_diff.Y - 3, 3, 3));//画实心椭圆
           //     //    g.DrawLine(new Pen(Color.Red), point_diff.X, point_diff.Y, point_diff.X, point_diff.Y);
           //     //    g.DrawLine(new Pen(Color.Red), 200, 200,210, 210);
           //     one.X = cir_Point.X + point_diff.X;
           //     one.Y = cir_Point.Y + point_diff.Y;
           //     two.X = list_trace[i + 1].X - pictureBox4.Left + cir_Point.X;
           //     two.Y = list_trace[i + 1].Y - pictureBox4.Top + cir_Point.Y;
           //     g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
           //     g.DrawLine(p, one, two);
           ////     System.Threading.Thread.Sleep(500);
           // }
           
            if (!flag_thread2) 
            {
               //  t2.Abort();
              //   t2 = new Thread(new ThreadStart(thread2));
              //  t2 = new Thread(new ThreadStart(thread2));
              //  t2.IsBackground = true;
                t2 = new Thread(new ThreadStart(thread2));
                t2.IsBackground = true;
                t2.Start();
                flag_thread2 = true;
            }
            else
            {
                
                t2.Abort();
                t2 = new Thread(new ThreadStart(thread2));
                t2.IsBackground = true;
                t2.Start();
            }
             //   t2.Start();


        }
        private void thread2()
        {
            Graphics g;
            Pen p = new Pen(Color.Red, 2);
            g = panel1.CreateGraphics();
            Point point;
            Point point_diff;
            Point cir_Point = new Point(0, 0);
            Point one = new Point(0, 0);
            Point two = new Point(0, 0);
            cir_Point.X = panel1.Width / 10 * 5;
            cir_Point.Y = panel1.Height / 10 * 5;
            //  point_diff.X = 300;
            //  point_diff.Y = 300;
            //point.X=pictureBox4.Top;
            //MessageBox.Show("3");
            for (int i = 0; i < 20; i++)
            {
                //g.DrawString();
            }
            for (int i = 0; i < list_trace.Count - 1; i++)
            {
                point = list_trace[i];
                point_diff = point;
                point_diff.X = point.X - pictureBox4.Left;
                point_diff.Y = point.Y - pictureBox4.Top;
                SolidBrush myBrush = new SolidBrush(System.Drawing.Color.Red);//画刷
                g.FillEllipse(myBrush, new Rectangle(cir_Point.X + point_diff.X - 3, cir_Point.Y + point_diff.Y - 3, 3, 3));//画实心椭圆
                //    g.DrawLine(new Pen(Color.Red), point_diff.X, point_diff.Y, point_diff.X, point_diff.Y);
                //    g.DrawLine(new Pen(Color.Red), 200, 200,210, 210);
                one.X = cir_Point.X + point_diff.X;
                one.Y = cir_Point.Y + point_diff.Y;
                two.X = list_trace[i + 1].X - pictureBox4.Left + cir_Point.X;
                two.Y = list_trace[i + 1].Y - pictureBox4.Top + cir_Point.Y;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawLine(p, one, two);
                System.Threading.Thread.Sleep(400);
            }
        }
        //private void checkedListBox_radartype_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (checkedListBox_radartype.GetItemChecked(0))
        //    {
        //        label_sel_radartype.Text = "多普勒雷达";
        //        checkedListBox_radartype.Hide();
        //        textBox_doppler.Visible=true;
        //        textBox_doppler.Text="检测范围\r\n\r\n距离精度\r\n\r\n目标速度\r\n\r\n速度精度";
        //        button_goback.Visible = true;
        //        //pictureBox4.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\..\\..\\..\\radarsystem\\Resources\\多普勒雷达.jpg");
        //        pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.duopule;
        //        pictureBox4.Visible = true;
        //        drawtrace();
        //    //    draw_monitor_trace();
        //   //     PaintEventArgs pe = new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle);
        //    //    pictureBox3_Paint(sender,pe);
             
        //    }
        //    if (checkedListBox_radartype.GetItemChecked(1))
        //    {
        //        label_sel_radartype.Text = "多基地雷达";
        //        checkedListBox_radartype.Hide();
        //        textBox_doppler.Visible = true;
        //        textBox_doppler.Text = "检测范围\r\n\r\n距离精度\r\n\r\n目标速度\r\n\r\n速度精度";
        //        button_goback.Visible = true;
        //    }
        //}

        private void button_goback_Click(object sender, EventArgs e)
        {
           // label_sel_radartype.Text = "雷达类型选择";
            //checkedListBox_radartype.Show();
            textBox_doppler.Visible = false;
            button_goback.Visible = false;
            label_sel_radartype.Visible = false;
            button_update_config.Visible = false;
            buttonDectecModeling.Visible = false;
            buttonModelDone.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            
        }

        //private void clb_setMod_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int i;
        //    strCollected = string.Empty;
        //    for (i = 0; i < clb_setMod.Items.Count; i++)
        //    {
        //        if (clb_setMod.GetItemChecked(i))
        //        {
        //            if (strCollected == string.Empty)
        //            {
        //                strCollected = clb_setMod.GetItemText(clb_setMod.Items[i]);
        //            }
        //            else
        //            {
        //                strCollected = strCollected + "，" + clb_setMod.GetItemText(clb_setMod.Items[i]);
        //            }
        //        }
        //    }
        //}

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            if (strCollected == string.Empty)
                MessageBox.Show("您未添加任何噪声！");
            else MessageBox.Show("您选择添加了" + strCollected, "提示");
        }

       

        private void featurecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int showIndex = featurecomboBox1.SelectedIndex;
            FeatureModel feature = new FeatureModel();
            if (showIndex == 0)
            {
                //当前选中了时域和空域特征分析
                Dictionary<String, double> featDic = feature.getTimeAndSpaceFeature(list,13);
                String[] featName = new String[13];
                int i = 0;
                foreach (String key in featDic.Keys)
                {
                    featName[i++] = key;
                }

                featurelistView.BeginUpdate();
                
                
                featurelistView.Clear();
                ColumnHeader header1 = new ColumnHeader();
                header1.Text = "算法";
                ColumnHeader header2 = new ColumnHeader();
                header2.Text = "数值分析";

                featurelistView.Columns.AddRange(new ColumnHeader[] { header1, header2 });
                featurelistView.FullRowSelect = true;
                //listview 中添加数据

                for (i = 0; i < 13; i++)
                {
                    featurelistView.Items.Add("" + featName[i]);
                    ListViewItem listItem = new ListViewItem();
                    listItem.SubItems.Add(""+featDic[featName[i]]);
                    featurelistView.Items[i].SubItems.Add("" + featDic[featName[i]]);
                    

                }

                featurelistView.View = System.Windows.Forms.View.Details;
                featurelistView.GridLines = true;
                featurelistView.EndUpdate();


            }
            else if(showIndex == 1)
            {
                //当前选中了频域特征分析
               MessageBox.Show("频域特征分析未实现", "hints");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            //创建画板
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1/2);
            //g.DrawLine(pen, 0, 0, 335, 0);

            int factor = panel1.Width/10;
            for ( int i = 0; i < 10; i++)
            {
                //画水平线
                g.DrawLine(pen, 0, i*factor, panel1.Width, i*factor);
                //画竖直线
                g.DrawLine(pen, i*factor, 0, factor*i, panel1.Height);
            }

            //画圆
            for(int j = 1;j<5;j++)
            {
                g.DrawEllipse(pen, 4*factor-(j-1)*factor, 4*factor-(j-1)*factor, j * 2*factor, j * 2*factor);
                //g.DrawEllipse(panel1.Width/10*4,)
            }
           // timer1.Start();
        }
        int degress = 0;
        float angle = 0;
        int x2 = 115, y2 = 0;
        double r = 50;
        private void timer1_Tick(object sender, EventArgs e)
        {
            using (Graphics g = panel1.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1 / 2);
                g.DrawLine(pen, 115, 115, x2, y2);
                degress += 10;
                angle = (float)(Math.PI * degress / 180.0);
                x2 = (int)(115 - r + Math.Cos(angle) * r);
                y2 = (int)(0-Math.Sin(angle)*r);
                //g.RotateTransform(angle);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = panel2.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1 / 2);
                for (int j = 1; j < 5; j++)
                {
                    g.DrawEllipse(pen, 25 - (j - 1) * 8, 25 - (j - 1) * 8, j * 16, j * 16);
                }
            }
        }

        private void OnDargDrop(object sender, DragEventArgs e) //拖动雷达时候产生该事件
        {
           // pictureBox4.
            MessageBox.Show("ga");
            screenpoint_pic4 = PointToScreen(pictureBox4.Location);
            Console.WriteLine(screenpoint_pic4.X);

        }
    //    private bool isDragging = false; //拖中
    //    private int currentX = 0, currentY = 0; //原来鼠标X,Y坐标
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;  //可以拖动
            currentX = e.X;
            currentY = e.Y;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
          //  MessageBox.Show("ga");
            if (isDragging)
            {
                pictureBox4.Top = pictureBox4.Top + (e.Y - currentY);
                pictureBox4.Left = pictureBox4.Left + (e.X - currentX);
            }
            isDragging = false;
      //      screenpoint_pic4 = PointToScreen(pictureBox4.Location);
      //      Console.WriteLine(pictureBox4.Top);  
       //     Console.WriteLine(screenpoint_pic4.Y);
       //     Console.WriteLine(screenpoint_pic4.X);
           
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            isDragging = true;  //可以拖动
          //  if (isDragging)
          //  {
          //      pictureBox4.Top = pictureBox1.Top + (e.Y - currentY);
           //     pictureBox4.Left = pictureBox1.Left + (e.X - currentX);
          //  }
        }

        private void Feature_SelectedIndexChanged(object sender, EventArgs e)
        {
            //flag_thread2 = 1;
            //Control ctrl=tabControl1.GetControl(2);
            if (tabControl1.SelectedIndex == 1)
                draw_monitor_trace();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //autoForm.controlAutoSize(this);
        }

        
        /**
         *  显示特性分析中X坐标轴的刻度
         **/
        private void Xpanel_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = Xpanel.CreateGraphics();
            double start = -1;
            int sLoc = 0;
            int addition = 40;
            for (int i = 0; i < 11; i++)
            {
                g.DrawString((start + 0.2 * i).ToString(), new Font(FontFamily.GenericMonospace, 10f), Brushes.Black, new PointF(sLoc + addition * i, 0));
            }
        }

        /**
         * 显示特性分析中Y轴坐标刻度
         **/

        private void Ypanel_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = Ypanel.CreateGraphics();
            double start = 1;
            int sLoc = 0;
            int addition = 40;
            for (int i = 0; i < 11; i++)
            {
                g.DrawString((start - 0.2 * i).ToString(), new Font(FontFamily.GenericMonospace, 10f), Brushes.Black, new PointF(0, sLoc + addition * i));
            }
        }

        //private void checkedListBox_radartype_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    if (checkedListBox_radartype.CheckedItems.Count > 0)
        //    {
        //        for (int i = 0; i < checkedListBox_radartype.Items.Count; i++)
        //        {
        //            if (i != e.Index)
        //            {
        //                this.checkedListBox_radartype.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
        //            }
        //        }
        //    }  
        //}

        private void radioButton1_CheckedChanged(object sender, EventArgs e)  //第一组groupbox1中的radiobutton,都对应了这个事件
        {
            if (radioButton1.Checked == true)  //选中了第一个单选按钮，即选择了多普勒雷达
            {
                
              //  button_goback.Visible = true;
                //pictureBox4.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\..\\..\\..\\radarsystem\\Resources\\多普勒雷达.jpg");
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.duopule;
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "多普勒雷达";
                groupBox1.Visible = false;
                drawtrace();
                readTxt();
               
            }
            if (radioButton2.Checked == true)  //选中了第二个单选按钮，即选择了多基地雷达
            {

                //  button_goback.Visible = true;
                //pictureBox4.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\..\\..\\..\\radarsystem\\Resources\\多普勒雷达.jpg");
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.radarpic;  //还没替换为多基地雷达图标
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "多基地雷达";
                groupBox1.Visible = false;
                drawtrace();
                readTxt();

            }
            if (radioButton3.Checked == true)  //选中了第3个单选按钮，即选择了超视距雷达
            {

                //  button_goback.Visible = true;
                //pictureBox4.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\..\\..\\..\\radarsystem\\Resources\\多普勒雷达.jpg");
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.radarpic;  //还没替换为多基地雷达图标
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "超视距雷达";
                groupBox1.Visible = false;
                drawtrace();
                readTxt();

            }
            if (radioButton4.Checked == true)  //选中了第4个单选按钮，即选择了声呐
            {

                //  button_goback.Visible = true;
                //pictureBox4.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\..\\..\\..\\radarsystem\\Resources\\多普勒雷达.jpg");
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.radarpic;  //还没替换为多基地雷达图标
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "声呐";
                groupBox1.Visible = false;
                drawtrace();
                readTxt();

            }
            if (radioButton5.Checked == true)  //选中了第5个单选按钮，即选择了电子对抗
            {

                //  button_goback.Visible = true;
                //pictureBox4.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\..\\..\\..\\radarsystem\\Resources\\多普勒雷达.jpg");
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.radarpic;  //还没替换为多基地雷达图标
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "电子对抗";
                groupBox1.Visible = false;
                drawtrace();
                readTxt();

            }
            if (radioButton6.Checked == true)  //选中了第6个单选按钮，即选择了指挥控制
            {

                //  button_goback.Visible = true;
                //pictureBox4.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\..\\..\\..\\radarsystem\\Resources\\多普勒雷达.jpg");
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.radarpic; 
                //还没替换为指挥控制雷达图标，2部雷达？
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "指挥控制";
                groupBox1.Visible = false;
                drawtrace();
                readTxt();

            }
            button_goback.Visible = true;
        }
        
        private void readTxt()
        {
            textBox_doppler.Visible = true;
            button_update_config.Visible = true;
            //string str_temp="";
            textBox_doppler.Text = "";
           // textBox_doppler.Text = "检测范围\r\n\r\n距离精度\r\n\r\n目标速度\r\n\r\n速度精度";
            String path = Application.StartupPath+"\\configure.txt";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null )
            {
              //  Console.WriteLine(line.ToString());
                if (radioButton1.Checked == true)
                {
                    if (line.ToString() == "多普勒雷达")
                    {                      
                        while((line=sr.ReadLine())!=null)
                        {
                            textBox_doppler.Text += line.ToString();
                            textBox_doppler.Text += "\r\n";
                            if(line.ToString()!="" &&line.Substring(0,5)=="-----")  //内层循环终止条件
                            {
                                break;
                            }
                            
                        }
                        break;  //外层循环终止
                    }
                   
                  
                }
                else if (radioButton2.Checked == true)
                {
                    if (line.ToString() == "多基地雷达")
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            textBox_doppler.Text += line.ToString();
                            textBox_doppler.Text += "\r\n";
                            if (line.ToString() != "" && line.Substring(0, 5) == "-----")  //内层循环终止条件
                            {
                                break;
                            }

                        }
                        break;  //外层循环终止
                    }
                  

                }
                else if (radioButton3.Checked == true)
                {
                    if (line.ToString() == "超视距雷达")
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            textBox_doppler.Text += line.ToString();
                            textBox_doppler.Text += "\r\n";
                            if (line.ToString() != "" && line.Substring(0, 5) == "-----")  //内层循环终止条件
                            {
                                break;
                            }

                        }
                        break;  //外层循环终止
                    }
                    

                }
                else if (radioButton4.Checked == true)
                {
                    if (line.ToString() == "声呐")
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            textBox_doppler.Text += line.ToString();
                            textBox_doppler.Text += "\r\n";
                            if (line.ToString() != "" && line.Substring(0, 5) == "-----")  //内层循环终止条件
                            {
                                break;
                            }

                        }
                        break;  //外层循环终止
                    }
                

                }
                else if (radioButton5.Checked == true)
                {
                    if (line.ToString() == "电子对抗")
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            textBox_doppler.Text += line.ToString();
                            textBox_doppler.Text += "\r\n";
                            if (line.ToString() != "" && line.Substring(0, 5) == "-----")  //内层循环终止条件
                            {
                                break;
                            }

                        }
                        break;  //外层循环终止
                    }
                    

                }
                else if(radioButton6.Checked == true)
                {
                    if (line.ToString() == "指挥控制")
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            textBox_doppler.Text += line.ToString();
                            textBox_doppler.Text += "\r\n";
                            if (line.ToString() != "" && line.Substring(0, 5) == "-----")  //内层循环终止条件
                            {
                                break;
                            }

                        }
                        break;  //外层循环终止
                    }
                    

                }
            }
            sr.Close();
        }

        private void OnButtonUpdateConfigClick(object sender, EventArgs e)  //更新配置文件响应事件
        {
            readTxt();
        }

        private void OnButtonDetectModeling(object sender, EventArgs e)  //探测建模按钮响应事件
        {
            if (radioButton6.Checked == false)  //不是指挥控制
            {
                groupBox1.Visible = false;
                buttonDectecModeling.Visible = false;
                button_update_config.Visible = false;
                textBox_doppler.Visible = false;
                groupBox2.Visible = true;
                buttonModelDone.Visible = true;
                button_goback.Visible = true;     //需要在程序最前面 说明每个控件的名字代表的意义，方便阅读代码
                button_goback.Enabled = false;
                radioButton7.Checked = false;     //清除单选按钮选中状态
                radioButton8.Checked = false;
                radioButton9.Checked = false;
            }
            else
            {
                groupBox1.Visible = false;
                buttonDectecModeling.Visible = false;
                button_update_config.Visible = false;
                textBox_doppler.Visible = false;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                buttonModelDone.Visible = true;
                button_goback.Visible = true;
                button_goback.Enabled = false;
                radioButton7.Checked = false;     //清除单选按钮选中状态
                radioButton8.Checked = false;
                radioButton9.Checked = false;
            }
        }

        private void OnButtonModelDone(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                MessageBox.Show("congratulations! 添加噪声完毕，你选择添加了高斯白噪声");
                button_goback.Enabled = true;
            }
            else if (radioButton8.Checked == true)
            {    MessageBox.Show("congratulations! 添加噪声完毕，你选择添加了泊松噪声");
                button_goback.Enabled = true;
            }
            else if (radioButton9.Checked == true)
            {
                MessageBox.Show("congratulations! 添加噪声完毕，你选择添加了平均噪声");
                button_goback.Enabled = true;
            }
            else
                MessageBox.Show("请选择添加一种噪声");
        }
        //private void radioButton5_CheckedChanged(object sender, EventArgs e)
        //{

        //}

    

        //private void pictureBox3_Paint(object sender, PaintEventArgs e)
        //{
        //    drawtrace();
        //}
    }
}
