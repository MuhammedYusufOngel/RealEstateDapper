using RealEstateDapperApi.Dtos.TestimonalDtos;

namespace RealEstateDapperApi.Repositories.TestimonalRepository
{
    public interface ITestimonalRepository
    {
        Task<List<ResultTestimonalDto>> GetAllTestimonalsAsync();
    }
}
