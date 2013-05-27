using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class XmlDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public XmlDependencyResolutionAttribute(String fileName, String path)
		{
			this.FileName = fileName;
			this.Path = path;
		}

		public String FileName
		{
			get;
			private set;
		}

		public String Path
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new XmlParameterValueElement() { FileName = this.FileName, Path = this.Path, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
