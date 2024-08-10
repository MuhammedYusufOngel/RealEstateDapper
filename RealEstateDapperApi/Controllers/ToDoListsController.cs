using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ToDoListDtos;
using RealEstateDapperApi.Repositories.ToDoListRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListsController(IToDoListRepository toDoListRepository)
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
            await _toDoListRepository.CreateToDo(createToDoListDto);
            return Ok("👍");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            await _toDoListRepository.DeleteToDo(id);
            return Ok("👍");
        }

        [HttpGet("UpdateToDoStatusFalse")]
        public async Task<IActionResult> UpdateToDoStatusFalse(int id)
        {
            await _toDoListRepository.UpdateToDoStatusFalse(id);
            return Ok("👍");
        }

        [HttpGet("UpdateToDoStatusTrue")]
        public async Task<IActionResult> UpdateToDoStatusTrue(int id)
        {
            await _toDoListRepository.UpdateToDoStatusTrue(id);
            return Ok("👍");
        }
    }
}
