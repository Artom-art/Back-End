namespace ScrumBoardLibrary
{
    public interface IBoard
    {
        void AddColumn(string columnName);
        void AddTask(ITask task);
        void MoveTask(IColumn columnFrom, IColumn columnTo, ITask task);
    }
}
