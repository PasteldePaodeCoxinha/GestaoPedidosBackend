using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoApi;

[Table("pedido")]
public class Pedido
{   
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("cliente")]
    public string Cliente { get; set; } = "";

    [Column("produto")]
    public string Produto { get; set; } = "";

    [Column("valor")]
    public double Valor { get; set; }

    [Column("status")]
    public Status Status { get; set; } = Status.Pendente;

    [Column("data_criacao")]
    public DateOnly DataCriacao { get; set; } = DateOnly.FromDateTime(DateTime.Today);
}
