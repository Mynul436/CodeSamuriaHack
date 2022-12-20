 using System.Security.Cryptography;
using System.Text;
using api.Dto;
using api.Helper;
using AutoMapper;
using core.Entities;
using core.Entities.Model;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, IRepository<User> userRepository){
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }   


        [HttpPost("Citizen-reg")]
        public async Task<IActionResult> CitizenRegistration(CitizenRegDto citizen)
        {
            
            if(await _unitOfWork.CitizenRepository.isExitAsync(filter => filter.email == citizen.email) 
            
                || 

                await _unitOfWork.AgencyRepository.isExitAsync(filter => filter.email == citizen.email)
                ) 
                return BadRequest("User already exit");

            var _citizen = _mapper.Map<Citizen>(citizen);

            _unitOfWork.CitizenRepository.AddAsync(_citizen);
           
            
            var res = new LoginResDto();
            res.Id = _citizen.Id.ToString();
            res.name = _citizen.name;
            res.role = _citizen.role;
            res.token = _tokenService.CreateToken(_citizen.role).Item1;
            await _unitOfWork.CommitAsync();
            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<IActionResult> CitizenLogin(LoginDto login)
        {
            var citizen = await _unitOfWork.CitizenRepository.FindOneAsync(filter => filter.email == login.email);

            var agency = await _unitOfWork.AgencyRepository.FindOneAsync(filter => filter.email == login.email);

            if(citizen == null && agency == null) return BadRequest("Not Valid Email");

           
            if(citizen != null &&  citizen.password == login.password){
                var res = new LoginResDto();
                res.Id = citizen.Id.ToString();
                res.name = citizen.name;
                res.role = citizen.role;
                res.token = _tokenService.CreateToken(citizen.role).Item1;
                return Ok(res);
            }

            if(agency !=  null && agency.password == login.password)
            {
                var res = new LoginResDto();
                res.code = agency.code;
                res.Id = agency.Id.ToString();
                res.name = agency.name;
                res.role = agency.type;
                res.token = _tokenService.CreateToken(agency.type).Item1;
                return Ok(res);
            }

            return BadRequest("Wrong Password");
        }


        [HttpGet("agency-code-validation")]
        public async Task<IActionResult> AgencyCodeValidation(string code)
        {
            if(!await _unitOfWork.AgencyRepository.isExitAsync(filter => filter.code == code))
                return Ok(true);
            return BadRequest();
        }
        

        [HttpPost("Agency-reg")]
        public async Task<IActionResult> AgencyRegistration(AgencyRegDto agencyRegDto)
        {

            if( await _unitOfWork.AgencyRepository.isExitAsync(filter => filter.email == agencyRegDto.email)

                || 

                await _unitOfWork.CitizenRepository.isExitAsync(filter => filter.email == agencyRegDto.email))

                return BadRequest("Email already Exits");

            var agency = _mapper.Map<core.Entities.Model.Agency>(agencyRegDto);
            agency.code = RadomString.RandomString(4);

            var res = new LoginResDto();
           
            res.Id = agency.Id.ToString();
            res.name = agency.name;
            res.role = agency.type;
            res.token = _tokenService.CreateToken(agency.type).Item1;

            return Ok(res);

        }
        // [HttpPost]
        // public async Task<IActionResult> Register(Signup signup)
        // {
        //     Console.WriteLine(signup.Name);   
        //     if(!ModelState.IsValid) return BadRequest();

           
        //     if(await _unitOfWork.UserRepository.isExitAsync(filter => filter.Email == signup.Email)) 
        //         return BadRequest("Email_Already_Used");
            
        //     if(await _unitOfWork.UserRepository.isExitAsync(filter => filter.Phone == signup.Phone))
        //         return BadRequest("Phone_Already_Used");


        //   //  if(await _unitOfWork.UserRepository.isExitAsync(filter => filter.UserName == signup.UserName)) return BadRequest(new Response<string>("Already Exit username"));

        //     var user = _mapper.Map<User>(signup);
            
        //     using var hmac = new HMACSHA512();
        //     user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(signup.Password));
        //     user.PasswordSalt = hmac.Key;
        
        //     _unitOfWork.UserRepository.AddAsync(user);
        //     await _unitOfWork.CommitAsync();

        //     var res = _mapper.Map<MemberDto>(user);
        //     res.Token = _tokenService.CreateToken(user).Item1;

        //     return Ok(new Response<MemberDto>(res));
        // }
    

        // [HttpPost]
        // [Route("login")]
        // public async Task<IActionResult> Login(Login login)
        // {
        //     if(!ModelState.IsValid){
        //         return BadRequest(new Response<String>("Wrong Formate"));
        //     }
        //     if(!await _unitOfWork.UserRepository.isExitAsync(filter => filter.Email == login.Email)) 
        //         return BadRequest();

        //     var user = await _unitOfWork.UserRepository.FindOneAsync(filter => filter.Email == login.Email);
            
        //     using var hmac = new HMACSHA512(user.PasswordSalt);
        //     var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

        //     for(int i = 0; i < computedHash.Length; i++){
        //         if(computedHash[i] != user.PasswordHash[i]){
        //             return BadRequest(new Response<String>("Wrong Password"));
        //         }
        //     }

        //     var res = _mapper.Map<MemberDto>(user);
        //     res.Token = _tokenService.CreateToken(user).Item1;
        //     return Ok(new Response<MemberDto>(res));

        // }

    
    }
}