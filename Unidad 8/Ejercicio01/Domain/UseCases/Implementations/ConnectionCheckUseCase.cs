using DOMAIN.UseCases.Interfaces;

namespace DOMAIN.UseCases
{
    public class ConnectionCheckUseCase : IConnectionCheckUseCase
    {
        private readonly IConnectionService _connectionService;

        public ConnectionCheckUseCase(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public string CheckConnection()
        {
            return _connectionService.CheckConnection();
        }
    }
}
