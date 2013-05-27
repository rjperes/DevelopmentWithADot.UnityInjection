using System;
using System.Configuration;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class EnvironmentParameterValueElement : BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			return (Environment.GetEnvironmentVariable(this.Variable));
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("variable", IsRequired = true)]
		public String Variable
		{
			get
			{
				return ((String) base [ "variable" ]);
			}

			set
			{
				base [ "variable" ] = value;
			}
		}
		#endregion
	}
}
