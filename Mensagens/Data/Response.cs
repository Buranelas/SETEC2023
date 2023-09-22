namespace Mensagens.Data;

public class Response
{
    public Response(bool sucesso, object? resposta)
    {
        if (sucesso)
        {
            this.Sucesso = true;
            this.Falha = false;
            this.Status = "Ouve sucesso na operação";
        }
        else
        {
            this.Sucesso = false;
            this.Falha = true;
            this.Status = "Ouve uma falha na operação";
        }
        this.Data = resposta;
    }

    public Response(bool sucesso, object? resposta, string mensagem)
    {
        if (sucesso)
        {
            this.Sucesso = true;
            this.Falha = false;
        }
        else
        {
            this.Sucesso = false;
            this.Falha = true;
        }
        this.Status = mensagem;
        this.Data = resposta;
    }

    public object? Data { get; set; }

    public bool Sucesso { get; set; }

    public bool Falha { get; set; }

    public string Status { get; set; }
}