using RealEstateDapperApi.Dtos.ProductImageDtos;

namespace RealEstateDapperApi.Repositories.ProductImageRepository
{
    public interface IProductImageRepository
    {
        Task CreateProductImage(CreateProductImageDto createProductImageDto);
        Task<List<ResultGetProductImageByIdDto>> GetProductImageByProductId(int id);
    }
}
