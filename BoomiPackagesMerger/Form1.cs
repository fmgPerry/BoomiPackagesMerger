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
            var inclMergeResult = MessageBox.Show(text: @"
Add Merge result columns?
Yes - 2 columns added, need to be removed before commit
No - as is, ready to commit", 
caption: @"Add Merge result columns?", 
buttons:MessageBoxButtons.YesNoCancel, 
icon:MessageBoxIcon.Question);

            if (inclMergeResult == DialogResult.Cancel) return;
            
            var includeMergeResults = inclMergeResult == DialogResult.Yes;

            try
            {
                PackageLinesBranches.Clear();

                ReadPackages(basePackageFileName, "base", isBase:true, isIncludeMergeResults:includeMergeResults);
                foreach (var branchPackage in branchPackages)
                {
                    ReadPackages(branchPackage.Path, branchPackage.FileName, isBase:false, isIncludeMergeResults: includeMergeResults);
                }

                MergeIt();
                WriteCSV(includeMergeResults);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var openMergedFile = MessageBox.Show("Open the merged file?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (openMergedFile == DialogResult.Yes)
            {
                Process.Start(mergedFileName);
            }

            buttonMerge.Enabled = false;
        }

        private void WriteCSV(bool isIncludeMergeResults)
        {
            var packageLines = new List<string>();
            var header = $@"PackageId,PackageVersion,ProcessName,PackageNotes{(isIncludeMergeResults ? ", FromFileName, isNew" : "")}";
            packageLines.Add(header);

            var orderedMergedPackageLines = mergedBranchPackages.OrderBy(p => p.ProcessName);
            foreach(var line in orderedMergedPackageLines)
            {
                var packageLine = $@"{line.PackageId},{line.PackageVersion},{line.ProcessName},{line.PackageNotes}";
                packageLine += isIncludeMergeResults ? $@",{line.FromFileName},{line.isNew}" : "";
                packageLines.Add(packageLine);
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
                        var mergedLineVersion = Convert.ToInt32(Convert.ToDecimal(mergedLine.PackageVersion));
                        var branchLineVersion = Convert.ToInt32(Convert.ToDecimal(branchLine.PackageVersion));
                        var index = mergedBranchPackages.IndexOf(mergedLine);
                        var lineToKeep = branchLineVersion > mergedLineVersion ? branchLine : mergedLine;
                        mergedBranchPackages[index] = lineToKeep;

                    }
                }
            }
        }

        private void ReadPackages(string filename, string fromFileName, bool isBase, bool isIncludeMergeResults)
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
                if (isIncludeMergeResults)
                {
                    entry.FromFileName = fromFileName;
                    entry.isNew = !isBase;
                }

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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            labelMergingInto.Text = mergingInto;
            labelBranch1.Text = $@"Branch 1: ";
            labelBranch2.Text = $@"Branch 2: ";
            labelBranch3.Text = $@"Branch 3: ";

            branchPackages.Clear();
            PackageLinesBase.Clear();
            PackageLinesBranches.Clear();
            mergedBranchPackages.Clear();

            buttonMerge.Enabled = true;
        }
    }
}
