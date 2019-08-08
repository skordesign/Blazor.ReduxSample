namespace Blazor.ReduxSample
{
    public class Reducers
    {
        public static AppState RootReducer(AppState state, object action)
        => new AppState(CounterReducer(state.CounterState, action));
        public static CounterState CounterReducer(CounterState state, object action)
        => action switch
        {
            IncrementAction _ => new CounterState(state.Count + 1, "Changing"),
            DoneAction _ => new CounterState(state.Count, "Done"),
            _ => state
        };
    }
}