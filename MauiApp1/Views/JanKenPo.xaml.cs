namespace MauiApp1.Views;

public partial class JanKenPo : ContentPage
{
	public JanKenPo()
	{
        BindingContext = new JanKenPoViewModel();

        InitializeComponent();
    }
}