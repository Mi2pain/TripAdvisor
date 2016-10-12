using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;

namespace RestApiWebCall
{
    public class RestApiWebCall
    {
        string urlAPI = "http://localhost:2729/api/";

        public static string getAllResto()
        {

        }

        public static async string getAsyncAllResto() 
        {
            using (HttpClient httpClient = new HttpClient())
            {
                if(comboBox.SelectedIndex == 1)
                // XML
                {
                    httpClient.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/xml"));//ACCEPT header
                }
                else
                //JSON
                {
                    httpClient.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                }
                
                var response = await httpClient.GetAsync(urlAPI + "Restaurant");
                return response;
        }

        public static string[] getResto(int id)
        {

        }

        public static async string[] getAsyncResto(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                if(comboBox.SelectedIndex == 1)
                // XML
                {
                    httpClient.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/xml"));//ACCEPT header
                }
                else
                //JSON
                {
                    httpClient.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                }
                
                var response = await httpClient.GetAsync(urlAPI + "Restaurant/" + id);
                return response;
        }

        public static void deleteResto(id)
        {

        }

        public static async void deleteAsyncResto(id)
        {

        }

        public static void updateResto()
        {

        }

        public static async void updateAsyncResto()
        {

        }

    }
}