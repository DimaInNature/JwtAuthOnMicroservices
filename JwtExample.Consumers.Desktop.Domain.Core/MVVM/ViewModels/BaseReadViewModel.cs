namespace JwtExample.Consumers.Desktop.Domain.Core.MVVM.ViewModels;

public abstract class BaseReadViewModel<TModel> : BaseViewModel
{
    #region Properties

    public List<TModel> GeneralDataList
    {
        get => _generalDataList ?? new();
        set
        {
            _generalDataList = value;

            OnPropertyChanged(propertyName: nameof(GeneralDataList));
        }
    }

    public TModel? SelectedGeneralValue
    {
        get => _selectedGeneralValue;
        set
        {
            _selectedGeneralValue = value;

            OnPropertyChanged(propertyName: nameof(SelectedGeneralValue));

            if (value is not null) SelectGeneralValue();
        }
    }

    public string SearchFilter
    {
        get => _searchFilter ?? string.Empty;
        set
        {
            _searchFilter = value;

            OnPropertyChanged(propertyName: nameof(SearchFilter));

            if (string.IsNullOrWhiteSpace(value) is false)
            {
                Find(filter: value);

                return;
            }

            UpdateData();
        }
    }

    private List<TModel> _generalDataList = new();

    private TModel? _selectedGeneralValue;

    private string _searchFilter = string.Empty;

    #endregion

    protected virtual void SelectGeneralValue() { }

    protected virtual void Find(string filter) { }

    protected abstract Task UpdateData();
}