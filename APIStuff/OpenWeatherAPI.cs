
//namespace Zachary_Childers_CPT_185_Final.APIStuff
//{
//    public class OpenWeatherAPI
//    {
//        private string openWeatherAPIKey;
//        public OpenWeatherAPI(string apikey) { openWeatherAPIKey = "a4113941f626eb8e3cca168c43e2ff74"; }
//        public async Task<double> QueryAsync(string queryStr)
//        {
//            Uri uri = new Uri(string.Format("http://maps.openweathermap.org/maps/2.0/weather/{op}/{z}/{x}/{y}&appid={a4113941f626eb8e3cca168c43e2ff74}", openWeatherAPIKey, queryStr).ToString());
//            var client = new WebClient();
//            string data = await client.DownloadStringTaskAsync(uri);
//            JObject jsonData = JObject.Parse(data);
//            if (jsonData.SelectToken("cod").ToString() == "200")
//            {
//                var mainData = jsonData.SelectToken("main");
//                var currentTemperature = ConvertToCelsius(double.Parse(mainData.SelectToken("temp").ToString()));
//                return currentTemperature;
//            }
//            else
//            {
//                return 0;
//            }
//        }
//        private double ConvertToCelsius(double kelvin) { return Math.Round(kelvin - 273.15, 3);}
//    }
//}
