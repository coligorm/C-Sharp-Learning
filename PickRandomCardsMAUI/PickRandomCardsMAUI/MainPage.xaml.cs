using PickRandomCards;

namespace PickRandomCardsMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void PickCardsButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(NumberOfCards.Text, out int numberOfCards))
            {
                string[] cards = CardPicker.PickSomeCards(numberOfCards);
                PickedCards.Text = String.Empty;

                foreach (string card in cards)
                {
                    PickedCards.Text += card + Environment.NewLine;
                }
                PickedCards.Text += Environment.NewLine + $"You picked {numberOfCards} cards.";

            } else
            {
                NumberOfCards.Placeholder = "Invalid Input. Please enter a valid number of cards to pick";
            }
        }
    }

}
