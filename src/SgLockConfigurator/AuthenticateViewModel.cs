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
    private uint[] authenticationCode =
    [
        0xF0DF0CCF,
        0xFB3662D5,
        0xC1EBEAE3,
        0xABD9A7B2,
        0xF3A08EFB,
        0x2E1298C0,
        0xA8C5B9AE,
        0x991B534A,
        0x39F1E67C,
        0x67EA4EAC,
        0xE42C10E2,
        0x550F515B,
    ];

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
