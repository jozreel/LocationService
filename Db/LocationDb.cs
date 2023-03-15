using LocationService.Models;
using Microsoft.VisualBasic.FileIO;

namespace LocationService.Db;
public class LocationDb
{
  
     public List<Location> GetLocationAvailability(int from, int to) {
        using var parser = new TextFieldParser("locations.csv");
        parser.TextFieldType =  FieldType.Delimited;
        parser.SetDelimiters(",");
        var res =  new List<Location>();
        while (!parser.EndOfData)
        {
            string[]? fields = parser.ReadFields();
            var now = DateTime.Now.ToString("yyyy-MM-dd");
            if(fields != null) {
            var loc = new Location
            {
                name = fields[0],
                open = DateTime.Parse(now+'T'+fields[1]),
                close = DateTime.Parse(now+'T'+fields[2]),
                type = fields[3]
            };

            if(loc.open.Hour >= from && (loc.open.Hour < to || loc.open.Hour == to && loc.open.Minute == 0 ) ) {
                 res.Add(loc);
            }
            }
        }
        return res;
    }

   
}