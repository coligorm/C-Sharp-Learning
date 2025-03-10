using System.Threading.Tasks;

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

            List<string> animalEmoji = [];

            List<string> emojiList = [
                "🐵",
                "🐸",
                "🐳",
                "🐷",
                "🦝",
                "🐴",
                "🐋",
                "🐶",
                "🐮",
                "🐱",
                "🐔",
                "🦊",
                "🐙",
                "🦞",
                "🦐",
                "🐬"
                ];
            for (int i = 0; i < 8; i++)
            {
                int index = Random.Shared.Next(emojiList.Count);
                animalEmoji.Add(emojiList[index]);
                animalEmoji.Add(emojiList[index]);
                emojiList.RemoveAt(index);
            }

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
                    else
                    {
                        FlashButton(buttonClicked);
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

        private async void FlashButton(Button button)
        {
            button.BackgroundColor = Colors.Red;
            await Task.Delay(1000); // Wait for 1 second asynchronously
            button.BackgroundColor = Colors.LightBlue; // Or any other default color
        }

    }

}
