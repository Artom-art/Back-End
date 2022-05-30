using ScrumBoardAPI.Models;

namespace ScrumBoardAPI.DTO
{
    public class MoveCTaskDTO
    {
        public string UUID { get; set; }
        public string ColumnFromUUID { get; set; }
        public string ColumnToUUID { get; set; }

    }
}
