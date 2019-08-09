namespace Blazor.ReduxSample
{
    public class IncrementAction {
        public string Message { get; }
        public IncrementAction(string message)
        {
            Message = message;
        }
    }
    public struct DoneAction { }
}