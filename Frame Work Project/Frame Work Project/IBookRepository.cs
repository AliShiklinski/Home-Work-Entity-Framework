using LibraryManagementApplication.Business.Services.Interfaces;

namespace LibraryManagementApplication.Business.Services.Implementations
{
    internal interface IBookRepository
    {
        void Commit();
        IEnumerable<object> GetAll();
        object GetAllWhere(Func<object, bool> value);
        object GetById(int v);
        void Insert(Book book);
    }
}