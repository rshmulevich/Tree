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
        static void Main(string[] args)
        {
            IConfigurator cnfg = new FileConfigurator("conf.txt");

            var treeConf = cnfg.Read();

            // TODO: Why don't pass configuration to tree as is? - DONE

            Tree myTree = new Tree(treeConf);
            myTree.PrintTree();

        }
       
    }
    
}
