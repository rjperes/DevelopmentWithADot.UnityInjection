using System;
using System.Configuration;
using System.Web;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class WebApplicationParameterValueElement : BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			return (HttpContext.Current.Application[ this.ApplicationKey ]);
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("applicationKey", IsRequired = true)]
		public String ApplicationKey
		{
			get
			{
				return ((String) base [ "applicationKey" ]);
			}

			set
			{
				base [ "applicationKey" ] = value;
			}
		}
		#endregion
	}
}
