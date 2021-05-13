using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class MonacoBox : UserControl
{
    public MonacoBox()
    {
        InitializeComponent();
    }

    WebClient wc = new WebClient();
    private string defPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/bin/Monaco/";

    private void addIntel(string label, string kind, string detail, string insertText)
    {
        string text = "\"" + label + "\"";
        string text2 = "\"" + kind + "\"";
        string text3 = "\"" + detail + "\"";
        string text4 = "\"" + insertText + "\"";
        webBrowser1.Document.InvokeScript("AddIntellisense", new object[]
        {
                label,
                kind,
                detail,
                insertText
        });
    }

    private void addGlobalF()
    {
        string[] array = File.ReadAllLines(this.defPath + "/globalf.txt");
        foreach (string text in array)
        {
            bool flag = text.Contains(":");
            if (flag)
            {
                this.addIntel(text, "Function", text, text.Substring(1));
            }
            else
            {
                this.addIntel(text, "Function", text, text);
            }
        }
    }

    private void addGlobalV()
    {
        foreach (string text in File.ReadLines(this.defPath + "/globalv.txt"))
        {
            this.addIntel(text, "Variable", text, text);
        }
    }

    private void addGlobalNS()
    {
        foreach (string text in File.ReadLines(this.defPath + "/globalns.txt"))
        {
            this.addIntel(text, "Class", text, text);
        }
    }

    private void addMath()
    {
        foreach (string text in File.ReadLines(this.defPath + "/classfunc.txt"))
        {
            this.addIntel(text, "Method", text, text);
        }
    }

    private void addBase()
    {
        foreach (string text in File.ReadLines(this.defPath + "/base.txt"))
        {
            this.addIntel(text, "Keyword", text, text);
        }
    }

    public async void MonacoBox_Load(object sender, EventArgs e, string content)
    {
        WebClient wc = new WebClient();
        wc.Proxy = null;
        try
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
            string friendlyName = AppDomain.CurrentDomain.FriendlyName;

            bool flag2 = registryKey.GetValue(friendlyName) == null;
            if (flag2)
            {
                registryKey.SetValue(friendlyName, 11001, RegistryValueKind.DWord);
            }
            registryKey = null;
            friendlyName = null;
        }
        catch (Exception)
        {
        }
        webBrowser1.Url = new Uri(string.Format("file:///{0}/bin/Monaco/Monaco.html", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)));
        await Task.Delay(500);
        webBrowser1.Document.InvokeScript("SetTheme", new string[]
        {
            "Dark"
        });
        addBase();
        addMath();
        addGlobalNS();
        addGlobalV();
        addGlobalF();
        webBrowser1.Document.InvokeScript("SetText", new object[]
        {
            content
        });
    }
}
