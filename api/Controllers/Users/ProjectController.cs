using System.Globalization;
using api.Dto;
using AutoMapper;
using core.Entities.Model;
using core.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
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
            // foreach(var project in query)
            // {
            //     double distance =Math.Sqrt((project.latitude - citizenGetProject.latitude) * (project.latitude - citizenGetProject.latitude) + (project.longitude-citizenGetProject.logitude)*(project.longitude - citizenGetProject.logitude));

            //     if(distance <= citizenGetProject.radious){
            //         result.Add(project);
            //     }
            // }
    
            return Ok(query);
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectList()
        {
            // var projects = await _unitOfWork.ProjectRepository.GetAllAsync();

            // foreach(var project in projects)
            // {
            //    var locations = await _unitOfWork.LocationRepository.FindAsync(filter => filter.ProjectId== project.Id);
            //    foreach(var loc in locations)
            //    {
            //     var _loc = new Location();
                
            //     _loc.Latitude = loc.Latitude;
            //     _loc.Logitude = loc.Logitude;

            //     if(project.Locations.Any(filter => filter.Latitude == _loc.Latitude && filter.Logitude == _loc.Logitude)){
            //         continue;
            //     }
            //     project.Locations.Add(_loc);
            //    }


            //    var affiliated_agency = await _unitOfWork.AffiliatedAgencyRepository.FindAsync(filter => filter.ProjectId == project.Id);
            //    foreach(var aff in affiliated_agency)
            //    {
            //     var _aff = new AffiliatedAgency();
            //     _aff.Name = aff.Name;

            //     if(project.AffiliatedAgencies.Any(filter => filter.Name == _aff.Name)) continue;
            //     project.AffiliatedAgencies.Add(_aff);
            //    }

            //    var category = await _unitOfWork.CategoryRepository.FindOneAsync(filter => filter.ProjectId == project.Id);
            //    project.Category = category;
            // }

            // var location = await _unitOfWork.LocationRepository.FindAsync(filter => filter.ProjectId==13);
            
            // return Ok(_mapper.Map<List<ProjectViewDto>>(projects));

            return Ok();


        }
    }
}