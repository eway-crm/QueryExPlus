using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MRUSampleControlLibrary {

  [DefaultEventAttribute("MruMenuItemClick")]
  public class MruMenuManager : Component, IPersistComponentSettings {

    // MRU menu list items buffer
    MruMenuListItems mruMenuListItems;

    // Property fields
    ToolStripMenuItem mruListMenu = null;
    MruListDisplayStyle displayMode = MruListDisplayStyle.InMenu;
    int textWidth = 40;
    int maximumItems = 10;

    public MruMenuManager() {
      mruMenuListItems = new MruMenuListItems(MaximumItems);
    }
    public MruMenuManager(IContainer container)
      : this() {
      container.Add(this);
    }

    [CategoryAttribute("Appearance")]
    [DescriptionAttribute("Gets or sets the menu item that will display the Mru list.")]
    [DefaultValueAttribute(null)]
    public ToolStripMenuItem MruListMenu {
      get { return mruListMenu; }
      set {
        mruListMenu = value;
        // Register Opening event
        if( (!this.DesignMode) && (mruListMenu != null) ) {
          ToolStripDropDownMenu rootMenu = (ToolStripDropDownMenu)mruListMenu.Owner;
          rootMenu.Opening += RootMenu_Opening;
        }
      }
    }

    [CategoryAttribute("Appearance")]
    [DescriptionAttribute("Gets or sets the Mru menu's display mode; in the same menu or in a sub-menu.")]
    [DefaultValueAttribute(MruListDisplayStyle.InMenu)]
    public MruListDisplayStyle DisplayStyle {
      get { return displayMode; }
      set { displayMode = value; }
    }

    [CategoryAttribute("Appearance")]
    [DescriptionAttribute("Gets or sets the maximum number of characters displayed per MRU menu item.")]
    [DefaultValueAttribute(40)]
    public int TextWidth {
      get { return textWidth; }
      set {
        // TextWidth must be > 0
        if( value < 0 ) {
          throw new ArgumentOutOfRangeException("TextWidth cannot be less than zero");
        }
        textWidth = value;
      }
    }

    [CategoryAttribute("Appearance")]
    [DescriptionAttribute("Gets or sets the maximum number of MRU menu items to be displayed.")]
    [DefaultValueAttribute(10)]
    public int MaximumItems {
      get { return maximumItems; }
      set {
        // MaximumItems must be > 0
        if( value < 0 ) {
          throw new ArgumentOutOfRangeException("MaximumItems cannot be less than zero");
        }
        maximumItems = value;

        // Update MRU menu list items buffer with new
        // maximum items size
        if( !this.DesignMode ) {
          mruMenuListItems.MaximumItems = maximumItems;
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ArrayList Filenames {
      get {
        return new ArrayList(this.mruMenuListItems.ToArray());
      }
      set {
        if( value == null ) return;
        this.mruMenuListItems.Clear();
        this.mruMenuListItems.AddRange((string[])value.ToArray(typeof(string)));
      }
    }

    // Add a filename to the mru menu list
    public void Add(string filename) {
      mruMenuListItems.Add(filename);
    }

    [CategoryAttribute("Action")]
    [DescriptionAttribute("Occurs when a MRU menu item is clicked.")]
    public event MruMenuItemClickEventHandler MruMenuItemClick;
    protected virtual void OnMruMenuItemClick(MruMenuItemClickEventArgs e) {
      if( MruMenuItemClick != null ) {
        MruMenuItemClick(this, e);
        // Move file to front of MRU
        this.Add(e.Filename);
      }
    }

    [CategoryAttribute("Action")]
    [DescriptionAttribute("Occurs when a file in the MRU Menu is missing.")]
    public event MruMenuItemFileMissingEventHandler MruMenuItemFileMissing;
    protected virtual void OnMruMenuItemFileMissing(MruMenuItemFileMissingEventArgs e) {
      if( MruMenuItemFileMissing != null ) {
        MruMenuItemFileMissing(this, e);
      }
    }

    // Render mru menu list with Mru items
    private void RootMenu_Opening(object sender, CancelEventArgs e) {

      // Bail if an mru list menu item hasn't been set
      if( mruListMenu == null ) return;

      // Render mru list menu items
      if( displayMode == MruListDisplayStyle.InMenu ) {
        RenderInMenu();
      }
      else {
        RenderInSubMenu();
      }
    }
    private void MruMenuItem_Click(object sender, System.EventArgs e) {
      // Get clicked MruToolStripMenuItem
      MruToolStripMenuItem mruMenuItem = (MruToolStripMenuItem)sender;
      string filename = mruMenuItem.Filename;

      // Check if file is missing and, if so, ask if it needs to 
      // be deleted. If nobody's registered with the MruMenuItemFileMissing
      // event, the file won't be deleted, MruMenuItemClick will be
      // called and an exception will be raised if the file is missing.
      MruMenuItemFileMissingEventArgs args = new MruMenuItemFileMissingEventArgs(filename, false);
      if( !File.Exists(filename) ) {
        OnMruMenuItemFileMissing(args);
        if( args.RemoveFromMru ) {
          this.mruMenuListItems.Remove(filename);
          return;
        }
      }

      OnMruMenuItemClick(new MruMenuItemClickEventArgs(filename));
    }

    private void RenderInMenu() {

      // Clear existing menu items, if any
      ToolStripDropDownMenu rootMenu = (ToolStripDropDownMenu)mruListMenu.Owner;
      int mruListMenuIndex = rootMenu.Items.IndexOf(mruListMenu);
      for( int index = rootMenu.Items.Count - 1; index > mruListMenuIndex; index-- ) {
        if( rootMenu.Items[index] is MruToolStripMenuItem ) {
          rootMenu.Items.RemoveAt(index);
        }
      }

      // Hide mru list menu
      mruListMenu.Enabled = false;
      mruListMenu.Visible = true;

      // Render mru menu
      if( mruMenuListItems.Count > 0 ) {
        for( int index = 0; index < mruMenuListItems.Count; index++ ) {
          string filename = mruMenuListItems[index];
          MruToolStripMenuItem mruMenuItem = new MruToolStripMenuItem(filename, textWidth, index + 1, MruMenuItem_Click);
          rootMenu.Items.Insert(mruListMenuIndex + index + 1, mruMenuItem);
        }
        // Show mru list menu
        mruListMenu.Enabled = true;
        mruListMenu.Visible = false;
      }
    }
    private void RenderInSubMenu() {

      // Clear existing sub-menu list items, if any
      mruListMenu.DropDownItems.Clear();
      mruListMenu.Enabled = false;

      // Render mru menu
      if( mruMenuListItems.Count > 0 ) {
        for( int index = 0; index < mruMenuListItems.Count; index++ ) {
          string filename = mruMenuListItems[index];
          MruToolStripMenuItem mruMenuItem = new MruToolStripMenuItem(filename, textWidth, index + 1, MruMenuItem_Click);
          mruListMenu.DropDownItems.Add(mruMenuItem);
        }
        mruListMenu.Enabled = true;
      }
    }

    // Clean up any resources being used.
    protected override void Dispose(bool disposing) {
      if( !disposing ) return;

      // Save component settings if specified
      if( saveSettings ) this.SaveComponentSettings();
      base.Dispose(disposing);
    }

    #region IPersistComponentSettings Members

    private bool saveSettings = false;
    private string settingsKey = "MruMenuManager.SettingsKey";
    private MruMenuManagerSettings settings;

    [Category("Behavior")]
    [Description("Specifies whether the MruMenuManager should persist user settings via IPersistComponentSettings.")]
    [DefaultValue(false)]
    public bool SaveSettings {
      get { return saveSettings; }
      set { saveSettings = value; }
    }

    [Category("Behavior")]
    [Description("Specifies the unique group under which MruMenuManager's settings are persisted.")]
    [DefaultValue("MruMenuManager.SettingsKey")]
    public string SettingsKey {
      get { return settingsKey; }
      set { settingsKey = value; }
    }

    public void LoadComponentSettings() {
      if( this.DesignMode ) return;
      this.mruMenuListItems.Clear();
      if( this.Settings.MruListItems == null ) return;
      this.mruMenuListItems.AddRange((string[])this.Settings.MruListItems.ToArray(typeof(string)));
    }
    public void SaveComponentSettings() {
      if( this.DesignMode ) return;
      this.Settings.MruListItems = new ArrayList(this.mruMenuListItems.ToArray());
      this.Settings.Save();
    }
    public void ResetComponentSettings() {
      if( this.DesignMode ) return;
      this.Settings.Reset();
      this.LoadComponentSettings();
    }

    private MruMenuManagerSettings Settings {
      get {
        if( settings == null ) {
          settings = new MruMenuManagerSettings(this, settingsKey);
        }
        return settings;
      }
    }

    #endregion
  }
}