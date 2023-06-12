namespace PhoneDialerIssue;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    async void emailOpener_Clicked(System.Object sender, System.EventArgs e)
    {
		if (!Email.Default.IsComposeSupported)
		{
			await Shell.Current.DisplayAlert("alert", "Phone dialer is not supported", "ok");
			return;
		}

		var email = new EmailMessage
		{
			Subject = "Test",
			Body = string.Empty,
			BodyFormat = EmailBodyFormat.PlainText,
			To = new() { "test@testdomain.com" }
		};

		await Email.Default.ComposeAsync(email);
    }

    async void phoneDialer_Clicked(System.Object sender, System.EventArgs e)
    {
        if (PhoneDialer.IsSupported)
            PhoneDialer.Default.Open("+1234567890");
        else await Shell.Current.DisplayAlert("alert", "Phone dialer is not supported", "ok");
    }
}


