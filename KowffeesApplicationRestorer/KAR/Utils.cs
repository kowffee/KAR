using static System.ConsoleColor;

namespace KAR
{
    internal class Utils
    {
        internal static class Printer
        {
            static object _lock = new object();
            internal static void Print(string text = "", ConsoleColor color = ConsoleColor.White)
            {
                lock (_lock)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(text);
                }
            }
        }



        internal static class Network
        {
            internal static async Task<string> GetString(string apiUrl)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            return responseBody;
                        }
                        else
                        {
                            return response.StatusCode.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        return "Exception: " + ex.Message;
                    }
                }
            }

            internal static async Task DownloadFile(string fileUrl, string fileName)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(fileUrl);

                        // Check if the request was successful (status code 200-299)
                        if (response.IsSuccessStatusCode)
                        {
                            Stream fileStream = await response.Content.ReadAsStreamAsync();

                            string filePath = Path.Combine("KARInstalls", fileName);

                            using (FileStream fs = File.Create(filePath))
                            {
                                await fileStream.CopyToAsync(fs);
                            }

                            Printer.Print($"{fileName} downloaded successfully to: {filePath}", Green);
                        }
                        else
                        {
                            Printer.Print("Error: " + response.StatusCode, Red);
                        }
                    }
                    catch (Exception ex)
                    {
                        Printer.Print("Exception: " + ex.Message, Red);
                    }
                }
            }
        }
    }
}
