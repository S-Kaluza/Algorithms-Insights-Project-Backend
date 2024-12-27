namespace MinimalAPI_Application.Models.Domains;

public class Error
{
    public int Code { get; set; }
    public string Message { get; set; }
    public object Value { get; set; }
}