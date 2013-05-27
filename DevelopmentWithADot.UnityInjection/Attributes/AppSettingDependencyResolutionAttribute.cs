using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class AppSettingDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public AppSettingDependencyResolutionAttribute(String appSettingKey)
		{
			this.AppSettingKey = appSettingKey;
		}

		public String AppSettingKey
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new AppSettingParameterValueElement() { AppSettingKey = this.AppSettingKey, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
