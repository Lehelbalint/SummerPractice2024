using FluentValidation;
using MongoDB.Bson;
using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.InsertBook
{
	public class InsertBookValidator : AbstractValidator<InsertBookRequest>
	{
        public InsertBookValidator()
        {
			RuleFor(x => x.Book.Id)
			   .NotEmpty().WithMessage("Id is required.")
			   .Must(BeAValidObjectId).WithMessage("Id must be a valid ObjectId.");
			RuleFor(x => x.Book.AuthorId)
			   .NotEmpty().WithMessage("Id is required.")
			   .Must(BeAValidObjectId).WithMessage("Id must be a valid ObjectId.");
			RuleFor(x => x.Book.PublisherId)
			   .NotEmpty().WithMessage("Id is required.")
			   .Must(BeAValidObjectId).WithMessage("Id must be a valid ObjectId.");
		}
		private bool BeAValidObjectId(string id)
		{
			return ObjectId.TryParse(id, out _);
		}
	}
}
