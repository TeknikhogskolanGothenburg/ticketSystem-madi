using MVCWebCodeByMadi.Models;
using Microsoft.IdentityModel.Protocols;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace MVCWebCodeByMadi.Helper
{
    public class VenuesRestClient 
    {
        private readonly RestClient _client;


        public List<Venues> GetVenues()
        {
            var client = new RestClient("http://localhost:50255");
            var request = new RestRequest("api/venues", Method.GET);
            var response = client.Execute<List<Venues>>(request);


            return response.Data;

        }

        public void AddNewVenue()
        {
            var client = new RestClient("http://localhost:50255/");
            var request = new RestRequest("api/venues", Method.POST);
            var response = client.Execute(request);
        }


        
       
    }
}