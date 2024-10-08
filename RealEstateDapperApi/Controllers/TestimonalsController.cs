﻿using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.TestimonalRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonalsController : ControllerBase
    {
        private readonly ITestimonalRepository _testimonalRepository;

        public TestimonalsController(ITestimonalRepository testimonalRepository)
        {
            _testimonalRepository = testimonalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestimonals()
        {
            var values = await _testimonalRepository.GetAllTestimonalsAsync();
            return Ok(values);
        }
    }
}
