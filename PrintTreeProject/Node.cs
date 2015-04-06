using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTreeProject
{
    class Node
    {
        //TODO: make immutable - DONE
        public int value { get; private set; }
        public Node left { get; private set; }
        public Node right { get; private set; }
        public int level { get; private set; }

        public Node(int root, int newlevel, Node newLeft, Node newRight)
        {
            value = root;
            left = newLeft;
            right = newRight;
            level = newlevel;
        }
    }
}
