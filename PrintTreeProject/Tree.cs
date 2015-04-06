using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace PrintTreeProject
{
    class Tree
    {
        // TODO: next time, use regions, as I added:
        // TODO: Can you add PrintTree method?
        
        private Node _top ;
        private static string _newString="";

        private Configuration _configuration;

        public Tree(Configuration treeConfig)
        {
            _configuration = treeConfig;
            _top = Build();
        }

        public string PrintTree()
        {
            return PrintTreeRecursive();
        }

        #region private methods
        // TODO: give meaningful name to the addRec method - DONE
        // TODO: Why send Node by ref? - Doesn't work correctly - DONE
        //recursive Add
        private Node AddNode(int value, int level)
        {
            if (level > 0)//check end of tree
            {
                // TODO: proper tabulation -DONE
                return new Node(value, 
                                level,
                                AddNode(value + _configuration.LeftInc, level - 1), 
                                AddNode(value + _configuration.RightInc, level - 1));
            }
            return null;
        }
        
        // TODO: What does parameter myValue mean? - DONE
        //adding the TOP of the tree
        private Node Build()
        {
           return AddNode(_configuration.Root,_configuration.TreeSize);

        }

        //Recursive printing the specified Tree level
        private string PrintTreeRecursive()
        {
            double k = Math.Pow(2, _configuration.TreeSize);//calculating the size of the last level

            // TODO: create method PrintTree
            StreamWriter sw = new StreamWriter(_configuration.Path);

            for (int i = (int)_configuration.TreeSize; i > 0; i--)//printing tree levels
            {
                string treestring = PrintLevelRec(_top, i);

                for (int j = (int)(k - treestring.Length / 2); j > 0; j--)//insert spaces to format the tree
                {
                    sw.Write(" ");
                }

                sw.WriteLine(treestring);
                treestring = "";
                Tree._newString = "";
            }

            sw.Close();
            sw.Dispose();
            return _configuration.Path;
        }


        private string PrintLevelRec(Node myNode, int level)
        {

            if (myNode.left != null)
            {
                if (myNode.level == level)
                {
                   return _newString = _newString + myNode.value.ToString().PadLeft(3);
                    
                }
                PrintLevelRec(myNode.left, level);
                
            }
            else
            {
                return _newString = _newString + myNode.value.ToString().PadLeft(3);
            }


            if (myNode.right != null)
            {
                if (myNode.level == level)
                {
                    return _newString = _newString + myNode.value.ToString().PadLeft(3);

                }
                PrintLevelRec(myNode.right,level);
            }

            return _newString;
        }

        //private string PrintTree(Node node)
        //{
        //    if (node == null)
        //        return "#";
        //    string rec = string.Format("     {0}\n", node.value);
        //    rec += string.Format("   {0}   {1}", PrintTree(node.left),  PrintTree(node.right));
        //    return rec;

        //    //return string.Format("L:{0}  V:{1}   R:{2}", PrintTree(node.left), node.value, PrintTree(node.right));
        //}
        ////// TODO: do not prefix method names with _
        ////private void _printNodeRec(ref Node myNode)
        ////{
        ////    if (myNode == null)
        ////        return ;

        ////    if (myNode.left != null)
        ////    {
        ////        Console.WriteLine(  myNode.value.ToString().PadLeft(5)  );

        ////        Console.Write(myNode.left.value.ToString().PadLeft(3));
        ////        Console.Write(myNode.right.value.ToString().PadLeft(3) + "\n");
        ////        _printNodeRec(ref myNode.left);
        ////    }

        ////    if (myNode.right != null)
        ////    {
        ////        Console.WriteLine(myNode.value.ToString().PadLeft(5));
        ////        Console.Write(myNode.left.value.ToString().PadLeft(3));
        ////        Console.Write(myNode.right.value.ToString().PadLeft(3) + "\n");

        ////        _printNodeRec(ref myNode.right);
        ////    }

        ////    return;

        ////}
        ////printing the specified Tree level

        #endregion private methods
    }
}


