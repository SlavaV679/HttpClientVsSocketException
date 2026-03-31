// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

for (int i = 0; i < 10000; i++)
{
    // Каждый раз создаём новый HttpClient (очень плохая практика)
    //using 
    var httpClient = new HttpClient();
    
        try
        {
            // Попытка сделать запрос
            HttpResponseMessage response = await httpClient.GetAsync("https://webhook.site/fc3a4f61-74bb-4444-bd98-5ca015171d3b");
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Request {i} succeeded");
        }
        catch (System.Net.Sockets.SocketException ex)
        {
            // Здесь вы увидите ошибку истощения сокетов при большом числе вызовов
            Console.WriteLine($"SocketException on request {i}: {ex.Message}");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Other exception on request {i}: {ex.Message}");
        }
}