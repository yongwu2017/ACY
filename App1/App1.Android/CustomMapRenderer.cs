using System.Collections.Generic;
using Android.Gms.Maps.Model;
using MapOverlay.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MapOverlay.Droid
{
    public class CustomMapRenderer : MapRenderer
    {
        List<List<Position>> Shapes;
       
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                Shapes = formsMap.Shapes;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(Android.Gms.Maps.GoogleMap map)
        {
            base.OnMapReady(map);

            foreach (var shape in Shapes){
                var polygonOptions = new PolygonOptions();
                polygonOptions.InvokeFillColor(0x66FF0000);
                polygonOptions.InvokeStrokeColor(0x66FF0000);
                polygonOptions.InvokeStrokeWidth(1.0f);

                foreach (var position in shape)
                {
                    polygonOptions.Add(new LatLng(position.Latitude, position.Longitude));
                }
                NativeMap.AddPolygon(polygonOptions);
            }

        }
    }
}