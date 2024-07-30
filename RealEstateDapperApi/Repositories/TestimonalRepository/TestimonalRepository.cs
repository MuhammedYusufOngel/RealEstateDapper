using Dapper;
using RealEstateDapperApi.Dtos.ServiceDtos;
using RealEstateDapperApi.Dtos.TestimonalDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.TestimonalRepository
{
    public class TestimonalRepository : ITestimonalRepository
    {
        private readonly Context _context;

        public TestimonalRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonalDto>> GetAllTestimonalsAsync()
        {
            string query = "Select *from Testimonals";
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultTestimonalDto>(query);
                return values.ToList();
            }
        }
    }
}
