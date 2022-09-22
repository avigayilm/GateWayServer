using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Usefuls
{
    public static class Location
    {

        public static Tuple<double, double>  GetLocationProperty()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            GeoCoordinate coord = watcher.Position.Location;

            //if (coord.IsUnknown != true)
            //{
               return Tuple.Create(
                    coord.Latitude,
                    coord.Longitude);
            
         
        }
    }
}
