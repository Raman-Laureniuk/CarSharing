namespace CarSharing.WebApi.Common.Validation.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class RequiredNotDefaultValueAttribute : ValidationAttribute
    {
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
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
