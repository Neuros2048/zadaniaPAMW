using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mobileliblary.services;
using mobileliblary.shared.Books;
using mobileliblary.shared.Messagebox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobileliblary.viewmodels
{
    public partial class BooksViewModel : ObservableObject
    {
        public ObservableCollection<Book> Books { get; set; }
        private List<Book> _books;

        [ObservableProperty]
        private Book selectedProduct;

        private readonly IConnectivity _connectivity;
        private readonly IMessageDialogService _messageDialogService;

        private int page = 0;
        private int number_of_pages =1;
        private int number_of_elements = 1;
        private int elem_on_page = 7; 
        private readonly ILiblaryServis _liblaryServis;
        public BooksViewModel(ILiblaryServis liblaryServis, IConnectivity connectivity, IMessageDialogService messageDialogService )
        {
            //
            _messageDialogService = messageDialogService;
            _liblaryServis = liblaryServis;
            _connectivity = connectivity;
            Books = new ObservableCollection<Book>();
            GetProducts();
        }

        public async Task GetProducts()
        {
            
            Books.Clear();
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            var productsResult = await _liblaryServis.GetProductsAsync();
            if (productsResult.Success)
            {
                number_of_elements = productsResult.Data.Count();
                number_of_pages = number_of_elements/ elem_on_page + (number_of_elements % elem_on_page == 0 ? 0 : 1);
                if (page >= number_of_pages)  page--;
                _books = productsResult.Data.ToList();
                LoudBooks();
            }
            
        }



        private void LoudBooks()
        {
            Books.Clear();
            for (int i = page * elem_on_page; i < number_of_elements && i < page * elem_on_page + elem_on_page; i++)
            {
                Books.Add(_books[i]);
            }
        }

        [RelayCommand]
        public async Task ShowDetails(Book product)
        {
            
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            await Shell.Current.GoToAsync(nameof(BookDetailsView), true, new Dictionary<string, object>
            {
                {"Book", product },
                {nameof(BooksViewModel), this }
            });
            SelectedProduct = product;
        }

        [RelayCommand]
        public async Task New()
        {
            
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            SelectedProduct = new Book();
            await Shell.Current.GoToAsync(nameof(BookDetailsView), true, new Dictionary<string, object>
            {
                {"Book", SelectedProduct },
                {nameof(BooksViewModel), this }
            });
        }


        [RelayCommand]
        public async Task Last()
        {
            page--;
            if (page < 0) page++;
            LoudBooks();
        }


        [RelayCommand]
        public async Task Next()
        {
            page++;
            if (page >= number_of_pages) page--;
            LoudBooks();
        }
    }
}
