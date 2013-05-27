using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class EnvironmentDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public EnvironmentDependencyResolutionAttribute(String variable)
		{
			this.Variable = variable;
		}

		public String Variable
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new EnvironmentParameterValueElement() { Variable = this.Variable, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
