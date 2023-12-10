namespace FinUnsize.Pages.Product.Business;

public class ProductCreate
{
    public string cod_barras { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public InfoCreate Informacoes { get; set; }
    public string Fornecedor { get; set; }
    public string Validade { get; set; }
    public string Descricao { get; set; }
    public decimal Varejo { get; set; }
    public decimal Atacado { get; set; }
    public string url_image { get; set; }
}