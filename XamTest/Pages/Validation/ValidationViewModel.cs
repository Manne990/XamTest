namespace XamTest.Pages.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Input;
    using Infrastructure;
    using XamTest.Common.Validation;

    public class ValidationViewModel : BindableBase
    {
        private IList<string> allErrors;

        public ValidationViewModel()
        {
            this.DataModel = new ValidationModel(new ValidationViewModelValidator());
            this.SolveCommand = new DelegateCommand(this.Solve, x => this.AllErrors.Count == 0);
            this.ChangeValidationRangeCommand = new DelegateCommand(this.ChangeValidationRange);
            this.DataModel.ValidateAllProperties();
            this.UpdateAllErrors();
            this.DataModel.ErrorsChanged += (s, e) => this.UpdateAllErrors();

            var props = GetValidableProperties();
        }

        public ValidationModel DataModel { get; set; }

        public DelegateCommand SolveCommand { get; private set; }

        public ICommand ChangeValidationRangeCommand { get; private set; }

        public IList<string> AllErrors
        {
            get { return this.allErrors; }
            set { this.SetProperty(ref this.allErrors, value); }
        }

        private void Solve(object obj)
        {
            this.DataModel.Solve();
        }

        private void ChangeValidationRange(object obj)
        {
            this.DataModel.MaxTo = 15;
            this.DataModel.MaxFrom = 4;
            this.DataModel.ValidateAllProperties();
        }

        private void UpdateAllErrors()
        {
            this.AllErrors = this.DataModel.GetAllErrors();
            this.SolveCommand.RaiseCanExecuteChanged();
        }

        private IEnumerable<PropertyInfo> GetValidableProperties()
        {
            return this.DataModel
                       .GetType()
                       .GetRuntimeProperties()
                       .Where(p => p.GetCustomAttributes(typeof(ValidateableAttribute), false).Count() > 0);
        }
    }
}