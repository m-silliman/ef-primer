using System;
using System.Collections.Generic;
using System.Configuration;

namespace AiLEndpointCall
{
    public class AilAppGeneric<TResult> where TResult : new()
    {
        
    }

    public class AilAppService 
    {
        string urlTemplate = @"{0}/api/";

        public string Url { get; set; }
        
        public AilAppService()
        {
            string remoteHost = ConfigurationManager.AppSettings["remoteHost"];
            if (string.IsNullOrEmpty(remoteHost))
                remoteHost = @"http://localhost:8000/";

            Url = string.Format(urlTemplate, remoteHost);
        }

       
        public List<string> GetExpiredQueues()
        {
            string url = Url + "ExpiredQueues";
            string result = SimpleRestClient.Get(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(result);
        }

        public List<ScriptDefinition> GetEndpointScripts()
        {
            string url = Url + @"scripts/production/EndpointModule";
            string result = SimpleRestClient.Get(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ScriptDefinition>>(result);
        }

        public string ExecuteEndpoint(string name, dynamic args)
        {
            string argString = Newtonsoft.Json.JsonConvert.SerializeObject(args, Newtonsoft.Json.Formatting.Indented);
            string url = Url + $@"EndPoint/{name}";

            return SimpleRestClient.Post(url, argString);
        }

        public string ExecuteEndpointSecure(Credentials c, string name, dynamic args)
        {
            string argString = Newtonsoft.Json.JsonConvert.SerializeObject(args, Newtonsoft.Json.Formatting.Indented);
            string url = Url + $@"EndPoint/{name}";

            return SimpleRestClient.Post(url, argString, c.Username, c.Password);
        }

        public TResult ExecuteEndpoint<TResult>(string function, dynamic context) where TResult : new()
        {
            Newtonsoft.Json.JsonSerializerSettings serializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
            };

            string result = ExecuteEndpoint(function, context);
            ScriptResult<TResult> theResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ScriptResult<TResult>>(result, serializerSettings);

            if (theResult.Success)
                return theResult.Context;

            throw new Exception(theResult.Message);
        }

        public TResult ExecuteEndpointSecure<TResult>(Credentials c, string function, dynamic context) where TResult : new()
        {
            Newtonsoft.Json.JsonSerializerSettings serializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
            };

            string result = ExecuteEndpointSecure(c, function, context);
            ScriptResult<TResult> theResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ScriptResult<TResult>>(result, serializerSettings);

            if (theResult.Success)
                return theResult.Context;

            throw new Exception(theResult.Message);
        }

    }

}
