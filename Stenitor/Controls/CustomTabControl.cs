using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class CustomTabControl : UserControl
{
    public CustomTabControl()
    {
        InitializeComponent();
    }

    public List<Button> Tabs = new List<Button> { };
    public List<Panel> TabsContent = new List<Panel> { };
    public List<string> Paths = new List<string> { };

    public bool ShowCloseButton = true;
    public bool isRounded = true;
    public int TabCount = 0;
    public int SelectedTabIndex = -1;
    public string SelectedTabName = "";

    private List<Button> closebuttonlist = new List<Button> { };
    private List<string> btstrlist = new List<string> { };
    private List<string> btstrlist2 = new List<string> { };

    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn
    (
        int nLeft,
        int nTop,
        int nRight,
        int nBottom,
        int nWidthEllipse,
        int nHeightEllipse
    );

    private void UpdateButtons()
    {
        if (Tabs.Count > 0)
        {
            for (int i = 0; i < Tabs.Count; i++)
            {
                if (i == SelectedTabIndex)
                {
                    Tabs[i].BackColor = Color.FromArgb(20, 120, 240);
                    Tabs[i].ForeColor = Color.White;
                }
                else
                {
                    Tabs[i].ForeColor = Color.White;
                    Tabs[i].BackColor = Color.FromArgb(40, 40, 40);
                }
            }

        }
        if (ShowCloseButton)
        {
            if (closebuttonlist.Count > 0)
            {
                for (int i = 0; i < closebuttonlist.Count; i++)
                {
                    if (i == SelectedTabIndex)
                    {
                        closebuttonlist[i].BackColor = Color.FromArgb(20, 120, 240);
                    }
                    else
                    {
                        closebuttonlist[i].BackColor = Color.FromArgb(40, 40, 40);
                    }
                }

            }
        }

    }

    private void createAndAddButton(string tabtext, Panel tpcontrol, Point loc, string path)
    {
        Button bx = new Button();
        bx.Text = tabtext;
        bx.Size = new Size(130, 30);
        bx.FlatAppearance.BorderSize = 0;
        bx.FlatStyle = FlatStyle.Flat;
        bx.TextAlign = ContentAlignment.MiddleLeft;
        bx.Location = new Point(loc.X + 3, 10);
        bx.ForeColor = Color.White;
        bx.BackColor = Color.FromArgb(20, 120, 240);
        bx.Font = Font;
        if (isRounded)
        {
            bx.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, bx.Width, bx.Height, 7, 7));
        }
        bx.Click += button_Click;

        if (ShowCloseButton)
        {
            Button close = new Button();
            close.Name = tabtext;
            close.BackgroundImage = CloseImageHolder.Image;
            close.Location = new Point(105, 4);
            close.Size = new Size(20, 20);
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
            close.BackgroundImageLayout = ImageLayout.Stretch;
            close.BackColor = Color.FromArgb(20, 120, 240);
            if (isRounded)
            {
                close.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, close.Width, close.Height, 5, 5));
            }
            close.Click += closebutton_Click;
            closebuttonlist.Add(close);
            bx.Controls.Add(close);
        }
        TabButtonPanel.Controls.Add(bx);
        Tabs.Add(bx);
        Paths.Add(path);

        SelectedTabName = bx.Text;
        TabsContent.Add(tpcontrol);

        UpdateButtons();

        string btext = bx.Text;
        int index = 0, i;
        for (i = 0; i < Tabs.Count; i++)
        {
            if (Tabs[i].Text == btext)
            {
                index = i;
            }
        }

        SelectedTabName = Tabs[index].Text;
        TabPanel.Controls.Clear();
        TabPanel.Controls.Add(TabsContent[index]);
        SelectedTabIndex = bx.TabIndex;

        UpdateButtons();
    }

    public async void SelectTab(int index)
    {
        await Task.Delay(1);
        SelectedTabName = Tabs[index].Text;
        TabPanel.Controls.Clear();
        TabPanel.Controls.Add(TabsContent[index]);
        SelectedTabIndex = index;

        UpdateButtons();
    }

    private void button_Click(object sender, EventArgs e)
    {
        string btext = ((Button)sender).Text;
        int index = 0, i;
        for (i = 0; i < Tabs.Count; i++)
        {
            if (Tabs[i].Text == btext)
            {
                index = i;
            }
        }

        SelectedTabName = Tabs[index].Text;
        TabPanel.Controls.Clear();
        TabPanel.Controls.Add(TabsContent[index]);
        SelectedTabIndex = ((Button)sender).TabIndex;

        UpdateButtons();
    }

    private void closebutton_Click(object sender, EventArgs e)
    {
        string btext = ((Button)sender).Name;
        int index = 0, i;
        for (i = 0; i < closebuttonlist.Count; i++)
        {
            if (closebuttonlist[i].Name == btext)
            {
                index = i;
            }
        }

        RemoveTab(index);
        UpdateButtons();
    }

    public void AddTab(string tabtext, Panel tpcontrol, string path)
    {
        TabCount++;
        if (!Tabs.Any())
        {
            createAndAddButton(tabtext, tpcontrol, new Point(0, 0), path);
        }
        else
        {
            createAndAddButton(tabtext, tpcontrol, new Point(Tabs[Tabs.Count - 1].Size.Width + Tabs[Tabs.Count - 1].Location.X, 0), path);
        }
    }

    public void BackToFront_SelButton()
    {
        int i = 0;

        TabButtonPanel.Controls.Clear();
        btstrlist.Clear();
        for (i = 0; i < Tabs.Count; i++)
        {
            btstrlist.Add(Tabs[i].Text);
        }
        Tabs.Clear();

        for (i = 0; i < closebuttonlist.Count; i++)
        {
            btstrlist2.Add(closebuttonlist[i].Name);
        }
        closebuttonlist.Clear();

        for (int j = 0; j < btstrlist.Count; j++)
        {
            if (j == 0)
            {
                Button bx = new Button();
                bx.Text = btstrlist[j];
                bx.Size = new Size(130, 30);
                bx.TextAlign = ContentAlignment.MiddleLeft;
                bx.FlatStyle = FlatStyle.Flat;
                bx.FlatAppearance.BorderSize = 0;
                bx.Location = new Point(3, 10);
                bx.ForeColor = Color.White;
                bx.BackColor = Color.FromArgb(20, 120, 240);
                bx.Font = Font;
                if (isRounded)
                {
                    bx.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, bx.Width, bx.Height, 7, 7));
                }
                bx.Click += button_Click;
                SelectedTabName = bx.Text;
                TabButtonPanel.Controls.Add(bx);
                Tabs.Add(bx);
                SelectedTabIndex++;

                if (ShowCloseButton)
                {
                    Button close = new Button();
                    close.Name = btstrlist[j];
                    close.BackgroundImage = CloseImageHolder.Image;
                    close.Location = new Point(105, 4);
                    close.Size = new Size(20, 20);
                    close.FlatStyle = FlatStyle.Flat;
                    close.FlatAppearance.BorderSize = 0;
                    close.BackgroundImageLayout = ImageLayout.Stretch;
                    close.BackColor = Color.FromArgb(20, 120, 240);
                    if (isRounded)
                    {
                        close.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, close.Width, close.Height, 5, 5));
                    }
                    close.Click += closebutton_Click;
                    closebuttonlist.Add(close);
                    bx.Controls.Add(close);
                }
            }
            else if (j > 0)
            {
                Button bx = new Button();
                bx.Text = btstrlist[j];
                bx.TextAlign = ContentAlignment.MiddleLeft;
                bx.Size = new Size(130, 33);
                bx.FlatStyle = FlatStyle.Flat;
                bx.Location = new Point(3, 3);
                bx.FlatAppearance.BorderSize = 0;
                bx.ForeColor = Color.White;
                bx.BackColor = Color.FromArgb(20, 120, 240);
                bx.Font = Font;
                if (isRounded)
                {
                    bx.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, bx.Width, bx.Height, 7, 7));
                }
                bx.Click += button_Click;
                bx.Location = new Point(Tabs[j - 1].Size.Width + Tabs[j - 1].Location.X + 3, 3);
                SelectedTabName = bx.Text;
                TabButtonPanel.Controls.Add(bx);
                Tabs.Add(bx);
                SelectedTabIndex++;

                if (ShowCloseButton)
                {
                    Button close = new Button();
                    close.Name = btstrlist[j];
                    close.BackgroundImage = CloseImageHolder.Image;
                    close.Location = new Point(105, 4);
                    close.Size = new Size(20, 20);
                    close.FlatStyle = FlatStyle.Flat;
                    close.FlatAppearance.BorderSize = 0;
                    close.BackgroundImageLayout = ImageLayout.Stretch;
                    close.BackColor = Color.FromArgb(20, 120, 240);
                    if (isRounded)
                    {
                        close.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, close.Width, close.Height, 5, 5));
                    }
                    close.Click += closebutton_Click;
                    closebuttonlist.Add(close);
                    bx.Controls.Add(close);
                }
            }
        }

        TabPanel.Controls.Clear();
    }

    public void RemoveTab(int index)
    {
        if (index >= 0 && Tabs.Count > 0 && index < Tabs.Count)
        {
            Tabs.RemoveAt(index);
            TabsContent.RemoveAt(index);
            Paths.RemoveAt(index);
            BackToFront_SelButton();
            TabCount--;
            if (Tabs.Count > 1)
            {
                if (index - 1 >= 0)
                {
                    TabPanel.Controls.Add(TabsContent[index - 1]);
                }
                else
                {
                    TabPanel.Controls.Add(TabsContent[(index - 1) + 1]);
                    SelectedTabIndex = (index - 1) + 1;
                }
            }

            SelectedTabIndex = index - 1;

            if (Tabs.Count == 1)
            {
                TabPanel.Controls.Add(TabsContent[0]);
                SelectedTabIndex = 0;
            }

        }

        UpdateButtons();
    }

}