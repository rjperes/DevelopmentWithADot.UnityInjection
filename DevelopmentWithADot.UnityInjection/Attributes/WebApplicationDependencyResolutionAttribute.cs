using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class WebApplicationDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public WebApplicationDependencyResolutionAttribute(String applicationKey)
		{
			this.ApplicationKey = applicationKey;

		}

		public String ApplicationKey
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new WebApplicationParameterValueElement() { ApplicationKey = this.ApplicationKey, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
