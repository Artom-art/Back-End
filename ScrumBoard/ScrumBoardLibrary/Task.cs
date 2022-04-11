namespace ScrumBoardLibrary
{
    public class Task : ITask
    {
        private string _name;
        private string _description;
        private int _priority;
        public string Name => _name;
        public string Description => _description;
        public int Priority => _priority;

        public Task(string taskName, string descr, int prior)
        {
            _name = taskName;
            _description = descr;
            _priority = prior;
        }

        public void ChangeName(string newName)
        {
            _name = newName;
        }

        public void ChangePriority(int newPriority)
        {
            _priority = newPriority;
        }

        public void ChangeDescription(string newDescription)
        {
            _description = newDescription;
        }
    }
}
