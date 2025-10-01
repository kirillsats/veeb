using Microsoft.AspNetCore.Mvc;
using System;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimitiividController : ControllerBase
    {
        private readonly Random _rand = new Random();

        // GET: primitiivid/hello-world
        [HttpGet("hello-world")]
        public string HelloWorld()
        {
            return "Hello world at " + DateTime.Now;
        }

        // GET: primitiivid/hello-variable/mari
        [HttpGet("hello-variable/{nimi}")]
        public string HelloVariable(string nimi)
        {
            return "Hello " + nimi;
        }

        // GET: primitiivid/add/5/6
        [HttpGet("add/{nr1}/{nr2}")]
        public int AddNumbers(int nr1, int nr2)
        {
            return nr1 + nr2;
        }

        // GET: primitiivid/multiply/5/6
        [HttpGet("multiply/{nr1}/{nr2}")]
        public int Multiply(int nr1, int nr2)
        {
            return nr1 * nr2;
        }

        // GET: primitiivid/do-logs/5
        [HttpGet("do-logs/{arv}")]
        public void DoLogs(int arv)
        {
            for (int i = 0; i < arv; i++)
            {
                Console.WriteLine("See on logi nr " + i);
            }
        }

        // GET: primitiivid/random-number/5/10
        [HttpGet("random-number/{nr1}/{nr2}")]
        public int RandomNumber(int nr1, int nr2)
        {
            return _rand.Next(nr1, nr2 + 1);
        }

        // GET: primitiivid/age/1990-05-15
        [HttpGet("age/{birthdate}")]
        public string CalculateAge(string birthdate)
        {
            try
            {
                // Парсим строку даты в DateTime
                DateTime birthDate = DateTime.ParseExact(birthdate, "yyyy-MM-dd", null);
                int currentYear = DateTime.Now.Year;

                // Вычисление возраста
                int age = currentYear - birthDate.Year;

                // Если день рождения еще не был в этом году, уменьшаем возраст на 1
                if (DateTime.Now < birthDate.AddYears(age))
                {
                    age--;
                }

                // Формируем строку с результатом
                return $"Вам {age} лет (с математической точностью), в зависимости от того, был ли в этом году уже день рождения.";
            }
            catch (FormatException)
            {
                return "Неверный формат даты. Используйте формат yyyy-MM-dd.";
            }
        }
    }
}
