namespace ScrumBoardLibrary
{
    public interface ITask
    {
        string Name { get; }
        string Description { get; }
        int Priority { get; }
        void ChangeName(string newName);
        void ChangePriority(int newPriority);
        void ChangeDescription(string newDescrition);
    }
}
