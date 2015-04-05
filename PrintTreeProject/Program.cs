﻿using System;
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


        static void Main(string[] args)
        {
            IConfigurator cnfg = new FileConfigurator("conf.txt");

            var treeConf = cnfg.Read();

            // TODO: Why don't pass configuration to tree as is?

            Tree myTree = new Tree(treeConf.Root, treeConf.TreeSize, treeConf.LeftInc, treeConf.RightInc);
            //string strTree = myTree.Print();
            //Console.WriteLine(strTree);

            double k = Math.Pow(2,treeConf.TreeSize);//calculating the size of the last level

            // TODO: create method PrintTree
            StreamWriter sw = new StreamWriter(treeConf.Path);

            //Node initNode = null;

           

            for (int i = (int)treeConf.TreeSize; i > 0; i--)//printing tree levels
            {
                string treestring = myTree.PrintLevel(i);

                for (int j = (int)(k - treestring.Length / 2); j > 0; j--)//insert spaces to format the tree
                {
                    sw.Write (" ");
                    //Console.Write(" ");//console app option
                }

                sw.WriteLine(treestring);
                // Console.WriteLine(treestring);//console app option
                treestring = "";
                Tree.newString ="";
            }
            //printing nodes
           myTree.PrintNode();
           Console.ReadLine();

            sw.Close();
            sw.Dispose();
        //Console.Read();//console app option
        }
       
    }
    
}
