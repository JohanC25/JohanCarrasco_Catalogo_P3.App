using JohanCarrasco_Catalogo_P3.ViewModels;

namespace JohanCarrasco_Catalogo_P3;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(Navigation);
	}
}

