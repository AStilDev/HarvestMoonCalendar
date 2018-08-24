using System;
using HMCalendar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMCalendar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarPage : ContentPage
    {
	    private CalendarViewModel _calendarVM;

		public CalendarPage ()
		{
			InitializeComponent ();

		    BindingContext = _calendarVM = new CalendarViewModel();

		    Calendar.Characters = _calendarVM.SeasonCharacters;

            // calendar frame tapped
		    Calendar.FrameTapped += (sender, controlTapped) =>
		    {
                // todo go to chara page
		        var frameClicked = (Frame)sender;
                var day = int.Parse(((Label)frameClicked.Content).Text);
		        var frameChara = Calendar.Characters[day];
		        // go to framChara page
		    };
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