using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTreeProject
{
    class Tree
    {
        private Node Top ;
        public static string newString="";


        public Tree(int root, int triSize, int linc, int rinc)
        {
             Top = new Node(root, 0);
            Build(root, triSize, linc, rinc);

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



        public void PrintNode()
        {
            _printNodeRec(ref Top);
            return ;
        }
        private void _printNodeRec(ref Node myNode)
        {
            if (myNode == null)
                return ;
            
            if (myNode.left != null)
            {
                Console.WriteLine(myNode.value.ToString().PadLeft(5));
                Console.Write(myNode.left.value.ToString().PadLeft(3));
                Console.Write(myNode.right.value.ToString().PadLeft(3) + "\n");
                _printNodeRec(ref myNode.left);
            }

            if (myNode.right != null)
            {
                Console.WriteLine(myNode.value.ToString().PadLeft(5));
                Console.Write(myNode.left.value.ToString().PadLeft(3));
                Console.Write(myNode.right.value.ToString().PadLeft(3) + "\n");

                _printNodeRec(ref myNode.right);
            }
            
            return;

        }


        //Recursive printing the specified Tree level
        public string PrintLevel(int level)
        {
            return PrintLevelRec(Top, level);
        }

        //printing the specified Tree level
        private string PrintLevelRec(Node myNode, int level)
        {

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


