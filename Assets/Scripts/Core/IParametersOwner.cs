namespace Core
{
    public interface IParametersOwner
    {
        string Id { get; }
        Parameters Parameters { get; }
    }
}