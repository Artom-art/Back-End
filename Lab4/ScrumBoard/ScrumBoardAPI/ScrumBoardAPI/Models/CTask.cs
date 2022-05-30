namespace ScrumBoardAPI.Models
{
    public enum Priority
    {
        Low = 0,
        Medium,
        High
    }

    public class CTask
    {
        private string _uuid;
        private string _name;
        private string _description;
        private Priority _priority;

        public CTask(string name, string description, Priority priority, string uuid = "")
        {
            if (uuid == "")
            {
                _uuid = Guid.NewGuid().ToString();
            }
            else
            {
                _uuid = uuid;
            }

            _name = name;
            _description = description;
            _priority = priority;
        }

        public string GetUUID()
        {
            return _uuid;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public Priority GetPriority()
        {
            return _priority;
        }

        public CTask SetName(string name)
        {
            _name = name;

            return this;
        }

        public CTask SetDescription(string description)
        {
            _description = description;

            return this;
        }

        public CTask SetPriority(Priority priority)
        {
            _priority = priority;
            
            return this;
        }
    }
}
