using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Sructure
{
    public partial class Form1 : Form
    {
        NumericUpDown[] NUD;// araye baraye gereftan adad
        public Form1()
        {
            InitializeComponent();
            numericUpDownCreator();
            SetSize();
        }        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SetSize();
        }   
        //tanzim anasor safhe
        public void SetSize()
        {
            panel2.Size = new Size(tabPage1.Size.Width, tabPage1.Size.Height - (panel1.Size.Height + panel3.Size.Height + panel4.Size.Height + panel5.Size.Height));
            if (NUD != null)            
                for (int i = 0; i < NUD.Length; i++)
                    NUD[i].Size = new Size(panel2.Width - 15, NUD[i].Size.Height);                            
        }        
        //rasm derakht
        public Bitmap DrawTree(Node Head,int height)
        {
            int Width = (int)Math.Pow(2, height) * 100;
            int Height=(height+1) * 100+100;
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            //draw node
            DrawNode(Head, ref bitmap, ref graphics, Width/2,0, 15);                        
            return bitmap;
        }
        // rasm gereh
        public void DrawNode(Node node, ref Bitmap bitmap, ref Graphics graphics, int Width, int Width1, int height)
        {
            // agar gereh vorudi khali naboud rasm kon
            if (node!=null)
            {
                //rasm moraba
            graphics.DrawRectangle(new Pen(Color.Black, 3), Width - 25, height, 50, 50);
           // Brush brush=new Brush();
            SolidBrush myBrush = new SolidBrush(Color.Red);                    
            Font font=new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //neveshtan adad ru axe
            graphics.DrawString(node.Data.ToString(), font, myBrush, Width-10 ,height + 20);
                //agar farzand chap dasht vase ounam rasm kon
            if (node.LeftChild!=null)
            {
                graphics.DrawLine(new Pen(Color.Cyan, 2), Width , height + 50, Width - (Width - Width1) / 2, height + 100);
                DrawNode(node.LeftChild, ref bitmap, ref graphics, Width - (Width - Width1)/2, 0, height + 100);
                
            }
            //agar farzand rast dasht vase ounam rasm kon
            if(node.RightChild!=null)
            {
                graphics.DrawLine(new Pen(Color.Cyan, 2), Width, height + 50, Width + (Width - Width1) / 2, height +100);
                DrawNode(node.RightChild, ref bitmap, ref graphics, Width + (Width - Width1) / 2, Width, height + 100);
            }

            }
        }          
        private void numericUpDown1_ValueChanged_2(object sender, EventArgs e)
        {
            numericUpDownCreator();
        }
        //sakht arraye az componet "numericUpDown" baraye gereftan adad az karbar
        private void numericUpDownCreator()
        {
            if (NUD != null)
            {
                for (int i = 0; i < NUD.Length; i++)
                    panel2.Controls.Remove(NUD[i]);
            }
            NUD = new NumericUpDown[(int)numericUpDown1.Value];
            for (int i = 0; i < NUD.Length; i++)
            {
                NUD[i] = new NumericUpDown();
                panel2.Controls.Add(NUD[i]);
                NUD[i].Size = new System.Drawing.Size(panel2.Size.Width, 0);
                NUD[i].Location = new Point(0, i * NUD[i].Size.Height);
                NUD[i].Minimum = -1000;
                NUD[i].Maximum = 1000;
            }
            numericUpDown2.Maximum = numericUpDown1.Value;
        }
        
        // vaghti karbar ruye button kilik kard 
        private void Do()
        {
            BinerySearch Bst_tree = new BinerySearch();
            MinHeap MH_tree = new MinHeap();
            string Bst_treeStr = "Data :";
            string MH_treeStr = "Data :";
            string Bst_treeStr1 = "Data n:";
            string MH_treeStr1 = "Data n:";
            for (int i = 0; i < NUD.Length; i++)
            {
                Bst_tree.Insert((int)NUD[i].Value);
                MH_tree.Insert((int)NUD[i].Value);
            }
            int[] BstArray = Bst_tree.GetSortedData();
            int[] MinHeapArray = new int[MH_tree.Counter];

            Bitmap Image1 = DrawTree(Bst_tree.Head, Bst_tree.Height);
            Bitmap Image2 = DrawTree(MH_tree.Head, MH_tree.Height);
            Image1.Save("./BST.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Image2.Save("./MinHeap.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox2.Image = Image1;
            pictureBox1.Image = Image2;           
            for (int i = 0; i < MinHeapArray.Length; i++)
                MinHeapArray[i] = MH_tree.Remove();

            for (int i = 0; i < MinHeapArray.Length; i++)
            {
                MH_treeStr += MinHeapArray[i] + " ";
                if ((int)numericUpDown2.Value>i)
                {
                    MH_treeStr1 += MinHeapArray[i] + " ";
                }
            }
            for (int i = 0; i < BstArray.Length; i++)
            {
                Bst_treeStr += BstArray[i] + " ";
                if ((int)numericUpDown2.Value > i)
                {
                    Bst_treeStr1 += BstArray[i] + " ";
                }
            }
            label7.Text = Bst_treeStr;
            label6.Text = MH_treeStr;

            
            if (radioButton1.Checked)
            {
                MinHeap temp= new MinHeap();
                Bst_treeStr1 = "";
                for (int i = 0; i <(int) numericUpDown2.Value; i++)                
                    temp.Insert(MinHeapArray[i]);
                pictureBox3.Image = DrawTree(temp.Head, temp.Height);
            }
            else if (radioButton2.Checked)
            {
                MinHeap temp = new MinHeap();
                Bst_treeStr1 = ""; 
                for (int i = 0; i < (int)numericUpDown2.Value; i++)
                    temp.Insert(BstArray[i]);
                pictureBox3.Image = DrawTree(temp.Head, temp.Height);
            }
            else if (radioButton3.Checked)
            {
                MH_treeStr1 = "";
                BinerySearch temp = new BinerySearch();
                for (int i = 0; i < (int)numericUpDown2.Value; i++)
                    temp.Insert(MinHeapArray[i]);
                pictureBox3.Image = DrawTree(temp.Head, temp.Height);
            }
            else
            {
                MH_treeStr1 = "";
                BinerySearch temp = new BinerySearch();
                for (int i = 0; i < (int)numericUpDown2.Value; i++)
                    temp.Insert(BstArray[i]);
                pictureBox3.Image = DrawTree(temp.Head, temp.Height);
            }
            
         label9.Text=Bst_treeStr1;
         label10.Text = MH_treeStr1;                                                                     
        }
       
        private void numericUpDown1_ValueChanged_3(object sender, EventArgs e)
        {
            numericUpDownCreator();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Do();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
