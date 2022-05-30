using ScrumBoardAPI.Models;

namespace ScrumBoardAPI.DTO
{
    public class UpdateCTaskDTO
    {
        public string UUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
    }
}
