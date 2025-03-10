namespace AnimalMatchingGame
{
    public partial class MainPage : ContentPage
    {
        Button lastClicked;
        bool findingMatch = false;
        int matchesFound;

        public 
            MainPage()
        {
            InitializeComponent();
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {
            AnimalButtons.IsVisible = true;
            PlayAgainButton.IsVisible = false;

            List<string> animalEmoji = [
                "🐵","🐵",
                "🐸","🐸",
                "🐳","🐳",
                "🐷","🐷",
                "🦝","🦝",
                "🐴","🐴",
                "🐋","🐋",
                "🐶","🐶"
                ];

            foreach (var button in AnimalButtons.Children.OfType<Button>())
            {
                int index = Random.Shared.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                button.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }

            Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick);
        }
        int tenthsOfSecondElapsed = 0;
        private bool TimerTick()
        {
            if (!this.IsLoaded) return false;

            tenthsOfSecondElapsed++;

            TimeElapsed.Text = "Time Elapsed " +
                (tenthsOfSecondElapsed / 10F).ToString("0.0s");

            if (PlayAgainButton.IsVisible)
            {
                tenthsOfSecondElapsed = 0;
                return false;
            }

            throw new NotImplementedException();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button buttonClicked)
            {
                if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && (findingMatch == false))
                {
                    buttonClicked.BackgroundColor = Colors.DarkBlue;
                    lastClicked = buttonClicked;
                    findingMatch = true;
                }
                else
                {
                    if ((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text) && (!String.IsNullOrWhiteSpace(buttonClicked.Text)))
                    {
                        matchesFound++;
                        lastClicked.Text = " ";
                        buttonClicked.Text = " ";
                    }
                    lastClicked.BackgroundColor = Colors.LightBlue;
                    buttonClicked.BackgroundColor = Colors.LightBlue;
                    findingMatch = false;
                }
            }

            if (matchesFound == 8)
            {
                matchesFound = 0;
                AnimalButtons.IsVisible = false;
                PlayAgainButton.IsVisible = true;
            }
        }

    }

}
