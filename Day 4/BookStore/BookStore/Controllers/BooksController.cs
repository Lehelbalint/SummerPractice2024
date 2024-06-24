using BookStore.Application.DeleteBookById;
using BookStore.Application.GetAllBooks;
using BookStore.Application.GetBookById;
using BookStore.Application.GetWeatherForecast;
using BookStore.Application.InsertBook;
using BookStore.Application.UpdateBook;
using BookStore.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BooksController : ControllerBase
	{
		private readonly IMediator mediator;
		public BooksController(IMediator mediator)
		{
			this.mediator = mediator;
		}
		[HttpGet(Name = "GetBook/{id}")]
		public async Task<IActionResult> Get(string id, CancellationToken token)
		{
			var response = await this.mediator.Send(new GetBookByIdRequest { Id = id }, token);
			return this.Ok(response);
		}

		[HttpGet("GetAllBooks")]
		public async Task<IActionResult> GetBooks(CancellationToken token)
		{
			var response = await this.mediator.Send(new GetAllBooksRequest(), token);
			return this.Ok(response);
		}

		[HttpPost("InsertBook")]
		public async Task<IActionResult> Insert([FromBody] Book book, CancellationToken token)
		{
			if (book == null)
			{
				return BadRequest();
			}

			var response = await this.mediator.Send(new InsertBookRequest { Book = book }, token);

			return response.message == "Inserted" ? Ok() : StatusCode(500);
		}
		[HttpDelete("DeleteBook/{id}")]
		public async Task<IActionResult> Delete(string id, CancellationToken token)
		{
			if (string.IsNullOrEmpty(id))
			{
				return BadRequest("Id must be provided.");
			}
			var response = await this.mediator.Send(new DeleteBookByIdRequest { Id =id }, token);	
			return response.message == "Deleted" ? this.Ok(): StatusCode(500);
		}
		[HttpPut("Update")]
		public async Task<IActionResult> Update([FromBody] Book book, CancellationToken cancellationToken)
		{
			var result = await this.mediator.Send(new UpdateBookRequest { Book = book }, cancellationToken);
			return result.message == "Updated"? Ok() : StatusCode(500);
		}

	}

	/*
	 * GetAllAsync
	 * InsertAsync
	 * DeleteAsync
	 * UpdateAsync
	 */
}

