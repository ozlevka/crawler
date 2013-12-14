using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPathExplorer
{
    public class NodeView
    {
        public NodeView(HtmlAgilityPack.HtmlNode node)
        {
            Node = node;
        }

        public HtmlAgilityPack.HtmlNode Node { get;private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<");
            sb.Append(Node.Name);
            foreach (var item in Node.Attributes)
            {
                sb.AppendFormat(" {0}={1}", item.Name, item.Value);
            }
            sb.Append(">");
            return sb.ToString();
        }
    }
}
