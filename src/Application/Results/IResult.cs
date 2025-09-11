namespace Application.Results
{
    public interface IResult
    {
        bool Succeeded { get; }
        string Message { get; }
    }
}