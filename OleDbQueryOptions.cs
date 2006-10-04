using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QueryExPlus
{
    class OleDbQueryOptions : QueryOptions
    {
        public override void ApplyToConnection(IDbConnection connection)
        {
            return;
        }

        public override void SetupBatch(IDbConnection connection)
        {
            return;
        }

        public override void ResetBatch(IDbConnection connection)
        {
            return;
        }

        public override DialogResult ShowForm()
        {
            return ShowForm(new QueryOptionsForm());
        }
    }
}
