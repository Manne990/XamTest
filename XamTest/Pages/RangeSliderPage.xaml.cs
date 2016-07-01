using System;
using System.Collections.Generic;

using Xamarin.Forms;
using GalaSoft.MvvmLight;

namespace XamTest.Pages
{
	public partial class RangeSliderPage : ContentPage
	{
		private RangeSliderViewModel _viewmodel;

		public RangeSliderPage()
		{
			InitializeComponent();

			_viewmodel = new RangeSliderViewModel() { MaxHydraulicReachMin = 0.0f, MaxHydraulicReachMax = 20.0f, MaxLiftingCapacityMin = 0.0f, MaxLiftingCapacityMax = 15000.0f };

			this.BindingContext = _viewmodel;
		}

		private void MaxHydraulicReachValueChanged(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("MaxHydraulicReach: {0}, {1}", _viewmodel.MaxHydraulicReachMin, _viewmodel.MaxHydraulicReachMax);
		}

		private void MaxLiftingCapacityValueChanged(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("MaxLiftingCapacity: {0}, {1}", _viewmodel.MaxLiftingCapacityMin, _viewmodel.MaxLiftingCapacityMax);
		}
	}

	public class RangeSliderViewModel : ViewModelBase
	{
		private float _maxHydraulicReachMin;
		public float MaxHydraulicReachMin
		{
			get
			{
				return _maxHydraulicReachMin;
			}
			set
			{
				if (value != _maxHydraulicReachMin)
				{
					_maxHydraulicReachMin = value;
					RaisePropertyChanged("MaxHydraulicReachMin");
				}
			}
		}

		private float _maxHydraulicReachMax;
		public float MaxHydraulicReachMax
		{
			get
			{
				return _maxHydraulicReachMax;
			}
			set
			{
				if (value != _maxHydraulicReachMax)
				{
					_maxHydraulicReachMax = value;
					RaisePropertyChanged("MaxHydraulicReachMax");
				}
			}
		}

		private float _maxLiftingCapacityMin;
		public float MaxLiftingCapacityMin
		{
			get
			{
				return _maxLiftingCapacityMin;
			}
			set
			{
				if (value != _maxLiftingCapacityMin)
				{
					_maxLiftingCapacityMin = value;
					RaisePropertyChanged("MaxLiftingCapacityMin");
				}
			}
		}

		private float _maxLiftingCapacityMax;
		public float MaxLiftingCapacityMax
		{
			get
			{
				return _maxLiftingCapacityMax;
			}
			set
			{
				if (value != _maxLiftingCapacityMax)
				{
					_maxLiftingCapacityMax = value;
					RaisePropertyChanged("MaxLiftingCapacityMax");
				}
			}
		}
	}
}