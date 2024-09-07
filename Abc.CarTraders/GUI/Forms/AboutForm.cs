using System.Diagnostics;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            lblVersion.Text = $"V {Program.Version}";
        }

        private void linkEMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:nifraz@live.com?subject=ABC");
        }

        private void linkFB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/nifraz319/");
        }

        private void linkDotNet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://dotnet.microsoft.com/download/dotnet-framework/");
        }

        private void linkEntityFramework_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/ef/ef6/");
        }

        private void linkPagedList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/TroyGoode/PagedList");
        }

        private void linkLiveCharts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://lvcharts.net/");
        }

        private void linkLoadingCircle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.codeproject.com/Articles/14841/How-to-write-a-loading-circle-animation-in-NET");
        }

        private void linkPagedListEF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/NickStrupat/PagedList.EntityFramework");
        }

        private void linkClosedXml_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/ClosedXML/ClosedXML");
        }

        private void linkPhone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("skype:+94712319319?call");
        }
    }
}
