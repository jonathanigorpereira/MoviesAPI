using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AddressController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;
        public AddressController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("/AddAddress")]
        public IActionResult AddAddress([FromBody] CreateAddressDto createAddressDto)
        {
            Address address = _mapper.Map<Address>(createAddressDto);

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddressById), new { Id = address.Id }, createAddressDto);
        }

        [HttpGet]
        public IEnumerable<ReadAddressDto> RescueAddress()
        {
            return _mapper.Map<List<ReadAddressDto>>(_context.Addresses.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(x => x.Id == id);
            if (address != null)
            {
                ReadAddressDto readAddressDto = _mapper.Map<ReadAddressDto>(address);
                return Ok(readAddressDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDTO updateAddressDTO)
        {
            Address address = _context.Addresses.FirstOrDefault(x => x.Id == id);
            if (address == null) { return NotFound(); }
            _mapper.Map(updateAddressDTO, address);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(x => x.Id == id);
            if (address == null) { return NotFound(); }
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
