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
using Microsoft.Extensions.DependencyInjection;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class LiblaryViewModel : ObservableObject
    {
        public ObservableCollection<Book> Books { get; set; }
        private readonly ILiblaryServis _liblaryServis;
        private readonly EditBookView _editBookView;
        private readonly IServiceProvider _serviceProvider;

        private String token;


        [ObservableProperty]
        private Book selectedBook;

        public LiblaryViewModel(ILiblaryServis liblaryServis, EditBookView editBookView, IServiceProvider serviceProvider)
        {
            _liblaryServis = liblaryServis;
            Books = new ObservableCollection<Book>();
            _editBookView = editBookView;
            token = null;
            _serviceProvider  = serviceProvider;
        }
        private int page = 0;
        private List<Book> _books;
        public async void GetProducts()
        {
            if (token != null)
            {
                var productsResult = await _liblaryServis.GetProductsAsync();
                if (productsResult.Success)
                {
                    _books = productsResult.Data;
                    LoudBooks();
                }
            }
        }

        public void setToken(String _token)
        {
            this.token = _token;
        }
        public void nullToken()
        {
            token = null;
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
            if (token != null)
            {
                await _liblaryServis.DeleteProductAsync(selectedBook.Id);
                GetProducts();
            }
        }

        public async Task CreateProduct()
        {
            if (token != null)
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
        }

        public async Task UpdateProduct()
        {
            if (token != null)
            {
                var productToUpdate = new Book()
                {
                    Title = selectedBook.Title,
                    Description = selectedBook.Description,
                    Author = selectedBook.Author,
                    NumberOfBooks = selectedBook.NumberOfBooks,
                    Id = selectedBook.Id,
                };

                var result = await _liblaryServis.ChangeProduct(productToUpdate);
                GetProducts();
                if (result.Success)
                    GetProducts();
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
            if (page * 3 >= _books.LongCount())
                page--;
            LoudBooks();
        }


        [RelayCommand]
        public async Task ShowDetails(Book product)
        {
            if (token != null)
            {
                _editBookView.Show();
                _editBookView.DataContext = this;

                SelectedBook = product;
            }
        }

        [RelayCommand]
        public async Task New()
        {
            if (token != null)
            {
                _editBookView.Show();
                _editBookView.DataContext = this;

                SelectedBook = new Book();
            }
        }

        [RelayCommand]
        public async Task Delete()
        {
            if (token != null)
            {
                DeleteProduct();
                //_editBookView.Close();
                _editBookView.Hide();
            }
        }

        [RelayCommand]
        public async Task Save()
        {
            if (token != null)
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

        [RelayCommand]
        public async Task Logout()
        {
            nullToken();
            Books.Clear();
            _books.Clear();
        }

        [RelayCommand]
        public async Task Changepass()
        {
            if (token != null)
            {
                CHangePasswordView changePasswordView = _serviceProvider.GetService<CHangePasswordView>();
                changePasswordView.Show();
            }
        }

    }
}
