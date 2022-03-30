namespace ScrumBoardLibrary
{
    public interface ITask
    {
        string Name { get; }
        void ChangeName(string newName);
    }
}
