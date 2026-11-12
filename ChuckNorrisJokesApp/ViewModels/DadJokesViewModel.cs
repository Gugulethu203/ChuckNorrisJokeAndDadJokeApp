using ChuckNorrisJokesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChuckNorrisJokesApp.ViewModels
{
    public class DadJokesViewModel : BaseViewModel
    {
        public ICommand GetDadJokeCommand { get; set; }

        private string _dadJoke;

        public string DadJoke
        {
            get { return _dadJoke; }
            set
            {
                _dadJoke = value;
                OnPropertyChanged();
            }
        }

        private IDadJokeApiService _dadJokeApiService;
        private IPopUps _popupService;

        public DadJokesViewModel(IDadJokeApiService service, IPopUps popups)
        {
            _dadJokeApiService = service;
            _popupService = popups;

            GetDadJokeCommand = new Command(FetchJoke);
        }

        private async void FetchJoke(object param)
        {
            try
            {

                //  throw new HttpRequestException("BOOM");
                DadJoke = await _dadJokeApiService.GetJokeAsync();
            }
            catch (Exception ex)
            {
                await _popupService.ShowPopupAsync("Error", ex.Message, "OK");
            }
        }
    }
}

