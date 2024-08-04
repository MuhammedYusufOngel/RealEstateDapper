﻿namespace RealEstateDapperApi.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository
{
    public interface IStatisticRepository
    {
        int ProductCountByEmployeeId(int id);
        int ProductCountByStatusTrue(int id);
        int ProductCountByStatusFalse(int id);
        int AllProductCount();
    }
}
