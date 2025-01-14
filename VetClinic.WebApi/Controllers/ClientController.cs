﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VetClinic.Core.Entities;
using VetClinic.Core.Interfaces.Services;
using VetClinic.WebApi.ViewModels;

namespace VetClinic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ClientViewModel model)
        {
            var client = _mapper.Map<Client>(model);
            client = await _clientService.AddAsync(client);

            return Ok(client);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(string id)
        {

            var client = await _clientService.GetByIdAsync(id);

            if (client != null)
                return Ok(client);
            else
                return NotFound();
        }


        [HttpPut]
        public IActionResult Update(string id, Client model)
        {
            var client = _mapper.Map<Client>(model);

            _clientService.Update(id, client);
            return Ok();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            try
            {
                await _clientService.DeleteAsync(id);
                return Ok($"{nameof(Client)} has been deleted");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
