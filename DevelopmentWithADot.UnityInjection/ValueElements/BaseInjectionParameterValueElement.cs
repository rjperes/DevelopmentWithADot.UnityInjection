using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public abstract class BaseInjectionParameterValueElement : ParameterValueElement, IDependencyResolverPolicy
	{
		#region Protected virtual methods
		protected virtual Object CreateInstance()
		{
			Object configurationValue = this.GetValue();

			if ((configurationValue != null) && (this.GetTypeToCreate().IsAssignableFrom(configurationValue.GetType())))
			{
				return (configurationValue);
			}

			if (this.GetTypeToCreate() == typeof(String))
			{
				return (configurationValue.ToString());
			}

			TypeConverter converter = this.GetTypeConverter(this.GetTypeToCreate(), this.TypeConverterName);

			return (converter.ConvertFrom(configurationValue));
		}
		#endregion

		#region Protected abstract methods
		protected abstract Object GetValue();
		#endregion

		#region Public override methods
		public override InjectionParameterValue GetInjectionParameterValue(IUnityContainer container, Type parameterType)
		{
			Type type = null;

			if (String.IsNullOrEmpty(this.TypeName) == true)
			{
				type = parameterType;
			}
			else
			{
				type = TypeResolver.ResolveType(this.TypeName);
			}

			Object value = this.CreateInstance();

			return (new InjectionParameter(type, value));
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("typeConverter", IsRequired = false, DefaultValue = null)]
		public String TypeConverterName
		{
			get
			{
				return ((String) base [ "typeConverter" ]);
			}

			set
			{
				base [ "typeConverter" ] = value;
			}
		}

		[ConfigurationProperty("typeName", DefaultValue = null)]
		public String TypeName
		{
			get
			{
				return ((String) base [ "typeName" ]);
			}

			set
			{
				base [ "typeName" ] = value;
			}
		}
		#endregion

		#region Protected methods
		protected TypeConverter GetTypeConverter(Type typeToCreate, String typeConverterName)
		{
			if (String.IsNullOrEmpty(typeConverterName) == false)
			{
				return ((TypeConverter) Activator.CreateInstance(TypeResolver.ResolveType(typeConverterName)));
			}

			return (TypeDescriptor.GetConverter(typeToCreate));
		}

		protected Type GetTypeToCreate()
		{
			return (TypeResolver.ResolveTypeWithDefault(this.TypeName, typeof(String)));
		}
		#endregion

		#region IDependencyResolverPolicy Members

		public Object Resolve(IBuilderContext context)
		{
			if (String.IsNullOrEmpty(this.TypeName) == true)
			{
				if (context.CurrentOperation is ResolvingPropertyValueOperation)
				{
					ResolvingPropertyValueOperation op = (context.CurrentOperation as ResolvingPropertyValueOperation);
					PropertyInfo prop = op.TypeBeingConstructed.GetProperty(op.PropertyName);
					this.TypeName = prop.PropertyType.FullName;
				}
				else if (context.CurrentOperation is ConstructorArgumentResolveOperation)
				{
					ConstructorArgumentResolveOperation op = (context.CurrentOperation as ConstructorArgumentResolveOperation);
					String args = op.ConstructorSignature.Split('(') [ 1 ].Split(')') [ 0 ];
					Type [] types = args.Split(',').Select(a => Type.GetType(a.Split(' ') [ 0 ])).ToArray();
					ConstructorInfo ctor = op.TypeBeingConstructed.GetConstructor(types);
					this.TypeName = ctor.GetParameters().Where(p => p.Name == op.ParameterName).Single().ParameterType.FullName;
				}
				else if (context.CurrentOperation is MethodArgumentResolveOperation)
				{
					MethodArgumentResolveOperation op = (context.CurrentOperation as MethodArgumentResolveOperation);
					String methodName = op.MethodSignature.Split('(') [ 0 ].Split(' ') [ 1 ];
					String args = op.MethodSignature.Split('(') [ 1 ].Split(')') [ 0 ];
					Type [] types = args.Split(',').Select(a => Type.GetType(a.Split(' ') [ 0 ])).ToArray();
					MethodInfo method = op.TypeBeingConstructed.GetMethod(methodName, types);
					this.TypeName = method.GetParameters().Where(p => p.Name == op.ParameterName).Single().ParameterType.FullName;
				}
			}

			return (this.CreateInstance());
		}

		#endregion
	}
}
