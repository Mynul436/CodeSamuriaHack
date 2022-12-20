using System.Globalization;
using api.Dto;
using AutoMapper;
using core.Entities.Model;
using core.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Users
{
     [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("citizen")]
        public async Task<IActionResult> GetProjectListCitizen([FromQuery]CitizenGetProjectDto citizenGetProject)
        {
            var query = await _unitOfWork.ProjectRepository.GetAllAsync();

            var result = new List<Project>();
            return Ok(query);
        }
  

        [HttpPost("Add-proposal")]
        [Authorize(Roles = "EXEC")]
        public async Task<IActionResult> AddProjectProposal(AddProjectProposal projectProposal)
        {
            var proposal = _mapper.Map<Proposals>(projectProposal);
            proposal.proposal_date = DateTime.Now;
            proposal.project_id = Guid.NewGuid().ToString();

            _unitOfWork.ProposalRepository.AddAsync(proposal);
            await _unitOfWork.CommitAsync();
            return Ok("Add new proposal");
        }

        [HttpPut("udpate-proposal")]
        [Authorize(Roles ="EXEC")]
        public async Task<IActionResult> UpdateProjectProposal(Proposals proposals)
        {
            var prosal = await _unitOfWork.ProposalRepository.FindOneAsync(filter => filter.project_id == proposals.project_id);

            if(prosal == null) return BadRequest();

            var _prosal = _mapper.Map<Proposals>(proposals);
            _unitOfWork.ProposalRepository.UpdateAsync(proposals);
            return Ok();
        }   

        [HttpGet("get-proposal")]
        [Authorize(Roles ="EXEC")]
        public async Task<IActionResult> GetProposedProject(string code)
        {
            var query = await _unitOfWork.ProjectRepository.getProposedProject(code);
            return Ok(query);
        }


       // [HttpGet("get-projects")]
      //  [Authorize(Roles ="EXEC")]
       // public async Task
    }
}