using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stock_Model.Models;
using System.Diagnostics;

namespace Stock_Model.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = new Datas<List<BWIBBU>>("TWSE", "GET", "BWIBBU").data;
            data = data
                .Where(x => convert(x.PEratio) <= 15
                && convert(x.DividendYield) >= 5
                && convert(x.DividendYield) <= 15
                && convert(x.PBratio) <= 1.2)
                .OrderBy(x => Convert.ToDouble(x.DividendYield))
                .ToList();
            ViewBag.Type = new BWIBBU();
            ViewBag.Data = data;
            CalculateData a = new CalculateData();
            Console.WriteLine(a.K + " , " + a.D);
            return View();
        }

        private double convert(string PEratio) => PEratio == "" ? 100 : Convert.ToDouble(PEratio);

        public IActionResult Privacy(string code = "0050",string timeframe = "D")
        {
            var data = new Datas<FuGleData>("FuGle", "GET", "Historical_Candles", code, DateTime.Today.AddDays(-360).ToString("yyyy-MM-dd"),DateTime.Today.ToString("yyyy-MM-dd"), timeframe).data;
            ViewBag.Data = data.data;//只接List<T>物件
            ViewBag.Type = new DataItem();//根據上一行T
            ViewBag.Code = code;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}