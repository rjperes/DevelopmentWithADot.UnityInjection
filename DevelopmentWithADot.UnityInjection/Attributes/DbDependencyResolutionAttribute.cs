using System;
using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentWithADot.UnityInjection.Attributes
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class DbDependencyResolutionAttribute : BaseDependencyResolutionAttribute
	{
		public DbDependencyResolutionAttribute(String connectionString, String tableName, String keyValue, String keyColumnName, String valueColumnName)
		{
			this.ConnectionString = connectionString;
			this.KeyColumnName = keyColumnName;
			this.KeyValue = keyValue;
			this.ValueColumnName = valueColumnName;
			this.TableName = tableName;
		}

		public String KeyTypeName
		{
			get;
			set;
		}

		public String ConnectionString
		{
			get;
			private set;
		}

		public String KeyColumnName
		{
			get;
			private set;
		}

		public String KeyValue
		{
			get;
			private set;
		}

		public String ValueColumnName
		{
			get;
			private set;
		}

		public String TableName
		{
			get;
			private set;
		}

		public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
		{
			return (new DbParameterValueElement() { ConnectionString = this.ConnectionString, KeyTypeName = this.KeyTypeName, KeyColumnName = this.KeyColumnName, KeyValue = this.KeyValue, TableName = this.TableName, ValueColumnName = this.ValueColumnName, TypeName = this.TypeName, TypeConverterName = this.TypeConverterName });
		}
	}
}
