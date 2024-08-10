using RealEstateDapperApi.Models.DapperContext;
using RealEstateDapperApi.Repositories.AboutDetailRepository;
using RealEstateDapperApi.Repositories.AmenityRepository;
using RealEstateDapperApi.Repositories.BottomGridRepository;
using RealEstateDapperApi.Repositories.CategoryRepository;
using RealEstateDapperApi.Repositories.ContactRepository;
using RealEstateDapperApi.Repositories.EmployeeRepository;
using RealEstateDapperApi.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository;
using RealEstateDapperApi.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository;
using RealEstateDapperApi.Repositories.MessageRepository;
using RealEstateDapperApi.Repositories.PopularLocationRepository;
using RealEstateDapperApi.Repositories.ProductDetailRepository;
using RealEstateDapperApi.Repositories.ProductImageRepository;
using RealEstateDapperApi.Repositories.ProductRepository;
using RealEstateDapperApi.Repositories.ServiceRepository;
using RealEstateDapperApi.Repositories.StatisticsRepository;
using RealEstateDapperApi.Repositories.TestimonalRepository;
using RealEstateDapperApi.Repositories.ToDoListRepository;

namespace RealEstateDapperApi.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection Services)
        {

            Services.AddTransient<Context>();
            Services.AddTransient<ICategoryRepository, CategoryRepository>();
            Services.AddTransient<IProductRepository, ProductRepository>();
            Services.AddTransient<IAboutDetailRepository, AboutDetailRepository>();
            Services.AddTransient<IServiceRepository, ServiceRepository>();
            Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            Services.AddTransient<ITestimonalRepository, TestimonalRepository>();
            Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            Services.AddTransient<IContactRepository, ContactRepository>();
            Services.AddTransient<IToDoListRepository, ToDoListRepository>();
            Services.AddTransient<IStatisticRepository, StatisticRepository>();
            Services.AddTransient<IChartRepository, ChartRepository>();
            Services.AddTransient<IMessageRepository, MessageRepository>();
            Services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
            Services.AddTransient<IProductImageRepository, ProductImageRepository>();
            Services.AddTransient<IAmenityRepository, AmenityRepository>();
        }
    }
}
