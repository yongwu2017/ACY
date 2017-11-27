using CoreLocation;
using MapKit;
using MapOverlay.iOS;
using ObjCRuntime;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MapOverlay.iOS
{
    public class CustomMapRenderer : MapRenderer
    {
        MKPolygonRenderer polygonRenderer;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                if (nativeMap != null)
                {
                    nativeMap.RemoveOverlays(nativeMap.Overlays);
                    nativeMap.OverlayRenderer = null;
                    polygonRenderer = null;
                }
            }


            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;

                var nativeMap = Control as MKMapView;

                foreach (var shape in formsMap.Shapes)
                {
                    nativeMap.OverlayRenderer = GetOverlayRenderer;
                    CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[shape.Count];

                    int index = 0;
                    foreach (var position in shape)
                    {
                        coords[index] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
                        index++;
                    }

                    nativeMap.AddOverlay(MKPolygon.FromCoordinates(coords));
                    polygonRenderer = null;
                }
            }
        }

        MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlayWrapper)
        {
            if (polygonRenderer == null && !Equals(overlayWrapper, null))
            {
                var overlay = Runtime.GetNSObject(overlayWrapper.Handle) as IMKOverlay;
                polygonRenderer = new MKPolygonRenderer(overlay as MKPolygon)
                {
                    FillColor = UIColor.Red,
                    StrokeColor = UIColor.Red,
                    Alpha = 0.4f,
                    LineWidth = 1
                };
            }
            return polygonRenderer;
        }
    }
}