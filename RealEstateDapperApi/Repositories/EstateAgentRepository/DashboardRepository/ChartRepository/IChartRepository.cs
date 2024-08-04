using RealEstateDapperApi.Dtos.ChartDtos;

namespace RealEstateDapperApi.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository
{
    public interface IChartRepository
    {
        Task<List<ResultChartDto>> Get5CityForChart();
    }
}
