using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class AppDomainDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public AppDomainDependencyResolutionAttribute(String appDomainKey)
		{
			this.AppDomainKey = appDomainKey;
		}

		public String AppDomainKey
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new AppDomainParameterValueElement() { AppDomainKey = this.AppDomainKey, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
