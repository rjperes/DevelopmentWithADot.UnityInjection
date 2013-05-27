using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class MethodCallDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public MethodCallDependencyResolutionAttribute(String targetTypeName, String methodName)
		{
			this.TargetTypeName = targetTypeName;
			this.MethodName = methodName;
		}

		public String TargetTypeName
		{
			get;
			private set;
		}

		public String MethodName
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new MethodCallParameterValueElement() { TargetTypeName = this.TargetTypeName, MethodName = this.MethodName, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
