using Biblioteka.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class LiblaryViewModel : ObservableObject
    {
        public ObservableCollection<Book> Books { get; set; }
        private readonly ILiblaryServis _liblaryServis;
        public LiblaryViewModel(ILiblaryServis liblaryServis) {
            _liblaryServis = liblaryServis;
            Books = new ObservableCollection<Book>();
        }
        private int page = 0;
        private List<Book> _books;
        public async void GetProducts()
        {
            var productsResult = await _liblaryServis.GetProductsAsync();
            if (productsResult.Success)
            {
                _books = productsResult.Data;
                LoudBooks();
            }
        }

        private void LoudBooks()
        {
            Books.Clear();
            for (int i = page * 3; i < _books.LongCount() && i < page*3+3; i++)
            {
                Books.Add(_books[i]);
            }
        }
        [RelayCommand]
        public void Last()
        {
            if (page > 0)
                page--;
            LoudBooks();
        }

        [RelayCommand]
        public void Next()
        {
            page++;
            LoudBooks();
        }


    }
}
