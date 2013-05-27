using System;
using System.Configuration;
using System.Web;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class WebRequestParameterValueElement : BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			if (String.IsNullOrEmpty(this.HttpMethod) == false)
			{
				if (String.Equals(this.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase) == true)
				{
					return (HttpContext.Current.Request.QueryString [ this.RequestKey ]);
				}
				else if (String.Equals(this.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase) == true)
				{
					return (HttpContext.Current.Request.Form [ this.RequestKey ]);
				}
				else
				{
					throw (new ArgumentException("Invalid HTTP method"));
				}
			}
			else
			{
				return (HttpContext.Current.Request [ this.RequestKey ]);
			}
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("httpMethod", IsRequired = false)]
		public String HttpMethod
		{
			get
			{
				return ((String) base [ "httpMethod" ] ?? String.Empty);
			}

			set
			{
				base [ "httpMethod" ] = value ?? String.Empty;
			}
		}

		[ConfigurationProperty("requestKey", IsRequired = true)]
		public String RequestKey
		{
			get
			{
				return ((String) base [ "requestKey" ]);
			}

			set
			{
				base [ "requestKey" ] = value;
			}
		}
		#endregion
	}
}
