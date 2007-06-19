using System;
using System.Collections.Generic;
using System.Text;

namespace MRUSampleControlLibrary {
  public class MruMenuItemFileMissingEventArgs {
    private string filename;
    private bool removeFromMru;
    public MruMenuItemFileMissingEventArgs(string filename, bool removeFromMru) {
      this.filename = filename;
      this.removeFromMru = removeFromMru;
    }
    public string Filename {
      get { return this.filename; }
    }
    public bool RemoveFromMru {
      get { return this.removeFromMru; }
      set { this.removeFromMru = value; }
    }
  }
}
