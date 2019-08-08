namespace Blazor.Redux
{
    public delegate TState Reducer<TState>(TState state, object action);
}