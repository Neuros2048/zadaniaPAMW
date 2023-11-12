using shared.Books;
using shared.service;
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
        private readonly EditBookView _editBookView;


        [ObservableProperty]
        private Book selectedBook;

        public LiblaryViewModel(ILiblaryServis liblaryServis, EditBookView editBookView)
        {
            _liblaryServis = liblaryServis;
            Books = new ObservableCollection<Book>();
            _editBookView = editBookView;
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


        public async Task DeleteProduct()
        {
            await _liblaryServis.DeleteProductAsync(selectedBook.Id);
            GetProducts();

        }

        public async Task CreateProduct()
        {
            var newProduct = new Book()
            {
                Title = selectedBook.Title,
                Description = selectedBook.Description,
                Author = selectedBook.Author,
                NumberOfBooks = selectedBook.NumberOfBooks,
            };

            var result = await _liblaryServis.AddProduct(newProduct);
            if (result.Success)
                GetProducts();
            //else
               // _messageDialogService.ShowMessage(result.Message);
        }

        public async Task UpdateProduct()
        {
            var productToUpdate = new Book()
            {
                Title = selectedBook.Title,
                Description = selectedBook.Description,
                Author = selectedBook.Author,
                NumberOfBooks = selectedBook.NumberOfBooks,
                Id = selectedBook.Id,
            };

            var  result = await _liblaryServis.ChangeProduct(productToUpdate);
            GetProducts();
            if (result.Success)
                GetProducts();
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
            if (page * 3 >= _books.LongCount())
                page--;
            LoudBooks();
        }


        [RelayCommand]
        public async Task ShowDetails(Book product)
        {
            _editBookView.Show();
            _editBookView.DataContext = this;

            SelectedBook = product;
        }

        [RelayCommand]
        public async Task New()
        {
            _editBookView.Show();
            _editBookView.DataContext = this;

            SelectedBook = new Book();
        }

        [RelayCommand]
        public async Task Delete()
        {
            DeleteProduct();
            //_editBookView.Close();
            _editBookView.Hide();
        }

        [RelayCommand]
        public async Task Save()
        {
            if (selectedBook.Id == 0)
            {
                CreateProduct();
            }
            else
            {
                UpdateProduct();
            }
            _editBookView.Close();

        }


    }
}
