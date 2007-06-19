using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MRUSampleControlLibrary {
  public class MruToolStripMenuItem : ToolStripMenuItem {

    private string filename;

    public MruToolStripMenuItem(string filename, int textWidth, int index, System.EventHandler click) {
      this.filename = filename;
      this.Click += click;
      this.Text = GetMruMenuItemText(filename, textWidth, index);
    }

    public string Filename {
      get { return filename; }
    }
    
    private string GetMruMenuItemText(string filename, int textWidth, int index) {
      string formattedAccessKey = GetFormattedAccessKey(index);
      string formattedFilename = GetFormattedFilename(filename, textWidth);
      return string.Format("{0} {1}", formattedAccessKey, formattedFilename);
    }

    private string GetFormattedAccessKey(int index) {
      // Build numeric access key
      if( index <= 9 ) return string.Format("&{0}", index);
      else if( index == 10 ) return "1&0";
      else return index.ToString();
    }

    // Derived from original post by James Berry from Chris Sells's win_tech_off_topic list
    private string GetFormattedFilename(string filename, int textWidth) {
      // We will begin by taking the string and splitting it apart into an array
      // Check if we are within the max length then return the whole string
      if( filename.Length <= textWidth ) return filename;

      // Split the string into an array using the \ as a delimiter
      char[] seperator = { '\\' };
      string[] pathBits;
      pathBits = filename.Split(seperator);

      // The first value of the array is taken in case we need to create the string
      StringBuilder sb = new StringBuilder();
      int length = sb.Length;
      int beginLength = pathBits[0].Length + 3;
      bool addHeader = false;
      string pathItem;
      int pathItemLength;

      // Now we loop backwards through the string
      for( int pathItemIndex = pathBits.Length - 1; pathItemIndex > 0; pathItemIndex-- ) {
        pathItem = '\\' + pathBits[pathItemIndex];
        pathItemLength = pathItem.Length;

        // Check if adding the current item does not increase the length of the 
        // max string
        if( length + pathItemLength <= textWidth ) {
          // In this case we can afford to add the item
          sb.Insert(0, pathItem);
          length += pathItemLength;
        }
        else break;

        // Check if there is room to add the header and if so then reserve it by 
        // incrementing the length
        if( (addHeader == false) && (length + beginLength <= textWidth) ) {
          addHeader = true;
          length += beginLength;
        }
      }

      // It is possible that the last value in the array itself was long
      // In such case simply use the substring of the last value
      if( sb.Length == 0 ) return pathBits[pathBits.Length - 1].Substring(0, textWidth);

      // Add the header if the bool is true
      if( addHeader == true ) sb.Insert(0, pathBits[0] + "\\...");
      return sb.ToString();
    }
  }
}