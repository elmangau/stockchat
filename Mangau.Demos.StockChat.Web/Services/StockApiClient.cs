using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mangau.Demos.StockChat.Web.Services
{
    public interface ISockApiClient
    {
        Task<string> GetStockValue(string stockCode, CancellationToken cancellationToken = default);
    }

    public class StockApiClient : ISockApiClient
    {
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly HttpClient _client;

        public StockApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetStockValue(string stockCode, CancellationToken cancellationToken = default)
        {
            try
            {
                var api = $"?s={stockCode}&f=sd2t2ohlcv&h=&e=csv";
                var uri = new Uri(api, UriKind.Relative);
                var response = await _client.GetAsync(uri, cancellationToken);
                var cliresstr = await response.Content.ReadAsStringAsync();

                return cliresstr;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error calling stock API");
            }

            return string.Empty;
        }
    }
}
