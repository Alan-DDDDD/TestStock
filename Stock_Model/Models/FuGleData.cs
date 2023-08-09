using System.ComponentModel;

namespace Stock_Model.Models
{
    public class FuGleData
    {
        public string symbol { get; set; }
        public string type { get; set; }
        public string exchange { get; set; }
        public string market { get; set; }
        public List<DataItem> data { get; set; }
    }
    public class DataItem
    {
        [DisplayName("時間")]
        public string date { get; set; }
        [DisplayName("開盤價")]
        public double open { get; set; }
        [DisplayName("最高價")]
        public double high { get; set; }
        [DisplayName("最低價")]
        public double low { get; set; }
        [DisplayName("收盤價")]
        public double close { get; set; }
        [DisplayName("成交量")]
        public int volume { get; set; }
        [DisplayName("漲跌幅")]
        public double change { get; set; }
    }
}
