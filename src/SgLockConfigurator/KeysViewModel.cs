using System.Collections.ObjectModel;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SgLockNET;

namespace SgLockConfigurator;

/// <summary>
/// View model for displaying all keys.
/// </summary>
internal sealed partial class KeysViewModel : ObservableObject
{
    private readonly ObservableCollection<SgLock> allKeys;

    [ObservableProperty]
    private SgLock? selectedLock;

    [ObservableProperty]
    private SgLockViewModel? selectedViewModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeysViewModel"/> class.
    /// </summary>
    public KeysViewModel()
    {
        allKeys = new(SgLock.GetAllKeys());
        SelectedLock = allKeys.FirstOrDefault();
    }

    /// <summary>
    /// Gets a collection of all availible keys.
    /// </summary>
    public ReadOnlyObservableCollection<SgLock> AllKeys => new(allKeys);

    partial void OnSelectedLockChanged(SgLock? value)
    {
        if (value == null)
        {
            SelectedViewModel = null;
            return;
        }

        SelectedViewModel = new SgLockViewModel(value);
    }

    [RelayCommand]
    private void RefreshKeys()
    {
        SelectedLock = null;
        allKeys.Clear();
        var keys = SgLock.GetAllKeys();
        Dispatcher.CurrentDispatcher.Invoke(allKeys.Clear);
        Dispatcher.CurrentDispatcher.Invoke(() => allKeys.AddMany(keys));
    }
}
