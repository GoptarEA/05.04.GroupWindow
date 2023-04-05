using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication6;

public partial class ChooseWindow : Window
{
    public ChooseWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OpenGroupWindow(object? sender, RoutedEventArgs e)
    {
        var _groupWindow = new GroupWindow();
        _groupWindow.Show();
        Close();
    }
}