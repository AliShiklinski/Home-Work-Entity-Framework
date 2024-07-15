namespace LibraryManagementApplication.Business.Services.Implementations
{
    internal interface IAuthorRepository
    {
        void Commit();
        object GetById(int v);
    }
}