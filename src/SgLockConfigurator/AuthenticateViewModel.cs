using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SgLockNET;

namespace SgLockConfigurator;

/// <summary>
/// The view model for authenticating the lock.
/// </summary>
internal partial class AuthenticateViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AuthenticateCommand))]
    private uint[] authenticationCode = [];

    [RelayCommand]
    private void Authenticate()
    {
        try
        {
            SgLock.Authenticate(AuthenticationCode);
            var message = new NavigateToMessage(new KeysViewModel());
            WeakReferenceMessenger.Default.Send(message);
        }
        catch (SgLockException ex)
        {
            _ = MessageBox.Show(ex.Message, "Failed to authenticate");
        }
    }
}
