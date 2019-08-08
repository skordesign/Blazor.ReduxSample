using System;
using Microsoft.AspNetCore.Components;

namespace Blazor.Redux
{
    public abstract class ReduxComponent<TState, TViewModel> : ComponentBase, IDisposable where TState : class
    {
        [Inject]
        protected Store<TState> Store { get; set; }
        protected abstract TViewModel ViewModel { get; }

        protected override sealed void OnInit()
        {
            OnRInit();
            Store.StateChanged += StateChanged;
        }
        public void Dispose()
        {
            Store.StateChanged -= StateChanged;
            OnRDestroy();
        }
        public virtual void OnRInit()
        {
            base.OnInit();
        }
        public virtual void OnRDestroy()
        {

        }
        private void StateChanged()
         => StateHasChanged();
    }
}