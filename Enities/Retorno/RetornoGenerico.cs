namespace Entities.Retorno;

public  class RetornoGenerico<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Result { get; set; }
}
