using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Windows;
using Analyse;

namespace SyntacticAnalyzer
{
    public partial class SyntacticAnalyzer : Form
    {
        private Analysis Analysis;
        private bool Analysised;
        public SyntacticAnalyzer()
        {
            InitializeComponent();
        }


        private void SyntacticAnalyzer_Load(object sender, EventArgs e)
        {
            Init();
        }


        private void Openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "text(*.txt)|*.txt";
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;
            try
            {
                TextBox.Text = File.ReadAllText(fileName, System.Text.Encoding.Default).Replace("\r", "");
            }
            catch { }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Init()
        {
            ProductionView.Clear();
            FirstView.Clear();
            VnBox.Text = "";
            VtBox.Text = "";
            ItemSetView.Clear();
            TableView.Clear();
            InBox.Text = "";
            ProcessView.Clear();
        }

        private void start_Click(object sender, EventArgs e)
        {
            Analysised = false;
            Init();
            string input = Trim(TextBox.Text);
            if (input == string.Empty)
            {
                return;
            }
            try
            {
                Analysis = new Analysis(input.Split('\n'));
            }
            catch (Exception)
            {
                MessageBox.Show("文法输入错误,分析失败\n");
                return;
            }
            Analysised = true;
            BindData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ins = "→";
            int select = TextBox.SelectionStart;
            string s1 = TextBox.Text.Substring(0, select);
            string s2 = TextBox.Text.Substring(select);
            TextBox.Text = s1 + ins + s2;
            TextBox.Select(select + ins.Length, 0);
            TextBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ins = "ε";
            int select = TextBox.SelectionStart;
            string s1 = TextBox.Text.Substring(0, select);
            string s2 = TextBox.Text.Substring(select);
            TextBox.Text = s1 + ins + s2;
            TextBox.Select(select + ins.Length, 0);
            TextBox.Focus();
        }

        private void ProductionView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public string Trim(string input)
        {
            input = input.Replace("\r", "").Replace(" ", "").Replace("\t", "");
            while (input.Contains("\n\n"))
            {
                input = input.Replace("\n\n", "\n");
            }
            if (input.StartsWith("\n"))
            {
                input = input.Substring(1);
            }
            if (input.EndsWith("\n"))
            {
                input = input.Substring(0, input.Length - 1);
            }
            return input;
        }

        private void BindData()
        {
            BindSymbol();
            BindProductionView();
            BindFirstView();
            BindItemSetView();
            BindTableView();

        }

        private void BindTableView()
        {
            TableView.GridLines = true;
            TableView.View = View.Details;
            TableView.Clear();
            TableView.Columns.Add("状态", 40);
            for (int i = 0; i < Analysis.Va.Count; ++i)
            {
                TableView.Columns.Add(Analysis.Va[i].ToString(), 30);
            }
            for (int i = 0; i < Analysis.Vg.Count; ++i)
            {
                TableView.Columns.Add(Analysis.Vg[i].ToString(), 30);
            }
            int c = TableView.Columns.Count;            
            for (int i = 0; i < Analysis._ItemSetMap.Count; ++i)
            {
                List<String> a = new List<string>();
                a.Add(i.ToString());
                for (int k = 0; k < Analysis.Va.Count; ++k)
                {
                    char ch=Analysis.Va[k];
                    TableIndex index = new TableIndex(i, ch);
                    if (Analysis.Table.dic.ContainsKey(index))
                    {
                        TableItem item = Analysis.Table.dic[index];
                        if (item.ActionType == 'A')
                        {
                            a.Add("acc");
                        }
                        else
                        {
                            a.Add(item.ActionType.ToString() + item.Detail.ToString());
                        }
                    }
                    else
                    {
                        a.Add(".");
                    }                    
                }
                for (int k = 0; k < Analysis.Vg.Count; ++k)
                {
                    char ch = Analysis.Vg[k];
                    TableIndex index = new TableIndex(i, ch);
                    if (Analysis.Table.dic.ContainsKey(index))
                    {
                        TableItem item = Analysis.Table.dic[index];
                        if (item.ActionType == 'A')
                        {
                            a.Add("acc");
                        }
                        else
                        {
                            a.Add(item.ActionType.ToString() + item.Detail.ToString());
                        }
                    }
                    else
                    {
                        a.Add(".");
                    }
                }
                ListViewItem listViewItem = new ListViewItem(a.ToArray());
                TableView.Items.Add(listViewItem);
            }
        }

