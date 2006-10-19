using System;
using System.Collections.Generic;
using System.Text;

namespace QueryExPlus
{
    interface IQueryForm
    {
        event EventHandler<EventArgs> PropertyChanged;
        bool Open();
        bool Open(string fileName);
        void Execute();
        bool Save();
        bool SaveAs();
        void Cancel();
        void ShowQueryOptions();
        bool ResultsInText { get; set;}
        bool HideBrowser{get; set;}
        IBrowser Browser { get;}

        void ShowFind();
        void FindNext();
        
        DbClient.RunStates RunState{ get;}
        IQueryForm Clone();
    }
}
