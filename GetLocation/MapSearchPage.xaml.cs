using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace GetLocation;

public partial class MapSearchPage : ContentPage
{
    public double lat;
    public double lng;
	public MapSearchPage()
	{
		InitializeComponent();
	}
    async void HandleSearch(object sender, EventArgs e)
    {
        string searchQuery = query.Text;
        query.Text = "";
        query.IsEnabled= false;

        // the Unfocus method does not work.
        // simple workaround is to disable and enable the entry

        IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(searchQuery);

        Location location = locations?.FirstOrDefault();

        if (location != null)
        {
            lat = location.Latitude;
            lng = location.Longitude;
        }
        else
        {
            await DisplayAlert("Oops", "Something went wrong, please try again.", "Ok");
        }

        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(lat, lng), Distance.FromMiles(.2)));

        map.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin
        {
            Type = PinType.Place,
            Label = "Searched place",
            Location = new Location(lat, lng),
        });

        query.IsEnabled= true;
    }
}