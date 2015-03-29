using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace PrintTreeProject
{
    
    class Program
    {
        private const int POS_ROOT = 0;
        private const int POS_TREE_SIZE = 1;
        private const int POS_PATH = 2;
        private const int POS_LEFT_INC = 3;
        private const int POS_RIGHT_INC = 4;


        static void Main(string[] args)
        {
            // TODO: combine relative path to config file with current path of the application
            

            string dir = System.Reflection.Assembly.GetExecutingAssembly().Location;
            dir = System.IO.Path.GetDirectoryName(dir);
            string[] confFile = File.ReadAllLines(dir+@"\conf.txt");

            // TODO: add some content checking. What if file is empty? what if format doesn't reflect exactly required format?
            int root;//tree root value //path[0]
            double treeSize;//tree size value path[1]
            string path = confFile[POS_PATH];
            int leftInc;
            int rightInc;

            if (!int.TryParse(confFile[POS_ROOT], out root))
            {
                Console.WriteLine("Root can't be read: " + confFile[POS_ROOT]);
                return;
            }

            if (!double.TryParse(confFile[POS_TREE_SIZE], out treeSize))
            {
                Console.WriteLine("Tree Siize can't be read: " + confFile[POS_TREE_SIZE]);
                return;
            }
            
            if (!int.TryParse(confFile[POS_LEFT_INC], out leftInc))
            {
                Console.WriteLine("Left Inc can't be read: " + confFile[POS_LEFT_INC]);
                return;
            }
            
            if (!int.TryParse(confFile[POS_RIGHT_INC], out rightInc))
            {
                Console.WriteLine("Right Inc can't be read: " + confFile[POS_RIGHT_INC]);
                return;
            }


            string treestring = "";

           // root=Convert.ToInt32( ReadSetting("Root"));

            

            Tree myTree = new Tree(root);

            myTree.Add(root, (int)treeSize, Convert.ToInt32(leftInc), Convert.ToInt32(rightInc)); //building the tree

            double k = Math.Pow(2,treeSize);//calculating the size of the last level

            // TODO: create method PrintTree
            StreamWriter sw = new StreamWriter(path);
            


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
        //static string ReadSetting(string key)
        //{
        //    try
        //    {
        //        var appSettings = ConfigurationManager.AppSettings;
        //        string result = appSettings[key] ?? "Not Found";
        //        return result;
        //    }
        //    catch (ConfigurationErrorsException)
        //    {
        //        Console.WriteLine("Error reading app settings");
        //        return "Error reading app settings";
        //    }
        //}
    }
    
}
