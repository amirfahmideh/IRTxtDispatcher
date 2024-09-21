using System.Net;
using IRTxtDispatcher.DTO;
using IRTxtDispatcher.Interface;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace IRTxtDispatcher.Implementation;

public class Negin : IOperation
{
    private readonly HttpClient httpClient;
    public Negin()
    {
        httpClient = new HttpClient();
    }
    public string ServerUrl => "https://sms.3300.ir/api/wssend.ashx";

    public string ImplementSummery()
    {
        return "نگین ارتباط الماس";
    }

    public async Task<List<SendResult>> SendAsync(SendConfiguration configuration, List<Send> messages)
    {
        List<SendResult> sendingResults = [];
        foreach (var message in messages)
        {
            var data = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",configuration.Username),
                new KeyValuePair<string, string>("password",configuration.Password ),
                new KeyValuePair<string, string>("mobile",message.Number ),
                new KeyValuePair<string, string>("message",message.Message ),
                new KeyValuePair<string, string>("line",configuration.LineNumber),                
                // new KeyValuePair<string, string>("type","2" ), برای ارسال پیامک فعالسازی با خط خدماتی شرکت
            };
            try
            {
                var response = await httpClient.PostAsync("https://sms.3300.ir/api/wssend.ashx", new FormUrlEncodedContent(data));
                if (response.IsSuccessStatusCode)
                {
                    NeginResult? res = JsonSerializer.Deserialize<NeginResult>(await response.Content.ReadAsStreamAsync());
                    if (res != null && res.status == -1)
                    {
                        sendingResults.Add(new SendResult()
                        {
                            IsSuccess = true,
                            ErrorCode = string.Empty,
                            ErrorTitle = string.Empty,
                            LineNumber = configuration.LineNumber,
                            Message = message.Message,
                            Number = message.Number,
                            UniqueId = res.data.message_id.ToString()
                        });
                    }
                    else
                    {
                        sendingResults.Add(new SendResult()
                        {
                            IsSuccess = false,
                            ErrorCode = (res != null && res?.status != null) ? $"{res?.status}" : string.Empty,
                            ErrorTitle = res?.msg ?? string.Empty,
                        });
                    }
                }
            }
            catch (Exception e)
            {
                sendingResults.Add(new SendResult()
                {
                    IsSuccess = false,
                    ErrorCode = message.Number,
                    ErrorTitle = e.Message,
                });
                continue;
            }
        }
        return sendingResults;
    }
}


public class NeginMessageResult
{
    public long message_id { get; set; }
    public long line { get; set; }
    public long mobile { get; set; }
}

public class NeginResult
{
    public NeginMessageResult data { get; set; }
    public int status { get; set; }
    public string msg { get; set; }
}