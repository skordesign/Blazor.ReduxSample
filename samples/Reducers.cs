namespace Blazor.ReduxSample
{
    public class Reducers
    {
        public static AppState RootReducer(AppState state, object action)
        => new AppState(CounterReducer(state.CounterState, action));
        public static CounterState CounterReducer(CounterState state, object action)
        => action switch
        {
            IncrementAction incrementAction => new CounterState(state.Count + 1, incrementAction.Message),
            DoneAction _ => new CounterState(state.Count, "Done"),
            _ => state
        };
    }
}