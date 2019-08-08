using System;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Redux
{
    public class Store<TState> where TState : class
    {
        internal event Action StateChanged;
        public TState State { get; private set; }
        private Reducer<TState> _reducer;
        public Store(TState initState, Reducer<TState> rootReducer)
        {
            State = initState;
            _reducer = rootReducer;
        }
        public void Dispatch(object action)
        {
            State = _reducer(State, action);
            StateChanged?.Invoke();
        }
    }
    public static class ReduxExt
    {
        public static void AddRedux<TState>(this IServiceCollection services, TState initState, Reducer<TState> rootReducer) where TState : class
        {
            services.AddSingleton(new Store<TState>(initState, rootReducer));
        }
    }
}