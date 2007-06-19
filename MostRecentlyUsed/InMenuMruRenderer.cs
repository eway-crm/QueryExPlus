using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MRUSampleControlLibrary {
  public class InMenuMruMenuListRender : IMruMenuListRenderer {

    public void Render(ToolStripMenuItem mruListMenu, MruMenuListItems mruMenuListItems, int textWidth, EventHandler mruMenuItem_Click) {

      // Clear existing menu items, if any
      ToolStripDropDownMenu rootMenu = (ToolStripDropDownMenu)mruListMenu.Owner;
      int mruListMenuIndex = rootMenu.Items.IndexOf(mruListMenu);
      for( int index = rootMenu.Items.Count - 1; index > mruListMenuIndex; index-- ) {
        if( rootMenu.Items[index] is MruToolStripMenuItem ) {
          rootMenu.Items.RemoveAt(index);
        }
      }
      mruListMenu.Enabled = false;
      mruListMenu.Visible = true;

      // Fill MRU menu
      if( mruMenuListItems.Count > 0 ) {
        for( int index = 0; index < mruMenuListItems.Count; index++ ) {
          string filename = mruMenuListItems[index];
          MruToolStripMenuItem mruMenuItem = new MruToolStripMenuItem(filename, textWidth, index + 1, mruMenuItem_Click);
          rootMenu.Items.Insert(mruListMenuIndex + index + 1, mruMenuItem);
        }
        mruListMenu.Enabled = true;
        mruListMenu.Visible = false;
      }
    }
  }
}
