
using api.Dto;
using AutoMapper;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        // private readonly IUnitOfWork _unitOfWork;
        // private readonly IMapper _mapper;
        // public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        // {
        //     _unitOfWork = unitOfWork;
        //     _mapper = mapper;
        // }

        // [HttpPost]
        // public async Task<IActionResult> AddCustomer([FromForm]CustomerDto customerDto)
        // {
        //     if(!ModelState.IsValid) return BadRequest();
            
        //     var customerAddress = new List<CustomerAddress>();
        //     foreach(var addressName in customerDto.Addresss)
        //     {
        //         var add = new CustomerAddress();
        //         add.CusAddress = addressName;
        //         customerAddress.Add(add);
        //     }

        //     var customer = _mapper.Map<Customer>(customerDto);
        //     customer.Country = new Country();
        //     customer.Country.CountryName = customerDto.CountryName;
        //     customer.CustomerAddresses = customerAddress;
        //     customer.CustomerPhoto = await this.GetBytes(customerDto.Photo);
        //     _unitOfWork.Customer.AddAsync(customer);
        //     await _unitOfWork.CommitAsync();

        //     return Ok("Ok");
        // }


        // [HttpGet]
        // public async Task<IActionResult> ListOfCustomerName()
        // {
        //     return Ok(await _unitOfWork.Customer.ListOfCustomerName());
        // }


        // [HttpGet]
        // [Route("{id}")]
        // public async Task<IActionResult> GetUserById(int id)
        // {
        //     if(!await _unitOfWork.Customer.isExitAsync(filter => filter.Id == id)) return BadRequest();
        //     var cus = await _unitOfWork.Customer.GetCustomerById(id);
        //     return Ok(cus);
        // }

        // [HttpPut("{Id}")]
        // public async Task<IActionResult> UpdateCustomer([FromRoute]int Id, [FromForm] CustomerDto customerDto)
        // {
        //     if(!ModelState.IsValid) return BadRequest();
        //      if(!await _unitOfWork.Customer.isExitAsync(filter => filter.Id == Id)) return BadRequest();
            
        //     var customerAddress = new List<CustomerAddress>();
        //     foreach(var addressName in customerDto.Addresss)
        //     {
        //         var add = new CustomerAddress();
        //         add.CusAddress = addressName;
        //         customerAddress.Add(add);
        //     }

        //     var customer = _mapper.Map<Customer>(customerDto);
        //     customer.Country = new Country();
        //     customer.Country.CountryName = customerDto.CountryName;
        //     customer.CustomerAddresses = customerAddress;
        //     customer.CustomerPhoto = await this.GetBytes(customerDto.Photo);

        //     _unitOfWork.Customer.UpdateAsync(customer);
        //     await _unitOfWork.CommitAsync();
        //     return Ok("Ok");
        // }   


        // [HttpDelete("{Id}")]
        // public async Task<IActionResult> DeteleCustomer([FromRoute] int Id)
        // {
        //     if(!await _unitOfWork.Customer.isExitAsync(filter => filter.Id == Id)) return BadRequest();
        //     var entity = await _unitOfWork.Customer.GetByIdAsync(Id);
        //     _unitOfWork.Customer.RemoveAsync(entity);
        //     await _unitOfWork.CommitAsync();
        //     return Ok("Ok");
        // }

        // private  async Task<byte[]> GetBytes(IFormFile formFile)
        // {
        //     await using var memoryStream = new MemoryStream();
        //     await formFile.CopyToAsync(memoryStream);
        //     return memoryStream.ToArray();
        // }
    }
}