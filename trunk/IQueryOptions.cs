using System;
using System.Data;
using System.Windows.Forms;

namespace QueryExPlus
{
	/// <summary>
	/// Interface defining queyr options
	/// </summary>
	public interface IQueryOptions
	{
		string BatchSeparator
		{
			get;
			set;
		}
		void ApplyToConnection(IDbConnection connection);
		void SetupBatch(IDbConnection connection);
		void ResetBatch(IDbConnection connection);
		DialogResult ShowForm();
	}
}
