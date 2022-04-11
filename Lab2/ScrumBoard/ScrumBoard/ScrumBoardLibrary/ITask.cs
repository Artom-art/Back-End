namespace ScrumBoardLibrary
{
    public interface ITask
    {
        string Name { get; }
        void ChangeName(string newName);
        void ChangePriority(int newPriority);
        void ChangeDescription(string newDescrition);
    }
}
