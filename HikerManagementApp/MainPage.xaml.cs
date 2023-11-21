using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace HikerManagementApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        App thisApp = Microsoft.Maui.Controls.Application.Current as App;
        private MySQLiteDatase myDB;

        public MainPage()
        {
            InitializeComponent();
            thisApp.HikeList = new ObservableCollection<Hike>();
            myDB = new MySQLiteDatase();

        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirmation", "Are you sure you want to save this hike?", "CANCEL", "OK");
            if (response)
            {
                try
                {
                    // Ensure that the date and time are combined correctly
                    DateTime hikeDateTime = this.txtDateHike.Date + this.txtTimeHike.Time;

                    // Validate and parse the 'Days' input
                    if (!int.TryParse(this.txtDay.Text, out int hikeDays))
                    {
                        await DisplayAlert("Error", "Please enter a valid number for Days.", "OK");
                        return;
                    }

                    Hike h = new Hike(
                        hikeId: count++,
                        hikeName: this.txtNameHike.Text,
                        hikeLocation: this.txtLocation.Text,
                        hikeDate: hikeDateTime,
                        hikeTime: this.txtTimeHike.Time,
                        hikeDays: hikeDays,
                        hikeLength: this.txtLengthHike.Text,
                        hikeParking: this.txtParkingHike.IsToggled,
                        hikeLevel: this.txtLevelHike.SelectedItem?.ToString(),
                        hikeDescription: this.txtDescriptionHike.Text,
                        hikeGear: this.txtGearHike.Text
                    );

                    thisApp.HikeList.Add(h);
                    myDB.insertHike(h);
                    await DisplayAlert("Success", "Hike information has been saved successfully.", "OK");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    await DisplayAlert("Error", "An error occurred while saving the hike.", "OK");
                }
            }
        }

        private void btnView_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HikeList(), true);
        }
        private void btnLoad_Clicked(object sender, EventArgs e)
        {
            thisApp.HikeList = myDB.loadHike();
        }
    }
}
