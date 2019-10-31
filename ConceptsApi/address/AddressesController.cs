using ConceptsApi.address.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConceptsApi.address
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private IAddressRepository addressRepository;

        public AddressesController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get()
        {
            return addressRepository.getAddresses();
        }

        [HttpGet("{id}")]
        public ActionResult<Address> Get(int id)
        {
            return addressRepository.getAddresses(id);
        }

        [HttpPost]
        public ActionResult<Address> Post([FromBody] Address value)
        {
            Address created = addressRepository.createAddress(value);

            return CreatedAtAction(nameof(Get), new { id = created.AddressID });
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Address value)
        {
            addressRepository.updateAddress(id, value);
        }
    }
}
