using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieAppAPI.Models
{
    public class MovieDAL
    {
        public MovieModel GetMovie(string keyword)
        {// urls in C# need https://
            string url = $"http://www.omdbapi.com/?apikey=93fc2d72&t={keyword}";




            // request is called request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //response is called response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //this will allow it to read the response but won't be readable for humans
            StreamReader reader = new StreamReader(response.GetResponseStream());

            //This converts the data read in the stream reader into a c# class
            string JSON = reader.ReadToEnd();

            // takes the string and turns it into an object
            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result;
        }










    }
}
