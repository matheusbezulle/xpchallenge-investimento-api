﻿using MediatR;

namespace XpChallenge.Investimento.Application.Commands.ComprarProdutoFinanceiro
{
    public class ComprarProdutoFinanceiroCommand(Guid idCliente, string nome, int quantidade) : IRequest<ComprarProdutoFinanceiroCommandResponse>
    {
        public Guid IdCliente { get; set; } = idCliente;
        public string NomeProdutoFinanceiro { get; set; } = nome;
        public int Quantidade { get; set; } = quantidade;
    }
}
