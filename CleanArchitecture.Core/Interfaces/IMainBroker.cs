namespace CleanArchitecture.Core.Interfaces;

public interface IMainBroker
{
    string Get(string url);
    string Delete(string url);
    string Put(string url, string content);
    string Post(string url, string content);


}
