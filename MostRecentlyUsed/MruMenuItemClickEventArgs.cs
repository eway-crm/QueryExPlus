using System;
using System.Collections.Generic;
using System.Text;

namespace MRUSampleControlLibrary {

  public class MruMenuItemClickEventArgs {
    private string filename;
    public MruMenuItemClickEventArgs(string filename) {
      this.filename = filename;
    }
    public string Filename {
      get { return this.filename; }
    }
  }

}
