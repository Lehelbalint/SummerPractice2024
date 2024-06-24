using BookStore.Data.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.InsertBook
{
	public class InsertBookHandler : IRequestHandler<InsertBookRequest, InsertBookResponse>
	{
		private readonly IBookRepository _bookRepository;

		public InsertBookHandler(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<InsertBookResponse> Handle(InsertBookRequest request, CancellationToken cancellationToken)
		{
			try
			{
				await _bookRepository.InsertAsync(request.Book, cancellationToken);
				return new InsertBookResponse { message = "Inserted" };
			}
			catch (Exception ex)
			{
				{
					return new InsertBookResponse { message = ex.Message };
				}
			}
		}
	}
}
