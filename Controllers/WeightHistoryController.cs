using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WeightConversion.Data.Entities;

namespace WeightConversion.Controllers
{
    public class WeightHistoryController : BaseApiController
    {
        private readonly IMongoCollection<WeightHistory> _weights;

        public WeightHistoryController(IMongoClient client)
        {
            var database = client.GetDatabase("WeightConversion");
            _weights = database.GetCollection<WeightHistory>("WeightHistory");
        }


        [HttpGet]
        public async Task<ActionResult> GetWeightHistory()
        {
            try
            {
                return Ok(await _weights.Find(weight => true).ToListAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.HelpLink);
                return BadRequest(new ProblemDetails {Title = e.Message, Detail = e.StackTrace});
            }
        }
    }
}