namespace IRTxtDispatcher.DTO;
public class SendResult
{
    public bool IsSuccess { get; set; } = false;
    public string ErrorCode { get; set; } = default!;
    public string ErrorTitle { get; set; } = default!;
    public string UniqueId { get; set; } = default!;
    public string Number { get; set; } = default!;
    public string Message { get; set; } = default!;
    public string LineNumber { get; set; } = default!;
}