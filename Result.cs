namespace Rplace;

// DTO (data transfer object: tranfere dados) para retornar o resultado de uma requisição
public record Result<T>(
    T Data, // os dados
    bool IsSuccess, // booleano se deu certo ou não
    string Reason // razão se deu errado
)
{
    public static Result<T> Success(T data) // se der certo                                                                                                                                                                                                                                               
    => new(data, true, string.Empty);
    public static Result<T> Fail(string reason) // se der errado
    => new(default, false, reason);
}