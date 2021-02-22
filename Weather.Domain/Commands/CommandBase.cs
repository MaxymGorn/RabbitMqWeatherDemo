using MediatR;

namespace Rectangle.Domain.Commands
{
    public class CommandBase<TResult> : IRequest<TResult> 
    {
        
    }
}