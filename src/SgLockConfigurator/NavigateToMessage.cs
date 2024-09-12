namespace SgLockConfigurator;

/// <summary>
/// A message to navigate to a new page.
/// </summary>
/// <param name="ViewModel">The view model to display.</param>
public record class NavigateToMessage(object ViewModel);
