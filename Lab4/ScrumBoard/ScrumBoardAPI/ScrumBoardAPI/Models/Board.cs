namespace ScrumBoardAPI.Models
{
    public class Board 
    {
        private string _uuid;
        private string _name;
        private List<BoardColumn> _columns;

        public Board(string name)
        {
            _uuid = Guid.NewGuid().ToString();
            _name = name;
            _columns = new List<BoardColumn>();
        }

        public string GetUUID()
        {
            return _uuid;
        }

        public string GetName()
        {
            return _name;
        }

        public BoardColumn? GetColumn(string columnUUID)
        {
            return _columns.Find(x => x.GetUUID() == columnUUID);
        }

        public List<BoardColumn> GetColumns()
        {
            return _columns;
        }

        public Board AddColumn(BoardColumn column)
        {
            if (this.GetColumn(column.GetUUID()) == null && this.GetColumns().Count() < 10)
            {
                _columns.Add(column);
            }

            return this;
        }

        public Board SetColumns(List<BoardColumn> columns)
        {
            _columns = columns;
            return this;
        }

        public Board RemoveColumn(string columnUUID)
        {
            int index = _columns.FindIndex(x => x.GetUUID() == columnUUID);

            _columns.RemoveAt(index);

            return this;
        }

        public Board AddTask(CTask task)
        {
            if (_columns.Count() > 0)
            {
                _columns[0].AddTask(task);
            }

            return this;
        }

        public Board MoveTask(BoardColumn columnFrom, BoardColumn columnTo, CTask task)
        {
            columnFrom.RemoveTask(task.GetUUID());
            columnTo.AddTask(task);

            return this;
        }

    }
}
