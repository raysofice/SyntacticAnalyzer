namespace SyntacticAnalyzer
{
    partial class SyntacticAnalyzer
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.VtBox = new System.Windows.Forms.RichTextBox();
            this.VnBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FirstView = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.ProductionView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.Openfile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TableView = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ItemSetView = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Analyse = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.InBox = new System.Windows.Forms.TextBox();
            this.ProcessView = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(13, 42);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(193, 331);
            this.TextBox.TabIndex = 5;
            this.TextBox.Text = "";
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 524);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.VtBox);
            this.tabPage1.Controls.Add(this.VnBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.FirstView);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.ProductionView);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.start);
            this.tabPage1.Controls.Add(this.Openfile);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.TextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(789, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文法与基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // VtBox
            // 
            this.VtBox.Location = new System.Drawing.Point(485, 31);
            this.VtBox.Name = "VtBox";
            this.VtBox.Size = new System.Drawing.Size(229, 55);
            this.VtBox.TabIndex = 18;
            this.VtBox.Text = "";
            // 
            // VnBox
            // 
            this.VnBox.Location = new System.Drawing.Point(234, 31);
            this.VnBox.Name = "VnBox";
            this.VnBox.Size = new System.Drawing.Size(193, 55);
            this.VnBox.TabIndex = 17;
            this.VnBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "非终结符";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(571, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "终结符";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "First集";
            // 
            // FirstView
            // 
            this.FirstView.GridLines = true;
            this.FirstView.Location = new System.Drawing.Point(485, 114);
            this.FirstView.Name = "FirstView";
            this.FirstView.Size = new System.Drawing.Size(229, 310);
            this.FirstView.TabIndex = 13;
            this.FirstView.UseCompatibleStateImageBehavior = false;
            this.FirstView.SelectedIndexChanged += new System.EventHandler(this.FirstView_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "产生式";
            // 
            // ProductionView
            // 
            this.ProductionView.GridLines = true;
            this.ProductionView.Location = new System.Drawing.Point(234, 114);
            this.ProductionView.Name = "ProductionView";
            this.ProductionView.Size = new System.Drawing.Size(203, 310);
            this.ProductionView.TabIndex = 11;
            this.ProductionView.UseCompatibleStateImageBehavior = false;
            this.ProductionView.SelectedIndexChanged += new System.EventHandler(this.ProductionView_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "辅助输入工具";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "→";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(104, 395);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(103, 73);
            this.start.TabIndex = 8;
            this.start.Text = "开始分析";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Openfile
            // 
            this.Openfile.Location = new System.Drawing.Point(13, 395);
            this.Openfile.Name = "Openfile";
            this.Openfile.Size = new System.Drawing.Size(85, 29);
            this.Openfile.TabIndex = 7;
            this.Openfile.Text = "打开文件...";
            this.Openfile.UseVisualStyleBackColor = true;
            this.Openfile.Click += new System.EventHandler(this.Openfile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "ε";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TableView);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.ItemSetView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "项目集与分析表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TableView
            // 
            this.TableView.GridLines = true;
            this.TableView.Location = new System.Drawing.Point(289, 25);
            this.TableView.Name = "TableView";
            this.TableView.Size = new System.Drawing.Size(494, 467);
            this.TableView.TabIndex = 19;
            this.TableView.UseCompatibleStateImageBehavior = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(500, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "LR（1）分析表";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "项目集";
            // 
            // ItemSetView
            // 
            this.ItemSetView.GridLines = true;
            this.ItemSetView.Location = new System.Drawing.Point(6, 25);
            this.ItemSetView.Name = "ItemSetView";
            this.ItemSetView.Size = new System.Drawing.Size(262, 467);
            this.ItemSetView.TabIndex = 12;
            this.ItemSetView.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Analyse);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.InBox);
            this.tabPage3.Controls.Add(this.ProcessView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(789, 498);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "语法分析";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Analyse
            // 
            this.Analyse.Location = new System.Drawing.Point(491, 25);
            this.Analyse.Name = "Analyse";
            this.Analyse.Size = new System.Drawing.Size(75, 23);
            this.Analyse.TabIndex = 23;
            this.Analyse.Text = "分析";
            this.Analyse.UseVisualStyleBackColor = true;
            this.Analyse.Click += new System.EventHandler(this.Analyse_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "输入待识别串";
            // 
            // InBox
            // 
            this.InBox.Location = new System.Drawing.Point(110, 27);
            this.InBox.Name = "InBox";
            this.InBox.Size = new System.Drawing.Size(356, 21);
            this.InBox.TabIndex = 21;
            // 
            // ProcessView
            // 
            this.ProcessView.GridLines = true;
            this.ProcessView.Location = new System.Drawing.Point(13, 64);
            this.ProcessView.Name = "ProcessView";
            this.ProcessView.Size = new System.Drawing.Size(756, 400);
            this.ProcessView.TabIndex = 20;
            this.ProcessView.UseCompatibleStateImageBehavior = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 439);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 29);
            this.button3.TabIndex = 19;
            this.button3.Text = "保存文法...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SyntacticAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 548);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "SyntacticAnalyzer";
            this.Text = "SyntacticAnalyzer";
            this.Load += new System.EventHandler(this.SyntacticAnalyzer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button Openfile;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView ProductionView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView FirstView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox VtBox;
        private System.Windows.Forms.RichTextBox VnBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView TableView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView ItemSetView;
        private System.Windows.Forms.Button Analyse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox InBox;
        private System.Windows.Forms.ListView ProcessView;
        private System.Windows.Forms.Button button3;


    }
}

