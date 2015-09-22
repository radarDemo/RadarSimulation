namespace radarsystem
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbp_CharacterAnalysis = new System.Windows.Forms.TabPage();
            this.Ypanel = new System.Windows.Forms.Panel();
            this.Xpanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.featurelistView = new System.Windows.Forms.ListView();
            this.algorithmcolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numbercolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.featurecomboBox1 = new System.Windows.Forms.ComboBox();
            this.tbp_SceneSet = new System.Windows.Forms.TabPage();
            this.buttonModelDone = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.buttonDectecModeling = new System.Windows.Forms.Button();
            this.textBox_doppler = new System.Windows.Forms.TextBox();
            this.button_update_config = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button_goback = new System.Windows.Forms.Button();
            this.label_state = new System.Windows.Forms.Label();
            this.label_sel_radartype = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbp_CharacterAnalysis.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbp_SceneSet.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::radarsystem.Properties.Resources.header;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(925, 56);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(276, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 8);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbp_CharacterAnalysis
            // 
            this.tbp_CharacterAnalysis.Controls.Add(this.Ypanel);
            this.tbp_CharacterAnalysis.Controls.Add(this.Xpanel);
            this.tbp_CharacterAnalysis.Controls.Add(this.panel2);
            this.tbp_CharacterAnalysis.Controls.Add(this.panel1);
            this.tbp_CharacterAnalysis.Controls.Add(this.featurelistView);
            this.tbp_CharacterAnalysis.Controls.Add(this.label1);
            this.tbp_CharacterAnalysis.Controls.Add(this.featurecomboBox1);
            this.tbp_CharacterAnalysis.Location = new System.Drawing.Point(4, 22);
            this.tbp_CharacterAnalysis.Name = "tbp_CharacterAnalysis";
            this.tbp_CharacterAnalysis.Size = new System.Drawing.Size(788, 479);
            this.tbp_CharacterAnalysis.TabIndex = 2;
            this.tbp_CharacterAnalysis.Text = "特性分析";
            this.tbp_CharacterAnalysis.UseVisualStyleBackColor = true;
            // 
            // Ypanel
            // 
            this.Ypanel.Location = new System.Drawing.Point(24, 23);
            this.Ypanel.Name = "Ypanel";
            this.Ypanel.Size = new System.Drawing.Size(41, 442);
            this.Ypanel.TabIndex = 7;
            this.Ypanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Ypanel_Paint);
            // 
            // Xpanel
            // 
            this.Xpanel.Location = new System.Drawing.Point(71, 7);
            this.Xpanel.Name = "Xpanel";
            this.Xpanel.Size = new System.Drawing.Size(502, 15);
            this.Xpanel.TabIndex = 6;
            this.Xpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Xpanel_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(3, 411);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(90, 65);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(71, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 460);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox1.Location = new System.Drawing.Point(430, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "真实轨迹";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // featurelistView
            // 
            this.featurelistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.algorithmcolumn,
            this.numbercolumn});
            this.featurelistView.Location = new System.Drawing.Point(607, 76);
            this.featurelistView.Name = "featurelistView";
            this.featurelistView.Size = new System.Drawing.Size(167, 389);
            this.featurelistView.TabIndex = 3;
            this.featurelistView.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(605, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "轨迹特性分析";
            // 
            // featurecomboBox1
            // 
            this.featurecomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.featurecomboBox1.FormattingEnabled = true;
            this.featurecomboBox1.Items.AddRange(new object[] {
            "时域和空域的特征分析",
            "频域特征分析"});
            this.featurecomboBox1.Location = new System.Drawing.Point(607, 49);
            this.featurecomboBox1.Name = "featurecomboBox1";
            this.featurecomboBox1.Size = new System.Drawing.Size(167, 20);
            this.featurecomboBox1.TabIndex = 2;
            this.featurecomboBox1.SelectedIndexChanged += new System.EventHandler(this.featurecomboBox1_SelectedIndexChanged);
            // 
            // tbp_SceneSet
            // 
            this.tbp_SceneSet.Controls.Add(this.buttonModelDone);
            this.tbp_SceneSet.Controls.Add(this.groupBox3);
            this.tbp_SceneSet.Controls.Add(this.buttonDectecModeling);
            this.tbp_SceneSet.Controls.Add(this.textBox_doppler);
            this.tbp_SceneSet.Controls.Add(this.button_update_config);
            this.tbp_SceneSet.Controls.Add(this.groupBox1);
            this.tbp_SceneSet.Controls.Add(this.pictureBox4);
            this.tbp_SceneSet.Controls.Add(this.button_goback);
            this.tbp_SceneSet.Controls.Add(this.label_state);
            this.tbp_SceneSet.Controls.Add(this.pictureBox3);
            this.tbp_SceneSet.Controls.Add(this.groupBox2);
            this.tbp_SceneSet.Location = new System.Drawing.Point(4, 22);
            this.tbp_SceneSet.Name = "tbp_SceneSet";
            this.tbp_SceneSet.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_SceneSet.Size = new System.Drawing.Size(917, 534);
            this.tbp_SceneSet.TabIndex = 0;
            this.tbp_SceneSet.Text = "岸基场景设置";
            this.tbp_SceneSet.UseVisualStyleBackColor = true;
            // 
            // buttonModelDone
            // 
            this.buttonModelDone.Location = new System.Drawing.Point(774, 396);
            this.buttonModelDone.Name = "buttonModelDone";
            this.buttonModelDone.Size = new System.Drawing.Size(75, 23);
            this.buttonModelDone.TabIndex = 12;
            this.buttonModelDone.Text = "建模完成";
            this.buttonModelDone.UseVisualStyleBackColor = true;
            this.buttonModelDone.Click += new System.EventHandler(this.OnButtonModelDone);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton12);
            this.groupBox3.Controls.Add(this.radioButton11);
            this.groupBox3.Controls.Add(this.radioButton10);
            this.groupBox3.Location = new System.Drawing.Point(774, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(133, 98);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择噪声类型（2#）";
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(18, 62);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(71, 16);
            this.radioButton12.TabIndex = 2;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "平均噪声";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(18, 39);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(71, 16);
            this.radioButton11.TabIndex = 1;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "泊松噪声";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.radioButton10.Location = new System.Drawing.Point(18, 16);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(83, 16);
            this.radioButton10.TabIndex = 0;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "高斯白噪声";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // buttonDectecModeling
            // 
            this.buttonDectecModeling.Location = new System.Drawing.Point(774, 367);
            this.buttonDectecModeling.Name = "buttonDectecModeling";
            this.buttonDectecModeling.Size = new System.Drawing.Size(98, 23);
            this.buttonDectecModeling.TabIndex = 9;
            this.buttonDectecModeling.Text = "探测建模";
            this.buttonDectecModeling.UseVisualStyleBackColor = true;
            this.buttonDectecModeling.Click += new System.EventHandler(this.OnButtonDetectModeling);
            // 
            // textBox_doppler
            // 
            this.textBox_doppler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_doppler.Location = new System.Drawing.Point(774, 43);
            this.textBox_doppler.Multiline = true;
            this.textBox_doppler.Name = "textBox_doppler";
            this.textBox_doppler.Size = new System.Drawing.Size(120, 214);
            this.textBox_doppler.TabIndex = 4;
            // 
            // button_update_config
            // 
            this.button_update_config.Location = new System.Drawing.Point(774, 338);
            this.button_update_config.Name = "button_update_config";
            this.button_update_config.Size = new System.Drawing.Size(98, 23);
            this.button_update_config.TabIndex = 8;
            this.button_update_config.Text = "更新配置文件";
            this.button_update_config.UseVisualStyleBackColor = true;
            this.button_update_config.Click += new System.EventHandler(this.OnButtonUpdateConfigClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label_sel_radartype);
            this.groupBox1.Location = new System.Drawing.Point(774, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 183);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "雷达类型选择";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(15, 146);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(71, 16);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "指挥控制";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(15, 121);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(71, 16);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "电子对抗";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(15, 96);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(47, 16);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "声呐";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(15, 71);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(83, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "超视距雷达";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "多基地雷达";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "多普勒雷达";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::radarsystem.Properties.Resources.duopule;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Location = new System.Drawing.Point(68, 155);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(58, 56);
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDargDrop);
            this.pictureBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.pictureBox4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // button_goback
            // 
            this.button_goback.Location = new System.Drawing.Point(774, 425);
            this.button_goback.Name = "button_goback";
            this.button_goback.Size = new System.Drawing.Size(75, 23);
            this.button_goback.TabIndex = 5;
            this.button_goback.Text = "返回";
            this.button_goback.UseVisualStyleBackColor = true;
            this.button_goback.Click += new System.EventHandler(this.button_goback_Click);
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(774, 501);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(125, 24);
            this.label_state.TabIndex = 3;
            this.label_state.Text = "说明：请将雷达移动到\r\n左边地图对应位置";
            // 
            // label_sel_radartype
            // 
            this.label_sel_radartype.AutoSize = true;
            this.label_sel_radartype.Location = new System.Drawing.Point(-2, -15);
            this.label_sel_radartype.Name = "label_sel_radartype";
            this.label_sel_radartype.Size = new System.Drawing.Size(53, 12);
            this.label_sel_radartype.TabIndex = 1;
            this.label_sel_radartype.Text = "雷达类型";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Image = global::radarsystem.Properties.Resources.pictureBox;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(756, 531);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton9);
            this.groupBox2.Controls.Add(this.radioButton8);
            this.groupBox2.Controls.Add(this.radioButton7);
            this.groupBox2.Location = new System.Drawing.Point(774, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择噪声类型";
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(20, 71);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(71, 16);
            this.radioButton9.TabIndex = 2;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "平均噪声";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(20, 46);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(71, 16);
            this.radioButton8.TabIndex = 1;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "泊松噪声";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(20, 24);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(83, 16);
            this.radioButton7.TabIndex = 0;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "高斯白噪声";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbp_SceneSet);
            this.tabControl1.Controls.Add(this.tbp_CharacterAnalysis);
            this.tabControl1.Location = new System.Drawing.Point(-2, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(925, 560);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.Feature_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 618);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbp_CharacterAnalysis.ResumeLayout(false);
            this.tbp_CharacterAnalysis.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbp_SceneSet.ResumeLayout(false);
            this.tbp_SceneSet.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private string strCollected;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tbp_CharacterAnalysis;
        private System.Windows.Forms.Panel Ypanel;
        private System.Windows.Forms.Panel Xpanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView featurelistView;
        private System.Windows.Forms.ColumnHeader algorithmcolumn;
        private System.Windows.Forms.ColumnHeader numbercolumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox featurecomboBox1;
        private System.Windows.Forms.TabPage tbp_SceneSet;
        private System.Windows.Forms.Button buttonModelDone;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.Button buttonDectecModeling;
        private System.Windows.Forms.Button button_update_config;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button_goback;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label_sel_radartype;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox_doppler;
    }
}

