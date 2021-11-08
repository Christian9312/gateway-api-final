using AutoMapper;
using gateway_api_final.Contracts;
using gateway_api_final.Dto;
using gateway_api_final.Entities.DataTransferObjects;
using gateway_api_final.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IRepositoryWrapper repoWrapper;
        private readonly IMapper mapper;
        private readonly ILoggerManager _logger;

        public GatewayController(IRepositoryWrapper repoWrapper, IMapper mapper, ILoggerManager logger)
        {
            this.repoWrapper = repoWrapper;
            this.mapper = mapper;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetGateways()
        {
            _logger.LogInfo("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");
            _logger.LogWarn("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");
            var gateways = await repoWrapper.Gateway.GetAllGateways();
            var mappedGateway = mapper.Map<IEnumerable<GatewayDetailedDto>>(gateways);
            return Ok(mappedGateway);
        }

        [HttpGet("{id}", Name = "GatewayById")]
        public async Task<ActionResult<GatewayDetailedDto>> GetGatewayById(string id)
        {
            var gateway = await repoWrapper.Gateway.GetGatewayById(id);
            if (gateway == null)
                return NotFound();
            var mappedGateway = mapper.Map<GatewayDetailedDto>(gateway);
            return Ok(mappedGateway);
        }

        [HttpPost(Name = "GatewayCreation")]
        public async Task<ActionResult> CreateGateway([FromBody] GatewayDto gatewayDto)
        {
            if (gatewayDto == null)
            {
                return BadRequest("Gateway object is null");
            }
            if (!ModelState.IsValid)
            {

                return BadRequest("Invalid model object");
            }

            var gatewayEntity = mapper.Map<Gateway>(gatewayDto);
            repoWrapper.Gateway.Create(gatewayEntity);
            var result = await repoWrapper.SaveAsync();

            if (!result.Success)
                return BadRequest(result.Message);

            var gatewayResult = mapper.Map<Gateway, GatewayDetailedDto>(gatewayEntity);

            return CreatedAtRoute("GatewayById", new { id = gatewayEntity.SerialNumber }, gatewayResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGateway(string id, [FromBody] GatewayDto gatewayDto)
        {
            if (gatewayDto == null)
            {
                return BadRequest("Gateway object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var gatewayEntity = await repoWrapper.Gateway.GetGatewayById(id);

            if (gatewayEntity == null)
                return NotFound();

            mapper.Map(gatewayDto, gatewayEntity);

            repoWrapper.Gateway.Update(gatewayEntity);
            var response = await repoWrapper.SaveAsync();
            if (!response.Success)
                return BadRequest(response.Message);

            var gatewayResult = mapper.Map<Gateway, GatewayDetailedDto>(gatewayEntity);

            return Ok(gatewayResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGateway(string id)
        {
            var gatewayEntity = await repoWrapper.Gateway.GetGatewayById(id);
            if (gatewayEntity == null)
                return NotFound();

            var peripheralsInGateway = await repoWrapper.Peripheral.GetPeripheralByGateways(id);
            if (peripheralsInGateway.Any())
                return BadRequest("Cannot delete gateway. It has related peripherals. Delete those peripherals first");

            repoWrapper.Gateway.Delete(gatewayEntity);
            var response = await repoWrapper.SaveAsync();
            if (!response.Success)
                return BadRequest(response.Message);

            var gatewayResult = mapper.Map<Gateway, GatewayDetailedDto>(gatewayEntity);

            return Ok(gatewayResult);
        }
    }
}
