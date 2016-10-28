using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VROWorkflowViewer
{
    public partial class VROWorkflowView : Form
    {
        VROWorkFlow workflowitems;
        Stack<TabPage> history;
        RichTextBox currentBox;
        Label currentLabel;
        FormWindowState lastState;
        public VROWorkflowView()
        {
            InitializeComponent();
            lastState = WindowState;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReInit()
        {
            history = new Stack<TabPage>();
            currentBox = null;
            currentLabel = null;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "VRO Workflow Viewer";
            ofd.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workflowitems = new VROWorkFlow(ofd.FileName);
                rootToolStripMenuItem.Enabled = true;
                ReInit();
            }
        }

        private void importFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workflowitems = new VROWorkFlow();
            ReInit();
            if (workflowitems.ParseWorkFlow(Clipboard.GetText()))
            {
                DisplayWorkFlowItems();
                rootToolStripMenuItem.Enabled = true;
            }
            else
            {                
                MessageBox.Show("Error : " + workflowitems.errorMessage,"VRO Workflow Viewer");
                rootToolStripMenuItem.Enabled = false;
            }
            
            
        }

        private void CopyRTB(RichTextBox iRTB,ref RichTextBox box,Boolean fullscreen=false)
        {            
            box.Font = iRTB.Font;

            if (fullscreen)
            {
                box.Location = new Point(5, 15);
                box.Height = multiTabs.Height - 140 + 65;
            }
            else
            {
                box.Location = new Point(5, 80);
                box.Height = multiTabs.Height - 140;
            }

            box.Width = multiTabs.Width - 25;
            

            box.Anchor = iRTB.Anchor;
            box.Dock = iRTB.Dock;
            box.BackColor = iRTB.BackColor;
            box.ForeColor = iRTB.ForeColor;
            box.ReadOnly = iRTB.ReadOnly;
            box.Multiline = iRTB.Multiline;
            box.ScrollBars = iRTB.ScrollBars;
            box.WordWrap = iRTB.WordWrap;
            box.ContextMenuStrip = iRTB.ContextMenuStrip;
        }

        private void CopyBOX(TextBox iBOX,ref TextBox box)
        {            
            box.Font = iBOX.Font;            
            box.Location = new Point(5, 15);
            box.Width = multiTabs.Width - 25;
            box.Height = 50;
            box.Anchor = iBOX.Anchor;
            box.Dock = iBOX.Dock;
            box.BackColor = iBOX.BackColor;
            box.ForeColor = iBOX.ForeColor;
            box.ReadOnly = iBOX.ReadOnly;
            box.Multiline = iBOX.Multiline;
            box.ScrollBars = iBOX.ScrollBars;
        }

        private void CopyLabel(Label iLabel, Label oLabel)
        {
            oLabel.Font = iLabel.Font;
            oLabel.Location = new Point(5, multiTabs.Height - 50); 
            oLabel.Width = 100;
            oLabel.Height = 20;                       
            oLabel.Anchor = iLabel.Anchor;
            oLabel.Dock = iLabel.Dock;
            oLabel.BackColor = iLabel.BackColor;
            oLabel.ForeColor = iLabel.ForeColor;            
        }

        private void DisplayWorkFlowItems()
        {
            multiTabs.TabPages.Clear();
            RichTextBox box = null;
            TextBox sumBox = null;
            TabPage page = null;
            Label lab = null;
            String[] tabs = {"Inputs","Attributes"}; // Removed Sequence
            //foreach (TabPage cPage in multiTabs.TabPages)
            //{
            //    cPage.Controls.Clear();
            //    multiTabs.TabPages.Remove(cPage);                
            //}
            foreach (String tabName in tabs)
            {
                page = new TabPage();
                page.Text = tabName;
                page.Name = tabName;
                box = new RichTextBox();
                page.Controls.Add(box);
                multiTabs.TabPages.Add(page); 
                CopyRTB(templateRTB, ref box,true);
                box.ContextMenuStrip = null;
                
                switch (tabName)
                {
                    case "Inputs":
                        foreach (VROWorkFlow.Variables iVar in workflowitems.inputs.Values)
                        {
                            box.AppendText(iVar.ToString() + Environment.NewLine);
                        }
                        break;
                    case "Attributes":
                        foreach (VROWorkFlow.Variables iVar in workflowitems.attribs.Values)
                        {
                            box.AppendText(iVar.ToString() + Environment.NewLine);
                        }
                        break;
                    case "Sequence":                        
                        VROWorkFlow.WorkFlowItem wfi = workflowitems.workitems[workflowitems.rootItem];
                        box.AppendText("Root Item : " + wfi.ToString() + Environment.NewLine);                        
                        while (wfi.wfiType != "end")
                        {
                            wfi = workflowitems.workitems[wfi.outItemName];
                            box.AppendText("Next Item : " + wfi.ToString() + Environment.NewLine);
                        }
                        break;    
                }                
            }
            List<String> wfkeys = workflowitems.itemKeys.Keys.ToList();
            wfkeys.Sort();
            foreach (String key in wfkeys)
            {
                String wfiItemName = workflowitems.itemKeys[key];
                page = new TabPage();
                VROWorkFlow.WorkFlowItem wfi = workflowitems.workitems[wfiItemName];
                page.Text = wfi.displayName == null ? wfi.itemName : wfi.displayName;
                page.Tag = wfi;
                page.Name = wfi.itemName;

                
                box = new RichTextBox();
                box.Name = "RTB-" + wfi.itemName;
                box.KeyDown += TextBoxMonitorKeyDown;
                box.KeyUp += TextBoxMonitorKeyUp;
                box.Click += RTBBoxClicked;
                sumBox = new TextBox();
                sumBox.Name = "SUMMARY-" + wfi.itemName;

                lab = new Label();
                lab.Name = "LABEL-" + wfi.itemName;

                page.Controls.Add(sumBox);
                page.Controls.Add(box);
                page.Controls.Add(lab);
                multiTabs.TabPages.Add(page);

                CopyRTB(templateRTB, ref box);
                CopyBOX(templateSummary, ref sumBox);
                CopyLabel(PositionMarker, lab);
                
                box.Lines = wfi.lines;
                sumBox.AppendText(wfi.ToString() + Environment.NewLine);
                if (wfi.inputs.Count > 0)
                {
                    foreach (String eName in wfi.inputs.Keys)
                    {
                        sumBox.AppendText("Input : " + eName + " - " + wfi.inputs[eName].ToString() + Environment.NewLine);
                    }                    
                }
                if (wfi.outputs.Count > 0)
                {
                    foreach (String eName in wfi.outputs.Keys)
                    {
                        sumBox.AppendText("Output : " + eName + " - " + wfi.outputs[eName].ToString() + Environment.NewLine);
                    }
                }
            }

        }

        void RTBBoxClicked(object sender, EventArgs e)
        {
            RTBLineNumber();
        }

        void MonitorKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.N)
            {
                if (nextToolStripMenuItem.Enabled) nextToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.L)
            {
                if (lastToolStripMenuItem.Enabled) lastToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.R)
            {
                if (rootToolStripMenuItem.Enabled) rootToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.A)
            {
                if (alternateNextToolStripMenuItem.Enabled) alternateNextToolStripMenuItem_Click(null, null);                
            }
            else
            {
                e.Handled = false;
            }            
        }


        void TextBoxMonitorKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.N)
            {
                if (nextToolStripMenuItem.Enabled) nextToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.L)
            {
                if (lastToolStripMenuItem.Enabled) lastToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.R)
            {
                if (rootToolStripMenuItem.Enabled) rootToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.A)
            {
                if (alternateNextToolStripMenuItem.Enabled) alternateNextToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.Space)
            {
                RTBLineNumber();
            }
            else
            {
                e.Handled = false;
            }
        }

        void TextBoxMonitorKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp)
            {
                RTBLineNumber();
                e.Handled = false;
            }
        }

        private void RTBLineNumber()
        {
            if (currentBox != null)            
            {
                int cursorPosition = currentBox.SelectionStart;
                int lineIndex = currentBox.GetLineFromCharIndex(cursorPosition) + 1;
                currentLabel.Text = String.Format("Current Line : {0}", lineIndex);
            }
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VROWorkFlow.WorkFlowItem cwfi = multiTabs.SelectedTab.Tag as VROWorkFlow.WorkFlowItem;
            multiTabs.SelectedTab = multiTabs.TabPages[cwfi.outItemName];
        }

        private void alternateNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VROWorkFlow.WorkFlowItem cwfi = multiTabs.SelectedTab.Tag as VROWorkFlow.WorkFlowItem;
            multiTabs.SelectedTab = multiTabs.TabPages[cwfi.altOutItemName];
        }


        private void NewTabPage(object sender, TabControlEventArgs e)
        {
            currentBox = null;
            currentLabel = null;
            if (e.TabPage == null) return;
            System.Diagnostics.Debug.Print("New Tab : " + e.TabPage.Name + " Orig : " + multiTabs.SelectedTab.Name);
            if (e.TabPage.Tag != null)
            {
                VROWorkFlow.WorkFlowItem wfi = e.TabPage.Tag as VROWorkFlow.WorkFlowItem;
                currentBox = e.TabPage.Controls["RTB-" + wfi.itemName] as RichTextBox;
                currentLabel = e.TabPage.Controls["LABEL-" + wfi.itemName] as Label;
                alternateNextToolStripMenuItem.Enabled = wfi.altOutItemName != null;
                nextToolStripMenuItem.Enabled = wfi.outItemName != null;
                lastToolStripMenuItem.Enabled = false;
                if (history.Count == 0 || history.Peek() != e.TabPage) history.Push(e.TabPage);
            }
            else
            {
                nextToolStripMenuItem.Enabled = false;
                lastToolStripMenuItem.Enabled = false;
                alternateNextToolStripMenuItem.Enabled = false;
            }
            if (history.Count > 1) lastToolStripMenuItem.Enabled = true;
        }

        private void rootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history = new Stack<TabPage>();
            multiTabs.SelectedTab = multiTabs.TabPages[workflowitems.rootItem];            
            lastToolStripMenuItem.Enabled = false;
        }

        private void tabsToSpacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VROWorkFlow.WorkFlowItem wfi = multiTabs.SelectedTab.Tag as VROWorkFlow.WorkFlowItem;
            if (wfi != null)
            {
                RichTextBox rtb = multiTabs.SelectedTab.Controls["RTB-" + wfi.itemName] as RichTextBox;
                rtb.Text = rtb.Text.Replace("\t", "    ");
            }

        }

        private void lastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history.Pop();
            if (history.Count > 0)
            {
                multiTabs.SelectedTab = history.Peek();
            }
            if (history.Count < 2) lastToolStripMenuItem.Enabled = false;
        }

        private void selectAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentBox.SelectAll();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentBox != null)
            {
                currentBox.Copy();                
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }
    }
}
