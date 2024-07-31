using RealEstateDapperApi.Dtos.ToDoListDtos;

namespace RealEstateDapperApi.Repositories.ToDoListRepository
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetToDoListAsync();
        void CreateToDo(CreateToDoListDto createToDoListDto);
        void DeleteToDo(int id);
        void UpdateToDo(UpdateToDoListDto updateToDoListDto);
        Task<GetByIdToDoListDto> GetToDo(int id);
    }
}
