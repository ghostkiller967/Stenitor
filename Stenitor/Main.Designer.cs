
partial class Main
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ToolBarPanel = new System.Windows.Forms.Panel();
            this.Minimize = new System.Windows.Forms.Button();
            this.Fullscreen = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.ToolStrip = new GhostMenuStrip();
            this.FileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.New = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstallRegistryKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.Language = new System.Windows.Forms.ToolStripMenuItem();
            this.Lua = new System.Windows.Forms.ToolStripMenuItem();
            this.None = new System.Windows.Forms.ToolStripMenuItem();
            this.Python = new System.Windows.Forms.ToolStripMenuItem();
            this.View = new System.Windows.Forms.ToolStripMenuItem();
            this.ToggleConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.Plugins = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsolePanel = new System.Windows.Forms.Panel();
            this.ConsoleSizePanel = new System.Windows.Forms.Panel();
            this.ConsoleLabel = new System.Windows.Forms.Label();
            this.ConsoleBox = new System.Windows.Forms.RichTextBox();
            this.CloseConsoleButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.Tabs = new CustomTabControl();
            this.TopSizer = new System.Windows.Forms.Panel();
            this.LeftSizer = new System.Windows.Forms.Panel();
            this.RightSizer = new System.Windows.Forms.Panel();
            this.BottomSizer = new System.Windows.Forms.Panel();
            this.Loop = new System.Windows.Forms.Timer(this.components);
            this.ToolBarPanel.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.ConsolePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBarPanel
            // 
            this.ToolBarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ToolBarPanel.Controls.Add(this.Minimize);
            this.ToolBarPanel.Controls.Add(this.Fullscreen);
            this.ToolBarPanel.Controls.Add(this.Exit);
            this.ToolBarPanel.Controls.Add(this.LanguageLabel);
            this.ToolBarPanel.Controls.Add(this.ToolStrip);
            this.ToolBarPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolBarPanel.Name = "ToolBarPanel";
            this.ToolBarPanel.Size = new System.Drawing.Size(1000, 29);
            this.ToolBarPanel.TabIndex = 1;
            // 
            // Minimize
            // 
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Minimize.BackgroundImage = global::Stenitor.Properties.Resources.subtract_25px;
            this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Minimize.FlatAppearance.BorderSize = 0;
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minimize.ForeColor = System.Drawing.Color.White;
            this.Minimize.Location = new System.Drawing.Point(865, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(45, 25);
            this.Minimize.TabIndex = 5;
            this.Minimize.UseVisualStyleBackColor = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // Fullscreen
            // 
            this.Fullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Fullscreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Fullscreen.BackgroundImage = global::Stenitor.Properties.Resources.fill_dock_25px;
            this.Fullscreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Fullscreen.FlatAppearance.BorderSize = 0;
            this.Fullscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Fullscreen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fullscreen.ForeColor = System.Drawing.Color.White;
            this.Fullscreen.Location = new System.Drawing.Point(910, 0);
            this.Fullscreen.Name = "Fullscreen";
            this.Fullscreen.Size = new System.Drawing.Size(45, 25);
            this.Fullscreen.TabIndex = 4;
            this.Fullscreen.UseVisualStyleBackColor = false;
            this.Fullscreen.Click += new System.EventHandler(this.Fullscreen_Click);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Exit.BackgroundImage = global::Stenitor.Properties.Resources.delete_25px;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(955, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(45, 25);
            this.Exit.TabIndex = 3;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.LanguageLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LanguageLabel.ForeColor = System.Drawing.Color.White;
            this.LanguageLabel.Location = new System.Drawing.Point(769, 4);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LanguageLabel.Size = new System.Drawing.Size(96, 23);
            this.LanguageLabel.TabIndex = 3;
            this.LanguageLabel.Tag = "";
            this.LanguageLabel.Text = "Python";
            this.LanguageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LanguageLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LanguageLabel_MouseDown);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileButton,
            this.Language,
            this.View,
            this.Plugins});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(1000, 24);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "ToolStrip";
            this.ToolStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolStrip_MouseDown);
            // 
            // FileButton
            // 
            this.FileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New,
            this.Open,
            this.Save,
            this.settingsToolStripMenuItem});
            this.FileButton.ForeColor = System.Drawing.Color.White;
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(37, 20);
            this.FileButton.Text = "File";
            // 
            // New
            // 
            this.New.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.New.ForeColor = System.Drawing.Color.White;
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(116, 22);
            this.New.Text = "New";
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // Open
            // 
            this.Open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Open.ForeColor = System.Drawing.Color.White;
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(116, 22);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Save.ForeColor = System.Drawing.Color.White;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(116, 22);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InstallRegistryKeys});
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // InstallRegistryKeys
            // 
            this.InstallRegistryKeys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.InstallRegistryKeys.ForeColor = System.Drawing.Color.White;
            this.InstallRegistryKeys.Name = "InstallRegistryKeys";
            this.InstallRegistryKeys.Size = new System.Drawing.Size(177, 22);
            this.InstallRegistryKeys.Text = "Install Registry Keys";
            this.InstallRegistryKeys.Click += new System.EventHandler(this.InstallRegistryKeys_Click);
            // 
            // Language
            // 
            this.Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Lua,
            this.None,
            this.Python});
            this.Language.ForeColor = System.Drawing.Color.White;
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(71, 20);
            this.Language.Text = "Language";
            // 
            // Lua
            // 
            this.Lua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Lua.ForeColor = System.Drawing.Color.White;
            this.Lua.Name = "Lua";
            this.Lua.Size = new System.Drawing.Size(112, 22);
            this.Lua.Text = "Lua";
            this.Lua.Click += new System.EventHandler(this.Lua_Click);
            // 
            // None
            // 
            this.None.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.None.ForeColor = System.Drawing.Color.White;
            this.None.Name = "None";
            this.None.Size = new System.Drawing.Size(112, 22);
            this.None.Text = "None";
            this.None.Click += new System.EventHandler(this.None_Click);
            // 
            // Python
            // 
            this.Python.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Python.ForeColor = System.Drawing.Color.White;
            this.Python.Name = "Python";
            this.Python.Size = new System.Drawing.Size(112, 22);
            this.Python.Text = "Python";
            this.Python.Click += new System.EventHandler(this.Python_Click);
            // 
            // View
            // 
            this.View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleConsole});
            this.View.ForeColor = System.Drawing.Color.White;
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(44, 20);
            this.View.Text = "View";
            // 
            // ToggleConsole
            // 
            this.ToggleConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ToggleConsole.ForeColor = System.Drawing.Color.White;
            this.ToggleConsole.Name = "ToggleConsole";
            this.ToggleConsole.Size = new System.Drawing.Size(117, 22);
            this.ToggleConsole.Text = "Console";
            this.ToggleConsole.Click += new System.EventHandler(this.Console_Click);
            // 
            // Plugins
            // 
            this.Plugins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Plugins.ForeColor = System.Drawing.Color.White;
            this.Plugins.Name = "Plugins";
            this.Plugins.Size = new System.Drawing.Size(58, 20);
            this.Plugins.Text = "Plugins";
            // 
            // ConsolePanel
            // 
            this.ConsolePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsolePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ConsolePanel.Controls.Add(this.ConsoleSizePanel);
            this.ConsolePanel.Controls.Add(this.ConsoleLabel);
            this.ConsolePanel.Controls.Add(this.ConsoleBox);
            this.ConsolePanel.Controls.Add(this.CloseConsoleButton);
            this.ConsolePanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ConsolePanel.Location = new System.Drawing.Point(0, 381);
            this.ConsolePanel.Name = "ConsolePanel";
            this.ConsolePanel.Size = new System.Drawing.Size(1000, 170);
            this.ConsolePanel.TabIndex = 2;
            this.ConsolePanel.Visible = false;
            // 
            // ConsoleSizePanel
            // 
            this.ConsoleSizePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleSizePanel.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.ConsoleSizePanel.Location = new System.Drawing.Point(0, 0);
            this.ConsoleSizePanel.Name = "ConsoleSizePanel";
            this.ConsoleSizePanel.Size = new System.Drawing.Size(1000, 4);
            this.ConsoleSizePanel.TabIndex = 6;
            this.ConsoleSizePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConsoleSizePanel_MouseDown);
            this.ConsoleSizePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ConsoleSizePanel_MouseMove);
            this.ConsoleSizePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ConsoleSizePanel_MouseUp);
            // 
            // ConsoleLabel
            // 
            this.ConsoleLabel.AutoSize = true;
            this.ConsoleLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleLabel.ForeColor = System.Drawing.Color.White;
            this.ConsoleLabel.Location = new System.Drawing.Point(4, 6);
            this.ConsoleLabel.Name = "ConsoleLabel";
            this.ConsoleLabel.Size = new System.Drawing.Size(62, 20);
            this.ConsoleLabel.TabIndex = 5;
            this.ConsoleLabel.Text = "Console";
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ConsoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleBox.ForeColor = System.Drawing.Color.White;
            this.ConsoleBox.Location = new System.Drawing.Point(3, 33);
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.ReadOnly = true;
            this.ConsoleBox.Size = new System.Drawing.Size(994, 133);
            this.ConsoleBox.TabIndex = 4;
            this.ConsoleBox.Text = "Console";
            // 
            // CloseConsoleButton
            // 
            this.CloseConsoleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseConsoleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.CloseConsoleButton.BackgroundImage = global::Stenitor.Properties.Resources.delete_25px;
            this.CloseConsoleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseConsoleButton.FlatAppearance.BorderSize = 0;
            this.CloseConsoleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseConsoleButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseConsoleButton.ForeColor = System.Drawing.Color.White;
            this.CloseConsoleButton.Location = new System.Drawing.Point(972, 3);
            this.CloseConsoleButton.Name = "CloseConsoleButton";
            this.CloseConsoleButton.Size = new System.Drawing.Size(25, 25);
            this.CloseConsoleButton.TabIndex = 3;
            this.CloseConsoleButton.UseVisualStyleBackColor = false;
            this.CloseConsoleButton.Click += new System.EventHandler(this.CloseConsoleButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RunButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.RunButton.BackgroundImage = global::Stenitor.Properties.Resources.play_32px;
            this.RunButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RunButton.FlatAppearance.BorderSize = 0;
            this.RunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunButton.ForeColor = System.Drawing.Color.White;
            this.RunButton.Location = new System.Drawing.Point(971, 29);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(25, 25);
            this.RunButton.TabIndex = 0;
            this.RunButton.UseVisualStyleBackColor = false;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tabs.Location = new System.Drawing.Point(2, 19);
            this.Tabs.Name = "Tabs";
            this.Tabs.Size = new System.Drawing.Size(998, 530);
            this.Tabs.TabIndex = 0;
            this.Tabs.Tag = "";
            // 
            // TopSizer
            // 
            this.TopSizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopSizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TopSizer.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.TopSizer.Location = new System.Drawing.Point(0, 0);
            this.TopSizer.Name = "TopSizer";
            this.TopSizer.Size = new System.Drawing.Size(865, 4);
            this.TopSizer.TabIndex = 3;
            this.TopSizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopSizer_MouseDown);
            this.TopSizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopSizer_MouseMove);
            this.TopSizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopSizer_MouseUp);
            // 
            // LeftSizer
            // 
            this.LeftSizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftSizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.LeftSizer.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.LeftSizer.Location = new System.Drawing.Point(0, 0);
            this.LeftSizer.Name = "LeftSizer";
            this.LeftSizer.Size = new System.Drawing.Size(4, 550);
            this.LeftSizer.TabIndex = 4;
            this.LeftSizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftSizer_MouseDown);
            this.LeftSizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LeftSizer_MouseMove);
            this.LeftSizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LeftSizer_MouseUp);
            // 
            // RightSizer
            // 
            this.RightSizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RightSizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.RightSizer.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.RightSizer.Location = new System.Drawing.Point(996, 25);
            this.RightSizer.Name = "RightSizer";
            this.RightSizer.Size = new System.Drawing.Size(4, 525);
            this.RightSizer.TabIndex = 5;
            this.RightSizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RightSizer_MouseDown);
            this.RightSizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RightSizer_MouseMove);
            this.RightSizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RightSizer_MouseUp);
            // 
            // BottomSizer
            // 
            this.BottomSizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomSizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BottomSizer.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.BottomSizer.Location = new System.Drawing.Point(0, 546);
            this.BottomSizer.Name = "BottomSizer";
            this.BottomSizer.Size = new System.Drawing.Size(1000, 4);
            this.BottomSizer.TabIndex = 6;
            this.BottomSizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BottomSizer_MouseDown);
            this.BottomSizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BottomSizer_MouseMove);
            this.BottomSizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BottomSizer_MouseUp);
            // 
            // Loop
            // 
            this.Loop.Enabled = true;
            this.Loop.Tick += new System.EventHandler(this.Loop_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.BottomSizer);
            this.Controls.Add(this.RightSizer);
            this.Controls.Add(this.LeftSizer);
            this.Controls.Add(this.TopSizer);
            this.Controls.Add(this.ConsolePanel);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.ToolBarPanel);
            this.Controls.Add(this.Tabs);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stenitor";
            this.ToolBarPanel.ResumeLayout(false);
            this.ToolBarPanel.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ConsolePanel.ResumeLayout(false);
            this.ConsolePanel.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel ToolBarPanel;
    private GhostMenuStrip ToolStrip;
    private System.Windows.Forms.ToolStripMenuItem FileButton;
    private System.Windows.Forms.ToolStripMenuItem New;
    private System.Windows.Forms.ToolStripMenuItem Open;
    private System.Windows.Forms.ToolStripMenuItem Save;
    private System.Windows.Forms.ToolStripMenuItem Language;
    private System.Windows.Forms.ToolStripMenuItem Python;
    private System.Windows.Forms.ToolStripMenuItem View;
    private System.Windows.Forms.ToolStripMenuItem ToggleConsole;
    private System.Windows.Forms.ToolStripMenuItem Lua;
    private System.Windows.Forms.Label LanguageLabel;
    private System.Windows.Forms.Panel ConsoleSizePanel;
    private System.Windows.Forms.Button Fullscreen;
    private System.Windows.Forms.Button Exit;
    private System.Windows.Forms.Button Minimize;
    private System.Windows.Forms.Panel TopSizer;
    private System.Windows.Forms.Panel LeftSizer;
    private System.Windows.Forms.Panel RightSizer;
    private System.Windows.Forms.Panel BottomSizer;
    private System.Windows.Forms.ToolStripMenuItem Plugins;
    public CustomTabControl Tabs;
    private System.Windows.Forms.Timer Loop;
    public System.Windows.Forms.Panel ConsolePanel;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem InstallRegistryKeys;
    private System.Windows.Forms.ToolStripMenuItem None;
    public System.Windows.Forms.Button RunButton;
    public System.Windows.Forms.RichTextBox ConsoleBox;
    public System.Windows.Forms.Button CloseConsoleButton;
    public System.Windows.Forms.Label ConsoleLabel;
}
