using System.Collections.Generic;
using System.Windows.Forms;

namespace PluginAPI
{
    public interface Plugin
    {
        void Init();
        void Update();
        string Name { get; }
        ToolStripMenuItem GetMenuItem(KeyValuePair<string, Plugin> pair);
        void GetMain(Form form);
    }
}
