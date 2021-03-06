﻿using System;
using System.Linq;
using HMCalendar.ViewModels;
using Xamarin.Essentials;
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
                // go to character page
                var frameClicked = (Frame)controlTapped;

                var day = int.Parse(((Label)frameClicked.Content).Text);
                var frameCharas = Calendar.Characters.Where(c => c.Birthday.EndsWith(" " + day));

                if (frameCharas.Any())
                {
                    var charaVM = new CharacterViewModel(frameCharas.First());
                    Navigation.PushAsync(new CharacterPage(charaVM));
                }
            };

            MessagingCenter.Subscribe<GameSelectionPage>(this, "GameSelected", SourceCallback);
        }

        private void SourceCallback(GameSelectionPage obj)
        {
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

        public async void OnOptionsClicked(object sender, EventArgs args)
        {
            // open game change selection
            await Navigation.PushModalAsync(new GameSelectionPage());
        }
    }
}