using RealEstateDapperApi.Dtos.AmenityDtos;
using RealEstateDapperApi.Dtos.ProductDetailDtos;
using RealEstateDapperApi.Dtos.ProductDtos;

namespace RealEstateDapperApi.Repositories.ProductDetailRepository
{
    public interface IProductDetailRepository
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetails();
        Task CreateProductDetail(CreateProductDetailDto createProductDetailDto);
        Task DeleteProductDetail(int id);
        Task UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto);
        Task<ResultGetProductDetailByIdDto> GetProductDetailById(int id);
        Task<GetByIdProductDetailForUpdateDto> GetByIdProductDetailForUpdate(int id);
    }
}
