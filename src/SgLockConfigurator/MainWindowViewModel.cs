using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace SgLockConfigurator;

/// <summary>
/// The view model for the main window.
/// </summary>
internal sealed partial class MainWindowViewModel
    : ObservableRecipient,
    IRecipient<NavigateToMessage>
{
    [ObservableProperty]
    private object currentViewModel = new AuthenticateViewModel();

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel()
        => IsActive = true;

    /// <inheritdoc/>
    public void Receive(NavigateToMessage message)
        => CurrentViewModel = message.ViewModel;
}
