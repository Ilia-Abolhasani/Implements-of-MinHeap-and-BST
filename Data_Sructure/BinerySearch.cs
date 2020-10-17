using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Sructure
{
    public class BinerySearch
    {
        public Node Head;
        public int Counter=0;
        public int Height;
        // tabe e sazande
        public BinerySearch()
        {

        }
        // ezafe kardan be data e drakht
        public void Insert(int Data)
        {
            int tempNumber = 1;            
            if (Head == null)            
            {
                Head = new Node(Data,1);
                Height = 1;
            }
            else
            {
                Node temp = Head;
                while (true)
                {
                    if (temp.Data > Data)
                    {
                        if (temp.LeftChild == null)
                        {
                            Node node = new Node(Data, tempNumber);
                            temp.LeftChild = node;
                            node.Father = temp;
                            if (tempNumber > this.Height)
                                Height = tempNumber;
                            break;
                        }
                        else
                        {
                            temp = temp.LeftChild;
                            tempNumber++;
                        }
                    }
                    else
                    {
                        if (temp.RightChild == null)
                        {
                            Node node = new Node(Data, tempNumber);
                            temp.RightChild= node;
                            node.Father = temp;
                            if (tempNumber > this.Height)
                                Height = tempNumber;
                            break;
                        }
                        else
                        {
                            temp = temp.RightChild;
                            tempNumber++;
                        }
                    }
                }
            }
            Counter++;
            
        }
        //gereftan dade hay ba Inorder va ja gozari dar arraye va yek arraye khoruji midahad
        public int[] GetSortedData()
        {
            int[] Ans=new int[Counter];
            InOrder(Head, ref Ans);
            return Ans;
        }
        int tempCounter = 0;
        // peymayesh miyan tartibi
        public void InOrder(Node node, ref int [] Ans)
        {
            if (node.LeftChild != null)
                InOrder(node.LeftChild, ref Ans);
            Ans[tempCounter++] = node.Data;
            if (node.RightChild != null)
                InOrder(node.RightChild, ref  Ans);
        }                       
    }
}
