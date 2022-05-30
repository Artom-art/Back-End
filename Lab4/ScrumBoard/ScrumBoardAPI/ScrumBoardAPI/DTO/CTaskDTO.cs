using ScrumBoardAPI.Models;

namespace ScrumBoardAPI.DTO
{
    public class CTaskDTO
    {
        public string UUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }

        public CTaskDTO(CTask task)
        {
            UUID = task.GetUUID();
            Name = task.GetName();
            Description = task.GetDescription();
            Priority = task.GetPriority();
        }
    }
}
