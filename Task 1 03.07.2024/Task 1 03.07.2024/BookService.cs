using Microsoft.EntityFrameworkCore;

public class BookService
{
    private readonly ApplicationDbContext _context;

    public BookService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Book> CreateBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> GetBookById(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _context.Books.Include(b => b.Genre).ToListAsync();
    }

    public async Task<Book> UpdateBook(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
