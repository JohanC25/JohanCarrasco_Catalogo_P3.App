namespace JohanCarrasco_Catalogo_P3;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Productos), typeof(Productos));
	}
}
