using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using PluginAPI;

namespace Example_Plugin
{
    public class ExamplePlugin : Plugin
    {
        public string Name => "Example Plugin";
        public Main main; //This is the Main form, you can use it to change things inside the main form, like main.Width = 100; will set the form width to 100

        public void GetMain(Form form)
        {
            //This function just updates the "main" variable 10 times per second (every 100 milliseconds), recommended to not change anything inside this form
            main = (Main)form;
        }

        public void Init() 
        {
            //This function will be called when the Plugin gets loaded
        }

        public void Update() 
        {
            //This function will be called 10 times per second (every 100 milliseconds)
        }

        public ToolStripMenuItem GetMenuItem(KeyValuePair<string, Plugin> pair)
        {
            //This function will be called on initialization to create the toolstrip item inside the Plugins menu item
            //This item will show in the "Plugins" tool strip
            ToolStripMenuItem mainItem = new ToolStripMenuItem(pair.Key);
            mainItem.BackColor = Color.FromArgb(45, 45, 45);
            mainItem.ForeColor = Color.White;

            ToolStripMenuItem clearItem = new ToolStripMenuItem();
            clearItem.Click += new EventHandler(ClearText_Click);
            clearItem.Text = "Clear Text";
            clearItem.BackColor = Color.FromArgb(45, 45, 45);
            clearItem.ForeColor = Color.White;

            ToolStripMenuItem addTabItem = new ToolStripMenuItem();
            addTabItem.Click += new EventHandler(AddTab_Click);
            addTabItem.Text = "Add Tab";
            addTabItem.BackColor = Color.FromArgb(45, 45, 45);
            addTabItem.ForeColor = Color.White;
            
            //Add the items to the final item
            mainItem.DropDownItems.Add(addTabItem);
            mainItem.DropDownItems.Add(clearItem);
            return mainItem;
        }

        private void ClearText_Click(object sender, EventArgs e)
        { 
            //Gets the webbrowser object inside the monacobox
            WebBrowser wb = main.GetMonaco(main.Tabs.SelectedTabIndex).Controls.Find("webBrowser1", true).FirstOrDefault() as WebBrowser;
            wb.Document.InvokeScript("SetText", new object[] { "" }); //Sets the text to nothing
        }

        private void AddTab_Click(object sender, EventArgs e)
        {
            main.AddTab("", "New " + (main.Tabs.TabCount + 1), ""); //Adds the tab page to the tab control
        }
    }
}