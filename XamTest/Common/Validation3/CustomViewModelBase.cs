using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using Infrastructure;
using Xamarin.Validations.Validations;
using XamTest.Pages.Validation;

namespace XamTest.Common.Validation3
{
    public class CustomViewModelBase<T> : ViewModelBase, IValidableModel, INotifyDataErrorInfo
    {
        private readonly IValidator<T> _validator;

        protected CustomViewModelBase(IValidator<T> validator)
        {
            _validator = validator;
        }

        // -------------


        public IEnumerable<string> Errors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsValid
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void RegisterValidationRules()
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }


        // -----------


        public bool HasErrors
        {
            get { return _validator.HasErrors; }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _validator.GetErrors(propertyName);
        }
    }
}