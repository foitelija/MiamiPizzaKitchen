﻿namespace BlazorMiamiPizza.Server.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        Task<ServiceResponse<List<ProductType>>> GetProductTypes();
    }
}
