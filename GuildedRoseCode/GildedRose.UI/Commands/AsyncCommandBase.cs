using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GildedRose.UI.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool _isExecuting;

        public bool IsExecuting
        {
            get => _isExecuting;
            private set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => !IsExecuting;

        public async void Execute(object? parameter)
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
        }

        protected abstract Task ExecuteAsync(object? parameter);
    }
}
