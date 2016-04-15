using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace XamTest.Views.TemplatedTableView
{
	public class TemplatedTableView : Grid
	{
		#region Overrides

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			CreateGrid();
		}

		protected override void OnPropertyChanged(string propertyName)
		{
			if(propertyName == TemplatedTableView.ItemsSourceProperty.PropertyName)
			{
				CreateGrid();
			}

			base.OnPropertyChanged(propertyName);
		}

		#endregion

		// ------------------------------------------------------------

		#region Public Properties

		public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<IEnumerable<object>>), typeof(TemplatedTableView), null);
		public IEnumerable<IEnumerable<object>> ItemsSource
		{
			get { return (IEnumerable<IEnumerable<object>>)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(TemplatedTableView), null);
		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}

		public static readonly BindableProperty VerticalContentAlignmentProperty = BindableProperty.Create(nameof(VerticalContentAlignment), typeof(TemplatedTableViewContentAlignment), typeof(TemplatedTableView), TemplatedTableViewContentAlignment.Default);
		public TemplatedTableViewContentAlignment VerticalContentAlignment
		{
			get { return (TemplatedTableViewContentAlignment)GetValue(VerticalContentAlignmentProperty); }
			set { SetValue(VerticalContentAlignmentProperty, value); }
		}

		public static readonly BindableProperty HorizontalContentAlignmentProperty = BindableProperty.Create(nameof(HorizontalContentAlignment), typeof(TemplatedTableViewContentAlignment), typeof(TemplatedTableView), TemplatedTableViewContentAlignment.Default);
		public TemplatedTableViewContentAlignment HorizontalContentAlignment
		{
			get { return (TemplatedTableViewContentAlignment)GetValue(HorizontalContentAlignmentProperty); }
			set { SetValue(HorizontalContentAlignmentProperty, value); }
		}

		#endregion

		// ------------------------------------------------------------

		#region Private Methods

		private void CreateGrid()
		{
			// Check for data
			if(this.ItemsSource == null || this.ItemsSource.Count() == 0 || this.ItemsSource.First().Count() == 0)
			{
				return;
			}

			// Create the grid
			this.RowDefinitions = CreateRowDefinitions();
			this.ColumnDefinitions = CreateColumnDefinitions();

			CreateCells();
		}

		private RowDefinitionCollection CreateRowDefinitions()
		{
			var rowDefinitions = new RowDefinitionCollection();

			if(this.VerticalContentAlignment == TemplatedTableViewContentAlignment.Center)
			{
				rowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			}

			foreach(var row in this.ItemsSource.First())
			{
				rowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			}

			if(this.VerticalContentAlignment == TemplatedTableViewContentAlignment.Center)
			{
				rowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			}

			return rowDefinitions;
		}

		private ColumnDefinitionCollection CreateColumnDefinitions()
		{
			var columnDefinitions = new ColumnDefinitionCollection();

			if(this.HorizontalContentAlignment == TemplatedTableViewContentAlignment.Center)
			{
				columnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			}

			foreach(var column in this.ItemsSource)
			{
				columnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
			}

			if(this.HorizontalContentAlignment == TemplatedTableViewContentAlignment.Center)
			{
				columnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			}

			return columnDefinitions;
		}

		private void CreateCells()
		{
			int startRowIndex = this.VerticalContentAlignment == TemplatedTableViewContentAlignment.Center ? 1 : 0;
			int colIndex = this.HorizontalContentAlignment == TemplatedTableViewContentAlignment.Center ? 1 : 0;

			foreach(var column in this.ItemsSource)
			{
				var rowIndex = startRowIndex;

				foreach(var item in column)
				{
					this.Children.Add(CreateCellView(item), colIndex, rowIndex);
					rowIndex++;
				}

				colIndex++;
			}
		}

		private Xamarin.Forms.View CreateCellView(object item)
		{
			var view = (View)this.ItemTemplate.CreateContent();
			var bindableObject = (BindableObject)view;

			if (bindableObject != null)
			{
				bindableObject.BindingContext = item;
			}

			return view;
		}

		#endregion
	}
}