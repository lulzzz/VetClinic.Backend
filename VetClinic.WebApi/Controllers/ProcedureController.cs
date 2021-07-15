﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetClinic.Core.Entities;
using VetClinic.Core.Interfaces.Services;
using VetClinic.WebApi.Validators.EntityValidators;
using VetClinic.WebApi.ViewModels;
using static VetClinic.Core.Resources.TextMessages;

namespace VetClinic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureService _procedureService;
        private readonly IMapper _mapper;
        private readonly ProcedureValidator _validator;
        public ProcedureController(IProcedureService procedureService, IMapper mapper, ProcedureValidator validator)
        {
            _procedureService = procedureService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProcedures()
        {
            var procedures = await _procedureService.GetProceduresAsync(asNoTracking: true);

            var procedureViewModel = _mapper.Map<IEnumerable<ProcedureViewModel>>(procedures);

            return Ok(procedureViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcedure(int id)
        {
            try
            {
                var procedure = await _procedureService.GetByIdAsync(id);

                var procedureViewModel = _mapper.Map<ProcedureViewModel>(procedure);

                return Ok(procedureViewModel);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertProcedure(ProcedureViewModel model)
        {
            var newProcedure = _mapper.Map<Procedure>(model);

            var validationResult = _validator.Validate(newProcedure);

            if (validationResult.IsValid)
            {
                await _procedureService.InsertAsync(newProcedure);
                return CreatedAtAction("InsertProcedureAsync", new { id = newProcedure.Id }, newProcedure);
            }
            return BadRequest(validationResult.Errors);
        }

        [HttpPut]
        public IActionResult Update(int id, ProcedureViewModel model)
        {
            var procedure = _mapper.Map<Procedure>(model);

            var validationResult = _validator.Validate(procedure);

            if (validationResult.IsValid)
            {
                try
                {
                    _procedureService.Update(id, procedure);
                    return Ok();
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(validationResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedure(int id)
        {
            try
            {
                await _procedureService.DeleteAsync(id);
                return Ok($"{nameof(Procedure)} {EntityHasBeenDeleted}");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProcedures([FromQuery(Name = "ids")] IList<int> ids)
        {
            try
            {
                await _procedureService.DeleteRangeAsync(ids);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}