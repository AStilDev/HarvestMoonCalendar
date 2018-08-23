using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            0,
            BindingMode.TwoWay,
            propertyChanged: HandleNumDaysChanged);

	    public int NumDays
	    {
	        get => (int) GetValue(NumDaysProperty);

	        set => SetValue(NumDaysProperty, value);
	    }

        // todo need list of colors? Need to pass in color somewhere
        // dictionary of b-days with assoc. colors (pink gals, blue boys, everyone else yellow)

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
                var frameTap = new TapGestureRecognizer();
                frameTap.Tapped += (sender, e) =>
                {
                    Frame frameClicked = (Frame)sender;
                    int day = int.Parse(((Label)frameClicked.Content).Text);
                    HighlightDay(day, "#ff1122");
                };

	            var frame = new Frame
	            {
	                Content = new Label
	                {
	                    Text = "" + (i + 1),
	                    Style = (Style)Application.Current.Resources["CalendarLabel"]
	                },
	                Style = (Style)Application.Current.Resources["CalendarFrame"],
                    GestureRecognizers = { frameTap }
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

        private void HighlightDay(int day, string hexColor)
	    {
	        CalendarGrid.Children[day - 1].BackgroundColor = Color.FromHex(hexColor);
        }
    }
}