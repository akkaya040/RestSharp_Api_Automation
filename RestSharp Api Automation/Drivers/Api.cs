using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace RestSharp_Api_Automation.Drivers;

public class Api
{
    public RestClient? restClient { get; set; }
    public RestRequest? restRequest { get; set; }
    public RestResponse? restResponse { get; set; }
    public string? baseUrl { get; set; }
    public string? endPoint { get; set; }
    public string? responseString { get; set; }
    
    
    public RestResponse GetRequest(string endP, Dictionary<string, string>? headers = null)
    {
        restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
        restRequest = new RestRequest(endP, Method.Get);
        restRequest.AddHeader("Content-Type", "application/json");
        restRequest.AddHeader("Accept", "application/json");

        if (headers != null)
        {
            foreach (var header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
        }

        restResponse = restClient.ExecuteGetAsync(restRequest).GetAwaiter().GetResult();
        responseString = restResponse.Content;

        return restResponse;
    }
    
    public RestResponse PostRequest(string endP, string? body = null,
        Dictionary<string, string>? headers = null)
    {
        restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
        restRequest = new RestRequest(endP, Method.Post);

        restRequest.AddHeader("Content-Type", "application/json;charset=utf-8");
        restRequest.AddHeader("Accept", "*/*");
        restRequest.AddHeader("Connection", "keep-alive");
        restRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");

        if (headers != null)
        {
            foreach (var header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
        }
        
        if (body != null)
        {
            restRequest.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
        }

        restResponse = restClient.ExecutePostAsync(restRequest).GetAwaiter().GetResult();
        responseString = restResponse.Content;
        return restResponse;
    }
    
    public RestResponse PostRequest(string endP, Dictionary<string, string>? body = null,
        Dictionary<string, string>? headers = null)
    {
        restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
        restRequest = new RestRequest(endP, Method.Post);

        restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
        restRequest.AddHeader("Accept", "application/json, text/plain, */*");

        if (headers != null)
        {
            foreach (var header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
        }

        if (body != null)
        {
            foreach (var param in body)
            {
                restRequest.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);
            }
        }

        restResponse = restClient.ExecutePostAsync(restRequest).GetAwaiter().GetResult();
        responseString = restResponse.Content;
        return restResponse;
    }
    
}