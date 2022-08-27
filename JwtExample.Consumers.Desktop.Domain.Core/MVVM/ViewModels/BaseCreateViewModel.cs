namespace JwtExample.Consumers.Desktop.Domain.Core.MVVM.ViewModels;

public abstract class BaseCreateViewModel : BaseViewModel
{
    public ICommand? CreateCommand { get; protected set; }

    protected abstract bool CanExecuteCreateCommand(object obj);

    protected abstract void ExecuteCreateCommand(object obj);
}