using Newtonsoft.Json;

namespace JohanCarrasco_Catalogo_P3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dashboard : ContentPage
	{
		public Dashboard()
		{
			InitializeComponent();
			GetProfileInfo();
		}

		private void GetProfileInfo()
		{
			var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
			UsuariosRegistrados.Text = userInfo.User.Email;
			
		}
	}
}