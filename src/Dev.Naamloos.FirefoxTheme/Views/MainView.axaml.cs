using Avalonia.Controls;
using Dev.Naamloos.FirefoxTheme.ViewModels;

namespace Dev.Naamloos.FirefoxTheme.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void OnStartClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var nextView = new ProfilePicker()
        {
            DataContext = new ProfilePickerViewModel()
        };

        var parent = this.Parent as ContentControl;
        if (parent != null)
        {
            parent.Content = nextView;
        }
    }
}
