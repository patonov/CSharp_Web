using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Models.Calculator calculator)
        {
            return View(calculator);
        }

        [HttpPost]
        public ActionResult Calculate(Models.Calculator calculator)
        {
            calculator.Result = CalculateResult(calculator);

            return RedirectToAction("Index", calculator);
        }

        private decimal CalculateResult(Models.Calculator calculator)
        {
            var result = 0m;

            switch (calculator.Operator)
            {
                case "+": result = calculator.LeftOperand + calculator.RightOperand; break;
                case "-": result = calculator.LeftOperand - calculator.RightOperand; break;
                case "*": result = calculator.LeftOperand * calculator.RightOperand; break;
                case "/": result = calculator.LeftOperand / calculator.RightOperand; break;
            }
            return result;
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
