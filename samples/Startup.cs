using Blazor.Redux;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blazor.ReduxSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRedux(AppState.Init(), Reducers.RootReducer, new Middleware<AppState>[]
            {
                (MiddlewareDelegate<AppState>)SampleMiddleware,
                (MiddlewareDelegate<AppState>)SecondMiddleware
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
        public static void SampleMiddleware(Store<AppState> store, object action, Dispatcher dispatcher)
        {
            Console.WriteLine("Went to SampleMiddleware");
            if(action is IncrementAction incrementAction)
            {
                dispatcher(new IncrementAction(incrementAction.Message + "by SampleMiddleware"));
            }
            else
            {
                dispatcher(action);
            }
        }
        public static void SecondMiddleware(Store<AppState> store, object action, Dispatcher dispatcher)
        {
            Console.WriteLine("Went to SampleMiddleware");
            if (action is IncrementAction incrementAction)
            {
                dispatcher(new IncrementAction(incrementAction.Message + "by SecondMiddleware"));
            }
            else
            {
                dispatcher(action);
            }
        }
    }
}
