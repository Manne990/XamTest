namespace Infrastructure
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    using FluentValidation;

    public class FluentValidator<T> : AbstractValidator<T>, IValidator<T>
    {
        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors
        {
            get { return this.errors.Count > 0; }
        }
        
        IDictionary<string, string> IValidator<T>.Validate(T instance)
        {
            var currentErrors = new Dictionary<string, string>(this.errors);
            this.ValidateAndUpdateErrors(instance);
            this.RaiseErrorsChangedIfReallyChanged(currentErrors, this.errors);
            this.RaiseErrorsChangedIfReallyChanged(this.errors, currentErrors);

            return this.errors;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                // The caller requests all errors associated with this object.
                return this.GetAllErrors();
            }

            ThrowIfInvalidPropertyName(propertyName);

            return this.ExtractErrorMessageOf(propertyName);
        }

        public IList<string> GetAllErrors()
        {
            return this.errors.Select(error => error.Value).ToList();
        }

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            var handler = this.ErrorsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private static void ThrowIfInvalidPropertyName(string propertyName)
        {
            var propertyInfo = typeof(T).GetRuntimeProperty(propertyName);
            if (propertyInfo == null)
            {
                var msg = string.Format("No such property name '{0}' in {1}", propertyName, typeof(T));
                throw new ArgumentException(msg, propertyName);
            }
        }

        private void ValidateAndUpdateErrors(T instance)
        {
            this.errors.Clear();
            var result = this.Validate(instance);
            if (result.IsValid)
            {
                return;
            }

            foreach (var err in result.Errors)
            {
                this.errors.Add(err.PropertyName, err.ErrorMessage);
            }
        }

        private void RaiseErrorsChangedIfReallyChanged(
            IEnumerable<KeyValuePair<string, string>> errors1,
            IReadOnlyDictionary<string, string> errors2)
        {
            foreach (var err in errors1)
            {
                var propertyName = err.Key;
                var message = err.Value;
                if (!errors2.ContainsKey(propertyName) || !errors2[propertyName].Equals(message))
                {
                    this.RaiseErrorsChanged(propertyName);
                }
            }
        }

        private void RaiseErrorsChanged(string propertyName)
        {
            this.OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
        }

        private IEnumerable ExtractErrorMessageOf(string propertyName)
        {
            var result = new List<string>();
            if (this.errors.ContainsKey(propertyName))
            {
                result.Add(this.errors[propertyName]);
            }

            return result;
        }
    }
}
