namespace JwtExample.Consumers.Desktop.Domain.Core.MVVM.ViewModels;

public abstract class BaseUpdateViewModel<TModel>
    : BaseReadViewModel<TModel>
{
    public ICommand? UpdateCommand { get; protected set; }

    protected abstract bool CanExecuteUpdateCommand(object obj);

    protected abstract void ExecuteUpdateCommand(object obj);

    protected virtual void Clear() => SelectedGeneralValue = default;
}