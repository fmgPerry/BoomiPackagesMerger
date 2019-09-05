using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomiPackagesMerger
{
    public class PackageEntry
    {
        public string PackageId { get; set; }
        public string PackageVersion { get; set; }
        public string ProcessName { get; set; }
        public string PackageNotes { get; set; }
        public string FromFileName { get; set; }
        public bool isNew { get; set; }
    }
}
