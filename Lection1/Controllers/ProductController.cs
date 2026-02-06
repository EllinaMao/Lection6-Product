using Lection1.Models;
using Microsoft.AspNetCore.Mvc;
/*
 У нас есть веб-приложение для онлайн-магазина, и мы хотим реализовать функциональность поиска товаров. Для этого мы можем создать контроллер ProductController, который будет обрабатывать запросы на поиск товаров. Контроллер ProductController должен иметь следующие действия: 
 
Index() - метод, который будет возвращать список всех товаров на сайте в виде JSON; 
Create() - метод, который будет добавлять товар, через POST запрос. Для этого используйте HTML страницу или действие возвращающее соответствующую форму для заполнения данных о товаре.
Search(string keyword) - метод, который будет искать товары по ключевому слову и возвращать их в виде JSON; 
Details(int id) - метод, который будет отображать подробную информацию о товаре по его идентификатору в виде JSON;
Delete(int id) - метод, который будет удалять товар по его идентификатору, через POST запрос и в качестве ответа возвращать удаленный товар виде JSON.
 
Данные о товарах, хранить в базе данных.
 
 */
namespace Lection1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository = new ProductRepository();


        //Index() - метод, который будет возвращать список всех товаров на сайте в виде JSON; 

        [HttpGet]
        public IActionResult Index()
        {
            var products = _repository.GetAll();
            return Json(products);
        }

        [HttpGet]
        public IActionResult Create()
        {

           return View();
        }
        //Create() - метод, который будет добавлять товар, через POST запрос. Для этого используйте HTML страницу или действие возвращающее соответствующую форму для заполнения данных о товаре.  
        [HttpPost]
        public IActionResult Create(Product product)
        {

            try
            {
                _repository.Add(product);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Search(string keyword) - метод, который будет искать товары по ключевому слову и возвращать их в виде JSON; 
        [HttpGet]
        public IActionResult Search(string keyword)
        {
            try
            {
                var products = _repository.Search(keyword);
                return Json(products);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //Details(int id) - метод, который будет отображать подробную информацию о товаре по его идентификатору в виде JSON;
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var product = _repository.GetById(id);
                if (product == null)
                {
                    return NotFound($"Product with Id {id} not found.");
                }
                return Json(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        //Delete(int id) - метод, который будет удалять товар по его идентификатору, через POST запрос и в качестве ответа возвращать удаленный товар виде JSON.
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var deletedProduct = _repository.Delete(id);
                if (deletedProduct == null)
                {
                    return NotFound($"Product with Id {id} not found.");
                }
                return Json(deletedProduct);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Данные о товарах, хранить в списке :P


    }
}
