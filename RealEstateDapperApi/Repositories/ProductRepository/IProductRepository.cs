using RealEstateDapperApi.Dtos.ProductDtos;

namespace RealEstateDapperApi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithAsync();
        void CreateProduct(CreateProductDto createProductDto);
    }
}
