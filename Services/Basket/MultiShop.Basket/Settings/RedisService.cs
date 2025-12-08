using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService : IDisposable
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer? _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
            Connect(); //redisservice çağrıldığında hemen bağlan
        }

        // Güvenli bağlantı 
        private void Connect()
        {
            if (_connectionMultiplexer != null && _connectionMultiplexer.IsConnected)
                return;

            _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        }

       
        public IDatabase GetDb(int db = 0)
        {
            if (_connectionMultiplexer == null || !_connectionMultiplexer.IsConnected)
                Connect();

            return _connectionMultiplexer!.GetDatabase(db);
        }

        // Kaynak temizleme
        public void Dispose()
        {
            if (_connectionMultiplexer != null)
            {
                _connectionMultiplexer.Close();
                _connectionMultiplexer.Dispose();
            }
        }
    }
}
