using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mobileliblary.services;
using mobileliblary.shared.Books;
using mobileliblary.shared.Messagebox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobileliblary.viewmodels
{
    [QueryProperty(nameof(Book), nameof(Book))]
    [QueryProperty(nameof(BooksViewModel), nameof(BooksViewModel))]
    public partial class BookDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        Book book;

        private readonly BooksViewModel _booksViewModel;
        private readonly ILiblaryServis _liblaryServis;
        private readonly IMessageDialogService _messageDialogService;


        public BookDetailViewModel(BooksViewModel booksViewModel,ILiblaryServis liblaryServis, IMessageDialogService messageDialogService)
        {
            _booksViewModel = booksViewModel;
            _liblaryServis  = liblaryServis;
            _messageDialogService = messageDialogService;
        }


        public async Task DeleteProduct()
        {
            await _liblaryServis.DeleteProductAsync(book.Id);
            await _booksViewModel.GetProducts();
        }

        public async Task CreateProduct()
        {
            var newProduct = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                NumberOfBooks   = book.NumberOfBooks,
            };

            var result = await _liblaryServis.AddProduct(newProduct);
            if (result.Success)
                await _booksViewModel.GetProducts();
            else
                _messageDialogService.ShowMessage(result.Message);
            await _booksViewModel.GetProducts();
        }

        public async Task UpdateProduct()
        {
            var productToUpdate = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,   
                NumberOfBooks = book.NumberOfBooks,
            };

            await _liblaryServis.ChangeProduct(productToUpdate);
            await _booksViewModel.GetProducts();
        }


        [RelayCommand]
        public async Task Save()
        {
            if (book.Id == 0)
            {
                CreateProduct();
                await Shell.Current.GoToAsync("../", true);

            }
            else
            {
                UpdateProduct();
                await Shell.Current.GoToAsync("../", true);
            }

        }

        [RelayCommand]
        public async Task Delete()
        {
            DeleteProduct();
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
