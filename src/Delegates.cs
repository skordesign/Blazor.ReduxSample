namespace Blazor.Redux
{
    public delegate TState Reducer<TState>(TState state, object action);
    public delegate void Dispatcher(object action);
    public delegate void MiddlewareDelegate<TState>(Store<TState> state, object action, Dispatcher dispatcher) where TState : class;
}