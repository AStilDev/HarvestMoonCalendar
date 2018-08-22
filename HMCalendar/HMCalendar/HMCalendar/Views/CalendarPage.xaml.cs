using System;
using HMCalendar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMCalendar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarPage : ContentPage
    {
	    private const int MaxMonthDays = 30;
	    private CalendarViewModel _calendarVM;

        public Label SeasonLabel { get; set; }

		public CalendarPage ()
		{
			InitializeComponent ();

            /*var layout = new StackLayout();

		    var headerLayout = new StackLayout
		    {
		        BackgroundColor = Color.FromHex(_calendarVM.SeasonColor),
		        HorizontalOptions = LayoutOptions.Fill,
		    };

		    var labelLayout = new Grid
		    {
		        Padding = new Thickness(10),
                ColumnSpacing = 8,
		        HorizontalOptions = LayoutOptions.FillAndExpand
            };

		    labelLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
		    labelLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
		    labelLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // add left arrow
		    var leftTapGestureRecognizer = new TapGestureRecognizer();
		    leftTapGestureRecognizer.Tapped += (sender, e) => { _calendarVM.OnLeftClicked(); };

            var leftArrow = new Image
                {
                    Source = "circle_left.png",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    GestureRecognizers = { leftTapGestureRecognizer }
                };
            labelLayout.Children.Add(leftArrow, 0, 0);

            SeasonLabel = new Label
                {
                    Text = _calendarVM.Season,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    HeightRequest = 20
                };
            labelLayout.Children.Add(SeasonLabel, 1, 0);

            // add right arrow
            var rightTapGestureRecognizer = new TapGestureRecognizer();
		    rightTapGestureRecognizer.Tapped += (s, e) => { _calendarVM.OnRightClicked(); };

            var rightArrow = new Image
		        {
		            Source = "circle_right.png",
		            VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    GestureRecognizers = { rightTapGestureRecognizer }
		        };
		    labelLayout.Children.Add(rightArrow, 2, 0);

            headerLayout.Children.Add(labelLayout);
            layout.Children.Add(headerLayout);

            // todo make this a CalendarControl (like bigbuttoncontrol)
            var grid = new Grid
            {
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
		    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
		    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
		    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
		    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
		    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
		    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
		    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
		    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
		    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
		    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
		    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

		    int row = 0;
		    int col = 0;
		    for (int i = 0; i < MaxMonthDays; i++)
		    {
		        var frame = new Frame
		        {
                    Content = new Label
                    {
                        Text = "" + (i + 1),
                        Style = (Style)Application.Current.Resources["CalendarLabel"]
                    },
                    Style = (Style)Application.Current.Resources["CalendarFrame"]
                };

		        if (i != 0 && i % 7 == 0)
		        {
		            row++;
                    col = 0; // reset column
                }

                grid.Children.Add(frame, col, row); // view, row, col

		        col++;
		    }

            layout.Children.Add(grid);*/

		    // todo Content = layout;
		}

        public void OnLeftClicked(object sender, EventArgs args)
        {
            _calendarVM.OnLeftClicked();
        }

        public void OnRightClicked(object sender, EventArgs args)
        {
            _calendarVM.OnRightClicked();
        }
    }
}