using System;
using System.Reflection;
using MadeUpStats.Web.Services;
using MvcContrib.UI.InputBuilder.Conventions;
using MvcContrib.UI.InputBuilder.Views;

namespace MadeUpStats.Web
{
    public class MadeUpStatsConventions : DefaultConventions
    {
        private readonly DateFormatter dateFormatter;

        public MadeUpStatsConventions(DateFormatter dateFormatter)
        {
            this.dateFormatter = dateFormatter;
        }

        public override PropertyViewModel ModelPropertyBuilder(PropertyInfo propertyInfo, object value)
        {
            if (propertyInfo.PropertyType.IsEnum)
            {
                return base.ModelPropertyBuilder(propertyInfo, value);
            }
            if (propertyInfo.PropertyType == typeof(DateTime))
            {
                var dateString = dateFormatter.GetFormat(DateTime.Now, DateTime.Now);
                return new PropertyViewModel<string> { Value = dateString };
            }

            return new PropertyViewModel<object> { Value = value };
        }
    }
}