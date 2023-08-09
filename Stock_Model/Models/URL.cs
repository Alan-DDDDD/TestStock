using System.Reflection;

namespace Stock_Model.Models
{
    public class URL
    {
        private string TWSEUrl = "https://openapi.twse.com.tw/v1/";
        private string FuGleUrl = "https://api.fugle.tw/marketdata/v1.0/stock/";
        public string? Url { get; set; }
        public URL(string source, string ApiName, string? param1, string? param2, string? param3, string? param4)
        {
            UrlData urlData = new(param1, param2, param3, param4);
            PropertyInfo[] properties = urlData.GetType().GetProperties();
            string urlbase = source == "TWSE" ? TWSEUrl : FuGleUrl;
            foreach (PropertyInfo property in properties)
                if (property.Name == ApiName)
                    Url = urlbase + property.GetValue(urlData);
        }
    }

    public class UrlData
    {
        private string? _param1 { get; set; }
        private string? _param2 { get; set; }
        private string? _param3 { get; set; }
        private string? _param4 { get; set; }
        private string? _param5 { get; set; }
        private string? _param6 { get; set; }
        private string? _param7 { get; set; }
        private string? _param8 { get; set; }

        public UrlData(string? param1, string? param2, string? param3, string? param4)
        {
            _param1 = param1;
            _param2 = param2;
            _param3 = param3;
            _param4 = param4;
        }

        //TWSE API NAME
        public string BWIBBU { get { return "exchangeReport/BWIBBU_ALL"; } }
        public string STOCK_DAY { get { return "exchangeReport/STOCK_DAY_ALL"; } }
        public string STOCK_DAY_AVG { get { return "exchangeReport/STOCK_DAY_AVG_ALL"; } }

        //FuGle API NAME
        public string Historical_Candles { get { return $"historical/candles/{_param1}?from={_param2}&to={_param3}&timeframe={_param4}&fields=open,high,low,close,volume,change"; } }
    }
}
