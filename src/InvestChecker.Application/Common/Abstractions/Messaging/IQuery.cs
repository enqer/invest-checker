using MediatR;

namespace InvestChecker.Application.Common.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>;