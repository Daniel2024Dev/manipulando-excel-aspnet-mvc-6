namespace AgendaVeicular.Models;

public class PropertyAnotacaoModel
{
    // Propriedade que armazena o identificador único da Anotação
    public int IdAnotacao { get; set; }

    // Propriedade que armazena a data e hora da criação ou última atualização da Anotação
    public DateTime DataAtual { get; set; }

    // Propriedade que armazena os registros ou conteúdo da Anotação
    // O tipo é marcado com ? indicando que pode ser nulo
    public string? Registros { get; set; }
}
