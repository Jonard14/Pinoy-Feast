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

namespace GROUP7_IT123P_MP
{
    internal class DBClass
    {
        /*  Jonard Note:
            Nilagay ko dito para isahan edit ng IP Address
            Sa request, call this variable IP_DB then lagyan nalang ng plus 
            e.g. (HttpWebRequest)WebRequest.Create(IP_DB + "update.php?name=" + name + "&status=" + status)
         */
        string IP_DB = "http://192.168.200.210/IT123P-MPGrp7-Food/";

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

        }
    }
}

/* Table of 'fooddata'
CREATE TABLE `fooddata` (
`name` varchar(100) NOT NULL,
`imgfile` varchar(100) NOT NULL,
`description` text NOT NULL,
`status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

NOTE: tinyint is boolean and has only 0 or 1 value
*/