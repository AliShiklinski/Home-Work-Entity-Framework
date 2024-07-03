using Microsoft.EntityFrameworkCore;

public class GenreService
{
    private readonly ApplicationDbContext _context;

    public GenreService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Genre> CreateGenre(Genre genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
        return genre;
    }

    public async Task<Genre> GetGenreById(int id)
    {
        return await _context.Genres.FindAsync(id);
    }

    public async Task<List<Genre>> GetAllGenres()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<Genre> UpdateGenre(Genre genre)
    {
        _context.Genres.Update(genre);
        await _context.SaveChangesAsync();
        return genre;
    }

    public async Task DeleteGenre(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre != null)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}
