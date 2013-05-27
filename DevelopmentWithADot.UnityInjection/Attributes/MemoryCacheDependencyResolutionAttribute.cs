using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class MemoryCacheDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public MemoryCacheDependencyResolutionAttribute(String cacheKey)
		{
			this.CacheKey = cacheKey;
		}

		public String CacheKey
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new MemoryCacheParameterValueElement() { CacheKey = this.CacheKey, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
