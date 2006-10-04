using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace QueryExPlus
{
	internal class CommandLineParams : IEnumerable
	{
		private StringDictionary Parameters = new StringDictionary ();

		public CommandLineParams (string[] Args)
		{
			Regex Spliter = new Regex (@"^-{1,2}|^/|=|:", RegexOptions.IgnoreCase | RegexOptions.Compiled);

			Regex Remover = new Regex (@"^['""]?(.*?)['""]?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

			string Parameter = null;
			string[] Parts;

			// Valid parameters forms:
			// {-,/,--}param{ ,=,:}((",')value(",'))
			// Examples: 
            //         -param1 value1 --param2 /param3:"Test-:-work" 
            //           /param4=happy -param5 '--=nice=--'
			foreach (string Txt in Args)
			{
				// Look for new parameters (-,/ or --) and a
				// possible enclosed value (=,:)
				Parts = Spliter.Split (Txt, 3);

				switch (Parts.Length)
				{
					case 1:
						// Found a value (for the last parameter 
						// found (space separator))

						if (Parameter != null)
						{
							if (!Parameters.ContainsKey (Parameter))
							{
								Parts[0] = Remover.Replace (Parts[0], "$1");
								Parameters.Add (Parameter, Parts[0]);
							}
							Parameter = null;
						}
						break;
						// else Error: no parameter waiting for a value (skipped)
					case 2: // Found just a parameter
						// The last parameter is still waiting. 
						// With no value, set it to true.
						if (Parameter != null)

						{
							if (!Parameters.ContainsKey (Parameter))
								Parameters.Add (Parameter, "true");
						}


						Parameter = Parts[1];
						break;
						// Parameter with enclosed value;
					case 3: // Parameter with enclosed value
						// The last parameter is still waiting. 
						// With no value, set it to true.
						if (Parameter != null)

						{
							if (!Parameters.ContainsKey (Parameter))
								Parameters.Add (Parameter, "true");
						}

						Parameter = Parts[1];

						// Remove possible enclosing characters (",')
						if (!Parameters.ContainsKey (Parameter))
						{
							Parts[2] = Remover.Replace (Parts[2], "$1");
							Parameters.Add (Parameter, Parts[2]);
						}

						Parameter = null;
						break;
				}
			}
			// In case a parameter is still waiting
			if (Parameter != null)
			{
				if (!Parameters.ContainsKey (Parameter))
					Parameters.Add (Parameter, "true");
			}
		}

		public IEnumerator GetEnumerator ()
		{
			return Parameters.GetEnumerator ();
		}

		public string this [string key]
		{
			get { return Parameters[key]; }
		}

		public bool ContainsKey(string value)
		{
			 return Parameters.ContainsKey(value);
		}
	}

}