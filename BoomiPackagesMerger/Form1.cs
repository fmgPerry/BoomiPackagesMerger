using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BoomiPackagesMerger
{
    public partial class FormBoomiPackagesMerger : Form
    {
        private static string initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);// @"C:\Users\fmgpr2\Documents\FMGConnect\BoomiPackages";
        private static string mergedFileName = $@"{initialDirectory}\merged.csv";
        private static string mergingInto = @"Merging into: ";

        private static string basePackageFileName;
        private List<BranchPackage> branchPackages = new List<BranchPackage>();
        private List<PackageEntry> PackageLinesBase = new List<PackageEntry>();
        //private List<PackageEntry> PackageLinesBranch = new List<PackageEntry>();
        private List<List<PackageEntry>> PackageLinesBranches = new List<List<PackageEntry>>();
        private List<PackageEntry> mergedBranchPackages = new List<PackageEntry>();

        public FormBoomiPackagesMerger()
        {
            InitializeComponent();
        }


        private void FormBoomiPackagesMerger_Load(object sender, EventArgs e)
        {

        }

        private void buttonPackagesBase_Click(object sender, EventArgs e)
        {
            openFileDialogBase.InitialDirectory = initialDirectory;
            openFileDialogBase.ShowDialog();
        }

        private void buttonPackagesBranch1_Click(object sender, EventArgs e)
        {
            openFileDialogBranch1.InitialDirectory = initialDirectory;
            openFileDialogBranch1.ShowDialog();
        }

        private void buttonPackagesBranch2_Click(object sender, EventArgs e)
        {
            openFileDialogBranch2.InitialDirectory = initialDirectory;
            openFileDialogBranch2.ShowDialog();
        }

        private void buttonPackagesBranch3_Click(object sender, EventArgs e)
        {
            openFileDialogBranch3.InitialDirectory = initialDirectory;
            openFileDialogBranch3.ShowDialog();
        }

        private void openFileDialogBase_FileOk(object sender, CancelEventArgs e)
        {
            basePackageFileName = openFileDialogBase.FileName;
            labelMergingInto.Text = mergingInto + basePackageFileName;            
        }

        private void openFileDialogBranch1_FileOk(object sender, CancelEventArgs e)
        {
            labelBranch1.Text = $@"Branch 1: {openFileDialogBranch1.FileName}";
            branchPackages.Add(new BranchPackage(openFileDialogBranch1.FileName, openFileDialogBranch1.SafeFileName));
        }
        
        private void openFileDialogBranch2_FileOk(object sender, CancelEventArgs e)
        {
            labelBranch2.Text = $@"Branch 2: {openFileDialogBranch2.FileName}";
            branchPackages.Add(new BranchPackage(openFileDialogBranch2.FileName, openFileDialogBranch2.SafeFileName));
        }

        private void openFileDialogBranch3_FileOk(object sender, CancelEventArgs e)
        {
            labelBranch3.Text = $@"Branch 3: {openFileDialogBranch3.FileName}";
            branchPackages.Add(new BranchPackage(openFileDialogBranch3.FileName, openFileDialogBranch3.SafeFileName));
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            try
            {
                PackageLinesBranches.Clear();

                ReadPackages(basePackageFileName, "base", true);
                foreach (var branchPackage in branchPackages)
                {
                    ReadPackages(branchPackage.Path, branchPackage.FileName, false);
                }

                MergeIt();
                WriteCSV();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var dialogResult = MessageBox.Show("Open the merged file?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start(mergedFileName);
            }
        }

        private void WriteCSV()
        {
            var packageLines = new List<string>();
            packageLines.Add(@"PackageId,PackageVersion,ProcessName,PackageNotes,FromFileName,isNew");

            var orderedMergedPackageLines = mergedBranchPackages.OrderBy(p => p.ProcessName);
            foreach(var line in orderedMergedPackageLines)
            {
                var ss = $@"{line.PackageId},{line.PackageVersion},{line.ProcessName},{line.PackageNotes},{line.FromFileName},{line.isNew}";
                packageLines.Add(ss);
            }

            if(File.Exists(mergedFileName))
            {
                File.Delete(mergedFileName);
            }

            using (var file = File.CreateText(mergedFileName))
            {
                foreach (var packageLine in packageLines)
                {
                    file.WriteLine(packageLine);
                }
            }
        }

        private void MergeIt()
        {
            mergedBranchPackages = PackageLinesBase;

            foreach (var packageLinesBranch in PackageLinesBranches)
            {
                foreach (var branchLine in packageLinesBranch)
                {
                    var processName = branchLine.ProcessName;
                    var mergedLine = mergedBranchPackages.FirstOrDefault(m => m.ProcessName == processName);
                    if (mergedLine == null)
                    {
                        mergedBranchPackages.Add(branchLine);
                    }
                    else
                    {
                        branchLine.isNew = mergedLine.isNew;
                        var mergedLineVersion = Convert.ToInt32(mergedLine.PackageVersion);
                        var branchLineVersion = Convert.ToInt32(branchLine.PackageVersion);
                        var index = mergedBranchPackages.IndexOf(mergedLine);
                        mergedBranchPackages[index] = branchLineVersion > mergedLineVersion ? branchLine : mergedLine;

                    }
                }
            }
        }

        private void ReadPackages(string filename, string fromFileName, bool isBase)
        {
            if (isBase)
            {
                PackageLinesBase.Clear();
            }

            var PackageLinesBranch = new List<PackageEntry>();

            var lines = new List<string>();
            var lineCount = 0;
            using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(fileStream))
            {
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (++lineCount > 1) // skipping first line
                    {
                        lines.Add(line);
                    }
                }
            }

            //var headers = lines.First();
            foreach (var line in lines)
            {
                var entries = line.Split(',');
                var entry = new PackageEntry();
                entry.PackageId = entries[0];
                entry.PackageVersion = entries[1];
                entry.ProcessName = entries[2];
                entry.PackageNotes = entries[3];
                entry.FromFileName = fromFileName;
                entry.isNew = !isBase;

                if (isBase)
                {
                    PackageLinesBase.Add(entry);
                }
                else
                {
                    PackageLinesBranch.Add(entry);
                }
            }

            if(!isBase)
            {
                PackageLinesBranches.Add(PackageLinesBranch);
            }
        }
    }
}
