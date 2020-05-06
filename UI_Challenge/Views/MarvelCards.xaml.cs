using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Challenge.Extensions;
using UI_Challenge.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI_Challenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarvelCards : ContentPage
    {
        private double _heroImageTranslationY = 50;
        private double _movementFactor = 100;

        public MarvelCards()
        {
            InitializeComponent();
            this.BindingContext = new HeroCardsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainCardView.UserInteracted += MainCardView_UserInteracted;
            MessagingCenter.Subscribe<CardEvent>(this, CardState.Expanded.ToString(), CardExpand);
        }

        private void CardExpand(CardEvent obj)
        {
            // turn off swipe interaction
            MainCardView.IsUserInteractionEnabled = false;

            // animate Title out
            AnimateTitle(CardState.Expanded);
        }

        private void BackArrowTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // animate the title back in
            AnimateTitle(CardState.Collapsed);

            // tell the card to collapse
            ((HeroCard)MainCardView.CurrentView).GoToState(CardState.Collapsed);

            // re-enable swiping
            MainCardView.IsUserInteractionEnabled = true;
        }

        private void AnimateTitle(CardState cardState)
        {
            var translationY = cardState == CardState.Expanded ? 0 - (MoviesHeader.Height + MoviesHeader.Margin.Top) : 0;
            var opacity = cardState == CardState.Expanded ? 0 : 1;

            var animation = new Animation();
            if (cardState == CardState.Expanded)
            {
                animation.Add(0.00, 0.25, new Animation(v => MoviesHeader.TranslationY = v, MoviesHeader.TranslationY, translationY));
                animation.Add(0.00, 0.25, new Animation(v => MoviesHeader.Opacity = v, MoviesHeader.Opacity, opacity));
            }
            else
            {
                animation.Add(0.75, 1.00, new Animation(v => MoviesHeader.TranslationY = v, MoviesHeader.TranslationY, translationY));
                animation.Add(0.75, 1.00, new Animation(v => MoviesHeader.Opacity = v, MoviesHeader.Opacity, opacity));
            }

            animation.Commit(this, "titleAnimation", 16, 1000);

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MainCardView.UserInteracted -= MainCardView_UserInteracted;
            MessagingCenter.Unsubscribe<CardEvent>(this, CardState.Expanded.ToString());
        }


        private void MainCardView_UserInteracted(
            PanCardView.CardsView view,
            PanCardView.EventArgs.UserInteractedEventArgs args)
        {

            if (args.Status == PanCardView.Enums.UserInteractionStatus.Running)
            {
                // get the front card
                var card = MainCardView.CurrentView as HeroCard;

                // work out what percent the swipe is at
                var percentFromCenter = Math.Abs(args.Diff / this.Width);

                // adjust scale when panning
                if ((percentFromCenter > 0) && (card.Scale == 1))
                    card.ScaleTo(.95, 50);

                // update elements based on swipe position
                AnimateFrontCardDuringSwipe(card, percentFromCenter);

                // get the next card on the stack, which is the one coming into view
                var nextCard = MainCardView.CurrentBackViews.First() as HeroCard;

                // update elements based on swipe position
                AnimateIncomingCardDuringSwipe(nextCard, percentFromCenter);
            }

            if (args.Status == PanCardView.Enums.UserInteractionStatus.Ended ||
                args.Status == PanCardView.Enums.UserInteractionStatus.Ending)
            {
                // at the end of dragging we need to make sure card is reset
                var card = MainCardView.CurrentView as HeroCard;
                AnimateFrontCardDuringSwipe(card, 0);
                card.ScaleTo(1, 50);
            }

        }


        private void AnimateFrontCardDuringSwipe(HeroCard card, double percentFromCenter)
        {
            // opacity of the maincard during swipe
            MainCardView.CurrentView.Opacity = Helpers.LimitToRange((1 - (percentFromCenter)) * 2, 0, 1);

            // scaling on the main card during swipe
            card.MainImage.Scale = Helpers.LimitToRange((1 - (percentFromCenter) * 1.5), 0, 1);

            // y offset of image during swipe
            card.MainImage.TranslationY = _heroImageTranslationY + (_movementFactor * percentFromCenter);

            // adjust opacity of image
            card.MainImage.Opacity = Helpers.LimitToRange((1 - (percentFromCenter)) * 1.5, 0, 1); ;
        }


        private void AnimateIncomingCardDuringSwipe(HeroCard nextCard, double percentFromCenter)
        {
            // opacity fading in
            nextCard.MainImage.Opacity = Helpers.LimitToRange(percentFromCenter * 1.5, 0, 1);

            // scaling in
            nextCard.MainImage.Scale = Helpers.LimitToRange(percentFromCenter * 1.1, 0, 1);

            var offset = _heroImageTranslationY + (_movementFactor * (1 - (percentFromCenter * 1.1)));
            nextCard.MainImage.TranslationY = Helpers.LimitToRange(offset, _heroImageTranslationY, _heroImageTranslationY + _movementFactor);
        }

    }
}