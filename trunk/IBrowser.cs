using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;

namespace QueryExPlus
{
    #region Browser Interface
    /// <summary>
    /// An interface defining Browser classes (an Explorer-like tree view of a database).
    /// </summary>
    internal interface IBrowser
    {
        /// <summary>
        /// Returns the active Database Client object (this should be set in construction)
        /// </summary>
        DbClient DbClient { get;}

        /// <summary>
        /// Returns an array of TreeNodes representing the object hierarchy for the "Explorer" view.
        /// This can return either the entire hierarchy, or for efficiency, just the higher level(s).
        /// </summary>
        TreeNode[] GetObjectHierarchy();

        /// <summary>
        /// Returns an array of TreeNodes representing the object hierarchy below a given node.
        /// This should return null if there is no hierarchy below the given node, or if the hierarchy
        /// is already present.  This method is called whenever the user expands a node.
        /// </summary>
        TreeNode[] GetSubObjectHierarchy(TreeNode node);

        /// <summary>
        /// Returns text suitable for dropping into a query window, for a given node.
        /// </summary>
        string GetDragText(TreeNode node);

        /// <summary>
        /// Returns a list of actions applicable to a node (suitable for a context menu).
        /// Returns null if no actions are applicable.
        /// </summary>
        StringCollection GetActionList(TreeNode node);

        /// <summary>
        /// Returns text suitable for pasting into a query window, given a particular node and action.
        /// GetActionList() should be called first to obtain a list of applicable actions.
        /// </summary>
        /// <param name="actionIndex">One of the action text strings returned by GetActionList()</param>
        string GetActionText(TreeNode node, string action);

        /// <summary>
        /// Returns a list of available databases
        /// </summary>
        string[] GetDatabases();

        /// <summary>
        /// Creates and returns a new browser object, using the supplied database client object.
        /// </summary>
        IBrowser Clone(DbClient newDbClient);
    }
    #endregion
}