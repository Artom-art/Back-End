using ScrumBoardAPI.DTO;

namespace ScrumBoardAPI.Models
{
    public class BoardColumn
    {
        private string _uuid;
        private string _name;
        private List<CTask> _tasks;

        public BoardColumn(string name)
        {
            _uuid = Guid.NewGuid().ToString();
            _name = name;
            _tasks = new List<CTask>();
        }

        public BoardColumn(ColumnDTO column)
        {
            _uuid = column.UUID;
            _name = column.Name;
            _tasks = new List<CTask>();
        }

        public string GetUUID()
        {
            return _uuid;
        }

        public string GetName()
        {
            return _name;
        }

        public CTask? GetTask(string taskUUID)
        {
            return _tasks.Find(x => x.GetUUID() == taskUUID);
        }

        public List<CTask> GetTasks()
        {
            return _tasks;
        }

        public BoardColumn SetName(string name)
        {
            _name = name;

            return this;
        }

        public BoardColumn SetTasks(List<CTask> tasks)
        {
            _tasks = tasks;

            return this;
        }

        public BoardColumn AddTask(CTask task)
        {
            if (this.GetTask(task.GetUUID()) == null)
            {
                _tasks.Add(task);
            }

            return this;
        }

        public BoardColumn RemoveTask(string taskUUID)
        {
            int index = _tasks.FindIndex(x => x.GetUUID() == taskUUID);

            _tasks.RemoveAt(index);

            return this;
        }
    }
}
