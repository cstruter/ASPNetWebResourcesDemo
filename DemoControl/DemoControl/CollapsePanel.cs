using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoControl
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CollapsePanel runat=server></{0}:CollapsePanel>")]
    public class CollapsePanel : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public string Title
        {
            get
            {
                String s = (String)ViewState["Title"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Title"] = value;
            }
        }

        private string WebResource(string resourceName)
        {
            return Page.ClientScript.GetWebResourceUrl(this.GetType(), resourceName);
        }

        protected override void CreateChildControls()
        {
            Page.ClientScript.RegisterClientScriptInclude("collapse", WebResource("DemoControl.javascripts.collapse.js"));
            base.CreateChildControls();
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.WriteFullBeginTag("span");            
            output.WriteBeginTag("img");
            output.WriteAttribute("src", WebResource("DemoControl.images.down.jpg"));
            output.WriteAttribute("onclick", "toggle(this,'toggle_" + ClientID + "')");
            output.Write("/>");
            output.Write("&nbsp;" + Title);
            output.WriteEndTag("span");
            output.Write("<br />");
            output.WriteBeginTag("span");
            output.WriteAttribute("id", "toggle_" + ClientID);
            output.WriteAttribute("style", "display:none");
            output.Write(">" + Text);
            output.WriteEndTag("span");
        }
    }
}
