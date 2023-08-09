using System.ComponentModel;

namespace Stock_Model.Models
{
    public class BWIBBU
    {
        [DisplayName("股票代號")]
        public string Code { get; set; }
        [DisplayName("股票名稱")]

        public string Name { get; set; }
        [DisplayName("本益比")]

        public string PEratio { get; set; }
        [DisplayName("殖利率(%)")]

        public string DividendYield { get; set; }
        [DisplayName("股價淨值比")]

        public string PBratio { get; set; }
    }

}
