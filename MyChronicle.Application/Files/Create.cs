﻿using FluentValidation;
using MediatR;
using MyChronicle.Infrastructure;

namespace MyChronicle.Application.Files
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required Guid PersonId { get; set; }
            public required FileDTO FileDTO { get; set; }

        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FileDTO).SetValidator(new FileDTOValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.FileDTO.PersonId != request.PersonId)
                {
                    return Result<Unit>.Failure($"Not matching Id. Request PersonId was {request.PersonId}. Request File PersonId was {request.FileDTO.PersonId}");
                }

                var person = await _context.Persons.FindAsync(request.PersonId);
                if (person == null) return Result<Unit>.Failure($"The Person with Id {request.FileDTO.Id} could not be found", ErrorCategory.NotFound);

                var file = new Domain.File
                {
                    Id = request.FileDTO.Id,
                    Name = request.FileDTO.Name,
                    FileType = request.FileDTO.FileType,
                    Content = request.FileDTO.Content,
                    FileExtension = request.FileDTO.FileExtension,
                    PersonId = request.PersonId,
                    Person = person
                };

                _context.Files.Add(file);
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create File"); 
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
