using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class RegistryDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public RegistryDependencyResolutionAttribute(String location)
		{
			this.Location = location;
		}

		public String Location
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new RegistryParameterValueElement() { Location = this.Location, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
