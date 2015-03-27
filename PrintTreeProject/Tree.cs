using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTreeProject
{
    class Tree
    {
        Node top;

        public Tree(int root)
        {
            top = new Node(root, 0);
        }

        //recursive Add
        private void _addRec(ref Node myNode, int val, int level, int leftInc, int rightInc)
        {
            
            if (level > 0)//check end of tree
            {
                Node newNode = new Node(val, level);

                myNode = newNode;//attaching new node

                _addRec(ref myNode.left, val + leftInc, level - 1,leftInc ,rightInc);//add left node
                _addRec(ref myNode.right, val + rightInc, level - 1, leftInc, rightInc);//add right node
                return;

            }
        }
        
        //adding the TOP of the tree
        public void Add(int myValue, int treeSize, int leftInc, int rightInc)
        {
            _addRec(ref top, myValue, treeSize, leftInc, rightInc);

        }

        //printing the specified Tree level
        public void Print(Node myNode, ref string newString, int level)
        {
            if (myNode == null)
            {
                myNode = top;
            }

            if (myNode.left != null)
            {
                if (myNode.level == level)
                {
                    newString = newString + myNode.value.ToString().PadLeft(3);
                    return;
                }
                Print(myNode.left, ref newString, level);
                
            }
            else
            {
                newString = newString + myNode.value.ToString().PadLeft(3);
            }


            if (myNode.right != null)
            {
                if (myNode.level == level)
                {
                    newString = newString + myNode.value.ToString().PadLeft(3);
                    return;
                }
                Print(myNode.right, ref newString,level);
            }
        }

    }
}


