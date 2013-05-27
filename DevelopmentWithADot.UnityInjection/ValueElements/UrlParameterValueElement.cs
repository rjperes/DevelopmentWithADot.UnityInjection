using System;
using System.Configuration;
using System.Net;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class UrlParameterValueElement : BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			WebClient client = new WebClient();
			String value = client.DownloadString(this.Url);
			return (value);
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("url", IsRequired = true)]
		public String Url
		{
			get
			{
				return ((String)base["url"]);
			}

			set
			{
				base["url"] = value;
			}
		}
		#endregion
	}
}
