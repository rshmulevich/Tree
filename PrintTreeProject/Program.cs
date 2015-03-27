using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PrintTreeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //read data from conf.txt file, root and treesize can be configured to be read from [0] [1]
            string[] confFile = File.ReadAllLines(@"..\..\..\conf.txt");

            int root = Convert.ToInt32( confFile[0]);//tree root value //path[1]
            double treeSize = Convert.ToInt32(confFile[1]); ; //tree size value path[2]
            string treestring = "";

            

            

            Tree myTree = new Tree(root);

            myTree.Add(root, (int)treeSize, Convert.ToInt32(confFile[3]), Convert.ToInt32(confFile[4])); //building the tree

            double k = Math.Pow(2,treeSize);//calculating the size of the last level


            StreamWriter sw = new StreamWriter(confFile[2]);
            


                for (int i = (int)treeSize; i > 0; i--)//printing tree levels
                {
                    myTree.Print(null, ref treestring, i);//print level i

                    for (int j = (int)(k - treestring.Length / 2); j > 0; j--)//insert spaces to format the tree
                    {
                        sw.Write (" ");
                        //Console.Write(" ");//console app option
                    }

                    sw.WriteLine(treestring);
                    // Console.WriteLine(treestring);//console app option
                    treestring = "";
                }
                sw.Close();
                sw.Dispose();
            //Console.Read();//console app option
        }
    }
}
