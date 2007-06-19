using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MRUSampleControlLibrary {
  internal interface IMruMenuListRenderer {
    void Render(ToolStripMenuItem mruListMenu, MruMenuListItems mruMenuListItems, int textWidth, EventHandler mruMenuItem_Click);
  }
}
