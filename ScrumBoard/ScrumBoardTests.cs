using System.Collections.Generic;
using Xunit;
using ScrumBoardLibrary;

namespace ScrumBoardTests
{
    public class ScrumBoardTests
    {
        [Fact]
        public void Create_new_task()
        {
            ITask newTask = new Task("name1", "description", 1);

            Assert.Equal("name1", newTask.Name);
            Assert.Equal("description", newTask.Description);
            Assert.Equal(1, newTask.Priority);
        }

        [Fact]
        public void Change_task_name()
        {
            ITask task = new Task("name1", "description", 1);
            task.ChangeName("name2");

            Assert.Equal("name2", task.Name);
        }

        [Fact]
        public void Change_task_description()
        {
            ITask task = new Task("name1", "my description", 2);
            task.ChangeDescription("Ohh");

            Assert.Equal("Ohh", task.Description);
        }

        [Fact]
        public void Change_task_priority()
        {
            ITask task = new Task("name1", "description", 5);
            task.ChangePriority(1);

            Assert.Equal(1, task.Priority);
        }

        [Fact]
        public void Create_new_column()
        {
            IColumn newColumn = new Column("Column1");

            Assert.Equal("Column1", newColumn.ColumnName);
        }

        [Fact]
        public void Add_new_task()
        {
            IColumn newColumn = new Column("Column1");
            ITask newTask = new Task("Check_task", "Check new task", 1);
            
            newColumn.AddTask(newTask);
            ITask actualTask = newColumn.GetTask("Check_task");

            Assert.Equal(newTask, actualTask);
        }

        [Fact]
        public void Change_column_name()
        {
            IColumn newColumn = new Column("Column1");

            newColumn.ChangeName("Column2");

            Assert.Equal("Column2", newColumn.ColumnName);
        }

        [Fact]
        public void Delete_task_in_column()
        {
            IColumn newColumn = new Column("Column1");
            ITask newTask = new Task("Check_task", "Check task delete", 1);

            newColumn.AddTask(newTask);
            newColumn.DeleteTask(newTask);
            ITask actualTask = newColumn.GetTask("Check_task");

            Assert.NotEqual(newTask, actualTask);
        }

        [Fact]
        public void Clear_the_column()
        {
            IColumn firstColumn = new Column("Column1");
            ITask newTask = new Task("Task1", "Task for check", 2);

            firstColumn.AddTask(newTask);
            firstColumn.Clear();
            List<ITask> expectedTasks = new List<ITask>();
            List<ITask> tasks = firstColumn.GetAllTasks();

            Assert.Equal(expectedTasks, tasks);
        }

        [Fact]
        public void Create_new_board()
        {
            IBoard newBoard = new Board("board1");
            List<IColumn> colmns = new List<IColumn>();

            Assert.Equal("board1", newBoard.Name);
            Assert.Equal(colmns, newBoard.Columns);
        }

        [Fact]
        public void Add_new_column()
        {
            IBoard board = new Board("board1");
            IColumn newColumn = new Column("column1");
            
            board.AddColumn("column1");

            Assert.Single(board.Columns);
        }

        [Fact]
        public void Add_new_task_to_first_column()
        {
            IBoard board = new Board("board1");
            ITask task = new Task("first", "check add", 1);

            board.AddColumn("abc");
            board.AddTask(task);

            Assert.Equal(task, board.Columns[0].GetTask("first"));
        }

        [Fact]
        public void Move_task()
        {
            IBoard board = new Board("board1");
            ITask task = new Task("first", "check add", 1);

            board.AddColumn("column1");
            board.AddColumn("column2");
            board.AddTask(task);

            Assert.Equal(task, board.Columns[0].GetTask("first"));
            Assert.NotEqual(task, board.Columns[1].GetTask("first"));

            board.MoveTask(board.Columns[0], board.Columns[1], task);

            Assert.Equal(task, board.Columns[1].GetTask("first"));
            Assert.NotEqual(task, board.Columns[0].GetTask("first"));
        }
    }
}
