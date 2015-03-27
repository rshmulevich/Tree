using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTreeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int root = Convert.ToInt32( args[0]);//tree root value
            double treeSize = Convert.ToInt32(args[1]); ; //tree size value
            string treestring = "";
            
            Tree myTree = new Tree(root);

            myTree.Add(root, (int)treeSize); //building the tree

            double k = Math.Pow(2,treeSize);//calculating the size of the last level

            for (int i = (int)treeSize; i > 0; i--)//printing tree levels
            {
                myTree.Print(null, ref treestring, i);//print level i

                for (int j =(int)(k - treestring.Length/2); j > 0;j-- )//insert spaces to format the tree
                    Console.Write(" ");
                Console.WriteLine(treestring);
                treestring = "";
            }
            Console.Read();
        }
    }
}
