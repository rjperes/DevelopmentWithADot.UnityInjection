using System;
using System.Configuration;
using System.Xml;
using System.Xml.XPath;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class XmlParameterValueElement: BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(this.FileName);
			XPathNavigator navigator = doc.CreateNavigator();			
			XPathNodeIterator iterator = navigator.Select(this.Path);

			if (iterator.MoveNext() == true)
			{
				return (iterator.Current.Value);
			}

			return (null);
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("fileName", IsRequired = true)]
		public String FileName
		{
			get
			{
				return ((String) base [ "fileName" ]);
			}

			set
			{
				base [ "fileName" ] = value;
			}
		}

		[ConfigurationProperty("path", IsRequired = true)]
		public String Path
		{
			get
			{
				return ((String) base [ "path" ]);
			}

			set
			{
				base [ "path" ] = value;
			}
		}
		#endregion
	}
}
