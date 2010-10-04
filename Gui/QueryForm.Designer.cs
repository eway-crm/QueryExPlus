namespace QueryExPlus  
{
    partial class QueryForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.splitBrowser = new System.Windows.Forms.SplitContainer();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panRunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panExecTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabResults = new System.Windows.Forms.TabControl();
            this.tmrExecTime = new System.Windows.Forms.Timer(this.components);
            this.splitBrowser.Panel1.SuspendLayout();
            this.splitBrowser.Panel2.SuspendLayout();
            this.splitBrowser.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitBrowser
            // 
            this.splitBrowser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBrowser.Location = new System.Drawing.Point(0, 0);
            this.splitBrowser.Name = "splitBrowser";
            // 
            // splitBrowser.Panel1
            // 
            this.splitBrowser.Panel1.Controls.Add(this.cboDatabase);
            this.splitBrowser.Panel1.Controls.Add(this.label1);
            this.splitBrowser.Panel1.Controls.Add(this.treeView);
            // 
            // splitBrowser.Panel2
            // 
            this.splitBrowser.Panel2.Controls.Add(this.splitContainer2);
            this.splitBrowser.Size = new System.Drawing.Size(764, 417);
            this.splitBrowser.SplitterDistance = 227;
            this.splitBrowser.TabIndex = 0;
            this.splitBrowser.TabStop = false;
            // 
            // cboDatabase
            // 
            this.cboDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(3, 25);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(217, 21);
            this.cboDatabase.TabIndex = 1;
            this.cboDatabase.TabStop = false;
            this.cboDatabase.Enter += new System.EventHandler(this.cboDatabase_Enter);
            this.cboDatabase.SelectedIndexChanged += new System.EventHandler(this.cboDatabase_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database";
            this.label1.VisibleChanged += new System.EventHandler(this.label1_VisibleChanged);
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(3, 52);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(217, 349);
            this.treeView.TabIndex = 2;
            this.treeView.TabStop = false;
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseUp);
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtQuery);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStripContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(533, 417);
            this.splitContainer2.SplitterDistance = 166;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // txtQuery
            // 
            this.txtQuery.AcceptsReturn = true;
            this.txtQuery.AcceptsTab = true;
            this.txtQuery.AllowDrop = true;
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQuery.Size = new System.Drawing.Size(529, 162);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.DragOver += new System.Windows.Forms.DragEventHandler(this.txtQuery_DragOver);
            this.txtQuery.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtQuery_DragDrop);
            this.txtQuery.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtQuery_DragEnter);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabResults);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(529, 221);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(529, 243);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.panRunStatus,
            this.panExecTime,
            this.panRows});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(529, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panRunStatus
            // 
            this.panRunStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.panRunStatus.Name = "panRunStatus";
            this.panRunStatus.Size = new System.Drawing.Size(506, 17);
            this.panRunStatus.Spring = true;
            this.panRunStatus.Text = "Ready";
            // 
            // panExecTime
            // 
            this.panExecTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.panExecTime.Name = "panExecTime";
            this.panExecTime.Size = new System.Drawing.Size(4, 17);
            // 
            // panRows
            // 
            this.panRows.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.panRows.Name = "panRows";
            this.panRows.Size = new System.Drawing.Size(4, 17);
            // 
            // tabResults
            // 
            this.tabResults.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResults.Location = new System.Drawing.Point(0, 0);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.Size = new System.Drawing.Size(529, 221);
            this.tabResults.TabIndex = 0;
            // 
            // tmrExecTime
            // 
            this.tmrExecTime.Interval = 1000;
            this.tmrExecTime.Tick += new System.EventHandler(this.tmrExecTime_Tick);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 417);
            this.Controls.Add(this.splitBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "QueryForm";
            this.Text = "QueryForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QueryForm_FormClosed);
            this.Activated += new System.EventHandler(this.QueryForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueryForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QueryForm_KeyDown);
            this.splitBrowser.Panel1.ResumeLayout(false);
            this.splitBrowser.Panel1.PerformLayout();
            this.splitBrowser.Panel2.ResumeLayout(false);
            this.splitBrowser.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitBrowser;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.TabControl tabResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel panRunStatus;
        private System.Windows.Forms.ToolStripStatusLabel panExecTime;
        private System.Windows.Forms.ToolStripStatusLabel panRows;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Timer tmrExecTime;

    }
}