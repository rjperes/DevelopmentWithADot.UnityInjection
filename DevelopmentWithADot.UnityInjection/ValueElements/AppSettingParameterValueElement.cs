using System;
using System.Configuration;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class AppSettingParameterValueElement : BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			String configurationValue = ConfigurationManager.AppSettings [ this.AppSettingKey ];
			return (configurationValue);
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("appSettingKey", IsRequired = true)]
		public String AppSettingKey
		{
			get
			{
				return ((String) base [ "appSettingKey" ]);
			}

			set
			{
				base [ "appSettingKey" ] = value;
			}
		}
		#endregion
	}  
}
