using BookStore.Application.InsertBook;
using BookStore.Data.Abstractions;
using BookStore.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DeleteBookById
{
	public class DeleteBookHandler : IRequestHandler<DeleteBookByIdRequest, DeleteBookByIdResponse>
	{
		private readonly IBookRepository bookRepository;

		public DeleteBookHandler(IBookRepository bookRepository)
		{
			this.bookRepository = bookRepository;
		}

		public async Task<DeleteBookByIdResponse> Handle(DeleteBookByIdRequest request, CancellationToken cancellationToken)
		{
			try
			{
				await bookRepository.DeleteAsync(request.Id, cancellationToken);
				return new DeleteBookByIdResponse { message = "Deleted" };
			}
			catch (Exception ex)
			{
				{
					return new DeleteBookByIdResponse { message = ex.Message };
				}
			}
		}
	}
}
