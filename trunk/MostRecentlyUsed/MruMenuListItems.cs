using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace MRUSampleControlLibrary {

  public class MruMenuListItems : List<string> {

    private int maximumItems;

    public MruMenuListItems(int maximumItems) {
      this.maximumItems = maximumItems;
    }

    public int MaximumItems {
      get { return maximumItems; }
      set {
        maximumItems = value;

        // Remove extra if more than capacity
        TrimToMaximumItems();
      }
    }

    public new int Add(string value) {
      // Get the index of this value
      int valueIndex = this.IndexOf(value);

      // Don't do anything if this file is the first item
      if( valueIndex == 0 ) return -1;

      // Move file to top if already in the list, unless it's the first item
      if( valueIndex > 0 ) this.RemoveAt(valueIndex);
      this.Insert(0, value);

      // Remove extra if more than capacity
      TrimToMaximumItems();

      return 0;
    }

    private void TrimToMaximumItems() {
      if( this.Count > maximumItems ) {
        for( int i = this.Count - 1; i >= maximumItems; i-- ) {
          this.RemoveAt(maximumItems);
        }
      }
    }
  }
}
