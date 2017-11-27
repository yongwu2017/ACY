using System.Collections.Generic;
using Xamarin.Forms.Maps;

public class CustomMap : Map
{
    public List<List<Position>> Shapes { get; set; }

    public CustomMap()
    {
        Shapes = new List<List<Position>>();
    }
}
