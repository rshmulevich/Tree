using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTreeProject
{
    class Tree
    {
        private Node Top ;//{ get; private set; }
       // private int _root;
        //private int _treeSize;
        //private int _leftInc;
        //private int _rightInc;
        public static string newString="";


        public Tree(int root, int trSze, int li, int ri)
        {
            //_treeSize = trSze;
            //_leftInc = li;
            //_rightInc = ri;
            //_root = root;

            Top = new Node(root, 0);

            Build(root, trSze, li, ri);

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
            addRec(ref Top, myValue, treeSize, leftInc, rightInc);

        }
        //public string PrintLevel(int level)
        //{


        //    throw new NotImplementedException();
        //}

        //public string Print(Node myNode)
        //{
            
        //    if (myNode.left != null)
        //    {
                
        //        newString = newString + myNode.value.ToString().PadLeft(3);

        //        Print(myNode.left);

        //        return newString;


        //    }
        //    else
        //    {
        //        newString = newString + myNode.value.ToString().PadLeft(3);
        //    }


        //    if (myNode.right != null)
        //    {

        //        Print(myNode.right); 
                
        //        return newString = newString + myNode.value.ToString().PadLeft(3);
        //    }



        //    throw new NotImplementedException();
        //}


        //Recursive printing the specified Tree level
        public string PrintLevel(int level)
        {
            return PrintLevelRec(Top, level);
        }

        //printing the specified Tree level
        private string PrintLevelRec(Node myNode, int level)
        {
            if (myNode == null)
            {
                myNode = Top;
            }

            if (myNode.left != null)
            {
                if (myNode.level == level)
                {
                   return newString = newString + myNode.value.ToString().PadLeft(3);
                    
                }
                PrintLevelRec(myNode.left, level);
                
            }
            else
            {
                return newString = newString + myNode.value.ToString().PadLeft(3);
            }


            if (myNode.right != null)
            {
                if (myNode.level == level)
                {
                    return newString = newString + myNode.value.ToString().PadLeft(3);

                }
                PrintLevelRec(myNode.right,level);
            }

            return newString;
        }

    }
}


