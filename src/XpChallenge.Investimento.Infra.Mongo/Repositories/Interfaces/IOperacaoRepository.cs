﻿using XpChallenge.Investimento.Domain.AggregateRoots;

namespace XpChallenge.Investimento.Infra.Mongo.Repositories.Interfaces
{
    public interface IOperacaoRepository
    {
        Task<List<Operacao>> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken);
        Task CriarAsync(Carteira carteira, Operacao operacao, CancellationToken cancellationToken);
    }
}
