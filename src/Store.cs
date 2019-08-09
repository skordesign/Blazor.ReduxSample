using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Redux
{
    public class Store<TState> where TState : class
    {
        internal event Action StateChanged;
        public TState State { get; private set; }
        private Reducer<TState> Reducer;
        private Middleware<TState>[] Middlewares = new Middleware<TState>[0];
        public Store(TState initState, Reducer<TState> rootReducer)
        {
            State = initState;
            Reducer = rootReducer;
        }
        public Store(TState initState, Reducer<TState> rootReducers, Middleware<TState>[] middlewares) : this(initState, rootReducers)
        {
            Middlewares = middlewares;
        }
        public void Dispatch(object action)
        {
            DispatchMiddleware(action, 0);
        }
        private void DispatchMiddleware(object action, int index)
        {
            if (Middlewares.Length > index + 1)
                Middlewares[index].Handle(this, action, (obj) => DispatchMiddleware(obj, index + 1));
            else
                Middlewares[index].Handle(this, action, (obj) => DispatchState(obj));
        }
        private void DispatchState(object action)
        {
            State = Reducer(State, action);
            StateChanged?.Invoke();
        }
    }
    public static class ReduxExt
    {
        public static void AddRedux<TState>(this IServiceCollection services, TState initState, Reducer<TState> rootReducer) where TState : class
        {
            services.AddSingleton(new Store<TState>(initState, rootReducer));
        }
        public static void AddRedux<TState>(this IServiceCollection services, TState initState, Reducer<TState> rootReducer,
            Middleware<TState>[] middlewares) where TState : class
        {
            services.AddSingleton(new Store<TState>(initState, rootReducer, middlewares));
        }
    }
}