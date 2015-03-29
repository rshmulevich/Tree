using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;


namespace PrintTreeProject
{
    public class Configuration
    {
        

        public int Root     { get; private set; }
        public int TreeSize { get; private set; }
        public int LeftInc  { get; private set; }
        public int RightInc { get; private set; }
        public string Path  { get; private set; }
        
        public Configuration(int root, int treesize, int leftInc, int rightInc, string path)
        {
            Root = root;
            TreeSize = treesize;
            LeftInc = leftInc;
            RightInc = rightInc;
            Path = path;
        }

       

    }

    
}
