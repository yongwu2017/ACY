using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;
namespace XamarinMapSample
{
    public class MapPage : ContentPage
    {
        Map map;
        public MapPage()
        {
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            // starting location of map   
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(33.57, -101.85), Distance.FromMiles(1000.0)));
  
            // Instantiates a new Polyline object and adds points to define a rectangle
            PolylineOptions rectOptions = new PolylineOptions()
                    .add(new LatLng(37.35, -122.0))
                    .add(new LatLng(37.45, -122.0))  // North of the previous point, but at the same longitude
                    .add(new LatLng(37.45, -122.2))  // Same latitude, and 30km to the west
                    .add(new LatLng(37.35, -122.2))  // Same longitude, and 16km to the south
                    .add(new LatLng(37.35, -122.0)); // Closes the polyline.
            // Get back the mutable Polyline
            Polyline polyline = map.addPolyline(rectOptions);

            // map terrain buttons  
            var Street = new Button
            {
                Text = "Street"
            };
            var Satellite = new Button
            {
                Text = "Satellite"
            };

            Street.Clicked += HandleClicked;
            Satellite.Clicked += HandleClicked;

            var segments = new StackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = {
                            Street,
                            Satellite
                        }
            };
            // Assemble the page  
            var stack = new StackLayout
            {
                Spacing = 0
            };
            stack.Children.Add(map);
            stack.Children.Add(segments);
            Content = stack;

        }
        void HandleClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Street":
                    map.MapType = MapType.Street;
                    break;
                case "Satellite":
                    map.MapType = MapType.Hybrid;
                    break;
            }
        }
    }
}