﻿using System;
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

		public CalendarPage ()
		{
			InitializeComponent ();

		    BindingContext = _calendarVM = new CalendarViewModel()
		    {
                
		    };

            var layout = new StackLayout();

		    var headerLayout = new StackLayout
		    {
		        BackgroundColor = Color.FromHex(_calendarVM.SeasonColor),
		        HorizontalOptions = LayoutOptions.Fill,
		    };

            var labelLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0,20,0,20)
            };

            // add left arrow

            labelLayout.Children.Add(
                new Label
                {
                    Text = _calendarVM.Season, // todo
                    VerticalOptions = LayoutOptions.Center,
                    HeightRequest = 20
                }
            );

            // add right arrow

            headerLayout.Children.Add(labelLayout);
            layout.Children.Add(headerLayout);

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

            layout.Children.Add(grid);

		    Content = layout;
		}
    }
}