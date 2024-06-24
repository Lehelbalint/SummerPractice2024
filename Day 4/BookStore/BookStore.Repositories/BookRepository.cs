using BookStore.Data.Abstractions;
using BookStore.Domain;
using MongoDB.Driver;

namespace BookStore.Repositories
{
  public class BookRepository : IBookRepository
  {
    private readonly IMongoCollection<Book> books;

      public BookRepository(IDatabase database)
    {
      books = database.GetCollection<IMongoCollection<Book>, Book>("Books");
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
			var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
			var response= await books.DeleteOneAsync(filter, cancellationToken);
            return response != null;
    }

	public async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
	{
		var allBooks = await books.Find(Builders<Book>.Filter.Empty).Limit(1000).ToListAsync(cancellationToken); 
		return allBooks;
	}

	public async Task<Book> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
      var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
      var book = await this.books.Find(filter).FirstAsync(cancellationToken);
      return book;
    }

    public async Task<string> InsertAsync(Book item, CancellationToken cancellationToken)
    {
      
      await this.books.InsertOneAsync(item, cancellationToken);
      return item.Id;
    }

        public async Task<bool> UpdateAsync(Book item, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(b => b.Id, item.Id);
            var response = await this.books.ReplaceOneAsync(filter, item, new ReplaceOptions(), cancellationToken);
			return response != null;
		}	    
  }
}
