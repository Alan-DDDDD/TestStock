using System.ComponentModel;

namespace Stock_Model.Models
{
    public class STOCK_DAY
    {
        [DisplayName("股票代號")]
        public string Code { get; set; }
        [DisplayName("證券名稱")]
        public string Name { get; set; }
        [DisplayName("成交股數")]
        public string TradeVolume { get; set; }
        [DisplayName("成交金額")]
        public string TradeValue { get; set; }
        [DisplayName("開盤價")]
        public string OpeningPrice { get; set; }
        [DisplayName("最高價")]
        public string HighestPrice { get; set; }
        [DisplayName("最低價")]
        public string LowestPrice { get; set; }
        [DisplayName("收盤價")]
        public string ClosingPrice { get; set; }
        [DisplayName("漲跌價差")]
        public string Change { get; set; }
        [DisplayName("成交筆數")]
        public string Transaction { get; set; }
    }
}
