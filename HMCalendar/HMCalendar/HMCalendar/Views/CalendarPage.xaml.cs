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

        public Label SeasonLabel { get; set; }

		public CalendarPage ()
		{
			InitializeComponent ();

		    BindingContext = _calendarVM = new CalendarViewModel();
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