using Microsoft.AspNetCore.Mvc;
using ScrumBoardAPI.DTO;
using ScrumBoardAPI.Models;
using ScrumBoardAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumBoardAPI.Controllers
{
    [Route("api/boards")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly BoardRepository _boardRepository;
        private readonly BoardColumnRepository _columnRepository;
        private readonly TaskRepository _taskRepository;

        public BoardsController(BoardRepository boardRepository, BoardColumnRepository columnRepository, TaskRepository taskRepository)
        {
            _boardRepository = boardRepository;
            _columnRepository = columnRepository;
            _taskRepository = taskRepository;
        }

        // GET: api/boards
        [HttpGet]
        public IActionResult GetBoards()
        {
            IEnumerable<BoardDTO> boards = _boardRepository.GetBoards().Select(board => new BoardDTO(board));

            return Ok(boards);
        }

        // GET api/boards/{boardUUID}
        [HttpGet("{boardUUID}")]
        public IActionResult GetBoardByUUID(string boardUUID)
        {
            Board? board = _boardRepository.GetBoard(boardUUID);
            
            if (board == null)
            {
                return NotFound();
            }

            return Ok(new BoardDTO(board));
        }

        // POST api/boards
        [HttpPost]
        public IActionResult CreateBoard([FromBody] CreateBoardDTO board)
        {
            _boardRepository.AddBoard(new Board(board.Name));

            return Ok();
        }

        // DELETE api/boards/{boardUUID}
        [HttpDelete("{boardUUID}")]
        public IActionResult DeleteBoard(string boardUUID)
        {
            try
            {
                _boardRepository.RemoveBoard(boardUUID);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }

            return Ok();
        }

        // GET: api/boards/{boardUUID}/columns
        [HttpGet("{boardUUID}/columns")]
        public IActionResult GetColumns(string boardUUID)
        {
            IEnumerable<ColumnDTO> columns;

            try
            {
                columns = _columnRepository.GetColumns(boardUUID).Select(column => new ColumnDTO(column));
            }
            catch
            {
                return NotFound();
            }

            return Ok(columns);
        }

        // GET api/boards/{boardUUID}/columns/{columnUUID}
        [HttpGet("{boardUUID}/columns/{columnUUID}")]
        public IActionResult GetColumn(string boardUUID, string columnUUID)
        {
            try
            {
                BoardColumn? column = _columnRepository.GetColumn(boardUUID, columnUUID);
                if (column == null)
                {
                    return NotFound();
                }

                return Ok(new ColumnDTO(column));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/boards/{boardUUID}/columns
        [HttpPost("{boardUUID}/columns")]
        public IActionResult AddColumn(string boardUUID, [FromBody] CreateBoardColumnDTO column)
        {
            try
            {
                BoardColumn newColumn = new BoardColumn(column.Name);
                _columnRepository.AddColumn(boardUUID, newColumn);
            }
            catch
            {
                return NotFound();
            }
            return Ok();
        }

        // PUT api/boards/{boardUUID}/columns
        [HttpPut("{boardUUID}/columns")]
        public IActionResult UpdateColumn(string boardUUID, [FromBody] UpdateColumnDTO column)
        {
            try
            {
                BoardColumn? boardColumn = _columnRepository.GetColumn(boardUUID, column.UUID);

                if (boardColumn == null)
                {
                    return NotFound();
                }

                boardColumn.SetName(column.Name);
                _columnRepository.UpdateColumn(boardUUID, boardColumn);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/boards/{boardUUID}/columns/{columnUUID}
        [HttpDelete("{boardUUID}/columns/{columnUUID}")]
        public IActionResult DeleteColumn(string boardUUID, string columnUUID)
        {
            try
            {
                _columnRepository.RemoveColumn(boardUUID, columnUUID);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // GET: api/boards/{boardUUID}/columns/{columnsUUID}/tasks
        [HttpGet("{boardUUID}/columns/{columnUUID}/tasks")]
        public IActionResult GetTasks(string boardUUID, string columnUUID)
        {
            try
            {
                IEnumerable<CTaskDTO> tasks = _taskRepository.GetTasks(boardUUID, columnUUID).Select(task => new CTaskDTO(task));

                return Ok(tasks);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/boards/{boardUUID}/columns/{columnUUID}/tasks/{taskUUID}
        [HttpGet("{boardUUID}/columns/{columnUUID}/tasks/{taskUUID}")]
        public IActionResult GetTask(string boardUUID, string columnUUID, string taskUUID)
        {
            try
            {
                CTask? task = _taskRepository.GetTask(boardUUID, columnUUID, taskUUID);

                if (task == null)
                {
                    return NotFound();
                }

                return Ok(new CTaskDTO(task));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/boards/{boardUUID}/tasks
        [HttpPost("{boardUUID}/tasks")]
        public IActionResult AddTask(string boardUUID, [FromBody] CreateCTaskDTO task)
        {
            try
            {
                CTask newTask = new CTask(task.Name, task.Description, task.Priority);

                _taskRepository.AddTask(boardUUID, newTask);
            }
            catch
            {
                return NotFound();
            }

            return Ok();
        }

        // PUT api/boards/{boardUUID}/columns/{columnUUID}/tasks
        [HttpPut("{boardUUID}/columns/{columnUUID}/tasks")]
        public IActionResult UpdateTask(string boardUUID, string columnUUID, [FromBody] UpdateCTaskDTO task)
        {
            try
            {
                CTask? task1 = _taskRepository.GetTask(boardUUID, columnUUID, task.UUID);
                
                if (task1 == null)
                {
                    return NotFound();
                }

                task1.SetName(task.Name);
                task1.SetDescription(task.Description);
                task1.SetPriority(task.Priority);

                _taskRepository.UpdateTask(boardUUID, columnUUID, task1);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/boards/{boardUUID}/columns/{columnUUID}/tasks/{taskUUID}
        [HttpDelete("{boardUUID}/columns/{columnUUID}/tasks/{taskUUID}")]
        public IActionResult DeleteTask(string boardUUID, string columnUUID, string taskUUID)
        {
            try
            {
                _taskRepository.DeleteTask(boardUUID, columnUUID, taskUUID);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{boardUUID}/tasks")]
        public IActionResult MoveTask(string boardUUID, [FromBody] MoveCTaskDTO taskMoveParam)
        {
            try
            {
                _taskRepository.MoveTask(boardUUID, taskMoveParam.ColumnFromUUID, taskMoveParam.ColumnToUUID, taskMoveParam.UUID);
            }
            catch
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
