using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class CallContextDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public CallContextDependencyResolutionAttribute(String callContextKey)
		{
			this.CallContextKey = callContextKey;
		}

		public String CallContextKey
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new CallContextParameterValueElement() { CallContextKey = this.CallContextKey, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
