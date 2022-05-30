using ScrumBoardAPI.Models;

namespace ScrumBoardAPI.DTO
{
    public class ColumnDTO
    {
        public string UUID { get; set; }
        public string Name { get; set; }

        public ColumnDTO(BoardColumn column)
        {
            UUID = column.GetUUID();
            Name = column.GetName();
        }
    }
}
