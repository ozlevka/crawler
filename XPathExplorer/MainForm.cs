using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace XPathExplorer
{
    public partial class MainForm : Form
    {
        HtmlAgilityPack.HtmlDocument _htmlDocument;        
        public MainForm()
        {
            InitializeComponent();
            browser.ScriptErrorsSuppressed = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DisplayHtml(string html)
        {
            browser.Navigate("about:blank");
            try
            {
                if (browser.Document != null)
                {
                    browser.Document.Write(string.Empty);
                }
            }
            catch (Exception e)
            { } // do nothing with this
            browser.DocumentText = html;
        }

        private void ProcessExpression()
        {
            try
            {
                txtPath.Text = txtPath.Text.Replace(Environment.NewLine, string.Empty);
                XPathNavigator navigator = _htmlDocument.CreateNavigator();
                XPathNodeIterator iterator = navigator.Select(txtPath.Text);
                listBoxTags.Items.Clear();
                foreach (HtmlAgilityPack.HtmlNodeNavigator item in iterator)
                {
                    NodeView view = new NodeView(item.CurrentNode);
                    listBoxTags.Items.Add(view);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxTags_DoubleClick(object sender, EventArgs e)
        {
            NodeView nodeView = (NodeView)listBoxTags.SelectedItem;
            txtHtml.Text = nodeView.Node.OuterHtml;
            DisplayHtml(txtHtml.Text);
        }

        private void ProcessUrl()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            this.Cursor = Cursors.WaitCursor;
            _htmlDocument = web.Load(txtUrl.Text);
            this.Cursor = Cursors.Arrow;
            txtHtml.Text = _htmlDocument.DocumentNode.OuterHtml;
            DisplayHtml(_htmlDocument.DocumentNode.OuterHtml);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.ProcessUrl();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ProcessExpression();
        }

        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.ProcessUrl();
            }
        }

        private void txtPath_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                ProcessExpression(); 
            }
        }
    }
}
