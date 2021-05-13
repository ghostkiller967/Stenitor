using Microsoft.Win32;
using Newtonsoft.Json;
using PluginAPI;
using Stenitor.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class Main : Form
{

    #region Variables

    public static string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/";
    public _Language lang = new _Language();
    public bool isFullscreen = false;
    public List<_Language> runnables = new List<_Language>();

    WebClient wc = new WebClient();
    Dictionary<string, Plugin> plugins = new Dictionary<string, Plugin>();

    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    bool SizingUp = false;
    bool SizingLeft = false;
    bool SizingRight = false;
    bool SizingBottom = false;
    bool SizingConsole = false;
    int lastX;
    int lastY;
    int lastWidth;
    int lastHeight;

    public enum _Language
    {
        Lua,
        None,
        Python
    }

    #endregion

    #region Functions

    #region Custom

    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    public MonacoBox GetMonaco(int index)
    {
        MonacoBox monaco = Tabs.TabsContent[index].Controls.Find("MonacoBox", true).FirstOrDefault() as MonacoBox;
        return monaco;
    }

    private void LoadPlugins(string folder)
    {
        plugins.Clear();
        foreach (string dll in Directory.GetFiles(folder, "*.dll"))
        {
            try
            {
                Assembly asm = Assembly.LoadFrom(dll);
                foreach (Type type in asm.GetTypes())
                {
                    //Checks if plugin is an actual plugin
                    if (type.GetInterface("Plugin") == typeof(Plugin))
                    {
                        //Add plugins to a list
                        Plugin plugin = Activator.CreateInstance(type) as Plugin;
                        plugins[plugin.Name] = plugin;

                        plugin.GetMain(this);
                        plugin.Init();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Add plugins to the dropdown menu
        Plugins.DropDownItems.Clear();

        foreach (KeyValuePair<string, Plugin> pair in plugins)
        {
            Plugin plugin = plugins[pair.Key];
            Plugins.DropDownItems.Add(plugin.GetMenuItem(pair));
        }
    }

    public void AddTab(string content, string title, string path)
    {
        Panel panel = new Panel();
        panel.Dock = DockStyle.Fill;
        MonacoBox mb = new MonacoBox();
        mb.Name = "MonacoBox";
        mb.Dock = DockStyle.Fill;
        panel.Controls.Add(mb);
        Tabs.AddTab(title, panel, path);
        mb.MonacoBox_Load(null, null, content);
    }

    public string GetText(int index)
    {
        try
        {
            WebBrowser wb = Tabs.TabsContent[index].Controls.Find("MonacoBox", true).FirstOrDefault().Controls.Find("webBrowser1", true).FirstOrDefault() as WebBrowser;
            string script = wb.Document.InvokeScript("GetText", new string[0]).ToString();
            return script;
        }
        catch
        {
            return null;
        }
    }

    private string GetPythonPath()
    {
        IDictionary environmentVariables = Environment.GetEnvironmentVariables();
        string pathVariable = environmentVariables["Path"] as string;
        if (pathVariable != null)
        {
            string[] allPaths = pathVariable.Split(';');
            foreach (var path in allPaths)
            {
                string pythonPathFromEnv = path + "python.exe";
                if (File.Exists(pythonPathFromEnv))
                {
                    return pythonPathFromEnv;
                }
            }
        }
        return "";
    }

    public void Run()
    {
        if (lang == _Language.Python)
        {
            ConsoleBox.Text = "";
            string script = GetText(Tabs.SelectedTabIndex);
            if (script == null)
            {
                ConsoleBox.Text += "There isn't a tab opened.";
                return;
            }
            string path = Tabs.Paths[Tabs.SelectedTabIndex];
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (Stream s = File.Open(path, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(s))
            {
                sw.Write(script);
            }

            try
            {
                CreatePython(path, ConsoleBox);
            }
            catch (Exception ex)
            {
                ConsoleBox.Text += ex.Message;
            }
        }
        else
        {

        }
    }

    private async void CreatePython(string path, RichTextBox text)
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = GetPythonPath();
        if (GetPythonPath() == "")
        {
            text.Text += "You do not have Python installed or have the path in your Environtment Variables.";
            return;
        }
        psi.Arguments = $"\"{path}\"";
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        using (Process process = Process.Start(psi))
        {
            while (process != null)
            {
                text.Text += process.StandardOutput.ReadToEnd();
                text.Text += process.StandardError.ReadToEnd();
                await Task.Delay(1);
            }
        }

    }

    public void OpenFile()
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Title = "Open";
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            AddTab(File.ReadAllText(ofd.FileName), ofd.SafeFileName, ofd.FileName);
        }
    }

    public void SaveFile(int tab)
    {
        string script = GetText(tab);
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Title = "Save";
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            if (File.Exists(sfd.FileName))
            {
                File.Delete(sfd.FileName);
            }
            using (Stream s = File.Open(sfd.FileName, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(s))
            {
                sw.Write(script);
            }
        }
    }

    public void NewFile()
    {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Title = "New File";
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            if (File.Exists(sfd.FileName))
            {
                File.Delete(sfd.FileName);
            }
            using (Stream s = File.Open(sfd.FileName, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(s))
            {
                sw.Write("");
            }
            AddTab("", Path.GetFileName(sfd.FileName), sfd.FileName);
        }
    }

    public void SetLanguage(_Language lang)
    {
        this.lang = lang;
        if (lang == _Language.None)
        {
            LanguageLabel.Text = "";
        }
        else
        {
            LanguageLabel.Text = lang.ToString();
        }

        if (runnables.Contains(lang))
        {
            RunButton.Show();
        }
        else
        {
            RunButton.Hide();
        }

        int line = 87;
        JsonTextReader reader = new JsonTextReader(new StringReader(File.ReadAllText(path + "bin/Monaco/config.json")));
        while (reader.Read())
        {
            if (reader.Value != null)
            {
                if (reader.TokenType == JsonToken.String)
                {
                    line = Int32.Parse(reader.Value.ToString());
                }
            }
        }
        if (lang == _Language.None)
        {
            ChangeLine("					language: '',", path + "bin/Monaco/Monaco.html", line);
        }
        else
        {
            ChangeLine("					language: '" + lang.ToString().ToLower() + "',", path + "bin/Monaco/Monaco.html", line);
        }

        if (File.Exists(path + "bin/language.json"))
        {
            File.Delete(path + "bin/language.json");
        }

        StringBuilder sb = new StringBuilder();
        StringWriter strw = new StringWriter(sb);
        using (JsonWriter writer = new JsonTextWriter(strw))
        {
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Language");
            writer.WriteValue(lang.ToString());
            writer.WriteEndObject();
        }

        using (Stream s = File.Open(path + "bin/language.json", FileMode.CreateNew))
        using (StreamWriter sw = new StreamWriter(s))
        {
            sw.Write(sb.ToString());
        }
    }

    private void ChangeLine(string newText, string fileName, int line)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line - 1] = newText;
        File.WriteAllLines(fileName, arrLine);
    }

    public void ToggleFullscreen()
    {
        if (!isFullscreen)
        {
            Location = new Point(0, 0);
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height - 40;
            Fullscreen.BackgroundImage = Resources.virtual_machine_25px;
            isFullscreen = true;
        }
        else
        {
            Width = 1000;
            Height = 550;
            Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2));
            Fullscreen.BackgroundImage = Resources.fill_dock_25px;
            isFullscreen = false;
        }
    }

    #endregion

    #region Events

    #region ToolStrip

    #region File

    private void New_Click(object sender, EventArgs e)
    {
        SaveFileDialog sfd = new SaveFileDialog();
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            if (File.Exists(sfd.FileName))
            {
                File.Delete(sfd.FileName);
            }
            using (Stream s = File.Open(sfd.FileName, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(s))
            {
                sw.Write("");
            }
            AddTab("", Path.GetFileName(sfd.FileName), sfd.FileName);
        }
    }

    private void Open_Click(object sender, EventArgs e)
    {
        OpenFile();
    }

    private void Save_Click(object sender, EventArgs e)
    {
        SaveFile(Tabs.SelectedTabIndex);
    }

    private void InstallRegistryKeys_Click(object sender, EventArgs e)
    {
        try
        {
            if (Registry.ClassesRoot.OpenSubKey("*\\shell\\Stenitor") != null)
            {
                Registry.ClassesRoot.DeleteSubKeyTree("*\\shell\\Stenitor");
            }

            Registry.ClassesRoot.CreateSubKey("*\\shell\\Stenitor");
            Registry.SetValue("HKEY_CLASSES_ROOT\\*\\shell\\Stenitor", "", "Open in Stenitor");
            Registry.SetValue("HKEY_CLASSES_ROOT\\*\\shell\\Stenitor", "Icon", "\"" + Application.ExecutablePath + "\"");
            Registry.ClassesRoot.CreateSubKey("*\\shell\\Stenitor\\command");
            Registry.SetValue("HKEY_CLASSES_ROOT\\*\\shell\\Stenitor\\command", "", "\"" + Application.ExecutablePath + "\" \"%1\"");
            MessageBox.Show("Updated/Installed the Registry Keys", "Finished", MessageBoxButtons.OK);
        }
        catch
        {
            MessageBox.Show("Please open Stenitor as Administrator to install the Registry Keys.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #endregion

    #region Language

    private void None_Click(object sender, EventArgs e)
    {
        SetLanguage(_Language.None);
    }

    private void Lua_Click(object sender, EventArgs e)
    {
        SetLanguage(_Language.Lua);
    }

    private void Python_Click(object sender, EventArgs e)
    {
        SetLanguage(_Language.Python);
    }

    #endregion

    #region View

    private void Console_Click(object sender, EventArgs e)
    {
        if (ConsolePanel.Visible)
        {
            ConsolePanel.Hide();
        }
        else
        {
            ConsolePanel.Show();
        }
    }

    #endregion

    #endregion

    #region Window

    #region Resizing

    #region Top

    private void TopSizer_MouseMove(object sender, MouseEventArgs e)
    {
        if (SizingUp && !isFullscreen)
        {
            Height = lastY - MousePosition.Y + lastHeight;
            Location = new Point(Location.X, MousePosition.Y);
            Refresh();
        }
    }

    private void TopSizer_MouseDown(object sender, MouseEventArgs e)
    {
        SizingUp = true;
        lastY = Location.Y;
        lastHeight = Height;
    }

    private void TopSizer_MouseUp(object sender, MouseEventArgs e)
    {
        SizingUp = false;
    }

    #endregion

    #region Left

    private void LeftSizer_MouseDown(object sender, MouseEventArgs e)
    {
        SizingLeft = true;
        lastX = Location.X;
        lastWidth = Width;
    }

    private void LeftSizer_MouseUp(object sender, MouseEventArgs e)
    {
        SizingLeft = false;
    }

    private void LeftSizer_MouseMove(object sender, MouseEventArgs e)
    {
        if (SizingLeft && !isFullscreen)
        {
            Width = lastX - MousePosition.X + lastWidth;
            Location = new Point(MousePosition.X, Location.Y);
            Refresh();
        }
    }

    #endregion

    #region Right

    private void RightSizer_MouseDown(object sender, MouseEventArgs e)
    {
        SizingRight = true;
    }

    private void RightSizer_MouseMove(object sender, MouseEventArgs e)
    {
        if (SizingRight && !isFullscreen)
        {
            Width = MousePosition.X - Location.X;
            Refresh();
        }
    }

    private void RightSizer_MouseUp(object sender, MouseEventArgs e)
    {
        SizingRight = false;
    }

    #endregion

    #region Bottom

    private void BottomSizer_MouseUp(object sender, MouseEventArgs e)
    {
        SizingBottom = false;
    }

    private void BottomSizer_MouseMove(object sender, MouseEventArgs e)
    {
        if (SizingBottom && !isFullscreen)
        {
            Height = MousePosition.Y - Location.Y;
            Refresh();
        }
    }

    private void BottomSizer_MouseDown(object sender, MouseEventArgs e)
    {
        SizingBottom = true;
    }

    #endregion

    #endregion

    #region Repositioning

    private void ToolStrip_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && !isFullscreen)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }

    private void LanguageLabel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && !isFullscreen)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }

    #endregion

    #endregion

    #region Console

    private void ConsoleSizePanel_MouseDown(object sender, MouseEventArgs e)
    {
        SizingConsole = true;
    }

    private void ConsoleSizePanel_MouseMove(object sender, MouseEventArgs e)
    {
        int mouseY = Cursor.Position.Y - Location.Y;
        if (SizingConsole && mouseY > 55 && mouseY < Height - 30)
        {
            ConsolePanel.Location = new Point(ConsolePanel.Location.X, mouseY);
            ConsolePanel.Height = Height - mouseY;
        }
    }

    private void ConsoleSizePanel_MouseUp(object sender, MouseEventArgs e)
    {
        SizingConsole = false;
    }

    private void CloseConsoleButton_Click(object sender, EventArgs e)
    {
        ConsolePanel.Hide();
    }

    #endregion

    #region TitleBar

    private void Fullscreen_Click(object sender, EventArgs e)
    {
        ToggleFullscreen();
    }

    private void Exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Minimize_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }

    #endregion

    private void Tabs_DoubleClick(object sender, EventArgs e)
    {
        NewFile();
    }

    private void RunButton_Click(object sender, EventArgs e)
    {
        Run();
    }

    private void Loop_Tick(object sender, EventArgs e)
    {
        foreach (KeyValuePair<string, Plugin> pair in plugins)
        {
            Plugin plugin = plugins[pair.Key];
            plugin.GetMain(this);
            plugin.Update();
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        //Console.WriteLine(keyData);
        if (keyData == (Keys.Control | Keys.S))
        {
            SaveFile(Tabs.SelectedTabIndex);
            return true;
        }
        else if (keyData == (Keys.Control | Keys.N))
        {
            NewFile();
            return true;
        }
        else if (keyData == (Keys.Control | Keys.O))
        {
            OpenFile();
            return true;
        }
        else if (keyData == (Keys.Control | Keys.Oemtilde | Keys.Shift))
        {
            Run();
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    #endregion

    #endregion

    public Main()
    {
        InitializeComponent();

        //Start the loop which is used for the plugins
        Loop.Enabled = true;
        Loop.Start();

        //Deletes all Visual Studio garbage
        try
        {
            foreach (string file in Directory.GetFiles("./"))
            {
                if (file.EndsWith(".pdb") || file.EndsWith(".config"))
                {
                    File.Delete(file);
                }
            }

        }
        catch { }

        //Creates the Plugins folder if it doesn't exist
        if (!Directory.Exists(path + "Plugins"))
        {
            Directory.CreateDirectory(path + "Plugins");
        }

        //Loads all the Plugins from the Plugins folder
        LoadPlugins(path + "Plugins");

        //Creates a bin folder if it doesn't exist
        if (!Directory.Exists(path + "bin"))
        {
            Directory.CreateDirectory(path + "bin");
        }

        //Creates the default language file
        if (!File.Exists(path + "bin/language.json"))
        {
            StringBuilder sb = new StringBuilder();
            StringWriter strw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(strw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("Language");
                writer.WriteValue("None");
                writer.WriteEndObject();
            }

            using (Stream s = File.Open(path + "bin/language.json", FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(s))
            {
                sw.Write(sb.ToString());
            }
        }

        //Installs Monaco if it doesn't exist
        if (!Directory.Exists(path + "bin/Monaco"))
        {
            if (File.Exists(path + "bin/Monaco.zip"))
            {
                File.Delete(path + "bin/Monaco.zip");
            }

            wc.DownloadFile("https://cdn.discordapp.com/attachments/713846997039448134/836901911214686208/Monaco.zip", path + "bin/Monaco.zip");
            ZipFile.ExtractToDirectory(path + "bin/Monaco.zip", path + "bin");

            if (File.Exists(path + "bin/Monaco.zip"))
            {
                File.Delete(path + "bin/Monaco.zip");
            }
        }

        //Creates a config file inside the Monaco file which is used to determine where to change the language
        if (!File.Exists(path + "bin/Monaco/config.json"))
        {
            StringBuilder sb = new StringBuilder();
            StringWriter strw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(strw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("LanguageLine");
                writer.WriteValue("87");
                writer.WriteEndObject();
            }

            using (Stream s = File.Open(path + "bin/Monaco/config.json", FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(s))
            {
                sw.Write(sb.ToString());
            }
        }


        //Sets the language from the default language file
        _Language _default = _Language.None;
        JsonTextReader reader = new JsonTextReader(new StringReader(File.ReadAllText(path + "bin/language.json")));
        while (reader.Read())
        {
            if (reader.Value != null)
            {
                if (reader.TokenType == JsonToken.String)
                {
                    _default = (_Language)Enum.Parse(typeof(_Language), reader.Value.ToString(), true);
                }
            }
        }
        SetLanguage(_default);

        //Default startup things
        Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2));
        ConsoleBox.Text = "";
        Tabs.TabButtonPanel.DoubleClick += new EventHandler(Tabs_DoubleClick);
        runnables.Clear();
        runnables.Add(_Language.Python);

        //If the app is opened by right clicking a file it opens a new tab
        string[] paths = Environment.GetCommandLineArgs();
        if (paths.Length > 1)
        {
            AddTab(File.ReadAllText(paths[1]), paths[1].Split('\\')[paths[1].Split('\\').Length - 1], paths[1]);
            //Default things
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - 800, 0);
            Width = 800;
            Height = Screen.PrimaryScreen.Bounds.Height - 40;
            SetLanguage(_Language.None);
        }

    }

}
