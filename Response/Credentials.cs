using Newtonsoft.Json;

namespace FinUnsize.Response;

public class Credentials
{
    public string Id { get; set; }

    public string nome { get; set; }

    public string login { get; set; }
    public string password { get; set; }

    public string email { get; set; }

    public int telefone  { get; set; }

    public int cep { get; set; }

    public string role { get; set; }

    public string cnpj { get; set; }

    public string url_image { get; set; }
}

