using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomiPackagesMerger
{
    public class BranchPackage
    {
        public string Path { get; set; }
        public string FileName { get; set; }


        public BranchPackage(string path, string fileName)
        {
            Path = path;
            FileName = fileName;
        }

        
    }
}
