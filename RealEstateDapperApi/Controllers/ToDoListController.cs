using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ToDoListDtos;
using RealEstateDapperApi.Repositories.EmployeeRepository;
using RealEstateDapperApi.Repositories.ToDoListRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoList()
        {
            var values = await _toDoListRepository.GetToDoListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo(CreateToDoListDto createToDoListDto)
        {
            _toDoListRepository.CreateToDo(createToDoListDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            _toDoListRepository.DeleteToDo(id);
            return Ok("👍");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDo(UpdateToDoListDto updateToDoListDto)
        {
            _toDoListRepository.UpdateToDo(updateToDoListDto);
            return Ok("👍");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdToDo(int id)
        {
            var value = await _toDoListRepository.GetToDo(id);
            return Ok(value);
        }
    }
}
