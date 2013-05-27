using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class UrlDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public UrlDependencyResolutionAttribute(String url)
		{
			this.Url = url;
		}

		public String Url
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new UrlParameterValueElement() { Url = this.Url, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
