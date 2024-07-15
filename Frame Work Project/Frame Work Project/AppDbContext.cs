namespace LibraryManagementApplication.Business.Services.Implementations
{
    internal class AppDbContext
    {
        public AppDbContext()
        {
        }

        public object Borrowers { get; internal set; }
        public IEnumerable<object> Loans { get; internal set; }
    }
}