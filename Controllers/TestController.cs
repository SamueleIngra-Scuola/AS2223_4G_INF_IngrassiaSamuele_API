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
            string message;

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
    }
}
