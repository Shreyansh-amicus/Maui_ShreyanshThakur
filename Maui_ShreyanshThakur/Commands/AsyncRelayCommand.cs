
using System.Windows.Input;
using System.Threading;

namespace Maui_ShreyanshThakur.Commands;

public class AsyncRelayCommand : ICommand
{
    private readonly Func<Task> _executeAsync;
    private readonly Func<bool>? _canExecute;

    private int _isRunning;

    public event EventHandler? CanExecuteChanged;

    public bool IsRunning =>
        Volatile.Read(ref _isRunning) == 1;

    public AsyncRelayCommand(
        Func<Task> executeAsync,
        Func<bool>? canExecute = null)
    {
        _executeAsync = executeAsync
            ?? throw new ArgumentNullException(nameof(executeAsync));

        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return !IsRunning &&
               (_canExecute?.Invoke() ?? true);
    }

    public void Execute(object? parameter)
    {
        _ = ExecuteAsync();
    }

    public async Task ExecuteAsync()
    {
        // Check whether execution is allowed.
        if (!CanExecute(null))
            return;

        // Atomically prevent another execution from starting.
        if (Interlocked.CompareExchange(
                ref _isRunning, 1, 0) != 0)
        {
            return;
        }

        NotifyCanExecuteChanged();

        try
        {
            await _executeAsync();
        }
        finally
        {
            // Allow the command to execute again.
            Interlocked.Exchange(ref _isRunning, 0);

            NotifyCanExecuteChanged();
        }
    }

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
