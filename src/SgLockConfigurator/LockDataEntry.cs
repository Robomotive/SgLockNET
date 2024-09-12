using CommunityToolkit.Mvvm.ComponentModel;

namespace SgLockConfigurator;

/// <summary>
/// An entry of the data tree.
/// </summary>
/// <param name="index">The index of this data.</param>
/// <param name="data">The data at this index.</param>
public partial class LockDataEntry(uint index, uint data) : ObservableObject
{
    [ObservableProperty]
    private uint data = data;

    [ObservableProperty]
    private uint index = index;
}
