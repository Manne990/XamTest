namespace XamTest.Pages.Validation
{
    using FluentValidation;
    using Infrastructure;

    public class ValidationViewModelValidator : FluentValidator<ValidationModel>
    {
        private const string FromProperty = "'From'";
        private const string ToProperty = "'To'";
        private const string CannotBeLeftBlank = " cannot be left blank.";
        private const string MustBeValidWholeNumber = " must be a valid whole number.";
        private const string MustBeLessThan = " must be less than ";
        private const string MustBeGreaterThan = " must be greater than ";

        public ValidationViewModelValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            this.RuleFor(x => x.From)
                .NotEmpty()
                .WithMessage(FromProperty + CannotBeLeftBlank)
                .Must(a => a.IsInteger())
                .WithMessage(FromProperty + MustBeValidWholeNumber)
                .Must(
                    (x, a) =>
                    {
                        var from = int.Parse(a);
                        return x.MinFrom <= from && from <= x.MaxFrom;
                    })
                .WithMessage("{0} <= " + FromProperty + " <= {1}", x => x.MinFrom, x => x.MaxFrom)
                .Must(
                    (x, a) =>
                    {
                        // We validate this rule only when the "To" parameter is a valid integer.
                        int to;
                        if (int.TryParse(x.To, out to) && x.MinTo <= to && to <= x.MaxTo)
                        {
                            return int.Parse(a) < to;
                        }

                        // If "To" parameter is invalid, we shouldn't show the error message.
                        return true;
                    })
                .WithMessage(FromProperty + MustBeLessThan + ToProperty + ".");

            this.RuleFor(x => x.To)
                .NotEmpty()
                .WithMessage(ToProperty + CannotBeLeftBlank)
                .Must(a => a.IsInteger())
                .WithMessage(ToProperty + MustBeValidWholeNumber)
                .Must(
                    (x, a) =>
                    {
                        var to = int.Parse(a);
                        return x.MinTo <= to && to <= x.MaxTo;
                    })
                .WithMessage("{0} <= " + ToProperty + " <= {1}", x => x.MinTo, x => x.MaxTo)
                .Must(
                    (x, a) =>
                    {
                        // We validate this rule only when the "From" parameter is a valid integer.
                        int from;
                        if (int.TryParse(x.From, out from) && x.MinFrom <= from && from <= x.MaxFrom)
                        {
                            return int.Parse(a) > from;
                        }

                        // If "From" parameter is invalid, we shouldn't show the error message.
                        return true;
                    })
                .WithMessage(ToProperty + MustBeGreaterThan + FromProperty + ".");
        }
    }
}
