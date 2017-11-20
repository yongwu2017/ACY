using System.Collections.Generic;
using Xamarin.Forms.Maps;

public class CustomMap : Map
{
    public List<Position> ShapeCoordinates { get; set; }

    public CustomMap()
    {
        ShapeCoordinates = new List<Position> ();
    }
}
