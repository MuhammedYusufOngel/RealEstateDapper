using RealEstateDapperApi.Dtos.ProductDtos;

namespace RealEstateDapperApi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithAsync();
        Task CreateProduct(CreateProductDto createProductDto);
        Task DeleteProduct(int id);
        Task UpdateProduct(UpdateProductDto updateProductDto);
        Task<GetByIdProductForUpdateDto> GetByIdProduct(int id);
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task ProductStatusChangeToFalse(int id);
        Task ProductStatusChangeToTrue(int id);
        Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync();
        Task<List<GetByIdProductDto>> GetByEmployeeIdProductsTrueAsync(int id);
        Task<List<GetByIdProductDto>> GetByEmployeeIdProductsFalseAsync(int id);
        Task<List<ResultLast5ProductByEmployeeIdDto>> GetLast5ProductByEmployeeIdAsync(int id);
        Task<List<ResultLast3ProductDto>> GetLast3ProductAsync();
        Task<List<ResultProductWithSearchDto>> GetResultProductWithSearch(string searchKeyValue, int categoryId, string City);
        Task<List<ResultProductWithSearchDto>> GetResultProductWithSearch(int categoryId, string City);
        Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync();

        Task<ResultLastProductDto> GetLastProduct();
    }
}
