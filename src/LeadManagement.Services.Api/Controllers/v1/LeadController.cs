using System.Net;
using FluentValidation.Results;
using LeadManagement.Application.EventSourcedNormalizers.Lead;
using LeadManagement.Application.Interfaces;
using LeadManagement.Application.ViewModels.v1.Lead;
using LeadManagement.Services.Api.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using ProblemDetails = LeadManagement.Services.Api.Models.ProblemDetails;

namespace LeadManagement.Services.Api.Controllers.v1
{
    [Route("api/v1/leads")]
    public class LeadController : MainController
    {
        private readonly ILeadAppService _leadAppService;

        public LeadController(ILeadAppService leadAppService)
        {
            _leadAppService = leadAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LeadViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IEnumerable<LeadViewModel>> Get()
        {
            return await _leadAppService.GetAll();
        }

        [HttpGet("invited")]
        [ProducesResponseType(typeof(IEnumerable<LeadViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IEnumerable<LeadViewModel>> GetAllInvited()
        {
            return await _leadAppService.GetAllInvited();
        }

        [HttpGet("accepted")]
        [ProducesResponseType(typeof(IEnumerable<LeadViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IEnumerable<LeadViewModel>> GetAllAccepted()
        {
            return await _leadAppService.GetAllAccepted();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(LeadViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _leadAppService.GetById(id);
            return result is not LeadViewModel response ? CustomResponse((ValidationResult)result) : CustomResponse(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LeadViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] RegisterNewLeadViewModel leadViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _leadAppService.Register(leadViewModel);
            return result is not LeadViewModel response ? CustomResponse((ValidationResult)result) : CustomResponse(response);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _leadAppService.Remove(id));
        }

        [HttpPatch("{id:guid}/accept")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Accept(Guid id)
        {
            return CustomResponse(await _leadAppService.Accept(id));
        }

        [HttpPatch("{id:guid}/decline")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Decline(Guid id)
        {
            return CustomResponse(await _leadAppService.Decline(id));
        }

        [HttpGet("{id:guid}/history-data")]
        [ProducesResponseType(typeof(IList<LeadHistoryData>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IList<LeadHistoryData>> GetAllHistory(Guid id)
        {
            return await _leadAppService.GetAllHistory(id);
        }
    }
}