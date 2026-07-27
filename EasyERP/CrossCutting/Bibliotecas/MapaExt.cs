namespace Biblioteca
{
    public static class MapaExt
    {
        private const double RaioTerraMetros = 6371000;

        public static decimal CalcularDistanciaMetros(decimal latitude1, decimal longitude1, decimal latitude2, decimal longitude2)
        {
            double lat1 = (double)latitude1;
            double lon1 = (double)longitude1;
            double lat2 = (double)latitude2;
            double lon2 = (double)longitude2;

            var dLat = GrausParaRadianos(lat2 - lat1);
            var dLon = GrausParaRadianos(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(GrausParaRadianos(lat1)) * Math.Cos(GrausParaRadianos(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return (decimal)(RaioTerraMetros * c);
        }

        private static double GrausParaRadianos(double graus) => graus * Math.PI / 180;
    }
}