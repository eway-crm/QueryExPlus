using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Text;

namespace MRUSampleControlLibrary {
  class MruMenuManagerSettings : ApplicationSettingsBase {

    public MruMenuManagerSettings(IComponent owner, string settingsKey) : base(owner, settingsKey) { }

    [UserScopedSetting]
    public ArrayList MruListItems {
      get { return (ArrayList)this["MruListItems"]; }
      set { this["MruListItems"] = value; }
    }
  }
}
