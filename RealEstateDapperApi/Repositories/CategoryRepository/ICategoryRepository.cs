using RealEstateDapperApi.Dtos.CategoryDtos;

namespace RealEstateDapperApi.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategories();
        Task CreateCategory(CreateCategoryDto createCategoryDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<GetByIdCategoryDto> GetCategory(int id);
    }
}
