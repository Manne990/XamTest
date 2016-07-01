using System;
using FluentValidation;
using GalaSoft.MvvmLight.Command;
using Infrastructure;
using Xamarin.Validations.Validations;
using XamTest.Common.Validation3;

namespace XamTest.Pages.Validation3
{
    public class Validation3ViewModelValidator : FluentValidator<Validation3ViewModel>
    {
        public Validation3ViewModelValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            this.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .Must(a => a.Value.IsInteger())
                .WithMessage("Name must be a number")
                .Must((x, a) => {
                    var from = int.Parse(a.Value);
                    return 3 <= from && from <= 20;
                })
                .WithMessage("Name should be between 3 and 20 characters long");
        }
    }

    public class Validation3ViewModel : CustomViewModelBase<Validation3ViewModel>
    {
        public Validation3ViewModel() : base(new Validation3ViewModelValidator())
        { 
        
        }

        private ValidableProperty<string> _name;
        public ValidableProperty<string> Name
        {
            get { return _name ?? new ValidableProperty<string>(); }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(() => {

                    });
                }

                return _saveCommand;
            }
        }


    }
}