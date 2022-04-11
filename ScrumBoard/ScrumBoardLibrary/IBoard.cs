using System.Collections.Generic;

namespace ScrumBoardLibrary
{
    public interface IBoard
    {
        string Name { get; }
        List<IColumn> Columns { get; }
        void AddColumn(string columnName);
        void AddTask(ITask task);
        void MoveTask(IColumn columnFrom, IColumn columnTo, ITask task);
    }
}
