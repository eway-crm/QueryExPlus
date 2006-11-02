using System.Data;
using System.Windows.Forms;

namespace QueryExPlus
{
    /// <summary>
    /// Interface defining queyr options
    /// </summary>
    internal abstract class  QueryOptions
    {
        private int _RowCount = 0;
        private int _maxTextWidth = 60;
        private string _BatchSeparator = "GO";
        private int _ExecutionTimeout = 0;

        public virtual string BatchSeparator
        {
            get { return _BatchSeparator; }
            set { _BatchSeparator = value; }
        }

        public virtual int maxTextWidth
        {
            get { return _maxTextWidth; }
            set { _maxTextWidth = value; }
        }

        public virtual int RowCount
        {
            get { return _RowCount; }
            set { _RowCount = value; }
        }

        public virtual int ExecutionTimeout
        {
            get { return _ExecutionTimeout; }
            set { _ExecutionTimeout = value; }
        }

        public abstract void ApplyToConnection(IDbConnection connection);
        public abstract void SetupBatch(IDbConnection connection);
        public abstract void ResetBatch(IDbConnection connection);
        public abstract DialogResult ShowForm();
        protected DialogResult ShowForm(QueryOptionsForm optionsForm)
        {
            FieldsToForm(optionsForm);

            DialogResult res = optionsForm.ShowDialog();
            if (res == DialogResult.OK)
                FormToFields(optionsForm);
            return res;

        }

        protected void FormToFields(QueryOptionsForm f)
        {
            this.BatchSeparator = f.txtBatchSeparator.Text;
            this.ExecutionTimeout = (int)(f.txtExecutionTimeout.Value);
            this.RowCount = (int)(f.txtRowcount.Value);
        }

        protected void FieldsToForm(QueryOptionsForm f)
        {
            f.txtBatchSeparator.Text = this.BatchSeparator;
            f.txtExecutionTimeout.Value = this.ExecutionTimeout;
            f.txtRowcount.Value = this.RowCount;
        }
    }
}
