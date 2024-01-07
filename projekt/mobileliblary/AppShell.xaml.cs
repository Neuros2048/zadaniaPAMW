namespace mobileliblary
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(BookDetailsView),typeof(BookDetailsView));
        }
    }
}
