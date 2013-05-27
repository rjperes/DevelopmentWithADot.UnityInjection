using System;
using System.Configuration;
using System.Reflection;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
	public class MethodCallParameterValueElement: BaseInjectionParameterValueElement
	{
		#region Protected override methods
		protected override Object GetValue()
		{
			Type type = this.GetTargetType();
			Object result = null;

			if (type != null)
			{
				Object target = null;
				MethodInfo mi = type.GetMethod(this.MethodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod);

				if ((mi != null) && (mi.ReturnType != typeof(void)) && (mi.GetParameters().Length == 0))
				{
					if (mi.IsStatic == false)
					{
						target = Activator.CreateInstance(type);
					}

					result = mi.Invoke(target, null);
				}

				if (target is IDisposable)
				{
					(target as IDisposable).Dispose();
				}
			}

			return (result);
		}
		#endregion

		#region Protected methods
		protected Type GetTargetType()
		{
			return (TypeResolver.ResolveType(this.TargetTypeName));
		}
		#endregion

		#region Public properties
		[ConfigurationProperty("targetMethodName", IsRequired = true)]
		public String MethodName
		{
			get
			{
				return ((String) base [ "targetMethodName" ]);
			}

			set
			{
				base [ "targetMethodName" ] = value;
			}
		}

		[ConfigurationProperty("targetTypeName", IsRequired = true)]
		public String TargetTypeName
		{
			get
			{
				return ((String) base [ "targetTypeName" ]);
			}

			set
			{
				base [ "targetTypeName" ] = value;
			}
		}
		#endregion
	}
}
