namespace ScrumBoardLibrary
{
    public class Task : ITask
    {
        private string _name;
        public string Name => _name;
        public string description;
        public int priority;

        public Task(string taskName, string descr, int prior)
        {
            _name = taskName;
            description = descr;
            priority = prior;
        }

        public void ChangeName(string newName)
        {
            _name = newName;
        }
    }
}
