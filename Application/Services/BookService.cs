using Domain.Model;
using Infrastructure.Database;
using MediatR;

namespace Application
{
    public class BookService(FakeDatabase database)
    {
        internal readonly IMediator _mediator; 
        private readonly FakeDatabase _database = database; 

        //public async Task<IActionResult> GetBookById(Guid bookId)
        //{
        //    Book book = await _database.GetBookById(bookId);
        //    return book; 
        //}

        //public async void AddBook(Book book)
        //{
        //    Book bookToAdd = new Book("Book of Tired", "Vladamir", "ZZZ");
        //    await _mediator.Send(new CreateBookCommand(book));
        //}


        public async Task<Book> UpdateBook(Book book)
        {
            Book updatedBook = await _database.UpdateBook(book);
            return updatedBook; 
        }

        //public async Task<Book> DeleteBook(Guid id)
        //{
        //    var result = await _database.DeleteBook(id);
        //    return result; 
        //}
    }
}