using System;
using System.Configuration;
using System.Reflection;
using Microsoft.Win32;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class RegistryParameterValueElement : BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			String [] parts = (this.Location ?? String.Empty).Split('\\');
			String rootKey = parts[0];
			RegistryKey root = typeof(Registry).GetField(rootKey, BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField).GetValue(null) as RegistryKey;
			RegistryKey key = root;

			for (Int32 i = 1; i < parts.Length - 1; ++i)
			{
				key = key.OpenSubKey(parts[i]);
			}
			
			return (key.GetValue(parts[parts.Length - 1]));
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("location", IsRequired = true)]
		public String Location
		{
			get
			{
				return ((String) base [ "location" ]);
			}

			set
			{
				base [ "location" ] = value;
			}
		}
		#endregion
	}
}
