using Microsoft.AspNetCore.Mvc;

namespace AS2223_4G_INF_IngrassiaSamuele_API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/")]

    public class TestController : Controller
    {

        [HttpGet("GetOddOrEven")]
        public JsonResult GetOddOrEven(int number)
        {
            string status = "OK";
            string message = "";

            try
            {
                if (number % 2 == 0)
                {
                    message = "Il numero è pari";
                }
                else
                {
                    message = "Il numero è dispari";
                }
            }
            catch (Exception e)
            {
                status = "KO";
                message = $"Errore: {e}";
            }

            return Json(new { status = status, message = message});
        }

        [HttpGet("GetFactorial")]
        public JsonResult GetFactorial(int number)
        {
            int res = 1;
            string status = "OK";
            string message = "";

            try
            {
                for (int i = 1; i <= number; i++)
                {
                    res *= i;
                }
            }
            catch(Exception e)
            {
                res = 0;
                status = "KO";
                message = $"Errore: {e}";
            }
            

            return Json(new { res = res, status = status, message = message });;
        }

        [HttpGet("GetCalculatedTaxes")]
        public JsonResult GetCalculatedTaxes(int salary)
        {
            float taxes;
            string status = "OK";
            string message = "";

            if (salary <= 0)
            {
                taxes = 0;
                status = "KO";
                message = $"Errore: Il salario non può essere minore di 0";
            }
            else
            {
                try
                {

                    if (salary > 35000)
                    {
                        taxes = 35000 * 12 / 100; //Finds the 12% percentage number of 35000 as a fixed number (we are above 35000$ of salary)
                        salary -= 35000;
                        taxes += salary * 28 / 100;
                    }
                    else
                    {
                        taxes = salary * 12 / 100;
                    }
                }
                catch (Exception e)
                {
                    taxes = 0;
                    status = "KO";
                    message = $"Errore: {e}";
                }
            }


            return Json(new { res = taxes, status = status, message = message }); ;
        }
    }
}
