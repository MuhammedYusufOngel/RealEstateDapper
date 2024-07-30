namespace RealEstateDapperApi.Repositories.StatisticsRepository
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmantCount();
        string EmployeeNameByMaxProductCount();
        string CategoryNameByMaxProductCount();
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuilding();
        string OldestBuilding();
        int AverageRoomCount();
        int ActiveEmployeeCount();
    }
}
