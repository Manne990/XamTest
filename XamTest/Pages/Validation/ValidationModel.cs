namespace XamTest.Pages.Validation
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Infrastructure;
    using XamTest.Common.Validation;

    public class ValidationModel : ValidatableBindableBase, INotifyDataErrorInfo
    {
        private readonly IValidator<ValidationModel> validator;
        private string from;
        private string to;
        private string result;

        public ValidationModel(IValidator<ValidationModel> validator)
        {
            this.validator = validator;
            this.validator.ErrorsChanged += (s, e) => this.OnErrorsChanged(e);
            this.ClearResult();

            this.MaxFrom = 10;
            this.MinFrom = 1;
            this.MaxTo = 100;
            this.MinTo = 2;
            this.From = "1";
            this.To = "20";
        }

        public int MaxFrom { get; set; }

        public int MinFrom { get; set; }

        public int MaxTo { get; set; }

        public int MinTo { get; set; }

        [ValidateableAttribute]
        public string From
        {
            get
            {
                return this.from;
            }
            
            set 
            {
                if (this.SetPropertyAndValidateAllProperties(ref this.from, value))
                {
                    this.ClearResult();
                } 
            }
        }

        [ValidateableAttribute]
        public string To
        {
            get
            {
                return this.to;
            }

            set
            {
                if (this.SetPropertyAndValidateAllProperties(ref this.to, value))
                {
                    this.ClearResult();
                }
            }
        }

        public string Result
        {
            get { return this.result; }
            set { this.SetProperty(ref this.result, value); }
        }

        public bool HasErrors
        {
            get { return this.validator.HasErrors; }
        }

        public void Solve()
        {
            this.Result = SolveProblem(int.Parse(this.From), int.Parse(this.To)).ToString("D");
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return this.validator.GetErrors(propertyName);
        }

        public IList<string> GetAllErrors()
        {
            return this.validator.GetAllErrors();
        }

        public override void ValidateAllProperties()
        {
            this.validator.Validate(this);
        }

        private void ClearResult()
        {
            this.Result = string.Empty;
        }

        private int SolveProblem(int f, int t)
        {
            var r = 1;
            for (var i = f; i <= t; i++)
            {
                r = LeastCommonMultiple(r, i);
            }

            return r;
        }

        private int LeastCommonMultiple(int a, int b)
        {
            return (a / GreatestCommonDivisor(a, b)) * b;
        }

        private int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}
