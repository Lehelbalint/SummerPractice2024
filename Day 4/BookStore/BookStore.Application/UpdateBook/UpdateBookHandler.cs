using BookStore.Data.Abstractions;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UpdateBook
{
	public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
	{
		private readonly IBookRepository bookRepository;

		public UpdateBookHandler(IBookRepository bookRepository)
		{
			this.bookRepository = bookRepository;
		}

		public async Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
		{
			await this.bookRepository.UpdateAsync(request.Book, cancellationToken);
			return new UpdateBookResponse { message = "Updated" };
		}
	}
}
