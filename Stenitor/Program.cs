using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    
    public static string version = "2.0";

    [STAThread]
    static void Main()
    {
        WebClient wc = new WebClient();

        try
        {
            //Checks if there is a new update
            if (wc.DownloadString("https://pastebin.com/raw/NAvmDc8e") == version)
            {
                //No update found so it just continues normally by running
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            else
            {
                //Asks if the user wants to update
                if (MessageBox.Show("There is a new update, do you want to install it?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Downloads the new version
                    wc.DownloadFile(wc.DownloadString("https://pastebin.com/raw/dyJqKQJN"), $"Stenitor v{wc.DownloadString("https://pastebin.com/raw/NAvmDc8e")}.exe");
                    //Starts the new version
                    Process.Start(Application.StartupPath + $"/Stenitor v{wc.DownloadString("https://pastebin.com/raw/NAvmDc8e")}.exe");
                    //Deletes the old version
                    Process.Start(new ProcessStartInfo()
                    {
                        Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        FileName = "cmd.exe"
                    });
                }
                else
                {
                    //User doesn't want to update so it continues normally
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                }
            }
        } catch
        {
            //User isn't connected to the internet so it just continues normally
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

    }
}
