using System.ComponentModel;

namespace Stock_Model.Models
{
    public class STOCK_DAY_AVG
    {
        [DisplayName("證券代號")]
        public string Code { get; set; }
        [DisplayName("證券名稱")]
        public string Name { get; set; }
        [DisplayName("收盤價")]
        public string ClosingPrice { get; set; }
        [DisplayName("月平均價")]
        public string MonthlyAveragePrice { get; set; }
    }
}
