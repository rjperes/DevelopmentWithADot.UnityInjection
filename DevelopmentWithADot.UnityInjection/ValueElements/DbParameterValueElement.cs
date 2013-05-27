using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class DbParameterValueElement: BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[this.ConnectionString];
			DbProviderFactory factory = DbProviderFactories.GetFactory(settings.ProviderName);

			using (DbConnection con = factory.CreateConnection())
			using (DbCommand cmd = con.CreateCommand())
			{
				con.ConnectionString = settings.ConnectionString;
				con.Open();

				DbParameter parameter = factory.CreateParameter();
				parameter.ParameterName = "key";
				parameter.Value = Convert.ChangeType(this.KeyValue, this.GetKeyType());

				cmd.CommandText = String.Concat("SELECT ", this.ValueColumnName, " FROM ", this.TableName, " WHERE ", this.KeyColumnName, " = @key");
				cmd.Parameters.Add(parameter);

				using (DbDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SingleRow | CommandBehavior.SequentialAccess))
				{
					if (reader.Read() == true)
					{
						Int32 index = reader.GetOrdinal(this.ValueColumnName);

						if (index >= 0)
						{
							return (reader.GetValue(index));
						}
					}
				}
			}

			return(null);
		}
		#endregion

		#region Protected methods
		protected Type GetKeyType()
		{
			return (TypeResolver.ResolveTypeWithDefault(this.KeyTypeName, typeof(String)));
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("connectionString", IsRequired = true)]
		public String ConnectionString
		{
			get
			{
				return ((String) base [ "connectionString" ]);
			}

			set
			{
				base [ "connectionString" ] = value;
			}
		}

		[ConfigurationProperty("keyTypeName", IsRequired = false, DefaultValue = "System.String")]
		public String KeyTypeName
		{
			get
			{
				return ((String) base [ "keyTypeName" ]);
			}

			set
			{
				base [ "keyTypeName" ] = value;
			}
		}

		[ConfigurationProperty("keyValue", IsRequired = true)]
		public String KeyValue
		{
			get
			{
				return ((String) base [ "keyValue" ]);
			}

			set
			{
				base [ "keyValue" ] = value;
			}
		}

		[ConfigurationProperty("keyColumnName", IsRequired = true)]
		public String KeyColumnName
		{
			get
			{
				return ((String) base [ "keyColumnName" ]);
			}

			set
			{
				base [ "keyColumnName" ] = value;
			}
		}

		[ConfigurationProperty("valueColumnName", IsRequired = true)]
		public String ValueColumnName
		{
			get
			{
				return ((String) base [ "valueColumnName" ]);
			}

			set
			{
				base [ "valueColumnName" ] = value;
			}
		}

		[ConfigurationProperty("tableName", IsRequired = true)]
		public String TableName
		{
			get
			{
				return ((String) base [ "tableName" ]);
			}

			set
			{
				base [ "tableName" ] = value;
			}
		}
		#endregion
	}
}
