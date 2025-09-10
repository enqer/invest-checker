using MediatR;

namespace InvestChecker.Application.Common.Abstractions.Messaging;

public interface ICommand : IRequest;

public interface ICommand<TResult> : IRequest<TResult>;
