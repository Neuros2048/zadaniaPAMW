using mobileliblary.viewmodels;

namespace mobileliblary
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(BooksViewModel bookviewmodel)
        {

            BindingContext = bookviewmodel;
            InitializeComponent();


        }

        
    }

}
