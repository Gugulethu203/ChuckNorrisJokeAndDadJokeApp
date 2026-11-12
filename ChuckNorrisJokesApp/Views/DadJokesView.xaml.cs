using ChuckNorrisJokesApp.ViewModels;

namespace ChuckNorrisJokesApp.Views;

public partial class DadJokesView : ContentPage
{
    public DadJokesView(DadJokesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
