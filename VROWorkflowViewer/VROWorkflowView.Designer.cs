namespace VROWorkflowViewer
{
    partial class VROWorkflowView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VROWorkflowView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alternateNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsToSpacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiTabs = new System.Windows.Forms.TabControl();
            this.TemplatePage = new System.Windows.Forms.TabPage();
            this.PositionMarker = new System.Windows.Forms.Label();
            this.templateSummary = new System.Windows.Forms.TextBox();
            this.templateRTB = new System.Windows.Forms.RichTextBox();
            this.stdCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.multiTabs.SuspendLayout();
            this.TemplatePage.SuspendLayout();
            this.stdCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.navigateToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.importFromClipboardToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // importFromClipboardToolStripMenuItem
            // 
            this.importFromClipboardToolStripMenuItem.Name = "importFromClipboardToolStripMenuItem";
            this.importFromClipboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.importFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.importFromClipboardToolStripMenuItem.Text = "Import from Clipboard";
            this.importFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.importFromClipboardToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // navigateToolStripMenuItem
            // 
            this.navigateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextToolStripMenuItem,
            this.alternateNextToolStripMenuItem,
            this.lastToolStripMenuItem,
            this.rootToolStripMenuItem});
            this.navigateToolStripMenuItem.Name = "navigateToolStripMenuItem";
            this.navigateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.navigateToolStripMenuItem.Text = "Navigate";
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Enabled = false;
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.nextToolStripMenuItem.Text = "Next Item";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.nextToolStripMenuItem_Click);
            // 
            // alternateNextToolStripMenuItem
            // 
            this.alternateNextToolStripMenuItem.Enabled = false;
            this.alternateNextToolStripMenuItem.Name = "alternateNextToolStripMenuItem";
            this.alternateNextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.alternateNextToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.alternateNextToolStripMenuItem.Text = "Alternate Next Item";
            this.alternateNextToolStripMenuItem.Click += new System.EventHandler(this.alternateNextToolStripMenuItem_Click);
            // 
            // lastToolStripMenuItem
            // 
            this.lastToolStripMenuItem.Enabled = false;
            this.lastToolStripMenuItem.Name = "lastToolStripMenuItem";
            this.lastToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.lastToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.lastToolStripMenuItem.Text = "Last Item";
            this.lastToolStripMenuItem.Click += new System.EventHandler(this.lastToolStripMenuItem_Click);
            // 
            // rootToolStripMenuItem
            // 
            this.rootToolStripMenuItem.Enabled = false;
            this.rootToolStripMenuItem.Name = "rootToolStripMenuItem";
            this.rootToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.rootToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.rootToolStripMenuItem.Text = "Root Item";
            this.rootToolStripMenuItem.Click += new System.EventHandler(this.rootToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabsToSpacesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // tabsToSpacesToolStripMenuItem
            // 
            this.tabsToSpacesToolStripMenuItem.Name = "tabsToSpacesToolStripMenuItem";
            this.tabsToSpacesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.tabsToSpacesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.tabsToSpacesToolStripMenuItem.Text = "Tabs To Spaces";
            this.tabsToSpacesToolStripMenuItem.Click += new System.EventHandler(this.tabsToSpacesToolStripMenuItem_Click);
            // 
            // multiTabs
            // 
            this.multiTabs.Controls.Add(this.TemplatePage);
            this.multiTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiTabs.Location = new System.Drawing.Point(0, 24);
            this.multiTabs.Name = "multiTabs";
            this.multiTabs.SelectedIndex = 0;
            this.multiTabs.Size = new System.Drawing.Size(992, 509);
            this.multiTabs.TabIndex = 1;
            this.multiTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.NewTabPage);
            this.multiTabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MonitorKeyDown);
            // 
            // TemplatePage
            // 
            this.TemplatePage.Controls.Add(this.PositionMarker);
            this.TemplatePage.Controls.Add(this.templateSummary);
            this.TemplatePage.Controls.Add(this.templateRTB);
            this.TemplatePage.Location = new System.Drawing.Point(4, 22);
            this.TemplatePage.Name = "TemplatePage";
            this.TemplatePage.Padding = new System.Windows.Forms.Padding(3);
            this.TemplatePage.Size = new System.Drawing.Size(984, 483);
            this.TemplatePage.TabIndex = 0;
            this.TemplatePage.Text = "Overview";
            this.TemplatePage.UseVisualStyleBackColor = true;
            // 
            // PositionMarker
            // 
            this.PositionMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PositionMarker.AutoSize = true;
            this.PositionMarker.Location = new System.Drawing.Point(3, 464);
            this.PositionMarker.Name = "PositionMarker";
            this.PositionMarker.Size = new System.Drawing.Size(114, 13);
            this.PositionMarker.TabIndex = 2;
            this.PositionMarker.Text = "Current Cursor Position";
            // 
            // templateSummary
            // 
            this.templateSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateSummary.Location = new System.Drawing.Point(9, 12);
            this.templateSummary.Multiline = true;
            this.templateSummary.Name = "templateSummary";
            this.templateSummary.ReadOnly = true;
            this.templateSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.templateSummary.Size = new System.Drawing.Size(969, 49);
            this.templateSummary.TabIndex = 1;
            // 
            // templateRTB
            // 
            this.templateRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateRTB.ContextMenuStrip = this.stdCMS;
            this.templateRTB.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateRTB.Location = new System.Drawing.Point(3, 79);
            this.templateRTB.Name = "templateRTB";
            this.templateRTB.ReadOnly = true;
            this.templateRTB.Size = new System.Drawing.Size(973, 381);
            this.templateRTB.TabIndex = 0;
            this.templateRTB.Text = "";
            this.templateRTB.WordWrap = false;
            // 
            // stdCMS
            // 
            this.stdCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAlToolStripMenuItem,
            this.copyToolStripMenuItem1});
            this.stdCMS.Name = "stdCMS";
            this.stdCMS.Size = new System.Drawing.Size(123, 48);
            // 
            // selectAlToolStripMenuItem
            // 
            this.selectAlToolStripMenuItem.Name = "selectAlToolStripMenuItem";
            this.selectAlToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAlToolStripMenuItem.Text = "Select All";
            this.selectAlToolStripMenuItem.Click += new System.EventHandler(this.selectAlToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // VROWorkflowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 533);
            this.Controls.Add(this.multiTabs);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VROWorkflowView";
            this.Text = "VRO Workflow Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.multiTabs.ResumeLayout(false);
            this.TemplatePage.ResumeLayout(false);
            this.TemplatePage.PerformLayout();
            this.stdCMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl multiTabs;
        private System.Windows.Forms.TabPage TemplatePage;
        private System.Windows.Forms.RichTextBox templateRTB;
        private System.Windows.Forms.TextBox templateSummary;
        private System.Windows.Forms.ToolStripMenuItem navigateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alternateNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabsToSpacesToolStripMenuItem;
        private System.Windows.Forms.Label PositionMarker;
        private System.Windows.Forms.ContextMenuStrip stdCMS;
        private System.Windows.Forms.ToolStripMenuItem selectAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

