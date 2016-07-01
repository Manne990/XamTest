using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamTest.Common.Validation2
{
    public class ValidationEntry : Entry
    {
        public ValidationEntry()
        {

        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ValidationEntry.IsValidProperty.PropertyName)
            {
                this.BackgroundColor = this.IsValid ? Color.White : Color.Red;
                this.TextColor = this.IsValid ? Color.Black : Color.White;
            }
        }

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ValidationEntry), true);
        public bool IsValid
        {
            get { return (bool)this.GetValue(IsValidProperty); }
            set { this.SetValue(IsValidProperty, value); }
        }

        public static readonly BindableProperty ErrorsProperty = BindableProperty.Create(nameof(Errors), typeof(ObservableCollection<string>), typeof(ValidationEntry), null);
        public ObservableCollection<string> Errors
        {
            get { return (ObservableCollection<string>)this.GetValue(ErrorsProperty); }
            set { this.SetValue(ErrorsProperty, value); }
        }
    }
}