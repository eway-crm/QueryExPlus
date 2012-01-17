using System;
using System.Collections.Generic;
using System.Text;

namespace QueryExPlus
{
    public class MRUFileAddedEventArgs : EventArgs
    {
        private string filename;
        public MRUFileAddedEventArgs(string filename)
        {
            this.filename = filename;
        }
        public string Filename
        {
            get { return this.filename; }
        }
    }

    interface IQueryForm
    {
        event EventHandler<EventArgs> PropertyChanged;
        event EventHandler<MRUFileAddedEventArgs> MRUFileAdded;
        bool Open();
        bool Open(string fileName);
        void Execute();
        bool Save();
        bool SaveAs();
        void SaveResults();
        void Cancel();
        void Close();
        void ShowQueryOptions();
        bool ResultsInText { get; set;}
        bool GridShowNulls { get; set;}
        bool HideBrowser{get; set;}
        IBrowser Browser { get;}

        void ShowFind();
        void FindNext();
        
        DbClient.RunStates RunState{ get;}
        IQueryForm Clone();
    }
}
