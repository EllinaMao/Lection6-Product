using Microsoft.AspNetCore.Mvc;

namespace Lection1.Controllers
{
    /*Получить данные из контекста запроса (не используя параметры): имя, возраст, вес и массив оценок студента.*/

    public class FormController : Controller
    {
        [HttpPost]
        public string Register()
        {
            string? name = HttpContext.Request.Form["name"];
            int age = int.Parse(HttpContext.Request.Form["age"]!);
            double weight = double.Parse(HttpContext.Request.Form["weight"]!);
            int[] marks = HttpContext.Request.Form["marks"]!.ToString().Split(',').Select(m => int.Parse(m)).ToArray();

            var student = new Student
            {
                Name = name,
                Age = age,
                Weight = weight,
                Marks = marks
            };


            return $"Data - {student.ToString()}";
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }

    
    public record class Student
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        public int[]? Marks { get; set; }


        public override string ToString()
        {
            string marksStr = Marks != null ? string.Join(", ", Marks) : "No marks";
            return $"Name: {Name}, Age: {Age}, Weight: {Weight}, Marks: {marksStr}";
        }
    }

}


