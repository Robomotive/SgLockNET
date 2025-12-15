using System.Collections.ObjectModel;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SgLockNET;

namespace SgLockConfigurator;

/// <summary>
/// The view model for a single lock.
/// </summary>
/// <param name="sgLock">The lock to view.</param>
public sealed partial class SgLockViewModel(SgLock sgLock) : ObservableObject
{
    [ObservableProperty]
    private uint counterIndex;

    [ObservableProperty]
    private uint encryptionKeyIndex;

    /// <summary>
    /// Gets the configuration of this lock.
    /// </summary>
    public ConfigData ConfigData => sgLock.ConfigData;

    /// <summary>
    /// Gets all encrypted data entries.
    /// </summary>
    public ObservableCollection<LockDataEntry> Counters { get; } = [];

    /// <summary>
    /// Gets all encrypted data entries.
    /// </summary>
    public ObservableCollection<LockDataEntry> Data { get; } = [];

    /// <summary>
    /// Gets all decrypted data entries.
    /// </summary>
    public ObservableCollection<LockDataEntry> DecryptedData { get; } = [];

    /// <summary>
    /// Gets all data entries to encrypt.
    /// </summary>
    public ObservableCollection<LockDataEntry> EncryptedData { get; } = [];

    [RelayCommand]
    private async Task DecryptDataAsync()
    {
        await Dispatcher.CurrentDispatcher.InvokeAsync(DecryptedData.Clear);
        var data = EncryptedData.Select(x => x.Data).ToArray();
        var decryptedData = await sgLock.EncryptDataAsync(data, EncryptionKeyIndex).ConfigureAwait(true);
        var entries = decryptedData.Select((item, index) => new LockDataEntry((uint)index, item)).ToArray();
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => DecryptedData.AddMany(entries));
    }

    [RelayCommand]
    private async Task EncryptDataAsync()
    {
        await Dispatcher.CurrentDispatcher.InvokeAsync(EncryptedData.Clear);
        var data = DecryptedData.Select(x => x.Data).ToArray();
        var encryptedData = await sgLock.EncryptDataAsync(data, EncryptionKeyIndex).ConfigureAwait(true);
        var entries = encryptedData.Select((item, index) => new LockDataEntry((uint)index, item)).ToArray();
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => EncryptedData.AddMany(entries));
    }

    [RelayCommand]
    private async Task ReadAllDataAsync()
    {
        await Dispatcher.CurrentDispatcher.InvokeAsync(Data.Clear);
        var readData = await sgLock.ReadAllDataAsync().ConfigureAwait(true);
        var entries = readData.Select((item, index) => new LockDataEntry((uint)index, item)).ToArray();
        await Dispatcher.CurrentDispatcher.InvokeAsync(() => Data.AddMany(entries));
    }

    [RelayCommand]
    private async Task ReadCountersAsync()
    {
        await Dispatcher.CurrentDispatcher.InvokeAsync(Counters.Clear);
        for (var i = 0u; i < sgLock.ConfigData.CounterCount; i++)
        {
            var counterValue = await sgLock.ReadCounterAsync(i).ConfigureAwait(true);
            var entry = new LockDataEntry(i, counterValue);
            await Dispatcher.CurrentDispatcher.InvokeAsync(() => Counters.Add(entry));
        }
    }

    [RelayCommand]
    private async Task WriteCountersAsync()
    {
        var counters = new List<LockDataEntry>(Counters);
        foreach (var counter in counters)
        {
            await sgLock.WriteCounterAsync(counter.Index, counter.Data).ConfigureAwait(false);
        }
    }

    [RelayCommand]
    private async Task WriteDataAsync()
    {
        foreach (var dataEntry in Data)
        {
            await sgLock.WriteDataAsync(dataEntry.Data, dataEntry.Index).ConfigureAwait(false);
        }
    }
}
