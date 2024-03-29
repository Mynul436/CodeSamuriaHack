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

            query = query.OrderByDescending(x => x.completion).ToList();
            return Ok(query);
        }

        [HttpGet("get-project-ratting")]
        public async Task<IActionResult> getProjectRatting(string project_id)
        {
            var query = await _unitOfWork.RattingRepository.FindOneAsync(filter => filter.project_id == project_id);
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


        
        [HttpPost("add-feedback")]
        [Authorize(Roles = "CITIZEN")]
        public async Task<IActionResult> AddRattingAndFeedBack(AddFeedBackRatting ratting)
        {
            if(!await _unitOfWork.ProjectRepository.isExitAsync(filter => filter.project_id == ratting.project_id))
                return BadRequest();
                
            var _ratting = new ProjectRatting();
            _ratting.project_id = ratting.project_id;
            _ratting.feedback = ratting.feedback;
            _ratting.ratting = ratting.ratting;

            _unitOfWork.RattingRepository.AddAsync(_ratting);
            await _unitOfWork.CommitAsync();

            return Ok();
        }
   

        [HttpGet("get-executing-project")]
        [Authorize(Roles ="EXEC")]
        public async Task<IActionResult> GetExecutingProject(string code)
        {
            var query = await _unitOfWork.ProjectRepository.FindAsync(filter => filter.exec == code);

            query = query.OrderByDescending(x => x.completion).ToList();
            return Ok(query);
        }



        [HttpGet("proposed-approved")]
        [Authorize(Roles = "APPROV")]
        public async Task<IActionResult> GetProposedProjectList(string code)
        {
            var query = await _unitOfWork.ProjectRepository.GetProposalList(code);
            return Ok(query);
        }


        [HttpPost("approved-project")]
        [Authorize(Roles = "APPROV")]
        public async Task<IActionResult> ApprovedProject(ApprovedProjectDto approved)
        {
            if(!await _unitOfWork.ProposalRepository.isExitAsync(filter => filter.project_id == approved.project_id))
                return BadRequest();

            var pro = await _unitOfWork.ProposalRepository.FindOneAsync(filter => filter.project_id == approved.project_id);

            var project = _mapper.Map<Project>(pro);
            project.cost = approved.actual_cost;
            project.start_date = approved.startdate;
            project.completion = approved.completion;


            _unitOfWork.ProposalRepository.RemoveAsync(pro);
            _unitOfWork.ProjectRepository.AddAsync(project);

            await _unitOfWork.CommitAsync();

            return Ok();
        }

        

   
    }
}