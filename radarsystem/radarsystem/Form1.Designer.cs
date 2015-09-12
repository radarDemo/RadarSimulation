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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbp_SceneSet = new System.Windows.Forms.TabPage();
            this.button_goback = new System.Windows.Forms.Button();
            this.textBox_doppler = new System.Windows.Forms.TextBox();
            this.label_state = new System.Windows.Forms.Label();
            this.checkedListBox_radartype = new System.Windows.Forms.CheckedListBox();
            this.label_sel_radartype = new System.Windows.Forms.Label();
            this.tbp_SetModule = new System.Windows.Forms.TabPage();
            this.btn_Finish = new System.Windows.Forms.Button();
            this.clb_setMod = new System.Windows.Forms.CheckedListBox();
            this.label_addNoiseType = new System.Windows.Forms.Label();
            this.cob_setModules = new System.Windows.Forms.ComboBox();
            this.tbp_CharacterAnalysis = new System.Windows.Forms.TabPage();
            this.Ypanel = new System.Windows.Forms.Panel();
            this.Xpanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.featurelistView = new System.Windows.Forms.ListView();
            this.algorithmcolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numbercolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.featurecomboBox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tbp_SceneSet.SuspendLayout();
            this.tbp_SetModule.SuspendLayout();
            this.tbp_CharacterAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbp_SceneSet);
            this.tabControl1.Controls.Add(this.tbp_SetModule);
            this.tabControl1.Controls.Add(this.tbp_CharacterAnalysis);
            this.tabControl1.Location = new System.Drawing.Point(-2, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 505);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.Feature_SelectedIndexChanged);
            // 
            // tbp_SceneSet
            // 
            this.tbp_SceneSet.Controls.Add(this.pictureBox4);
            this.tbp_SceneSet.Controls.Add(this.button_goback);
            this.tbp_SceneSet.Controls.Add(this.textBox_doppler);
            this.tbp_SceneSet.Controls.Add(this.label_state);
            this.tbp_SceneSet.Controls.Add(this.checkedListBox_radartype);
            this.tbp_SceneSet.Controls.Add(this.label_sel_radartype);
            this.tbp_SceneSet.Controls.Add(this.pictureBox3);
            this.tbp_SceneSet.Location = new System.Drawing.Point(4, 22);
            this.tbp_SceneSet.Name = "tbp_SceneSet";
            this.tbp_SceneSet.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_SceneSet.Size = new System.Drawing.Size(774, 479);
            this.tbp_SceneSet.TabIndex = 0;
            this.tbp_SceneSet.Text = "岸基场景设置";
            this.tbp_SceneSet.UseVisualStyleBackColor = true;
            // 
            // button_goback
            // 
            this.button_goback.Location = new System.Drawing.Point(645, 208);
            this.button_goback.Name = "button_goback";
            this.button_goback.Size = new System.Drawing.Size(75, 23);
            this.button_goback.TabIndex = 5;
            this.button_goback.Text = "返回";
            this.button_goback.UseVisualStyleBackColor = true;
            this.button_goback.Click += new System.EventHandler(this.button_goback_Click);
            // 
            // textBox_doppler
            // 
            this.textBox_doppler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_doppler.Location = new System.Drawing.Point(645, 77);
            this.textBox_doppler.Multiline = true;
            this.textBox_doppler.Name = "textBox_doppler";
            this.textBox_doppler.Size = new System.Drawing.Size(120, 94);
            this.textBox_doppler.TabIndex = 4;
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(643, 328);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(125, 24);
            this.label_state.TabIndex = 3;
            this.label_state.Text = "说明：请将雷达移动到\r\n左边地图对应位置";
            // 
            // checkedListBox_radartype
            // 
            this.checkedListBox_radartype.CheckOnClick = true;
            this.checkedListBox_radartype.FormattingEnabled = true;
            this.checkedListBox_radartype.Items.AddRange(new object[] {
            "多普勒雷达",
            "多基地雷达",
            "超视距雷达",
            "声呐雷达"});
            this.checkedListBox_radartype.Location = new System.Drawing.Point(645, 77);
            this.checkedListBox_radartype.Name = "checkedListBox_radartype";
            this.checkedListBox_radartype.Size = new System.Drawing.Size(120, 84);
            this.checkedListBox_radartype.TabIndex = 2;
            this.checkedListBox_radartype.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_radartype_SelectedIndexChanged);
            // 
            // label_sel_radartype
            // 
            this.label_sel_radartype.AutoSize = true;
            this.label_sel_radartype.Location = new System.Drawing.Point(643, 38);
            this.label_sel_radartype.Name = "label_sel_radartype";
            this.label_sel_radartype.Size = new System.Drawing.Size(77, 12);
            this.label_sel_radartype.TabIndex = 1;
            this.label_sel_radartype.Text = "雷达类型选择";
            // 
            // tbp_SetModule
            // 
            this.tbp_SetModule.Controls.Add(this.btn_Finish);
            this.tbp_SetModule.Controls.Add(this.clb_setMod);
            this.tbp_SetModule.Controls.Add(this.label_addNoiseType);
            this.tbp_SetModule.Controls.Add(this.cob_setModules);
            this.tbp_SetModule.Location = new System.Drawing.Point(4, 22);
            this.tbp_SetModule.Name = "tbp_SetModule";
            this.tbp_SetModule.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_SetModule.Size = new System.Drawing.Size(774, 479);
            this.tbp_SetModule.TabIndex = 1;
            this.tbp_SetModule.Text = "探测建模";
            this.tbp_SetModule.UseVisualStyleBackColor = true;
            // 
            // btn_Finish
            // 
            this.btn_Finish.Location = new System.Drawing.Point(630, 195);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(75, 23);
            this.btn_Finish.TabIndex = 3;
            this.btn_Finish.Text = "选择完毕";
            this.btn_Finish.UseVisualStyleBackColor = true;
            this.btn_Finish.Click += new System.EventHandler(this.btn_Finish_Click);
            // 
            // clb_setMod
            // 
            this.clb_setMod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clb_setMod.CheckOnClick = true;
            this.clb_setMod.FormattingEnabled = true;
            this.clb_setMod.Items.AddRange(new object[] {
            "高斯白噪声",
            "泊松噪声",
            "平均噪声"});
            this.clb_setMod.Location = new System.Drawing.Point(651, 124);
            this.clb_setMod.Name = "clb_setMod";
            this.clb_setMod.Size = new System.Drawing.Size(120, 48);
            this.clb_setMod.TabIndex = 2;
            this.clb_setMod.SelectedIndexChanged += new System.EventHandler(this.clb_setMod_SelectedIndexChanged);
            // 
            // label_addNoiseType
            // 
            this.label_addNoiseType.AutoSize = true;
            this.label_addNoiseType.Location = new System.Drawing.Point(628, 93);
            this.label_addNoiseType.Name = "label_addNoiseType";
            this.label_addNoiseType.Size = new System.Drawing.Size(83, 12);
            this.label_addNoiseType.TabIndex = 1;
            this.label_addNoiseType.Text = "添加噪声种类:";
            // 
            // cob_setModules
            // 
            this.cob_setModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_setModules.FormattingEnabled = true;
            this.cob_setModules.Items.AddRange(new object[] {
            "多普勒雷达",
            "多基地雷达",
            "超视距雷达",
            "声呐雷达"});
            this.cob_setModules.Location = new System.Drawing.Point(630, 52);
            this.cob_setModules.Name = "cob_setModules";
            this.cob_setModules.Size = new System.Drawing.Size(121, 20);
            this.cob_setModules.TabIndex = 0;
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
            this.tbp_CharacterAnalysis.Size = new System.Drawing.Size(774, 479);
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
            this.panel1.Location = new System.Drawing.Point(71, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 442);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // featurelistView
            // 
            this.featurelistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.algorithmcolumn,
            this.numbercolumn});
            this.featurelistView.Location = new System.Drawing.Point(643, 76);
            this.featurelistView.Name = "featurelistView";
            this.featurelistView.Size = new System.Drawing.Size(121, 178);
            this.featurelistView.TabIndex = 3;
            this.featurelistView.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 23);
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
            this.featurecomboBox1.Location = new System.Drawing.Point(643, 49);
            this.featurecomboBox1.Name = "featurecomboBox1";
            this.featurecomboBox1.Size = new System.Drawing.Size(121, 20);
            this.featurecomboBox1.TabIndex = 2;
            this.featurecomboBox1.SelectedIndexChanged += new System.EventHandler(this.featurecomboBox1_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
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
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Image = global::radarsystem.Properties.Resources.pictureBox;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(637, 479);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::radarsystem.Properties.Resources.header;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(778, 56);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 573);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tbp_SceneSet.ResumeLayout(false);
            this.tbp_SceneSet.PerformLayout();
            this.tbp_SetModule.ResumeLayout(false);
            this.tbp_SetModule.PerformLayout();
            this.tbp_CharacterAnalysis.ResumeLayout(false);
            this.tbp_CharacterAnalysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbp_SceneSet;
        private System.Windows.Forms.TabPage tbp_SetModule;
        private System.Windows.Forms.TabPage tbp_CharacterAnalysis;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.CheckedListBox checkedListBox_radartype;
        private System.Windows.Forms.Label label_sel_radartype;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox_doppler;
        private System.Windows.Forms.Button button_goback;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.CheckedListBox clb_setMod;
        private System.Windows.Forms.Label label_addNoiseType;
        private System.Windows.Forms.ComboBox cob_setModules;
        private string strCollected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox featurecomboBox1;
        private System.Windows.Forms.ListView featurelistView;
        private System.Windows.Forms.ColumnHeader algorithmcolumn;
        private System.Windows.Forms.ColumnHeader numbercolumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Xpanel;
        private System.Windows.Forms.Panel Ypanel;
    }
}

