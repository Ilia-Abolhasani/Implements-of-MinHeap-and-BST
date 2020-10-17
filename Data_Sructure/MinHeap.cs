using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Sructure
{
    public class MinHeap
    {
        public Node Head;
        public int Counter = 0;
        public int Height;

        public MinHeap()
        {
        }
        //ezafe kardan
        public void Insert(int Data)
        {
            Counter++;
            SetHeight();
            if (Counter == 1)
                Head = new Node(Data);
            else
            {
                int tempCounter = this.Counter;
                int tempHeight = this.Height;
                Node node = new Node(Data);
                Node TempNode = Head;
                while (tempHeight > 2)
                {
                    if (tempCounter - Cumulative2(tempHeight - 1) <= (int)Math.Pow(2, tempHeight - 2))
                    {
                        TempNode = TempNode.LeftChild;
                        tempCounter -= (int)Math.Pow(2, tempHeight - 2);
                    }
                    else
                    {
                        TempNode = TempNode.RightChild;
                        tempCounter -= (int)Math.Pow(2, tempHeight-1);
                    }
                    tempHeight--;
                }
                if (TempNode.LeftChild == null)
                {
                    TempNode.LeftChild = node;
                    node.Father = TempNode;
                }
                else
                {
                    TempNode.RightChild = node;
                    node.Father = TempNode;
                }
                // baresi heap boudan
                while (node != Head)
                {
                    if (node.Data < node.Father.Data)
                    {
                        int temp = node.Father.Data;
                        node.Father.Data = node.Data;
                        node.Data = temp;
                    }
                    node = node.Father;
                }
            }                       
        }
        //pak kardan
        public int Remove()
        {
            int data = Head.Data;
            if (Counter == 1)
                Head = null;
            else
            {
                int tempCounter = this.Counter;
                int tempHeight = this.Height;
                Node TempNode = Head;
                while (tempHeight > 2)
                {
                    if (tempCounter - Cumulative2(tempHeight - 1) <= (int)Math.Pow(2, tempHeight - 2))
                    {
                        TempNode = TempNode.LeftChild;
                        tempCounter -= (int)Math.Pow(2, tempHeight - 2);
                    }
                    else
                    {
                        TempNode = TempNode.RightChild;
                        tempCounter -= (int)Math.Pow(2, tempHeight-1);
                    }
                    tempHeight--;
                }
                if (TempNode.RightChild == null)
                {
                    Node temp = TempNode.LeftChild;
                    TempNode.LeftChild = null;
                    temp.Father = null;
                    Head.Data = temp.Data;
                }                
                else
                {
                    Node temp = TempNode.RightChild;
                    TempNode.RightChild = null;
                    temp.Father = null;
                    Head.Data = temp.Data;
                }
                Node node = Head;
                // baresi heap boudan
                while (!(node.LeftChild == null && node.RightChild == null))
                {
                    if (node.RightChild == null)
                    {
                        if (node.Data > node.LeftChild.Data)
                        {
                            int temp = node.Data;
                            node.Data = node.LeftChild.Data;
                            node.LeftChild.Data = temp;
                        }
                        break;
                    }
                    else if (node.LeftChild.Data > node.RightChild.Data)
                    {
                        if (node.Data > node.RightChild.Data)
                        {
                            int temp = node.RightChild.Data;
                            node.RightChild.Data = node.Data;
                            node.Data = temp;
                            node = node.RightChild;
                        }
                        else
                            break;
                    }
                    else if (node.LeftChild.Data <= node.RightChild.Data)
                    {
                        if (node.Data > node.LeftChild.Data)
                        {
                            int temp = node.LeftChild.Data;
                            node.LeftChild.Data = node.Data;
                            node.Data = temp;
                            node = node.LeftChild;
                        }
                        else
                            break;
                    }                                            
                }
            }
            Counter--;
            SetHeight();
            return data;
        }
        //be dast avordan ertefa
        public void SetHeight()
        {
            this.Height = 0;
            int temp = Counter;
            while (!(temp % 2 == 0 && temp / 2 == 0))
            {
                temp /= 2;
                this.Height++;
            }
        }
        // tedad gereh bar asas ertefa
        public int Cumulative2(int Height)
        {
            int Ans = 0;
            for (int i = 0; i < Height; i++)
                Ans += (int)Math.Pow(2, i);
            return Ans;
        }
    }
}
