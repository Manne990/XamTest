using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamTest.Views.TableView
{
    public class TableView : Grid
    {
        #region Overrides

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            UpdateGrid();
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName == "ItemsProperty")
            {
                UpdateGrid();
            }

            base.OnPropertyChanged(propertyName);
        }

        #endregion

        // ------------------------------------------------------------

        #region Public Properties

        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<ObservableCollection<string>>), typeof(TableView), null);
        public ObservableCollection<ObservableCollection<string>> Items
        {
            get { return (ObservableCollection<ObservableCollection<string>>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TableView), string.Empty);
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty HeaderSeparatorLineColorProperty = BindableProperty.Create(nameof(HeaderSeparatorLineColor), typeof(Color), typeof(TableView), Color.Transparent);
        public Color HeaderSeparatorLineColor
        {
            get { return (Color)GetValue(HeaderSeparatorLineColorProperty); }
            set { SetValue(HeaderSeparatorLineColorProperty, value); }
        }

        #endregion

        // ------------------------------------------------------------

        #region Private Methods

        private void UpdateGrid()
        {
            // Init
            bool addHeaderLine = this.HeaderSeparatorLineColor != Color.Transparent;

            // Recreate grid
            this.RowDefinitions = new RowDefinitionCollection();
            this.ColumnDefinitions = new ColumnDefinitionCollection();

            // Check for data
            if (this.Items == null || this.Items.Count == 0 || this.Items[0].Count == 0)
            {
                return;
            }

            // Add Columns
            foreach (var column in this.Items)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150, GridUnitType.Absolute) });
            }

            // Add Rows
            bool firstRow = true;
            foreach (var row in this.Items[0])
            {
                if (firstRow)
                {
                    this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });

                    if (addHeaderLine)
                    {
                        this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5, GridUnitType.Absolute) });
                    }

                    firstRow = false;
                    continue;
                }

                this.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            // Add Cells
            int rowIndex = 0;
            int colIndex = 0;

            foreach (var column in this.Items)
            {
                rowIndex = 0;

                foreach (var item in column)
                {
                    this.Children.Add(CreateCellView(item, colIndex, rowIndex), colIndex, rowIndex);

                    rowIndex++;

                    if (rowIndex == 1 && addHeaderLine)
                    {
                        if (colIndex == 0)
                        {
                            var separator = CreateHeaderSeparatorLineView();

                            this.Children.Add(separator, colIndex, rowIndex);
                            Grid.SetColumnSpan(separator, this.Items.Count);
                        }

                        rowIndex++;
                    }
                }

                colIndex++;
            }
        }

        private Xamarin.Forms.View CreateHeaderSeparatorLineView()
        {
            return new StackLayout()
            {
                BackgroundColor = this.HeaderSeparatorLineColor,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
        }

        private Xamarin.Forms.View CreateCellView(string content, int colIndex, int rowIndex)
        {
            // Create the container view
            var container = new StackLayout()
            {
                BackgroundColor = rowIndex == 0 ? Color.Black : Color.White,
                Padding = new Thickness(10)
            };

            // Create the label
            var label = new Label()
            {
                Text = rowIndex == 0 ? content : content.Replace(",", "\r\n"),
                BackgroundColor = rowIndex == 0 ? Color.Black : Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = rowIndex == 0 ? Color.White : Color.Black,
                FontSize = 12,
                LineBreakMode = LineBreakMode.WordWrap
            };

            if (rowIndex == 0)
            {
                label.FontAttributes = FontAttributes.Bold;
            }

            label.SetBinding(Label.FontFamilyProperty, new Binding(path: "FontFamily", source: this));

            container.Children.Add(label);

            // Return...
            return container;
        }

        #endregion
    }
}