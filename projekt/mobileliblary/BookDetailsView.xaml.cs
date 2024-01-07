using mobileliblary.viewmodels;

namespace mobileliblary;

public partial class BookDetailsView : ContentPage
{
	public BookDetailsView(BookDetailViewModel bookDetailViewModel)
	{
        BindingContext = bookDetailViewModel;
        InitializeComponent();
    }
}