        private void BindItemSetView()
        {
            ItemSetView.GridLines = true;
            ItemSetView.View = View.Details;
            ItemSetView.Clear();
            ItemSetView.Columns.Add("项目标号", 60);
            ItemSetView.Columns.Add("项目", 200);
            int c = 0, i = 0;
            for (i = 0; i < Analysis._ItemSetMap.Count; ++i)
            {
                c += Analysis._ItemSetMap[i].Count;
            }
            ListViewItem[] p = new ListViewItem[c];
            i = 0;
            foreach (int index in Analysis._ItemSetMap.Keys)
            {
                HashSet<Item> set = Analysis._ItemSetMap[index];
                string tmp = index.ToString();
                foreach (Item item in set)
                {
                    string[] a = new string[2];
                    a[0] = tmp;
                    a[1] = item.ToString();
                    tmp = "";
                    p[i] = new ListViewItem(a);
                    ++i;
                }
            }
            ItemSetView.Items.AddRange(p);
        }

        private void BindSymbol()
        {
            HashSet<char> temp = Analysis.CFG.Vn;
            string s = "";
            foreach (char cr in temp)
            {
                s += cr.ToString() + ",";
            }
            VnBox.Text = s.Substring(0, s.Length - 1);

            temp = Analysis.CFG.Vt;
            s = "";
            foreach (char cr in temp)
            {
                if(cr!=System.Configuration.ConfigurationManager.AppSettings["Empty"][0])
                    s += cr.ToString() + ",";
            }
            VtBox.Text = s.Substring(0, s.Length - 1);
        }

        private void BindProductionView()
        {
            ProductionView.GridLines = true;
            ProductionView.View = View.Details;
            ProductionView.Clear();
            ProductionView.Columns.Add("Id", 40);
            ProductionView.Columns.Add("产生式", 200);
            int c = Analysis.CFG.Productions.Count, i = 0;
            ListViewItem[] p = new ListViewItem[c];
            foreach (Production pro in Analysis.CFG.Productions)
            {
                string[] a = new string[2];
                a[0] = (i + 1).ToString();
                a[1] = pro.ToString();
                p[i] = new ListViewItem(a);
                ++i;
            }
            ProductionView.Items.AddRange(p);
        }

        private void BindFirstView()
        {
            FirstView.GridLines = true;
            FirstView.View = View.Details;
            FirstView.Clear();
            FirstView.Columns.Add("终结符", 60);
            FirstView.Columns.Add("First集", 200);
            int c = Analysis.FirstSets.Count, i = 0;
            ListViewItem[] p = new ListViewItem[c];
            foreach (char ch in Analysis.FirstSets.Keys)
            {
                string[] a = new string[2];
                a[0] = ch.ToString();
                //a[1] = Analysis.FirstSets[ch].Count.ToString();
                HashSet<char> set = Analysis.FirstSets[ch];
                foreach (char cr in set)
                {
                    a[1] += cr.ToString() + ",";
                }
                a[1] = a[1].Substring(0, a[1].Length - 1);
                p[i] = new ListViewItem(a);
                ++i;
            }
            FirstView.Items.AddRange(p);
        }

        private void FirstView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Analyse_Click(object sender, EventArgs e)
        {
            bool succeed = false;
            InBox.Text = InBox.Text.Replace(" ", "").Replace("\t", "");
            if (!Analysised)
            {
                MessageBox.Show("请先分析文法", "Error");
                return;
            }
            try
            {
                succeed = Analysis.Process(InBox.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
                return;
            }
            BindProcessView();
            if (Analysis.AnalysisLogs.Last().Action == "ERR")
            {
                MessageBox.Show("不是该文法的句型", "分析失败");
            }
        }

        private void BindProcessView()
        {
            ProcessView.GridLines = true;
            ProcessView.View = View.Details;
            ProcessView.Clear();
            ProcessView.Columns.Add("步骤", 40);
            ProcessView.Columns.Add("状态栈", 200);
            ProcessView.Columns.Add("符号栈", 200);
            ProcessView.Columns.Add("输入串", 200);
            ProcessView.Columns.Add("ACTION", 60);
            ProcessView.Columns.Add("GOTO", 60);
            foreach (AnalysisLog log in Analysis.AnalysisLogs)
            {
                List<String> a = new List<string>();
                a.Add(log.Index.ToString());
                a.Add(log.StatusStack);
                a.Add(log.CharStack);
                a.Add(log.Remain);
                a.Add(log.Action);
                a.Add(log.GoTo);
                ListViewItem listViewItem = new ListViewItem(a.ToArray());
                ProcessView.Items.Add(listViewItem);
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TextBox.Text == "")
            {
                MessageBox.Show("文法框不能为空");
                return;
            }
            string output = TextBox.Text.Replace("\n","\r\n");
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "text(*.txt)|*.txt";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            try
            {
                File.WriteAllText(fileName, output, System.Text.Encoding.Default);
                MessageBox.Show("保存成功");
            }
            catch { }
        }
    }
}
