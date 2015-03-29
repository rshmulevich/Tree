using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTreeProject
{
    class Tree
    {
        private Node _top;
        private int _root;
        private int _treeSize;
        private int _leftInc;
        private int _rightInc;

        public Tree(int root, int trSze, int li, int ri)
        {
            //_root = root;
            _treeSize = trSze;
            _leftInc = li;
            _rightInc = ri;


            _top = new Node(root, 0);

            Build(_root, _treeSize, _leftInc, _rightInc);

        }

        //recursive Add
        private void addRec(ref Node myNode, int val, int level, int leftInc, int rightInc)
        {
            
            if (level > 0)//check end of tree
            {
                Node newNode = new Node(val, level);

                myNode = newNode;//attaching new node

                addRec(ref myNode.left, val + leftInc, level - 1,leftInc ,rightInc);//add left node
                addRec(ref myNode.right, val + rightInc, level - 1, leftInc, rightInc);//add right node
                return;

            }
        }
        
        //adding the TOP of the tree
        private void Build(int myValue, int treeSize, int leftInc, int rightInc)
        {
            addRec(ref _top, myValue, treeSize, leftInc, rightInc);

        }
        public string PrintLevel(int level)
        {
            throw new NotImplementedException();
        }

        public string Print()
        {
            throw new NotImplementedException();
        }


        //printing the specified Tree level
        public void Print(Node myNode, ref string newString, int level)
        {
            if (myNode == null)
            {
                myNode = _top;
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


