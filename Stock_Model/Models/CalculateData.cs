namespace Stock_Model.Models
{
    public class CalculateData
    {
        FuGleData _datas { get; set; }
        public double K { get; set; }
        public double D { get; set; }
        public CalculateData(string code = "0050", string timeframe = "D")
        {
            _datas = new Datas<FuGleData>("FuGle", "GET", "Historical_Candles", code, DateTime.Today.AddDays(-360).ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), timeframe).data;
            K_value(DateTime.Today, 9);
            D_value(DateTime.Today, 9);
        }
        public double RSV(DateTime dateTime, double Day)
        {
            var calRSVData = _datas.data
                .Where(x => Convert.ToDateTime(x.date) >= dateTime.AddDays(-(Day + 1)) && Convert.ToDateTime(x.date) <= dateTime)
                .Select(x => x.close).ToList();
            if (calRSVData.Count < Day)
                return 60;
            double value = ((calRSVData[0] - calRSVData.Min()) / (calRSVData.Max() - calRSVData.Min())) * 100;
            return value;
        }
        public double K_value(DateTime dateTime, double day)
        {
            if (DateTime.Today - dateTime == TimeSpan.FromDays(360))
                return 0;
            K = K_value(dateTime.AddDays(-1), day) * 2 / 3 + RSV(dateTime, day) / 3;
            return K;
        }
        public double D_value(DateTime dateTime, double day)
        {
            if (DateTime.Today - dateTime == TimeSpan.FromDays(360))
                return 0;
            D = D_value(dateTime.AddDays(-1), day) * 2 / 3 + K_value(dateTime.AddDays(-1), day) / 3;
            return D;
        }
    }
}
