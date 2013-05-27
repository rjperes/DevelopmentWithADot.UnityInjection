using System;
using System.Configuration;
using System.Runtime.Remoting.Messaging;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class CallContextParameterValueElement : BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			Object configurationValue = CallContext.GetData(this.CallContextKey);
			return (configurationValue);
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("callContextKey", IsRequired = true)]
		public String CallContextKey
		{
			get
			{
				return ((String) base [ "callContextKey" ]);
			}

			set
			{
				base [ "callContextKey" ] = value;
			}
		}
		#endregion
	}
}
