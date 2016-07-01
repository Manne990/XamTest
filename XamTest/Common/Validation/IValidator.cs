namespace Infrastructure
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public interface IValidator<in T> : INotifyDataErrorInfo
    {
        IDictionary<string, string> Validate(T instance);

        IList<string> GetAllErrors();
    }
}
