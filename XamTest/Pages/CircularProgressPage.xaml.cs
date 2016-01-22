using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamTest.Views.ProgressAndSpinner;

namespace XamTest.Pages
{
    public partial class CircularProgressPage : ContentPage
    {
        public CircularProgressPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            StartSpinner(spinner);
            StartProgress(progressView);
        }

        private void StartSpinner(VisualElement ve)
        {
            double currentRotation = 0;

            ve.RotateTo(currentRotation, 1, Easing.Linear);

            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () => {
                currentRotation += 360;

                ve.RotateTo(currentRotation, 1000, Easing.Linear);

                return true;
            });
        }

        private void StartProgress(CircularProgressView ve)
        {
            ve.Progress = 0f;

            Device.StartTimer(TimeSpan.FromMilliseconds(1), () => {
                ve.Progress += 0.005f;

                if (ve.Progress >= 1.0f) {
                    ve.Progress = 0f;
                }

                return true;
            });
        }
    }
}