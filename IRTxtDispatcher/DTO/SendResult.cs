namespace IRTxtDispatcher.DTO;
public class SendResult
{
    public bool IsSuccess { get; set; } = false;
    public string ErrorCode { get; set; } = default!;
    public string ErrorTitle { get; set; } = default!;
}