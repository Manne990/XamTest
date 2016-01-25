using System;
using System.Collections.Generic;

using Xamarin.Forms;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;

namespace XamTest.Pages
{
    public partial class DeviceMotionPage : ContentPage
    {
        private static MotionSensorType _sensorType = MotionSensorType.Accelerometer;

        public DeviceMotionPage()
        {
            InitializeComponent();

            CrossDeviceMotion.Current.SensorValueChanged += CrossDeviceMotion_Current_SensorValueChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CrossDeviceMotion.Current.Start(_sensorType, MotionSensorDelay.Ui);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossDeviceMotion.Current.Stop(_sensorType);
        }

        private void CrossDeviceMotion_Current_SensorValueChanged (object sender, SensorValueChangedEventArgs e)
        {
            switch(e.SensorType)
            {
                case MotionSensorType.Accelerometer:
                    System.Diagnostics.Debug.WriteLine("A: {0},{1},{2}", ((MotionVector)e.Value).X, ((MotionVector)e.Value).Y, ((MotionVector)e.Value).Z);
                    break;

                case MotionSensorType.Compass:
                    System.Diagnostics.Debug.WriteLine("C: {0}", e.Value);
                    break;

                case MotionSensorType.Gyroscope:
                    System.Diagnostics.Debug.WriteLine("G: {0},{1},{2}", ((MotionVector)e.Value).X, ((MotionVector)e.Value).Y, ((MotionVector)e.Value).Z);
                    break;
            }
        }
    }
}