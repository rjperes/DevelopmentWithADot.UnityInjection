using System;
using System.Configuration;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class AppDomainParameterValueElement : BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			Object configurationValue = AppDomain.CurrentDomain.GetData(this.AppDomainKey);
			return (configurationValue);
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("appDomainKey", IsRequired = true)]
		public String AppDomainKey
		{
			get
			{
				return ((String) base [ "appDomainKey" ]);
			}

			set
			{
				base [ "appDomainKey" ] = value;
			}
		}
		#endregion
	}
}
