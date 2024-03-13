using System.Windows.Input;

namespace NextEditor.Commands;

public class RelayCommand : ICommand
{
    private Action<object> _execute;
    private readonly Func<object, bool>? _canExecute;
    
    public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
    {
        this._execute = execute;
        this._canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
        return _canExecute is null || _canExecute(parameter);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
    }

    public void Execute(object? parameter)
    {
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
        _execute(parameter);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}