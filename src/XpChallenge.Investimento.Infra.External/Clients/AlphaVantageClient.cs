﻿using XpChallenge.Investimento.Infra.External.Apis;
using XpChallenge.Investimento.Infra.External.Clients.Interfaces;

namespace XpChallenge.Investimento.Infra.External.Clients
{
    public class AlphaVantageClient(IAlphaVantageApi alphaVantageApi) : IAlphaVantageClient
    {
        private readonly IAlphaVantageApi _alphaVantageApi = alphaVantageApi;
        
        private const string API_KEY = "B5GX8X9KQAVC6RJ0";

        public async Task<decimal> ObterCotacaoAtualAsync(string nomeProdutoFinanceiro, CancellationToken cancellationToken)
        {
            var nomeFormatado = $"{nomeProdutoFinanceiro}.SA";
            var response = await _alphaVantageApi.ObterCotacoesAsync(nomeFormatado, API_KEY, cancellationToken);

            if (response == null || response.CotacaoGlobal == null || response.CotacaoGlobal.CotacaoAtual == null)
            {
                return 0;
            }

            var valor = decimal.Parse(response.CotacaoGlobal.CotacaoAtual, System.Globalization.CultureInfo.InvariantCulture);
            return Math.Round(valor, 2);
        }
    }
}
