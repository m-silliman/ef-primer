/**************************************************************************\
Event2 Name:  SimpleRestClient.cs
Project:      Deadline Solutions Standard Library
Copyright (c) Deadline Solutions, Inc.

 * * 

All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace AiLEndpointCall
{
    public static class SimpleRestClient
    {
        public static string Post(string uri, byte[] postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/octet-stream";

            request.ContentLength = postData.Length;

            StreamWriter postStream = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            postStream.Write(Encoding.ASCII.GetChars(postData), 0, postData.Length);
            postStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string target = string.Empty;
            try
            {
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), true);
                try
                {
                    target = streamReader.ReadToEnd();
                }
                finally
                {
                    streamReader.Close();
                }
            }
            finally
            {
                response.Close();
            }

            return target;
        }

        public static string Post(string uri, string postData, string username = "", string password = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Post;

            //string encodedPostData = System.Net.WebUtility.UrlEncode($"ctx={postData}");
            string postDataWithCtx = $"ctx={postData}";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataWithCtx.Length;

            if (!string.IsNullOrEmpty(username))
            {
                string authInfo = username + ":" + password;
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers["Authorization"] = "Basic " + authInfo;
            }

            StreamWriter postStream = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            postStream.Write(postDataWithCtx);
            postStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string target = string.Empty;

            try
            {
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), true);
                try
                {
                    target = streamReader.ReadToEnd();
                }
                finally
                {
                    streamReader.Close();
                }
            }
            finally
            {
                response.Close();
            }

            return target;
        }

        public static string Get(string url, string username = "", string password = "")
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 5000; 

                if (!string.IsNullOrEmpty(username))
                {
                    string authInfo = username + ":" + password;
                    authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                    request.Headers["Authorization"] = "Basic " + authInfo;
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(String.Format(
                            "Server error (HTTP {0}: {1}).",
                            response.StatusCode,
                            response.StatusDescription));
                    }

                    StreamReader rdr = new StreamReader(response.GetResponseStream());
                    return rdr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                var v = new {Success = false, ErrorMessage = e.Message};
                return Newtonsoft.Json.JsonConvert.SerializeObject(v);
            }
        }
    }
}
