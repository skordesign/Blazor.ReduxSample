namespace Blazor.ReduxSample
{
    public class AppState
    {
        public CounterState CounterState { get; }
        public AppState(CounterState counterState)
        {
            CounterState = counterState;
        }
        public static AppState Init() => new AppState(CounterState.Init());
    }
    public class CounterState
    {
        public int Count { get; }
        public string Status { get; }
        public CounterState(int count, string status)
        {
            Count = count;
            Status = status;
        }
        public static CounterState Init() => new CounterState(0, string.Empty);
    }
}