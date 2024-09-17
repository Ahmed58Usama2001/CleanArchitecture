namespace CleanArchitecture.Infrastructure.Brokers;

public partial class MainBroker
{
    public string Post(string url,string content)
    {
        return $" {url} {content}";
    }
}
