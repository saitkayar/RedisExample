using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisExample.Catogory;
using System.Diagnostics;
using Timer = System.Timers.Timer;
namespace RedisExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("category/getall")]
        public async Task <IActionResult> GetAll()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
     
         
            var re = await Task.Run(() => _categoryService.GetAllCategory());
            stopWatch.Stop();
      
            Console.WriteLine(stopWatch.Elapsed.TotalSeconds);
          
            return Ok();
        }



        static public void Tick(Object stateInfo)
        {
            Console.WriteLine("Tick: {0}", DateTime.Now.ToString("h:mm:ss"));
        }
    }
}
