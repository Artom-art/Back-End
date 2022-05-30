using ScrumBoardAPI.Models;
using ScrumBoardAPI.DTO;

namespace ScrumBoardAPI.Repositories
{
    public class TaskRepository
    {
        private BoardColumnRepository _boardColumnRepository;

        public TaskRepository(BoardColumnRepository boardColumnRepository)
        {
            _boardColumnRepository = boardColumnRepository;
        }

        public List<CTask> GetTasks(string boardUUID, string columnUUID)
        {
            BoardColumn? column = _boardColumnRepository.GetColumn(boardUUID, columnUUID);

            if (column == null)
            {
                throw new ArgumentException("Column not found");
            }

            return column.GetTasks();
        }

        public CTask? GetTask(string boardUUID, string columnUUID, string taskUUID)
        {
            List<CTask> tasks = this.GetTasks(boardUUID, columnUUID);

            return tasks.Find(x => x.GetUUID() == taskUUID);
        }

        public void AddTask(string boardUUID, CTask task)
        {
            BoardRepository boardRepository = _boardColumnRepository.GetBoardRepository();
            Board? board = boardRepository.GetBoard(boardUUID);
            
            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            if (task.GetName() != null && task.GetDescription() != null)
            {
                board.AddTask(task);
            }

            boardRepository.SaveBoard(board);
        }

        public void UpdateTask(string boardUUID, string columnUUID, CTask task)
        {
            BoardRepository boardRepository = _boardColumnRepository.GetBoardRepository();
            Board? board = boardRepository.GetBoard(boardUUID);
            
            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            List<BoardColumn> columns = board.GetColumns();

            int index = columns.FindIndex(x => x.GetUUID() == columnUUID);
            if (index == -1)
            {
                throw new ArgumentException("Column not found");
            }

            List<CTask> tasks = columns[index].GetTasks();

            int taskIndex = tasks.FindIndex(x => x.GetUUID() == task.GetUUID());
            if (taskIndex == -1)
            {
                throw new ArgumentException("Task not found");
            }

            tasks[taskIndex] = task;

            columns[index].SetTasks(tasks);
            board.SetColumns(columns);

            boardRepository.SaveBoard(board);
        }

        public void MoveTask(string boardUUID, string columnFromUUID, string columnToUUID, string taskUUID)
        {
            BoardRepository boardRepository = _boardColumnRepository.GetBoardRepository();
            Board? board = boardRepository.GetBoard(boardUUID);

            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            List<BoardColumn> columns = board.GetColumns();
            int indexFrom = columns.FindIndex(x => x.GetUUID() == columnFromUUID);
            if (indexFrom == -1)
            {
                throw new ArgumentException("Column from not found");
            }
            int indexTo = columns.FindIndex(x => x.GetUUID() == columnToUUID);
            if (indexTo == -1)
            {
                throw new ArgumentException("Column to not found");
            }

            List<CTask> tasks = columns[indexFrom].GetTasks();
            int taskIndex = tasks.FindIndex(x => x.GetUUID() == taskUUID);
            if (taskIndex == -1)
            {
                throw new ArgumentException("Task not found");
            }

            CTask task = tasks[taskIndex];
            columns[indexFrom].RemoveTask(taskUUID);
            columns[indexTo].AddTask(task);

            board.SetColumns(columns);

            boardRepository.SaveBoard(board);
        }

        public void DeleteTask(string boardUUID, string columnUUID, string taskUUID)
        {
            BoardRepository boardRepository = _boardColumnRepository.GetBoardRepository();
            Board? board = boardRepository.GetBoard(boardUUID);

            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }
            
            List<BoardColumn> columns = this._boardColumnRepository.GetColumns(boardUUID);
            int index = columns.FindIndex(x => x.GetUUID() == columnUUID);
            if (index == -1)
            {
                throw new ArgumentException("Column not found");
            }

            columns[index].RemoveTask(taskUUID);
            board.SetColumns(columns);

            boardRepository.SaveBoard(board);
        }
    }
}
