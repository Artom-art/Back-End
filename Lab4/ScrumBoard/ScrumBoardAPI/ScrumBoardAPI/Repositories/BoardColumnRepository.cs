using ScrumBoardAPI.Models;
using ScrumBoardAPI.DTO;

namespace ScrumBoardAPI.Repositories
{
    public class BoardColumnRepository
    {
        private BoardRepository _boardRepository;

        public BoardColumnRepository(BoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public BoardRepository GetBoardRepository()
        {
            return _boardRepository;
        }

        public List<BoardColumn> GetColumns(string boardUUID)
        {
            Board? board = _boardRepository.GetBoard(boardUUID);

            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            return board.GetColumns();
        }

        public BoardColumn? GetColumn(string boardUUID, string columnUUID)
        {
            List<BoardColumn> columns = this.GetColumns(boardUUID);

            return columns.Find(x => x.GetUUID() == columnUUID);
        }

        public void AddColumn(string boardUUID, BoardColumn column)
        {
            Board? board = _boardRepository.GetBoard(boardUUID);

            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            if (board.GetColumns().FindIndex(x => x.GetUUID() == column.GetUUID()) == -1 && column.GetName() != null)
            {
                board.AddColumn(column);
            }

            _boardRepository.SaveBoard(board);
        }

        public void UpdateColumn(string boardUUID, BoardColumn column)
        {
            Board? board = _boardRepository.GetBoard(boardUUID);
            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            List<BoardColumn> columns = board.GetColumns();

            int columnIndex = columns.FindIndex(x => x.GetUUID() == column.GetUUID());
            if (columnIndex == -1)
            {
                throw new ArgumentException("Column not found");
            }
            
            columns[columnIndex] = column;

            board.SetColumns(columns);

            _boardRepository.SaveBoard(board);
        }

        public void RemoveColumn(string boardUUID, string columnUUID)
        {
            Board? board = _boardRepository.GetBoard(boardUUID);
            if (board == null)
            {
                throw new ArgumentException("Board not found");
            }

            board.RemoveColumn(columnUUID);

            _boardRepository.SaveBoard(board);
        }
    }
}
