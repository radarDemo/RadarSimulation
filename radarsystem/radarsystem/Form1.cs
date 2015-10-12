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
        //多目标轨迹
        public struct trace
        {
            public long tar_ID;
            public long track_ID;
            public Point trail_Point;
            public long time;
        };
        List<Point>[] list_trace = new List<Point>[50];
     //   List<PointD>[] list = new List<PointD>[50];


        List<PointD>[] list_detect_distance = new List<PointD>[50];  //list数组 元素数据类型为PointD，最后用于存储判断了雷达扫描距离的 数据点，仅仅是为了
        //计算精度要求，
        List<PointD>[] list_detect_distance_final = new List<PointD>[50];   //最终用这个数组,用这个数组添加噪声，画波形图上噪音轨迹，以及特征分析

        //List<PointD> list = new List<PointD>();
        //List<Point> list_trace = new List<Point>();
        ArrayList arr_tar=new ArrayList() ;  //目标ID数组
   
        //存储添加噪音后的轨迹点
        List<PointD>[] guassianList = new List<PointD>[50];
        List<PointD>[] poissonList = new List<PointD>[50];
        List<PointD>[] uniformList = new List<PointD>[50];

        //数据库操作
        DBInterface dbInterface = new DBInterface();

        //标识是否添加了噪音
        NoiseEnum noiseFlag = NoiseEnum.NoNoise;

        Point screenpoint_pic4;
        private bool isDragging = false; //拖中
        private int currentX = 0, currentY = 0; //原来鼠标X,Y坐标
        //bool flag_thread2 = false;
        //bool flag_thread1 = false;
        bool flag_editchange = false;  //对应的配置文件文本框内容发生改变
        bool flag_init_editchange = false; //第一次加载时候，文本框内容会发生改变
        //Thread t2;
        //Thread t1;
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
            button_text_update.Visible = false;

            textBox_juli.Visible = false;
            textBox_zaipin.Visible = false;
            textBox_chongpin.Visible = false;
            textBox_maikuan.Visible = false;
            textBox_maifu.Visible = false;
            textBox_saomiao.Visible = false;
            textBox_jiebianliang.Visible = false;
            textBox_doudongliang.Visible = false;

            ArrayList ToolList = new ArrayList();
            ToolList.Add(MapXLib.ToolConstants.miZoomInTool);
            ToolList.Add(MapXLib.ToolConstants.miZoomOutTool);
            ToolList.Add(MapXLib.ToolConstants.miPanTool);
            ToolList.Add(MapXLib.ToolConstants.miCenterTool);
            ToolList.Add(MapXLib.ToolConstants.miLabelTool);

            comboBox_ToolList.DataSource = ToolList;
            //CMapXFeature FtA
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //连接数据库
            long id, tar_ID;
            int index;
            string conStr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;
                            Data source=" + Application.StartupPath + "\\database\\whut\\RecognitionAid.mdb");

            DataSet ds = dbInterface.query(conStr, "select * from TargetTrailPoints", "目标轨迹");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//获取目标个数
            {
                trace s1 = new trace();
                s1.tar_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["TGT_ID"]);
                id = s1.tar_ID;
                if (!arr_tar.Contains(id))
                    arr_tar.Add(id);
            }
            for (int i = 0; i < arr_tar.Count; i++)//申请list和list_trace空间
            {
                list_trace[i] = new List<Point>();
                list_detect_distance[i] = new List<PointD>();
                list_detect_distance_final[i] = new List<PointD>();

                guassianList[i] = new List<PointD>();
                poissonList[i] = new List<PointD>();
                uniformList[i] = new List<PointD>();
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)          //循环取出ds.table中的值
            {
                //trace s = new trace();
                Point p = new Point();
                tar_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["TGT_ID"]);
                //id = s.tar_ID;
                //s.track_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["TrailID"]);
                p.X = Convert.ToInt32(ds.Tables[0].Rows[i]["X"]);
                p.Y = Convert.ToInt32(ds.Tables[0].Rows[i]["Y"]);
                //s.trail_Point = p;
                //s.time = Convert.ToInt64(ds.Tables[0].Rows[i]["moveTime"]);
                index = arr_tar.IndexOf(tar_ID);
                list_trace[index].Add(p);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)          //循环取出ds.table中的值
            {
                PointD p = new PointD();
                tar_ID = Convert.ToInt64(ds.Tables[0].Rows[i]["TGT_ID"]);
                p.X = Convert.ToDouble(ds.Tables[0].Rows[i]["X"]);
                p.Y = Convert.ToDouble(ds.Tables[0].Rows[i]["Y"]);
                index = arr_tar.IndexOf(tar_ID);
                list_detect_distance[index].Add(p);
            }
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)          //循环取出ds.table中的值
            //{

            //    PointD s = new PointD();                  // 实例化Point对象
            //    s.X= Convert.ToDouble(ds.Tables[0].Rows[i]["X"]);
            //    s.Y = Convert.ToDouble(ds.Tables[0].Rows[i]["Y"]);            

            //    list.Add(s);    // 将取出的对象保存在LIST中  以上是获得值。


            //}
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)          //循环取出ds.table中的值
            //{

            //    Point s = new Point();                  // 实例化Point对象
            //    s.X = Convert.ToInt32(ds.Tables[0].Rows[i]["X"]);  //X，Y看做是经度纬度
            //    s.Y = Convert.ToInt32(ds.Tables[0].Rows[i]["Y"]);

            //    list_trace.Add(s);    // 将取出的对象保存在LIST中  以上是获得值。


            //}
            //foreach (Point p in list_trace)
            //{
            //    Console.WriteLine(p.X);
             
            //    Console.WriteLine(p.Y);
            //}
            screenpoint_pic4 =PointToScreen(pictureBox4.Location);
            Console.WriteLine(screenpoint_pic4.X);
            Console.WriteLine(screenpoint_pic4.Y);

        }
        private void drawtrace()
        {
            System.Threading.Tasks.Parallel.For(0, arr_tar.Count, i =>
                {
                    TestMethod(i);
                });
            //if (!flag_thread1)
            //{             
            //    t1 = new Thread(new ThreadStart(TestMethod));
            //    t1.IsBackground = true;
            //    t1.Start();
            //    flag_thread1 = true;
            //}
            //else
            //{

            //    t1.Abort();
            //    t1 = new Thread(new ThreadStart(TestMethod));
            //    t1.IsBackground = true;
            //    t1.Start();
            //}
            //   t2.Start();

           
        }
        public void TestMethod(int flag)
        {
            Graphics g;
            
            g =axMap1.CreateGraphics();
            Pen p = new Pen(Color.Red, 2);         
           
            Point one, two;
            for (int i = 0; i < list_trace[flag].Count-1; i++)
            {
                one = list_trace[flag][i];
                two = list_trace[flag][i + 1];
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawLine(p, one, two);
                System.Threading.Thread.Sleep(200);
            } 
            g.Dispose();
        }
        private void draw_monitor_trace(List<PointD> points)
        {
            thread2(points);
            //if (!flag_thread2) 
            //{            
            //    t2 = new Thread(new ParameterizedThreadStart(thread2));
            //    t2.IsBackground = true;
            //    t2.Start(points);
            //    flag_thread2 = true;
            //}
            //else
            //{
            //    t2.Abort();
            //    t2 = new Thread(new ParameterizedThreadStart(thread2));
            //    t2.IsBackground = true;
            //    t2.Start(points);
            //}
            //t2.Start();
        }
        public void thread2(List<PointD> points)
        {
            
            //List<PointD> points = (List<PointD>)o;
            List<Point> list_trace = new List<Point>();
            double distance1, distance2;
            distance1 = 7 * panel1.Width / 20;
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
           
            for (int i = 0; i < points.Count; i++)
            {
                //double类型的坐标转换成int
                list_trace.Add(new Point((int)points[i].X,(int)points[i].Y));
                //g.DrawString();
            }
            for (int i = 0; i < list_trace.Count - 1; i++)
            {
                point = list_trace[i];
                point_diff = point;
                point_diff.X = point.X - pictureBox4.Left;
                point_diff.Y = point.Y - pictureBox4.Top;
                distance2 = Math.Sqrt(point_diff.X * point_diff.X + point_diff.Y * point_diff.Y);
                if (distance2 - distance1 > 0)
                    continue;
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
                System.Threading.Thread.Sleep(200);
            }
        //    double x1=116.41667;
        //    double y1 =39.91667;   //beijing经纬度
        //    double x2=114.31667;
        //    double y2 = 30.51667;   //武汉经纬度
        //    double dis=axMap1.Distance(x1,y1,x2,y2)*2;
        ////    textBox_longitude.Text = dis.ToString();
        }
         
        //
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

            textBox_juli.Visible = false;
            textBox_zaipin.Visible = false;
            textBox_chongpin.Visible = false;
            textBox_maikuan.Visible = false;
            textBox_maifu.Visible = false;
            textBox_saomiao.Visible = false;
            textBox_jiebianliang.Visible = false;
            textBox_doudongliang.Visible = false;
            button_text_update.Visible = false;
            
        }
     

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            if (strCollected == string.Empty)
                MessageBox.Show("您未添加任何噪声！");
            else MessageBox.Show("您选择添加了" + strCollected, "提示");
        }

       
        //特性分析中下拉框状态改变响应函数
        private void featurecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int showIndex = featurecomboBox1.SelectedIndex;
            FeatureModel feature = new FeatureModel();
            Dictionary<String, double> featDicX;
            Dictionary<String, double> featDicY; 

            if (noiseFlag == NoiseEnum.NoNoise)
                return;
            if (showIndex == 0)
            {
                //当前选中了时域和空域特征分析(X)
                if (noiseFlag == NoiseEnum.GUASSIAN){
                    featDicX = feature.getTimeAndSpaceFeatureX(guassianList[0], 13);
                    featDicY = feature.getTimeAndSpaceFeatureY(guassianList[0], 13);
                } 
                else if(noiseFlag == NoiseEnum.POISSON){
                    featDicX = feature.getTimeAndSpaceFeatureX(poissonList[0], 13);
                    featDicY = feature.getTimeAndSpaceFeatureY(uniformList[0], 13);
                }
                   
                else{
                    featDicX = feature.getTimeAndSpaceFeatureX(uniformList[0], 13);
                    featDicY = feature.getTimeAndSpaceFeatureY(uniformList[0], 13);
                }
                   
                String[] featName = new String[13];
                int i = 0;
                foreach (String key in featDicX.Keys)
                {
                    featName[i++] = key;
                }

                featurelistView.BeginUpdate();
                
                
                featurelistView.Clear();
                ColumnHeader header1 = new ColumnHeader();
                header1.Text = " ";
                header1.Width = 85;
                ColumnHeader header2 = new ColumnHeader();
                header2.Text = "X";
                header2.Width = 90;
                ColumnHeader header3 = new ColumnHeader();
                header3.Text = "Y";
                header3.Width = 90;

                featurelistView.Columns.AddRange(new ColumnHeader[] { header1, header2, header3 });
                featurelistView.FullRowSelect = true;
                //listview 中添加数据
                //featurelistView.Items.Add(" ");
                featurelistView.Items.Add("算法");
               
                //listItem.SubItems.Add("数值分析");
                featurelistView.Items[0].SubItems.Add("数值分析");
                featurelistView.Items[0].SubItems.Add("数值分析");
                ListViewItem listItem = new ListViewItem();
                for (i = 0; i < 13; i++)
                {
                    featurelistView.Items.Add("" + featName[i]);
                    //ListViewItem listItem = new ListViewItem();
                    //listItem.SubItems.Add(""+featDic[featName[i]]);
                    featurelistView.Items[i+1].SubItems.Add("" + featDicX[featName[i]]);
                    featurelistView.Items[i + 1].SubItems.Add("" + featDicY[featName[i]]);

                }

                featurelistView.View = System.Windows.Forms.View.Details;
                featurelistView.GridLines = true;
                featurelistView.EndUpdate();


            }
            else if (showIndex == 1)
            {
                //当前选中了时域和空域特征分析(Y)
            /*    if (noiseFlag == NoiseEnum.GUASSIAN)
                    featDic = feature.getTimeAndSpaceFeatureY(guassianList, 13);
                else if (noiseFlag == NoiseEnum.POISSON)
                    featDic = feature.getTimeAndSpaceFeatureY(poissonList, 13);
                else
                    featDic = feature.getTimeAndSpaceFeatureY(uniformList, 13);
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
                header1.Width = 95;
                ColumnHeader header2 = new ColumnHeader();
                header2.Text = "数值分析";
                header2.Width = 100;

                featurelistView.Columns.AddRange(new ColumnHeader[] { header1, header2 });
                featurelistView.FullRowSelect = true;
                //listview 中添加数据

                for (i = 0; i < 13; i++)
                {
                    featurelistView.Items.Add("" + featName[i]);
                    ListViewItem listItem = new ListViewItem();
                    listItem.SubItems.Add("" + featDic[featName[i]]);
                    featurelistView.Items[i].SubItems.Add("" + featDic[featName[i]]);


                }

                featurelistView.View = System.Windows.Forms.View.Details;
                featurelistView.GridLines = true;
                featurelistView.EndUpdate();
             */

            }
            else if(showIndex == 2)
            {
                //当前选中了频域特征分析
               MessageBox.Show("频域特征分析未实现", "hints");
            }
        }

        //画特性分析中间面板的坐标和圆
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
            drawtrace();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            isDragging = true;  //可以拖动
            float X, Y;
            X = pictureBox4.Left;  //SrnPt为鼠标点
            Y = pictureBox4.Top;
            double mapX1 = 0, mapY1 = 0;
            axMap1.ConvertCoord(ref X, ref Y, ref mapX1, ref mapY1, MapXLib.ConversionConstants.miScreenToMap);
            textBox_longitude.Text = mapX1.ToString();
            textBox_latitude.Text = mapY1.ToString();       
        }

        private void Feature_SelectedIndexChanged(object sender, EventArgs e)
        {
            //flag_thread2 = 1;
            //Control ctrl=tabControl1.GetControl(2);
            if (tabControl1.SelectedIndex == 1)
            {
                
                if (noiseFlag == NoiseEnum.GUASSIAN)
                {
                    //显示添加高斯噪音的轨迹
                    System.Threading.Tasks.Parallel.For(0, arr_tar.Count, i =>
                        {
                            draw_monitor_trace(guassianList[i]);
                        });
                }
                else if (noiseFlag == NoiseEnum.POISSON)
                {
                    //显示添加泊松噪音的轨迹
                    System.Threading.Tasks.Parallel.For(0, arr_tar.Count, i =>
                    {
                        draw_monitor_trace(poissonList[i]);
                    });
                }
                else if (noiseFlag == NoiseEnum.UNIFORM)
                {
                    System.Threading.Tasks.Parallel.For(0, arr_tar.Count, i =>
                    {
                        draw_monitor_trace(uniformList[i]);
                    });    
                }
                else
                {
                    MessageBox.Show("未添加任何噪声，请先建模！");
                }
            }
                //draw_monitor_trace();
            
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)  //第一组groupbox1中的radiobutton,都对应了这个事件
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
            {


                textBox_juli.Visible = true;
                textBox_zaipin.Visible = true;
                textBox_chongpin.Visible = true;
                textBox_maikuan.Visible = true;
                textBox_maifu.Visible = true;
                textBox_saomiao.Visible = true;
                textBox_jiebianliang.Visible = true;
                textBox_doudongliang.Visible = true;
                button_text_update.Visible = true;
            }
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
           
                double MapX = 103, mapY = 36;  //精度 ，纬度
                float screenX = 0, screenY = 0; //屏幕坐标
                axMap1.ConvertCoord(ref screenX, ref screenY, ref MapX, ref mapY,
                                    MapXLib.ConversionConstants.miMapToScreen);  //已知经纬度 转换为屏幕坐标
            //    Graphics g = axMap1.CreateGraphics();
                pictureBox4.Left =(int) screenX;
                pictureBox4.Top = (int)screenY;                        
              
        
                flag_init_editchange = true;
                readTxt();
               
            }
            if (radioButton2.Checked == true)  //选中了第二个单选按钮，即选择了多基地雷达
            {            
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.radarpic;  //还没替换为多基地雷达图标
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "多基地雷达";
                groupBox1.Visible = false;
              //  drawtrace();
                readTxt();

            }
            if (radioButton3.Checked == true)  //选中了第3个单选按钮，即选择了超视距雷达
            {                            
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.radarpic;  //还没替换为多基地雷达图标
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "超视距雷达";
                groupBox1.Visible = false;
               // drawtrace();
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
                label_sel_radartype.Text = "声呐主动";
                groupBox1.Visible = false;
               // drawtrace();
            //    readTxt();

            }
            if (radioButton5.Checked == true)  //选中了第5个单选按钮，即选择了电子对抗
            {
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.radarpic;  //还没替换为多基地雷达图标
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "电子对抗";
                groupBox1.Visible = false;
               // drawtrace();
            //    readTxt();

            }
            if (radioButton6.Checked == true)  //选中了第6个单选按钮，即选择了指挥控制
            {         
                pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.radarpic; 
                //还没替换为指挥控制雷达图标，2部雷达？
                pictureBox4.Visible = true;
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "指挥控制";
                groupBox1.Visible = false;
              //  drawtrace();
           //     readTxt();

            }
            if (radioButton13.Checked == true)  //选中了第7个单选按钮，即选择了声呐（被动）
            {                             
                buttonDectecModeling.Visible = true;
                label_sel_radartype.Visible = true;
                label_sel_radartype.Text = "声呐被动";
                groupBox1.Visible = false;
                // drawtrace();
             //   readTxt();

            }
            button_goback.Visible = true;
        }
        
        private void read_interface(int line_num)       //读配置文件公共接口
        {
            String path = Application.StartupPath + "\\configure.txt";
         //   StreamReader sr = new StreamReader(path, Encoding.Default);
            string[] content_read = System.IO.File.ReadAllText(path).Split(new char[] { '\r', '\n' },
               StringSplitOptions.RemoveEmptyEntries);
            int count = 1;
            int line_count = 0;
            while (count < 9)
            {
                textBox_doppler.Text += content_read[line_num * 10 + count].Split('\t')[0];
                textBox_doppler.Text += "\r\n\r\n";
                if ((line_count+1) % 3 == 0)
                {
                    textBox_doppler.Text += "\r\n"; //多加一个换行，保持美观
                    //line_count = 0;
                }
                if(line_count==4)
                    textBox_doppler.Text += "\r\n"; //多加一个换行，保持美观
                if (count == 1)
                    textBox_juli.Text = content_read[line_num * 10 + count].Split('\t')[1];
                else if (count == 2)
                    textBox_zaipin.Text = content_read[line_num * 10 + count].Split('\t')[1];
                else if (count == 3)
                    textBox_chongpin.Text = content_read[line_num * 10 + count].Split('\t')[1];
                else if (count == 4)
                    textBox_maikuan.Text = content_read[line_num * 10 + count].Split('\t')[1];
                else if (count == 5)
                    textBox_maifu.Text = content_read[line_num * 10 + count].Split('\t')[1];
                else if (count == 6)
                    textBox_saomiao.Text = content_read[line_num * 10 + count].Split('\t')[1];
                else if (count == 7)
                    textBox_jiebianliang.Text = content_read[line_num * 10 + count].Split('\t')[1];
                else if (count == 8)
                    textBox_doudongliang.Text = content_read[line_num * 10 + count].Split('\t')[1];
                count++;
                line_count++;
            }
        }
        private void readTxt()
        {
            textBox_doppler.Visible = true;
            button_update_config.Visible = true;
            //string str_temp="";
            textBox_doppler.Text = "";
           // textBox_doppler.Text = "检测范围\r\n\r\n距离精度\r\n\r\n目标速度\r\n\r\n速度精度";
          
            int line_num = 0;
            int count = 0;
            if (radioButton1.Checked == true)
            {
                line_num = 0;
                read_interface(line_num);
               // count = 1;
               // if (content_read[line_num * 1] == "多普勒雷达")
               // {           
                    
               // }

            }
            if (radioButton2.Checked == true)
            {
                line_num = 1;
                read_interface(line_num);
            }
            if (radioButton3.Checked == true)
            {
                line_num = 2;
                read_interface(line_num);
            }
              
          
   
        }

        private void OnButtonUpdateConfigClick(object sender, EventArgs e)  //选择文件更新 按钮响应事件
        {         
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "E:\\";
                openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;
                string path = "";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
                if(path!="")
                    System.Diagnostics.Process.Start(path);
           // }
            
        }

        private void wrTxt()
        {
          //  MessageBox.Show("wr");
            int line_num=0; //行号
            String path = Application.StartupPath + "\\configure.txt";
            
            string[] content = System.IO.File.ReadAllText(path).Split(new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            if (radioButton1.Checked == true)   //多普勒雷达被选中
            {
                line_num = 0;  //指定修改哪些行，最后一次整个文件都会更新
                content[line_num* 1 + 1] = "探测距离(km)"+"\t"+textBox_juli.Text;
                content[line_num * 1 + 2] = "载频(GHZ)"+"\t"+textBox_zaipin.Text;
                content[line_num * 1 + 3] = "重频(GHZ)" + "\t" + textBox_chongpin.Text;
                content[line_num * 1 + 4] = "脉宽(us)" + "\t" + textBox_maikuan.Text;
                content[line_num * 1 + 5] = "脉幅" + "\t" + textBox_maifu.Text;
                content[line_num * 1 + 6] = "天线扫描周期" + "\t" + textBox_saomiao.Text;
                content[line_num * 1 + 7] = "载频捷变量" + "\t" + textBox_jiebianliang.Text;
                content[line_num * 1 + 8] = "重频抖动量" + "\t" + textBox_doudongliang.Text;
            }
            //content[1] = "9,f,g,h";
            System.IO.File.WriteAllText(path, string.Join("\r\n", content),
                Encoding.Unicode);

        }
        private void OnButtonDetectModeling(object sender, EventArgs e)  //探测建模按钮响应事件
        {

            textBox_juli.Visible = false;
            textBox_zaipin.Visible = false;
            textBox_chongpin.Visible = false;
            textBox_maikuan.Visible = false;
            textBox_maifu.Visible = false;
            textBox_saomiao.Visible = false;
            textBox_jiebianliang.Visible = false;
            textBox_doudongliang.Visible = false;
            button_text_update.Visible = false;

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

        public void computeMeanVar(List<PointD> list, out double xMean, out double xVariance, out double yMean, out double yVariance)
        {
            xMean = 0.0; xVariance = 0.0;
            yMean = 0.0; yVariance = 0.0;
            for (int i = 0; i < list.Count; i++)
            {
                xMean += list[i].X;
                yMean += list[i].Y;

            }

            xMean /= list.Count;
            yMean /= list.Count;
            //方差
            for (int j = 0; j < list.Count; j++)
            {
                xVariance += Math.Pow((list[j].X - xMean), 2);
                yVariance += Math.Pow((list[j].Y - yMean), 2);
            }
            xVariance /= list.Count;
            xVariance = Math.Pow(xVariance, 1 / 2);
            yVariance /= list.Count;
            yVariance = Math.Pow(yVariance, 1 / 2);
        }

        private void prepareforListDetectDis()      //准备数据，即填充list_detect_distance_final[] 数组
        {
            //    List<Point> list_trace = new List<Point>();
            double distance1, distance2;
            distance1 = 7 * panel1.Width / 20;          
            PointD point = new PointD();
            PointD point_diff = new PointD();      

            for (int i = 0; i < arr_tar.Count; i++)
            {
                for (int j = 0; j < list_detect_distance[i].Count; j++)
                {
                    point.X = list_detect_distance[i][j].X;
                    point.Y = list_detect_distance[i][j].Y;

                    point_diff.X = point.X;
                    point_diff.Y = point.Y;

                    point_diff.X = point.X - pictureBox4.Left;
                    point_diff.Y = point.Y - pictureBox4.Top;
                    distance2 = Math.Sqrt(point_diff.X * point_diff.X + point_diff.Y * point_diff.Y);
                    if (distance2 - distance1 <= 0)   //相当于判断雷达的最大扫描范围
                    {
                        // list_trace.
                        PointD point_save = new PointD();
                        point_save.X = point.X;
                        point_save.Y = point.Y;
                        list_detect_distance_final[i].Add(point_save);
                        // continue;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
        }
        private void OnButtonModelDone(object sender, EventArgs e)
        {
                prepareforListDetectDis();   //准备数据，为数组list_detect_distance_final
                if (radioButton7.Checked == true)
                {
                    //添加高斯噪声
                    //均值
                    double xMean = 0, xVariance = 0;
                    double yMean = 0, yVariance = 0;
                    //计算均值和方差
                    for (int i = 0; i < arr_tar.Count; i++)
                    {
                        computeMeanVar(list_detect_distance_final[i], out xMean, out xVariance, out yMean, out yVariance);
                        guassianList[i] = new List<PointD>(Noise.addGuassianNoise(list_detect_distance_final[i].ToArray(), 
                            xMean, xVariance, yMean, yVariance));
                    }
                    button_goback.Enabled = true;
                    if (DialogResult.OK == MessageBox.Show("congratulations! 添加噪声完毕，你选择添加了高斯白噪声"))
                    {
                        noiseFlag = NoiseEnum.GUASSIAN;
                        //将当前选中的tab页设为特性分析
                        this.tabControl1.SelectedIndex = 1;

                    }


                }
                else if (radioButton8.Checked == true)
                {
                    //添加泊松噪音
                    for (int i = 0; i < arr_tar.Count; i++ )
                        poissonList[i] = new List<PointD>(Noise.addPoissonNoise(list_detect_distance_final[i].ToArray(),
                            (panel1.Width / 10) * 7, (panel1.Width / 10) * 7));
                    button_goback.Enabled = true;
                    if (DialogResult.OK == MessageBox.Show("congratulations! 添加噪声完毕，你选择添加了泊松噪声"))
                    {
                        //MessageBox.Show(""+(panel1.Width / 10) * 7);
                        noiseFlag = NoiseEnum.POISSON;
                        //将当前的页面切换成特性分析
                        this.tabControl1.SelectedIndex = 1;

                    }

                    //button_goback.Enabled = true;
                }
                else if (radioButton9.Checked == true)
                {
                    //添加均匀噪声
                    //计算均匀分布的a和b
                    double xMean = 0, xVariance = 0;
                    double yMean = 0, yVariance = 0;
                    double XA = 0, XB = 0;
                    double YA = 0, YB = 0;
                    for (int i = 0; i < arr_tar.Count; i++)
                    {
                        computeMeanVar(list_detect_distance_final[i], out xMean, out xVariance, out yMean, out yVariance);
                        XA = xMean - Math.Pow(3, 1 / 2) * Math.Pow(xVariance, 2);
                        XB = xMean + Math.Pow(3, 1 / 2) * Math.Pow(xVariance, 2);
                        YA = yMean - Math.Pow(3, 1 / 2) * Math.Pow(yVariance, 2);
                        YB = yMean + Math.Pow(3, 1 / 2) * Math.Pow(yVariance, 2);

                        uniformList[i] = new List<PointD>(Noise.addUniformNoise(list_detect_distance_final[i].ToArray(), XA, XB, YA, YB));
                    }
                    button_goback.Enabled = true;
                    if (DialogResult.OK == MessageBox.Show("congratulations! 添加噪声完毕，你选择添加了平均噪声"))
                    {
                        noiseFlag = NoiseEnum.UNIFORM;
                        this.tabControl1.SelectedIndex = 1;
                    }
                    //button_goback.Enabled = true;
                }
                else
                    MessageBox.Show("请选择添加一种噪声");
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.checkBox1.Checked == true)
            {
                MessageBox.Show("选中真实轨迹");
                //如果真是轨迹选项选中
                System.Threading.Tasks.Parallel.For(0, arr_tar.Count, i =>
                {
                    draw_monitor_trace(list_detect_distance_final[i]);
                });
                
            }
                

        }

        private void comboBox_ToolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            axMap1.CurrentTool = (MapXLib.ToolConstants)comboBox_ToolList.SelectedItem;
        }

        private void TextChanged(object sender, EventArgs e)
        {
            flag_editchange = true;
        }

        private void UpdateTextToTxt(object sender, EventArgs e)
        {
            wrTxt();
            readTxt();
            MessageBox.Show("配置文件更新完成");
        }

        private void Text_jinduAndweiduChanged(object sender, EventArgs e)
        {
            double MapX=0,MapY=0;
            if(textBox_longitude.Text!="")
                   MapX = Convert.ToDouble(textBox_longitude.Text);  //经度

            if(textBox_latitude.Text!="")
                   MapY = Convert.ToDouble(textBox_latitude.Text);  //纬度
            float screenX = 0, screenY = 0; //屏幕坐标

            if (textBox_longitude.Text != "" && textBox_latitude.Text != "")
            {


                axMap1.ConvertCoord(ref screenX, ref screenY, ref MapX, ref MapY,
                                MapXLib.ConversionConstants.miMapToScreen);  //已知经纬度 转换为屏幕坐标
                pictureBox4.Left = (int)screenX;
                pictureBox4.Top = (int)screenY;
            }
        //    Graphics g = axMap1.CreateGraphics();
          
        }
      
    }
}
