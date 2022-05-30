using ScrumBoardAPI.Models;

namespace ScrumBoardAPI.DTO
{
    public class CreateCTaskDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
    }
}
