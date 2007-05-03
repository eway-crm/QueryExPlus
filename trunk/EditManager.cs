using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QueryExPlus
{
    /// <summary>
    /// A mediator for managing Edit menu commands (copy, cut, paste, etc)
    /// </summary>
    public class EditManager //: Component
    {
        // MenuItems to which to connect
        ToolStripMenuItem miEdit, miUndo, miCopy, miCopyWithHeaders, miCut, miPaste, miSelectAll;

        private static EditManager _EditManagerInstance = new EditManager();
        
        private EditManager()
        {
            MenuItemCopy = null;
            MenuItemCopyWithHeaders = null;
            MenuItemCut = null;
            MenuItemEdit = null;
            MenuItemPaste = null;
            MenuItemSelectAll = null;
            MenuItemUndo = null;

        }

        public static EditManager GetEditManager()
        {
            return _EditManagerInstance;
        }

        // Menu item implementing Edit submenu.  Attach/detach event handler
        // to popup event so we can enable/disable sub-items when menu is activated.
        public ToolStripMenuItem MenuItemEdit
        {
            get { return miEdit; }
            set
            {
                if (miEdit != null)
                {
//                    miEdit.Click -= new EventHandler(miEdit_Popup);
                    miEdit.DropDownOpening -= new EventHandler(miEdit_Popup);
                }
                miEdit = value;
                if (miEdit != null)
                {
//                    miEdit.Click += new EventHandler(miEdit_Popup);
                    miEdit.DropDownOpening += new EventHandler(miEdit_Popup);
                }
            }
        }

        public ToolStripMenuItem MenuItemUndo
        {
            get { return miUndo; }
            set
            {
                if (miUndo != null)
                    miUndo.Click -= new EventHandler(miUndo_Click);
                miUndo = value;
                if (miUndo != null)
                    miUndo.Click += new EventHandler(miUndo_Click);
            }
        }

        public ToolStripMenuItem MenuItemCopy
        {
            get { return miCopy; }
            set
            {
                if (miCopy != null)
                    miCopy.Click -= new EventHandler(miCopy_Click);
                miCopy = value;
                if (miCopy != null)
                    miCopy.Click += new EventHandler(miCopy_Click);
            }
        }

        public ToolStripMenuItem MenuItemCopyWithHeaders
        {
            get { return miCopyWithHeaders; }
            set
            {
                if (miCopyWithHeaders != null)
                    miCopyWithHeaders.Click -= new EventHandler(miCopyWithHeaders_Click);
                miCopyWithHeaders = value;
                if (miCopyWithHeaders != null)
                    miCopyWithHeaders.Click += new EventHandler(miCopyWithHeaders_Click);
            }
        }

        public ToolStripMenuItem MenuItemCut
        {
            get { return miCut; }
            set
            {
                if (miCut != null)
                    miCut.Click -= new EventHandler(miCut_Click);
                miCut = value;
                if (miCut != null)
                    miCut.Click += new EventHandler(miCut_Click);
            }
        }

        public ToolStripMenuItem MenuItemPaste
        {
            get { return miPaste; }
            set
            {
                if (miPaste != null)
                    miPaste.Click -= new EventHandler(miPaste_Click);
                miPaste = value;
                if (miPaste != null)
                    miPaste.Click += new EventHandler(miPaste_Click);
            }
        }

        public ToolStripMenuItem MenuItemSelectAll
        {
            get { return miSelectAll; }
            set
            {
                if (miSelectAll != null)
                    miSelectAll.Click -= new EventHandler(miSelectAll_Click);
                miSelectAll = value;
                if (miSelectAll != null)
                    miSelectAll.Click += new EventHandler(miSelectAll_Click);
            }
        }

        public ContextMenuStrip GetContextMenuStrip(Control parent)
        {
            ContextMenuStrip cm = new ContextMenuStrip();
            //cm.Parent = parent;
            cm.Opened += new EventHandler(miEdit_Popup);
            cm.Items.AddRange(new ToolStripItem[] { new ToolStripMenuItem(miCopy.Text, miCopy.Image, new EventHandler(miCopy_Click)),
            new ToolStripMenuItem(miCopyWithHeaders.Text, miCopyWithHeaders.Image, new EventHandler(miCopyWithHeaders_Click)) ,
            new ToolStripMenuItem(miSelectAll.Text, miSelectAll.Image, new EventHandler(miSelectAll_Click)) }
                );
            if (!(parent is DataGridView))
                cm.Items[1].Enabled = false;
            return cm;
        }

        public ContextMenu GetContextMenu()
        {
            MenuItem[] mi = new MenuItem[] { new MenuItem(miCopy.Text, new EventHandler(miCopy_Click)) };
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.AddRange(new MenuItem[] {new MenuItem(miCopy.Text, new EventHandler(miCopy_Click))
            ,new MenuItem(miCopyWithHeaders.Text, new EventHandler(miCopyWithHeaders_Click))});
            return cm;
        }   


        public void Undo()
        {
            Control c = GetActiveControl();
            if (c is TextBoxBase) ((TextBoxBase)c).Undo();
        }

        public void Copy()
        {
            Control c = GetActiveControl();
            if (c is TextBoxBase) 
                ((TextBoxBase)c).Copy();
            if (c is DataGridView)
            {
                DataGridView ctrl = (DataGridView) c;
                // Add the selection to the clipboard.
                ctrl.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
                Clipboard.SetDataObject(
                    ctrl.GetClipboardContent());
            }
        }

        public void CopyWithHeaders()
        {
            Control c = GetActiveControl();
            if (c is TextBoxBase)
                return;
            if (c is DataGridView)
            {
                DataGridView ctrl = (DataGridView)c;
                // Add the selection to the clipboard.
                ctrl.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                Clipboard.SetDataObject(
                    ctrl.GetClipboardContent());
            }
            
        }

        public void Cut()
        {
            Control c = GetActiveControl();
            if (c is TextBoxBase) ((TextBoxBase)c).Cut();
        }

        public void Paste()
        {
            Control c = GetActiveControl();
            if (c is TextBoxBase) ((TextBoxBase)c).Paste();
        }

        public void SelectAll()
        {
            Control c = GetActiveControl();
            if (c is TextBoxBase) ((TextBoxBase)c).SelectAll();
        }

        protected Control GetActiveControl()
        {
            Form form = Form.ActiveForm;
            if (form != null && form.IsMdiContainer)
                form = form.ActiveMdiChild;
            return GetActiveControl(form);
        }
        
        protected Control GetActiveControl(Control ContainerControl)
        {
            if (ContainerControl == null || ContainerControl as ContainerControl == null)
                return ContainerControl;
            else
                return GetActiveControl(((ContainerControl)ContainerControl).ActiveControl);
        }

        protected void miEdit_Popup(object sender, EventArgs e)
        {
            EnableSubMenus();
        }

        private void EnableSubMenus()
        {
            bool canUndo, canCopy, canCopyWithHeaders, canCut, canPaste;
            System.Diagnostics.Debug.WriteLine("Popup");
            canUndo = canCopy = canCopyWithHeaders =
                      canCut = canPaste = false;
            Control c = GetActiveControl();
            if (c != null)
                CanEdit(c, ref canUndo, ref canCopy, ref canCopyWithHeaders, ref canCut, ref canPaste);
            if (miUndo != null) miUndo.Enabled = canUndo;
            if (miCopy != null) miCopy.Enabled = canCopy;
            if (miCopyWithHeaders != null) miCopyWithHeaders.Enabled = canCopyWithHeaders;
            if (miCut != null) miCut.Enabled = canCut;
            if (miPaste != null) miPaste.Enabled = canPaste;
        }

        protected void CanEdit(Control c, ref bool canUndo, ref bool canCopy, ref bool canCopyWithHeaders, ref bool canCut, ref bool canPaste)
        {
            if (c is TextBoxBase)
            {
                TextBoxBase t = (TextBoxBase)c;
                canUndo = t.CanUndo;
                canCopy = t.SelectionLength > 0;
                canCopyWithHeaders = false;
                canCut = t.SelectionLength > 0 && !t.ReadOnly;
                IDataObject iData = Clipboard.GetDataObject();
                canPaste = !t.ReadOnly && iData.GetDataPresent(DataFormats.Text); ;
            }
            else if (c is DataGridView)
            {
                DataGridView dgv = (DataGridView) c;
                canUndo = false;
                canCopy = dgv.RowCount > 0;
                canCopyWithHeaders = canCopy;
                canCut = false;
                canPaste = false;
            }
        }

        protected void miUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        protected void miCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        protected void miCopyWithHeaders_Click(object sender, EventArgs e)
        {
            CopyWithHeaders();
        }

        protected void miCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        protected void miPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        protected void miSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion
    }

}
