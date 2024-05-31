using Apache.Ignite.Core.Client;
using Apache.Ignite.Core;

namespace NoSqlDBInMemory
{
    public class IgniteClientSingleton
    {
        private static IIgniteClient _igniteClient;

        public static IIgniteClient GetClient()
        {
            if (_igniteClient == null)
            {
                var clientConfiguration = new IgniteClientConfiguration
                {
                    Endpoints = new List<string>
                {
                    "apache:10800"
                }
                };

                _igniteClient = Ignition.StartClient(clientConfiguration);
            }

            return _igniteClient;
        }
    }
}
