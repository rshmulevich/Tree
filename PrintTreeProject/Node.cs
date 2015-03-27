using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTreeProject
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
        public int level;

        public Node(int root, int floor)
        {
            value = root;
            left = null;
            right = null;
            level = floor;
        }
    }
}
