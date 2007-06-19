using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MRUSampleControlLibrary {
  public class InSubMenuMruMenuListRender : IMruMenuListRenderer {

    public void Render(ToolStripMenuItem mruListMenu, MruMenuListItems mruMenuListItems, int textWidth, EventHandler mruMenuItem_Click) {

      // Clear existing sub-menu list items, if any
      mruListMenu.DropDownItems.Clear();
      mruListMenu.Enabled = false;

      // Fill mru menu
      if( mruMenuListItems.Count > 0 ) {
        for( int index = 0; index < mruMenuListItems.Count; index++ ) {
          string filename = mruMenuListItems[index];
          MruToolStripMenuItem mruMenuItem = new MruToolStripMenuItem(filename, textWidth, index + 1, mruMenuItem_Click);
          mruListMenu.DropDownItems.Add(mruMenuItem);
        }
        mruListMenu.Enabled = true;
      }
    }
  }
}