using RealEstateDapperApi.Dtos.ToDoListDtos;

namespace RealEstateDapperApi.Repositories.ToDoListRepository
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetToDoListAsync();
        Task CreateToDo(CreateToDoListDto createToDoListDto);
        Task UpdateToDoStatusTrue(int id);
        Task UpdateToDoStatusFalse(int id);
        Task DeleteToDo(int id);
    }
}
