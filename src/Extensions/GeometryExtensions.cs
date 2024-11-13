using NetTopologySuite.Geometries;

public static class GeometryExtensions
{
    // reference 1: https://rosettacode.org/wiki/Haversine_formula#C#
    // reference 2: https://stackoverflow.com/questions/41621957/a-more-efficient-haversine-function
    public static double CalculateHaversineDistance(this Point point, Point point2)
    {
        const double R = 6378100; // In meters
        var dLat = toRadians(point2.Y - point.Y);
        var dLon = toRadians(point2.X - point.X);

        var lat1 = toRadians(point.Y);
        var lat2 = toRadians(point2.Y);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
        var c = 2 * Math.Asin(Math.Sqrt(a));
        return R * 2 * Math.Asin(Math.Sqrt(a));
    }

    public static double toRadians(double angle)
    {
        return Math.PI * angle / 180.0;
    }
}
