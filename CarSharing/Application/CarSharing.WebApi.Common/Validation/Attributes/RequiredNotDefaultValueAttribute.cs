namespace CarSharing.WebApi.Common.Validation.Attributes
{
    using System;
    using System.Collections.Concurrent;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class RequiredNotDefaultValueAttribute : ValidationAttribute
    {
        private static readonly ConcurrentDictionary<Type, object> _defaultValueCache = new ConcurrentDictionary<Type, object>();
        
        public override bool IsValid(object value)
        {
            return !IsDefault(value);
        }

        private static bool IsDefault(object value)
        {
            if (value == null)
            {
                return true;
            }

            object defaultValue = GetDefaultValue(value.GetType());

            return value.Equals(defaultValue);
        }

        private static object GetDefaultValue(Type type)
        {
            return _defaultValueCache.GetOrAdd(type, CreateDefaultValue);
        }
        
        private static object CreateDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
