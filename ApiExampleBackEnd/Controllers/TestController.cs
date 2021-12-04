using System;
using System.Collections.Generic;
using System.Linq;
using ApiExampleBackEnd.DB;
using ApiExampleBackEnd.Models;
using ApiExampleBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiExampleBackEnd.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ApiExampleContext _dbContext;

        public TestController(ILogger<TestController> logger, ApiExampleContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost("calculate")]
        public CalculationsResult CalculateTwoNumbers([FromBody] CalculateRequest request)
        {
            _dbContext.CalculateRequests.Add(request);
            _dbContext.SaveChanges();
            var result = CalculationService.Calculate(request.Number1, request.Number2);
            _dbContext.CalculationsResult.Add(result);
            _dbContext.SaveChanges();
            return result;
        }
        
        [HttpGet("requests")]
        public List<CalculateRequest> GetRequests()
        {
            var requests = _dbContext.CalculateRequests.ToList();
            return requests;
        }
        
        [HttpGet("responses")]
        public List<CalculationsResult> GetResponses()
        {
            var responses = _dbContext.CalculationsResult.ToList();
            return responses;
        }
        
        [HttpGet("responses/{number}")]
        public List<CalculationsResult> GetResponsesWhereAdditionIsMoreThanNumber(int number)
        {
            var responses = _dbContext.CalculationsResult.Where(x=>x.AdditionResult >= number).ToList();
            return responses;
        }
        
        [HttpPatch("responses/{responseId}")]
        public CalculationsResult PatchResponse(Guid responseId, [FromBody] CalculateRequest request)
        {
            var response = _dbContext.CalculationsResult.Where(x => x.Id == responseId).SingleOrDefault();
            var newResponse = CalculationService.Calculate(request.Number1, request.Number2);
            response.AdditionResult = newResponse.AdditionResult;
            response.SubtractionResult = newResponse.SubtractionResult;
            response.DivsionResult = newResponse.DivsionResult;
            response.MultiplicationResult = newResponse.MultiplicationResult;
            _dbContext.SaveChanges();
            return response;
        }
    }
}