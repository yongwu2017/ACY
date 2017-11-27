using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Diagnostics;

namespace XamarinMapSample
{
    public class MapPage : ContentPage
    {
        CustomMap map;
        public MapPage()
        {
            map = new CustomMap
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.Shapes.Add(new List<Position>());
            map.Shapes[0].Add(new Position(33.5, -101.8));
            map.Shapes[0].Add(new Position(33.5, -101.9));
            map.Shapes[0].Add(new Position(33.6, -101.9));
            map.Shapes[0].Add(new Position(33.6, -101.8));

            map.Shapes.Add(new List<Position>());
            map.Shapes[1].Add(new Position(43.5, -101.8));
            map.Shapes[1].Add(new Position(43.5, -101.9));
            map.Shapes[1].Add(new Position(43.6, -101.9));
            map.Shapes[1].Add(new Position(43.6, -101.8));

            map.Shapes.Add(new List<Position>());
            map.Shapes[2].Add(new Position(33.5, -111.8));
            map.Shapes[2].Add(new Position(33.5, -111.9));
            map.Shapes[2].Add(new Position(33.6, -111.9));
            map.Shapes[2].Add(new Position(33.6, -111.8));

            // You can use MapSpan.FromCenterAndRadius   

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(33.57, -101.85), Distance.FromMiles(1000.0)));
  
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
            // create pin
            var pin = new Pin
            {
                Position = new Position(30.57, -99.85),
                Label = "Texas"
            };
            pin.Clicked += PinSelect;
            map.Pins.Add(pin);

            // Assemble the page  
            var stack = new StackLayout
            {
                Spacing = 0
            };
            stack.Children.Add(map);
            stack.Children.Add(segments);
     //       stack.Children.Add(pin);
            Content = stack;

        }
        // Terrain button clicked
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

        // Pin slected
        private void PinSelect(object send, EventArgs e)
        {
            var selectedPin = send as Pin;
            DisplayAlert(selectedPin?.Label, "Gun Laws: \nGuns Blazing", "ok");

        }
    }
}