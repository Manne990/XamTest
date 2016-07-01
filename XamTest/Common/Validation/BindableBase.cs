namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            var result = !EqualityComparer<T>.Default.Equals(field, value);
            if (result)
            {
                field = value;
                this.RaisePropertyChanged(propertyName);
            }

            return result;
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = ExtractPropertyName(propertyExpression);
            this.RaisePropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var lambdaExpression = (LambdaExpression)propertyExpression;
            var body = lambdaExpression.Body;
            var unaryExpression = body as UnaryExpression;
            var memberExpression = unaryExpression == null
                ? (MemberExpression)body
                : (MemberExpression)unaryExpression.Operand;
            return memberExpression.Member.Name;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
