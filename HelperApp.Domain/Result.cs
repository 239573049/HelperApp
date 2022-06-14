namespace HelperApp.Domain;

public class ResponseView<T>
{
    public string Code { get; set; }
    public T Data { get; set; }

    public string Message { get; set; }
}
