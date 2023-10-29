using System;
using System.Windows.Input;

namespace SqlExtensions;

public class Command : ICommand
{
    private readonly Action<object?> _execute;

    public Command(Action<object?> execute)
    {
        _execute = execute;
    }
    
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _execute.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}