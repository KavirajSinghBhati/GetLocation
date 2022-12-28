namespace GetLocation;

public partial class MainPage : ContentPage

{ 
	public MainPage()
	{
		InitializeComponent();
	}

    async void OnMapClick(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {
        // get the coordinates from tap on screen
        await DisplayAlert("Coordinates", $"Lat: {e.Location.Latitude} Lon: {e.Location.Longitude}", "Ok");

    // get address from coordinates
    // geocoding

    IEnumerable<Placemark> pp = await Geocoding.Default.GetPlacemarksAsync(e.Location.Latitude, e.Location.Longitude);

        //Placemark place = pp?.FirstOrDefault();

        await DisplayAlert("Address", pp?.FirstOrDefault()?.ToString(), "Ok");
    }

    private async void GoToSearch(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapSearchPage());
    }
}

