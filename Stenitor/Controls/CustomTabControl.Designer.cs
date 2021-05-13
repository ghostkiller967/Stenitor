

partial class CustomTabControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.BackTopPanel = new System.Windows.Forms.Panel();
        this.RibbonPanel = new System.Windows.Forms.Panel();
        this.TabButtonPanel = new System.Windows.Forms.Panel();
        this.TabPanel = new System.Windows.Forms.Panel();
        this.CloseImageHolder = new System.Windows.Forms.PictureBox();
        this.BackTopPanel.SuspendLayout();
        this.TabPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.CloseImageHolder)).BeginInit();
        this.SuspendLayout();
        // 
        // BackTopPanel
        // 
        this.BackTopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
        this.BackTopPanel.Controls.Add(this.RibbonPanel);
        this.BackTopPanel.Controls.Add(this.TabButtonPanel);
        this.BackTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
        this.BackTopPanel.Location = new System.Drawing.Point(0, 0);
        this.BackTopPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        this.BackTopPanel.Name = "BackTopPanel";
        this.BackTopPanel.Size = new System.Drawing.Size(500, 35);
        this.BackTopPanel.TabIndex = 6;
        // 
        // RibbonPanel
        // 
        this.RibbonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.RibbonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(120)))), ((int)(((byte)(240)))));
        this.RibbonPanel.Location = new System.Drawing.Point(0, 30);
        this.RibbonPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        this.RibbonPanel.Name = "RibbonPanel";
        this.RibbonPanel.Size = new System.Drawing.Size(500, 1);
        this.RibbonPanel.TabIndex = 0;
        // 
        // TabButtonPanel
        // 
        this.TabButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
        this.TabButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
        this.TabButtonPanel.Location = new System.Drawing.Point(0, 0);
        this.TabButtonPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        this.TabButtonPanel.Name = "TabButtonPanel";
        this.TabButtonPanel.Size = new System.Drawing.Size(500, 30);
        this.TabButtonPanel.TabIndex = 1;
        // 
        // TabPanel
        // 
        this.TabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.TabPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
        this.TabPanel.Controls.Add(this.CloseImageHolder);
        this.TabPanel.Location = new System.Drawing.Point(0, 35);
        this.TabPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
        this.TabPanel.Name = "TabPanel";
        this.TabPanel.Size = new System.Drawing.Size(500, 265);
        this.TabPanel.TabIndex = 7;
        // 
        // CloseImageHolder
        // 
        this.CloseImageHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.CloseImageHolder.Image = global::Stenitor.Properties.Resources.delete_25px;
        this.CloseImageHolder.Location = new System.Drawing.Point(3, 242);
        this.CloseImageHolder.Name = "CloseImageHolder";
        this.CloseImageHolder.Size = new System.Drawing.Size(20, 20);
        this.CloseImageHolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.CloseImageHolder.TabIndex = 0;
        this.CloseImageHolder.TabStop = false;
        this.CloseImageHolder.Visible = false;
        // 
        // CustomTabControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.BackTopPanel);
        this.Controls.Add(this.TabPanel);
        this.Name = "CustomTabControl";
        this.Size = new System.Drawing.Size(500, 300);
        this.BackTopPanel.ResumeLayout(false);
        this.TabPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.CloseImageHolder)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel BackTopPanel;
    private System.Windows.Forms.Panel RibbonPanel;
    public System.Windows.Forms.Panel TabButtonPanel;
    public System.Windows.Forms.Panel TabPanel;
    private System.Windows.Forms.PictureBox CloseImageHolder;

}