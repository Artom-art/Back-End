namespace ScrumBoardLibrary
{
    public interface IColumn
    {
        string ColumnName { get; }
        void AddTask(ITask task);
        void DeleteTask(ITask task);
        void ChangeName(string newName);
    }
}
