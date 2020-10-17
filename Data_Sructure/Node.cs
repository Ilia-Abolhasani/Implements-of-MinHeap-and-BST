using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Sructure
{
    public class Node
    {
        //gereh pedar
        public Node Father;
        //gereh farzand chap
        public Node LeftChild;
        //gereh farzand rast
        public Node RightChild;
        // ertefa gereh faghat baraye bst karbord dare vase min heap bahash kari nadarim
        // vase bst ham baraye moghe rasm shekl
        int height;
        public int Data;

       //sazandeh
        public Node()
        {

        }
        //sazandeh ba yek argoman vorudi
        public Node(int Data)
        {
            this.Data = Data;
        }
        //sazandeh ba Do argoman vorudi
        public Node(int Data,int height)
        {
            this.Data = Data;
            this.height = height;
        }
    }
}
