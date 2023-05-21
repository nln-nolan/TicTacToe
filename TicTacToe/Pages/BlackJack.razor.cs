using Games.Abstractions;
using Games.Models;
using System.Net.NetworkInformation;

namespace Games.Pages
{
    public partial class BlackJack
    {
        private Dealer _dealer = new Dealer();

        private Player _player = new Player();

        private GameState _state = GameState.NotStarted;

        private GameState _status;

        public async Task Delay(int millis)
        {
            await Task.Delay(millis);
            StateHasChanged();
        }

        public async Task InitializeHand()
        {
            if (_dealer.Deck.Count < 13)
            {
                _state = GameState.Shuffling;
                _dealer.Deck = new Deck();
                await Delay(1000);
            }

            _state = GameState.Betting;
        }

        public async Task Bet(decimal amount)
        {
            if (_player.Funds >= amount)
            {
                _player.Bet += amount;
                await Deal();
            }
        }

        public async Task Deal()
        {
            _state = GameState.Dealing;
            await _dealer.DealToPlayer(_player);
            StateHasChanged();

            var dealerCard = _dealer.Deal();
            dealerCard.IsVisible = false;
            await _dealer.AddCard(dealerCard);
            StateHasChanged();

            await _dealer.DealToPlayer(_player);
            StateHasChanged();

            await _dealer.DealToSelf();
            StateHasChanged();

            _state = GameState.InProgress;

            if (_player.HasNaturalBlackjack)
            {
                EndHand();
            }
        }

        public async Task DealerTurn()
        {
            if(_dealer.Score < 17)
            {
                await _dealer.DealToSelf();
                StateHasChanged();
                await DealerTurn();
            }
        }

        public async Task Hit()
        {
            await _dealer.DealToPlayer(_player);
            if(_player.IsBusted)
            {
                EndHand();
            }
        }

        public async Task Stand()
        {
            _player.HasStood = true;
            _dealer.Reveal();

            await DealerTurn();

            EndHand();
        }

        public async Task DoubleDown()
        {
            _player.HasStood = true;

            _player.Bet *= 2;

            await Delay(300);

            await _player.AddCard(_dealer.Deal());

            await Stand();
        }

        public void Insurance()
        {
            _state = GameState.Insurance;

            if(_dealer.HasAceShowing)
            {
                _player.InsuranceBet = _player.Bet / 2;

                if(_dealer.Score == 21)
                {
                    _dealer.Reveal();

                    _player.Change += _player.InsuranceBet * 2;

                    _status = GameState.Payout;
                    StateHasChanged();
                    EndHand();
                }
                else
                {
                    _player.Change -= _player.InsuranceBet;
                }
            }

            _state = GameState.InProgress;
        }

        public void EndHand()
        {
            _state = GameState.Payout;
            if (_player.HasNaturalBlackjack && _dealer.Score != 21)
            {
                _player.Change += _player.Bet * 1.5M;
            }
            else if (!_player.IsBusted && _dealer.IsBusted)
            {
                _player.Change += _player.Bet;
            }
            else if (!_dealer.IsBusted
                && !_player.IsBusted
                && _player.Score > _dealer.Score)
            {
                _player.Change += _player.Bet;
            }
            else if (!_dealer.IsBusted
                && !_player.IsBusted
                && _player.Score == _dealer.Score)
            {

            }
            else
            {
                _player.Change += _player.Bet * -1;
            }

            _player.Bet = 0;
            _player.HasStood = false;
        }

        public async Task NewHand()
        {
            //Payout the player's bets
            _player.Collect();

            //Clear the hands
            _player.ClearHand();
            _dealer.ClearHand();

            //Reset the game state
            _state = GameState.NotStarted;

            //Start a new hand!
            await InitializeHand();
        }
    }
}
