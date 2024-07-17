using RealEstateDapperApi.Dtos.CategoryDtos;

namespace RealEstateDapperApi.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategorySync();
        void CreateCategory(CreateCategoryDto createCategoryDto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<GetByIdCategoryDto> GetCategory(int id);
    }
}
