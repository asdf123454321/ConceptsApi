using ConceptsApi.address.models;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ConceptsApi.address
{
    public interface IAddressRepository
    {
        Address createAddress(Address address);
        Address getAddresses(int AddressID);
        List<Address> getAddresses();
        void updateAddress(int AddressID, Address address);
        State getStates(int StateID);
        List<State> getStates();
    }

    public class AddressRepository : IAddressRepository
    {
        private IConfiguration configuration;
        private string conceptsConnectionString => configuration.GetConnectionString("concepts");

        public AddressRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Address createAddress(Address address)
        {
            var parameters = new
            {
                address.Street1,
                address.Street2,
                address.City,
                address.StateID,
                address.ZipCode
            };

            return conceptsConnectionString.getObject<Address>(parameters);
        }

        public Address getAddresses(int AddressID)
        {
            var parameters = new { AddressID };

            return conceptsConnectionString.getObject<Address>(parameters);
        }

        public List<Address> getAddresses()
        {
            return conceptsConnectionString.getList<Address>();
        }

        public void updateAddress(int AddressID, Address address)
        {
            var parameters = new
            {
                AddressID,
                address.Street1,
                address.Street2,
                address.City,
                address.StateID,
                address.ZipCode
            };

            conceptsConnectionString.execute(parameters);
        }

        public State getStates(int StateID)
        {
            var parameters = new { StateID };

            return conceptsConnectionString.getObject<State>(parameters);
        }

        public List<State> getStates()
        {
            return conceptsConnectionString.getList<State>();
        }
    }
}
