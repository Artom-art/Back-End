using System.Collections.Generic;

namespace ScrumBoardLibrary
{
    public class Board : IBoard
    {
        private string _name;
        private List<IColumn> columns;

        public Board(string name)
        {
            _name = name;
        }

        public void AddColumn(string columnName)
        {
            if (columns.Count < 10)
            {
                IColumn newColumn = new Column(columnName);
                columns.Add(newColumn);
            }
        }

        public void AddTask(ITask task)
        {
            IColumn column = columns[0];    
            column.AddTask(task);
        }

        public void MoveTask(IColumn columnFrom, IColumn columnTo, ITask task)
        {
            columnFrom.DeleteTask(task);
            columnTo.AddTask(task);
        }

    }
}
