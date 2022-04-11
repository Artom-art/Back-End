using System.Collections.Generic;

namespace ScrumBoardLibrary
{
    public class Board : IBoard
    {
        private string _name;
        private List<IColumn> _columns;

        public string Name => _name;
        public List<IColumn> Columns => _columns;

        public Board(string name)
        {
            _name = name;
            _columns = new List<IColumn>();
        }

        public void AddColumn(string columnName)
        {
            if (_columns.Count < 10)
            {
                IColumn newColumn = new Column(columnName);
                _columns.Add(newColumn);
            }
        }

        public void AddTask(ITask task)
        {
            IColumn column = _columns[0];    
            column.AddTask(task);
        }

        public void MoveTask(IColumn columnFrom, IColumn columnTo, ITask task)
        {
            columnFrom.DeleteTask(task);
            columnTo.AddTask(task);
        }

    }
}
