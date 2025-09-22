using System;
using System.Windows.Input;

namespace ENSIT.MVVMApp.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Func<System.Threading.Tasks.Task> _execute;
        private readonly Func<bool>? _canExecute;
        public RelayCommand(Func<System.Threading.Tasks.Task> execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;
        public async void Execute(object? parameter) => await _execute();
    }
}
