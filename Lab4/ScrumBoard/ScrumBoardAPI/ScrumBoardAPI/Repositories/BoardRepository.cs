using Microsoft.Extensions.Caching.Memory;
using ScrumBoardAPI.Models;
using ScrumBoardAPI.DTO;

namespace ScrumBoardAPI.Repositories
{
    public class BoardRepository
    {
        private const string BOARDS_KEY = "boards";
        private readonly IMemoryCache _memoryCache;
        
        public BoardRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddBoard(Board board)
        {
            List<Board> boards = this.GetBoards();

            if (boards.FindIndex(x => x.GetUUID() == board.GetUUID()) == -1 && board.GetName() != null)
            {
                boards.Add(board);

                this.SaveBoards(boards);
            }          
        }

        public void RemoveBoard(string boardUUID)
        {
            List<Board> boards = this.GetBoards();

            int index = boards.FindIndex(x => x.GetUUID() == boardUUID);
            if (index == -1)
            {
                throw new ArgumentException("Board not found");
            }

            boards.RemoveAt(index);
            this.SaveBoards(boards);
        }

        public void SaveBoard(Board board)
        {
            List<Board> boards = this.GetBoards();

            int index = boards.FindIndex(x => x.GetUUID() == board.GetUUID());
            if (index == -1)
            {
                throw new ArgumentException("Board not found");
            }

            boards[index] = board;
            this.SaveBoards(boards);
        }

        public void SaveBoards(List<Board> boards)
        {
            _memoryCache.Set(BOARDS_KEY, boards);
        }

        public List<Board> GetBoards()
        {
            List<Board> boards = _memoryCache.Get<List<Board>>(BOARDS_KEY);

            if (boards == null)
            {
                boards = new List<Board>();
            }

            return boards;
        }

        public Board? GetBoard(string boardUUID)
        {
            return this.GetBoards().Find(x => x.GetUUID() == boardUUID);
        }
    }
}