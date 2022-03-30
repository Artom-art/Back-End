using System.Collections.Generic;

namespace ScrumBoardLibrary
{
    public class Column : IColumn
    {
        private string _columnName;
        private List<ITask> tasks;

        public string ColumnName => _columnName;
        public Column(string name)
        {
            _columnName = name;
        }

        public void ChangeName(string newName)
        {
            _columnName = newName;
        }

        public void AddTask(ITask task)
        {
            tasks.Add(task);
        }

        public ITask GetTask(string taskName)
        {
            return tasks.Find(x => x.Name == taskName);
        }

        public void DeleteTask(ITask task)
        {
            tasks.Remove(task);
        }

        public void Clear()
        {
            tasks.Clear();
        }

    }
}
