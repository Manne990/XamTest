namespace Infrastructure
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class ValidatableBindableBase : BindableBase
    {
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public abstract void ValidateAllProperties();

        protected virtual bool SetPropertyAndValidateAllProperties<T>(
            ref T storage,
            T value,
            [CallerMemberName] string propertyName = null)
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            var result = this.SetProperty(ref storage, value, propertyName);

            if (result)
            {
                this.ValidateAllProperties();
            }

            return result;
        }

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            var handler = this.ErrorsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
