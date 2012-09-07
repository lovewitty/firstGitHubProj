using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;


public class HttpData
{
    public string WebRequest(string method, string url, string postData)
    {
        HttpWebRequest webRequest = null;
        StreamWriter requestWriter = null;
        string responseData = "";

        webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        webRequest.KeepAlive = false;
        webRequest.Method = method.ToString();
        webRequest.ServicePoint.Expect100Continue = false;

        if (method == "post")
        {
            webRequest.ContentType = "application/x-www-form-urlencoded";
            requestWriter = new StreamWriter(webRequest.GetRequestStream());
            try
            {
                requestWriter.Write(postData);
            }
            catch
            {
                throw;
            }
            finally
            {
                requestWriter.Close();
                requestWriter = null;
            }
        }

        responseData = _WebResponseGet(webRequest);

        webRequest = null;

        return responseData;

    }

    public string _WebResponseGet(HttpWebRequest webRequest)
    {
        StreamReader responseReader = null;
        string responseData = "";
        try
        {
            var response = webRequest.GetResponse();
            responseReader = new StreamReader(response.GetResponseStream());
            responseData = responseReader.ReadToEnd();
        }
        catch (WebException e)
        {
            WebResponse error = e.Response;
            if (error != null)
            {
                responseReader = new StreamReader(error.GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
        }
        finally
        {
            if (responseReader != null)
            {
                responseReader.Close();
            }
            responseReader = null;
        }

        return responseData;
    }
}
