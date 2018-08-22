﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMCalendar.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarControl : ContentView
	{
        public static readonly BindableProperty NumDaysProperty = BindableProperty.Create(
            "NumDays",
            typeof(int),
            typeof(CalendarControl),
            30,
            BindingMode.TwoWay,
            propertyChanged: HandleNumDaysChanged);

	    public int NumDays
	    {
	        get => (int) GetValue(NumDaysProperty);

	        set => SetValue(NumDaysProperty, value);
	    }

		public CalendarControl ()
		{
			InitializeComponent ();
		}

	    private static void HandleNumDaysChanged(BindableObject bindable, object oldValue, object newValue)
	    {
	        var control = bindable as CalendarControl;

	        control?.GenerateDays();
	    }

	    private void GenerateDays()
	    {
	        int row = 0;
	        int col = 0;
	        for (int i = 0; i < NumDays; i++)
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

	            CalendarGrid.Children.Add(frame, col, row); // view, row, col

	            col++;
	        }
        }

    }
}