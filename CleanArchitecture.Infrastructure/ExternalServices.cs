using CleanArchitecture.Core.Interfaces;
using Newtonsoft.Json;

namespace CleanArchitecture.Infrastructure;

public class ExternalServices : IExternalServices
{   
    private readonly HttpClient _httpClient;
    public ExternalServices()
    {
        _httpClient = new HttpClient();
    }

    public async ValueTask<TResult> Post<TResult, TRequest>(string url, TRequest content)
    {
        var oContent = JsonConvert.SerializeObject(content);

        var oResult = await _httpClient.PostAsync(url, new StringContent(oContent, System.Text.Encoding.UTF8, "application/json"));

        if (oResult.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<TResult>(await oResult.Content.ReadAsStringAsync())!;

        return default!;
    }

    public async ValueTask<HttpResponseMessage> Post<TRequest>(string url, TRequest content)
    {
        var oContent = JsonConvert.SerializeObject(content);

        var oResult = await _httpClient.PostAsync(url, new StringContent(oContent, System.Text.Encoding.UTF8, "application/json"));

        return default!;
    }

    public async ValueTask<TResult> Get<TResult>(string url)
    {
        var oResult=await _httpClient.GetStringAsync(url);

        return JsonConvert.DeserializeObject<TResult>(oResult)!;
    }


    public async ValueTask<TResult> Put<TResult, TRequest>(string url, TRequest content)
    {
        var oContent = JsonConvert.SerializeObject(content);

        var oResult = await _httpClient.PutAsync(url, new StringContent(oContent, System.Text.Encoding.UTF8, "application/json"));

        if (oResult.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<TResult>(await oResult.Content.ReadAsStringAsync())!;

        return default!;
    }

    public async ValueTask<HttpResponseMessage> Put<TRequest>(string url, TRequest content)
    {
        var oContent = JsonConvert.SerializeObject(content);

        var oResult = await _httpClient.PutAsync(url, new StringContent(oContent, System.Text.Encoding.UTF8, "application/json"));

        return default!;
    }

    public async ValueTask<HttpResponseMessage> Delete(string url)
    {
        return await _httpClient.DeleteAsync(url);
    }







}
