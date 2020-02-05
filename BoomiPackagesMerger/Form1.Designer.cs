namespace BoomiPackagesMerger
{
    partial class FormBoomiPackagesMerger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialogBase = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogBranch1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonPackagesBase = new System.Windows.Forms.Button();
            this.buttonPackagesBranch1 = new System.Windows.Forms.Button();
            this.labelMergingInto = new System.Windows.Forms.Label();
            this.buttonPackagesBranch2 = new System.Windows.Forms.Button();
            this.buttonPackagesBranch3 = new System.Windows.Forms.Button();
            this.labelBranch1 = new System.Windows.Forms.Label();
            this.labelBranch2 = new System.Windows.Forms.Label();
            this.labelBranch3 = new System.Windows.Forms.Label();
            this.openFileDialogBranch2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogBranch3 = new System.Windows.Forms.OpenFileDialog();
            this.buttonMerge = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialogBase
            // 
            this.openFileDialogBase.FileName = "openFileDialog1";
            this.openFileDialogBase.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogBase_FileOk);
            // 
            // openFileDialogBranch1
            // 
            this.openFileDialogBranch1.FileName = "openFileDialog2";
            this.openFileDialogBranch1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogBranch1_FileOk);
            // 
            // buttonPackagesBase
            // 
            this.buttonPackagesBase.Location = new System.Drawing.Point(12, 33);
            this.buttonPackagesBase.Name = "buttonPackagesBase";
            this.buttonPackagesBase.Size = new System.Drawing.Size(125, 23);
            this.buttonPackagesBase.TabIndex = 0;
            this.buttonPackagesBase.Text = "Choose base";
            this.buttonPackagesBase.UseVisualStyleBackColor = true;
            this.buttonPackagesBase.Click += new System.EventHandler(this.buttonPackagesBase_Click);
            // 
            // buttonPackagesBranch1
            // 
            this.buttonPackagesBranch1.Location = new System.Drawing.Point(12, 62);
            this.buttonPackagesBranch1.Name = "buttonPackagesBranch1";
            this.buttonPackagesBranch1.Size = new System.Drawing.Size(125, 23);
            this.buttonPackagesBranch1.TabIndex = 1;
            this.buttonPackagesBranch1.Text = "Choose branch 1";
            this.buttonPackagesBranch1.UseVisualStyleBackColor = true;
            this.buttonPackagesBranch1.Click += new System.EventHandler(this.buttonPackagesBranch1_Click);
            // 
            // labelMergingInto
            // 
            this.labelMergingInto.AutoSize = true;
            this.labelMergingInto.Location = new System.Drawing.Point(143, 38);
            this.labelMergingInto.Name = "labelMergingInto";
            this.labelMergingInto.Size = new System.Drawing.Size(71, 13);
            this.labelMergingInto.TabIndex = 2;
            this.labelMergingInto.Text = "Merging into: ";
            // 
            // buttonPackagesBranch2
            // 
            this.buttonPackagesBranch2.Location = new System.Drawing.Point(12, 91);
            this.buttonPackagesBranch2.Name = "buttonPackagesBranch2";
            this.buttonPackagesBranch2.Size = new System.Drawing.Size(125, 23);
            this.buttonPackagesBranch2.TabIndex = 3;
            this.buttonPackagesBranch2.Text = "Choose branch 2";
            this.buttonPackagesBranch2.UseVisualStyleBackColor = true;
            this.buttonPackagesBranch2.Click += new System.EventHandler(this.buttonPackagesBranch2_Click);
            // 
            // buttonPackagesBranch3
            // 
            this.buttonPackagesBranch3.Location = new System.Drawing.Point(12, 120);
            this.buttonPackagesBranch3.Name = "buttonPackagesBranch3";
            this.buttonPackagesBranch3.Size = new System.Drawing.Size(125, 23);
            this.buttonPackagesBranch3.TabIndex = 4;
            this.buttonPackagesBranch3.Text = "Choose branch 3";
            this.buttonPackagesBranch3.UseVisualStyleBackColor = true;
            this.buttonPackagesBranch3.Click += new System.EventHandler(this.buttonPackagesBranch3_Click);
            // 
            // labelBranch1
            // 
            this.labelBranch1.AutoSize = true;
            this.labelBranch1.Location = new System.Drawing.Point(143, 67);
            this.labelBranch1.Name = "labelBranch1";
            this.labelBranch1.Size = new System.Drawing.Size(56, 13);
            this.labelBranch1.TabIndex = 5;
            this.labelBranch1.Text = "Branch 1: ";
            // 
            // labelBranch2
            // 
            this.labelBranch2.AutoSize = true;
            this.labelBranch2.Location = new System.Drawing.Point(143, 96);
            this.labelBranch2.Name = "labelBranch2";
            this.labelBranch2.Size = new System.Drawing.Size(56, 13);
            this.labelBranch2.TabIndex = 6;
            this.labelBranch2.Text = "Branch 2: ";
            // 
            // labelBranch3
            // 
            this.labelBranch3.AutoSize = true;
            this.labelBranch3.Location = new System.Drawing.Point(143, 125);
            this.labelBranch3.Name = "labelBranch3";
            this.labelBranch3.Size = new System.Drawing.Size(56, 13);
            this.labelBranch3.TabIndex = 7;
            this.labelBranch3.Text = "Branch 3: ";
            // 
            // openFileDialogBranch2
            // 
            this.openFileDialogBranch2.FileName = "openFileDialog2";
            this.openFileDialogBranch2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogBranch2_FileOk);
            // 
            // openFileDialogBranch3
            // 
            this.openFileDialogBranch3.FileName = "openFileDialog2";
            this.openFileDialogBranch3.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogBranch3_FileOk);
            // 
            // buttonMerge
            // 
            this.buttonMerge.Location = new System.Drawing.Point(12, 162);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(125, 23);
            this.buttonMerge.TabIndex = 8;
            this.buttonMerge.Text = "Merge";
            this.buttonMerge.UseVisualStyleBackColor = true;
            this.buttonMerge.Click += new System.EventHandler(this.buttonMerge_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 191);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(125, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // FormBoomiPackagesMerger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 238);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonMerge);
            this.Controls.Add(this.labelBranch3);
            this.Controls.Add(this.labelBranch2);
            this.Controls.Add(this.labelBranch1);
            this.Controls.Add(this.buttonPackagesBranch3);
            this.Controls.Add(this.buttonPackagesBranch2);
            this.Controls.Add(this.labelMergingInto);
            this.Controls.Add(this.buttonPackagesBranch1);
            this.Controls.Add(this.buttonPackagesBase);
            this.Name = "FormBoomiPackagesMerger";
            this.Text = "Boomi Packages Merger";
            this.Load += new System.EventHandler(this.FormBoomiPackagesMerger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogBase;
        private System.Windows.Forms.OpenFileDialog openFileDialogBranch1;
        private System.Windows.Forms.Button buttonPackagesBase;
        private System.Windows.Forms.Button buttonPackagesBranch1;
        private System.Windows.Forms.Label labelMergingInto;
        private System.Windows.Forms.Button buttonPackagesBranch2;
        private System.Windows.Forms.Button buttonPackagesBranch3;
        private System.Windows.Forms.Label labelBranch1;
        private System.Windows.Forms.Label labelBranch2;
        private System.Windows.Forms.Label labelBranch3;
        private System.Windows.Forms.OpenFileDialog openFileDialogBranch2;
        private System.Windows.Forms.OpenFileDialog openFileDialogBranch3;
        private System.Windows.Forms.Button buttonMerge;
        private System.Windows.Forms.Button buttonReset;
    }
}

