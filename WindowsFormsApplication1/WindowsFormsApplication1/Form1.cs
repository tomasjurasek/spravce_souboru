using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

      
       
        //public string root = @"C:/";

        string ext = "*.*";
        string vybrane,vybrane1;
       
        public Form1()
        {
            InitializeComponent();

         
           
             
            

        }


        void FillTree(TreeNodeCollection nodes, string path)
        {
            foreach (var p in Directory.GetDirectories(path))
            {
                try
                {
                    bool hasChildren = Directory.GetDirectories(p).Length > 0;
                    var itm = new TreeNode(p.Substring(p.LastIndexOf("\\") + 1));
                    itm.Tag = p;
                    nodes.Add(itm);
                    if (hasChildren) itm.Nodes.Add("");
                }
                catch { }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // treeView1.LabelEdit = true;
            listBox1.Text = "";
            listBox2.Text = "";

        }

        private void button1_Click(object sender, EventArgs e) // Zobrazeni jednotky k prohlizeni
        {

          

            
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            //e.Node.Nodes.Clear();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                treeView1.Nodes.Clear();
                textBox1.Text = dlg.SelectedPath;
               vybrane = dlg.SelectedPath;

                FillTree(treeView1.Nodes, textBox1.Text);
                
            }


           
        }

        private void button2_Click(object sender, EventArgs e) 
        {
     
          
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                FillTree(treeView1.Nodes, textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var f in Directory.GetFiles(e.Node.Tag as string, ext))
            {
                listBox1.Items.Add(Path.GetFileName(f));

                textBox1.Text = Path.GetDirectoryName(f);
            }
        }

        private void button3_Click_1(object sender, EventArgs e) 
        {

            
        }

        private void smazatToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
            
            
        }

        private void vytvorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* string dir = textBox1.Text;
             Directory.CreateDirectory(dir + @"//Folder");
             * 
            */
           
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "")
            {
                e.Node.Nodes.Clear();
                FillTree(e.Node.Nodes, e.Node.Tag as string);


            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*
             * string filename = listBox1.SelectedItem.ToString();
            FileInfo fileInfo = new FileInfo(filename);
            string nameWithoutPath = fileInfo.Name;
            label1.Text = nameWithoutPath.ToString();
             * */
            label2.Text = listBox1.SelectedItem.ToString();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string klik = textBox1.Text;
            //string slozka =  Path.Combine(klik, "mydir");
          DirectoryInfo di = Directory.CreateDirectory(klik +"//"+ textBox2.Text);
           // label2.Text = Path.GetFullPath(label1.Text);

            
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            //e.Node.Nodes.Clear();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                treeView2.Nodes.Clear();
                textBox3.Text = dlg.SelectedPath;
                vybrane1 = dlg.SelectedPath;
                FillTree(treeView2.Nodes, textBox3.Text);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string klik = textBox3.Text;
            //string slozka =  Path.Combine(klik, "mydir");
            DirectoryInfo di = Directory.CreateDirectory(klik + "//" + textBox4.Text);
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string pall =    @"Program Files" ;
            // TreeNode node = treeView1.SelectedNode;
            //label4.Text = Path.GetFullPath(pall);
            //File.Delete(c);
            // label4.Text = Path.GetFullPath(treeView1.SelectedNode.ToString());
          // string source = @""  + textBox1.Text.ToString() + "\\" + listBox1.SelectedItem.ToString() ;
           //string konec = @"" + textBox2.Text.ToString() + "\\soubur"; 
            //Directory.Delete(node.ToString());
            //File.Copy(textBox1.Text.ToString() +"//"+ listBox1.SelectedItem.ToString(),textBox2.Text.ToString() +"//"+ listBox1.SelectedItem.ToString(),true);
//           File.Copy(source, konec, true);

           FileInfo fi = new FileInfo(textBox1.Text +"//"+ listBox1.SelectedItem);
           fi.CopyTo(textBox2.Text ,true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
                File.Delete(textBox1.Text + "//" + listBox1.SelectedItem);
         
  
              //  Directory.Delete(textBox1.Text,true);
           


        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        
        
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listBox2.Items.Clear();
            foreach (var f in Directory.GetFiles(e.Node.Tag as string, ext))
            {
                listBox2.Items.Add(Path.GetFileName(f));

                textBox3.Text = Path.GetDirectoryName(f);
            }
        }

        private void treeView2_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "")
            {
                e.Node.Nodes.Clear();
                FillTree(e.Node.Nodes, e.Node.Tag as string);


            }
        }

        private void listBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void listBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = listBox2.SelectedItem.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            File.Delete(textBox3.Text + "//" + listBox2.SelectedItem);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Directory.Delete(textBox1.Text, true);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Directory.Delete(textBox3.Text, true);
            treeView2.Nodes.Clear();
            FillTree(treeView2.Nodes, vybrane1);
        }
    }
}
