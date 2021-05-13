using System.Drawing;
using System.Windows.Forms;

class GhostMenuStrip : MenuStrip
{
    public GhostMenuStrip()
    {
        Renderer = new ToolStripProfessionalRenderer(new ColorTable());
    }
}

class ColorTable : ProfessionalColorTable
{
    public override Color ToolStripDropDownBackground
    {
        get { return Color.FromArgb(45, 45, 45); }
    }

    public override Color MenuItemSelected
    { get { return Color.FromArgb(35,35,35); } }

    public override Color MenuBorder
    { get { return Color.FromArgb(35, 35, 35); } }

    public override Color MenuItemSelectedGradientBegin
    { get { return Color.FromArgb(45, 45, 45); } }

    public override Color MenuItemSelectedGradientEnd
    { get { return Color.FromArgb(45, 45, 45); } }

    public override Color MenuItemBorder
    { get { return Color.FromArgb(35, 35, 35); } }

    public override Color MenuItemPressedGradientBegin
    { get { return Color.FromArgb(45, 45, 45); } }

    public override Color MenuItemPressedGradientEnd
    { get { return Color.FromArgb(45, 45, 45); } }

    public override Color MenuStripGradientBegin
    { get { return Color.FromArgb(35, 35, 35); } }

    public override Color MenuStripGradientEnd
    { get { return Color.FromArgb(35, 35, 35); } }
}