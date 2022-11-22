// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

/*
 To try this client
 1) run the RestAPI_01_HelloWorld Web APi solutuion
   - you can run it inside Visual studio and set a breakpoint in HelloController on the  GetHelloGreeting method 
 2) run this client code 
*/


try
{
    //1)  create an instacne of HttpClient
    using (HttpClient client = new HttpClient())
    {
        //2)  init the base address of the Webservice we are calling
        client.BaseAddress = new Uri("http://localhost:5145/");                             // base URL for API Controller i.e. Must be URL for API

        //3) Set the media types this client will accept (in this case, for a webservice,  JSON) by adding an Accept header 
        client.DefaultRequestHeaders.
                Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));         // or application/xml or application/bson

        //4) Call the Webapi using  a get Gttp request (we pass in the URL (wihout base address part as we already set that) 
        HttpResponseMessage response = await client.GetAsync("api/hello?name=John");

        //5 we can then check the Http response we get back to see if it succeeded
        if (response.IsSuccessStatusCode)
        {
            // parse result 
            //String message = response.Content.ReadAsAsync<string>().Result;                  // accessing the Result property blocks
            String message = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(message);                                                     // the greeting
        
        }
        else
        {
            Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}
