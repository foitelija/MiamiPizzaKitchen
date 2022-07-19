namespace BlazorMiamiPizza.Server.Services.AddressService
{
    public interface IAddressService
    {
        //return(get) Address
        Task<ServiceResponse<Address>> GetAddress();
        //Add or Update Method
        Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address);

    }
}
