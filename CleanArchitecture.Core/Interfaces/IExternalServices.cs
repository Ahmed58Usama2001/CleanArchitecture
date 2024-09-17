namespace CleanArchitecture.Core.Interfaces;

public interface IExternalServices
{
    ValueTask<TResult> Post<TResult, TRequest>(string url, TRequest content);
    ValueTask<HttpResponseMessage> Post<TRequest>(string url, TRequest content);

    ValueTask<TResult> Get<TResult>(string url);

    ValueTask<TResult> Put<TResult, TRequest>(string url, TRequest content);
    ValueTask<HttpResponseMessage> Put<TRequest>(string url, TRequest content);

    ValueTask<HttpResponseMessage> Delete(string url);

}
