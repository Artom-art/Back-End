using System.Collections.Generic;

namespace ScrumBoardLibrary
{
    public interface IColumn
    {
        string ColumnName { get; }
        void AddTask(ITask task);
        void DeleteTask(ITask task);
        void ChangeName(string newName);
        void Clear();
        ITask GetTask(string name);
        List<ITask> GetAllTasks();
    }
}
