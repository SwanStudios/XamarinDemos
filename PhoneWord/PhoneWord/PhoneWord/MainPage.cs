using System;
using System.Text;
using Xamarin.Forms;

public class MainPage : ContentPage
{
    Entry lEntry;
    Button lTranslateButton;
    Button lCallButton;
    string gTranslatedNumber;

    public MainPage()
    {
        this.Padding = new Thickness(20,
            Device.OnPlatform<double>(40, 20, 20), 20, 20);

        var lLabel = new Label
        {
            HorizontalTextAlignment = TextAlignment.Start,
            Text = "Enter the phone number"
        };

        lEntry = new Entry
        {
            HorizontalTextAlignment = TextAlignment.Start,
            Text = "91-9885822244"
        };

        lTranslateButton = new Button
        {
            Text = "Translate"
        };

        lCallButton = new Button
        {
            Text = "Call",
            IsEnabled = false

        };

        var mainStackLayout = new StackLayout
        {
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Orientation = StackOrientation.Vertical,
            Spacing = 15,
            Children = {
                lLabel,
                lEntry,
                lTranslateButton,
                lCallButton
            }
        };

        this.Content = mainStackLayout;

        lTranslateButton.Clicked += LTranslateButton_Clicked;
        lCallButton.Clicked += LCallButton_Clicked;
    }

    private async void LCallButton_Clicked(object sender, EventArgs e)
    {
        if(await this.DisplayAlert("Dial A Number", "Would you like to call " + gTranslatedNumber + "?", "Yes", "No"))
        {
            var dialer = DependencyService.Get<PhoneWord.IDialer>();
            if (dialer != null)
            {
                dialer.DialAsync(gTranslatedNumber);
            }
        }
    }

    private void LTranslateButton_Clicked(object sender, EventArgs e)
    {
        string lInputString = lEntry.Text;
        gTranslatedNumber = Core.PhoneNumberTranslator.ToNumber(lInputString);

        if(!String.IsNullOrEmpty(gTranslatedNumber))
        {
            lCallButton.Text = "Call " + gTranslatedNumber;
            lCallButton.IsEnabled = true;
        }
        else
        {
            lCallButton.Text = "Call";
            lCallButton.IsEnabled = false;
        }

    }

}

