using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Infrastructure.Brokers;

public partial class MainBroker:IMainBroker
{   
    HttpClient _client;
    public MainBroker()
    {
        _client = new HttpClient();
    }
}
