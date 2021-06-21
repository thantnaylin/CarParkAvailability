using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CarParkAvailability.DataMangers
{
    public class CarParkManager
    {
        public async Task<object> GetCarParkAvailabilityData(string baseUrl)
        {
            string currentDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            string url = baseUrl + "?date_time=" + currentDateTime;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                return data;
                            }
                            else
                            {
                                throw new Exception("Error occured during fetching data.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
