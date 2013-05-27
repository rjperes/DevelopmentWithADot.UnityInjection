using DevelopmentWithADot.UnityInjection.ValueElements;
using Microsoft.Practices.Unity.Configuration;

 namespace DevelopmentWithADot.UnityInjection.Extensions
{
	public class RegistryParameterInjectionElementExtension : SectionExtension
	{
		public override void AddExtensions(SectionExtensionContext context)
		{
			context.AddElement<RegistryParameterValueElement>("registry");
		}
	}
}
