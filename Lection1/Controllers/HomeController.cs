using Lection1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace Lection1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()

        {

           var timeService = HttpContext.RequestServices.GetService<ITimeService>();

            return Content($"Current time: {timeService.Time}");

        }


        public interface ITimeService
        {
            string Time { get; }
        }
        public class SimpleTimeService : ITimeService
        {
            public SimpleTimeService()
            {
                Time = DateTime.Now.ToString("hh:mm:ss");
            }
            public string Time { get; }
        }




    }


}

