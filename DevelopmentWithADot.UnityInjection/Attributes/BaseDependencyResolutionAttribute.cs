using System;
using Microsoft.Practices.Unity;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public abstract class BaseDependencyResolutionAttribute : DependencyResolutionAttribute
	{
		public String TypeName
		{
			get;
			set;
		}

		public String TypeConverterName
		{
			get;
			set;
		}
	}
}
