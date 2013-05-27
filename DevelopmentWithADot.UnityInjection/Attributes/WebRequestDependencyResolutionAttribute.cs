using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class WebRequestDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public WebRequestDependencyResolutionAttribute(String requestKey): this(requestKey, String.Empty)
		{

		}
	
		public WebRequestDependencyResolutionAttribute(String requestKey, String httpMethod)
		{
			this.RequestKey = requestKey;
			this.HttpMethod = httpMethod;
		}

		public String RequestKey
		{
			get;
			private set;
		}

		public String HttpMethod
		{
			get;
			set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new WebRequestParameterValueElement() { HttpMethod = this.HttpMethod, RequestKey = this.RequestKey, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
