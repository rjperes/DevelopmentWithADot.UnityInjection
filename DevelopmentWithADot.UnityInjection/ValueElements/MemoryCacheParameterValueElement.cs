using System;
using System.Configuration;
using System.Runtime.Caching;

 namespace DevelopmentWithADot.UnityInjection.ValueElements
{
    public class MemoryCacheParameterValueElement : BaseInjectionParameterValueElement
    {
        #region Protected override methods
        protected override Object GetValue()
        {
            Object configurationValue = MemoryCache.Default[this.CacheKey];
            return (configurationValue);
        }
        #endregion

        #region Public properties
        [ConfigurationProperty("cacheKey", IsRequired = true)]
        public String CacheKey
        {
            get
            {
                return ((String)base["callContextKey"]);
            }

            set
            {
                base["callContextKey"] = value;
            }
        }
        #endregion
    }
}
