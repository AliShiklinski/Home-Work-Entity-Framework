using LibraryManagementApplication.Business.Services.Interfaces;

namespace LibraryManagementApplication.Business.Services.Implementations
{
    internal interface IBorrowerRepository
    {
        void Commit();
        object GetAllWhere(Func<object, bool> value);
        object GetById(int v);
        void Insert(Borrower borrower);
    }
}