using JohanCarrasco_Catalogo_P3.ViewModels;

namespace JohanCarrasco_Catalogo_P3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();
			BindingContext = new RegisterViewModel(Navigation);
		}
	}
}