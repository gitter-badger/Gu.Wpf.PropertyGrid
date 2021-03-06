﻿namespace Gu.Wpf.PropertyGrid
{
    using System.Windows.Controls;
    using System.Xaml;

    public abstract class ControlTemplateSelector<T>
        where T : Control
    {
        public virtual void UpdateCurrentTemplate(T container)
        {
            container.Template = this.SelectTemplate(container);
        }

        protected static void AssertIsValidTemplate(ControlTemplate template)
        {
            if (!IsValidTemplate(template))
            {
                throw new XamlException($"Not a valid template for {typeof(T).Name}");
            }
        }

        protected static bool IsValidTemplate(ControlTemplate template)
        {
            var targetType = template?.TargetType;
            if (targetType == null)
            {
                return false;
            }

            return typeof(T).IsAssignableFrom(targetType);
        }

        protected abstract ControlTemplate SelectTemplate(T container);
    }
}
