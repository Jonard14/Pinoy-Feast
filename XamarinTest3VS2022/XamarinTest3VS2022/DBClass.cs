using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace XamarinTest3VS2022
{
    internal class DBClass
    {
        /*  Jonard Note:
            Nilagay ko dito para isahan edit ng IP Address
            Sa request, call this variable IP_DB then lagyan nalang ng plus 
            e.g. (HttpWebRequest)WebRequest.Create(IP_DB + "update.php?name=" + name + "&status=" + status)
         */
        string IP_DB = "http://192.168.100.204/IT123P-MPGrp7-Food/";

        //Http Response
        HttpWebResponse response;
        HttpWebRequest request;
        string res;

        public string UpdateStatus(string WebReq)
        {
            request = (HttpWebRequest)WebRequest.Create(IP_DB + WebReq);
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();
            return res;
        }

        public HttpWebResponse RetrieveData(string WebReq)
        {
            request = (HttpWebRequest)WebRequest.Create(IP_DB + WebReq);
            response = (HttpWebResponse)request.GetResponse();
            res = response.ProtocolVersion.ToString();
            return response;

            /*This part cannot return JsonElement because it'll lead to an error which says 
              "System.Text.Json Cannot access a dispose jsonDocument"
              i.e that the returned JsonDocument/JsonElement value is disposed wchih contains no value.
            */
            /*
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd();
            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;
            return root;
            */
        }
    }
}