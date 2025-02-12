﻿using Microsoft.AspNetCore.Mvc;

namespace VetClinic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //[Authorize(Policy = "Client")]
        [HttpGet]
        public ActionResult GetHello()
        {
            return Ok("Everyone gangsta till project initialization");
        }

        [HttpGet("{id}")]
        public ActionResult GetHelloById(int id)
        {
            return Ok($"You got nothing for {id}");
        }
    }
}
