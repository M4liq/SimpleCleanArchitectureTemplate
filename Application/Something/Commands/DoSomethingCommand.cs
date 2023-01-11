using Application.Common.Interfaces.Core;
using Application.Common.Interfaces.Settings;
using Domain.Common;
using MediatR;

namespace Application.Something.Commands;

public static class DoSomething
{
    public record DoSomethingCommand(string id) : IRequest<Response>;
        
    public class Validator : IDomainValidationHandler<DoSomethingCommand>
    {
        private readonly ISomeSetting _someSetting;

        public Validator(ISomeSetting someSetting)
        {
            _someSetting = someSetting;
        }

        public async Task<ValidationResult> Validate(DoSomethingCommand request)
        {
            if (request.id.Contains(_someSetting.SomethingStupid))
            {
                return new ValidationResult
                {
                    IsSuccessful = false,
                    ErrorMessage = "Request can not contain such stupid shit."
                };
            }

            return new ValidationResult();
        }
    }
    
    
    public class Handler : IRequestHandler<DoSomethingCommand, Response>
    {
        public async Task<Response> Handle(DoSomethingCommand request, CancellationToken cancellationToken)
        {
            return new Response { Status = "Something has been done."};
        }
    }
    
    public record Response : BaseResponse
    {
        public string Status { get; init; }
    }
}