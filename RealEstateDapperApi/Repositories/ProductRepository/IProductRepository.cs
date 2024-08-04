﻿using RealEstateDapperApi.Dtos.ProductDtos;

namespace RealEstateDapperApi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithAsync();
        void CreateProduct(CreateProductDto createProductDto);
        void ProductDealOfTheDayStatusChangeToTrue(int id);
        void ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync();
        Task<List<GetByIdProductDto>> GetByEmployeeIdProductsAsync(int id);
        Task<List<ResultLast5ProductByEmployeeIdDto>> GetLast5ProductByEmployeeIdAsync(int id);
    }
}
