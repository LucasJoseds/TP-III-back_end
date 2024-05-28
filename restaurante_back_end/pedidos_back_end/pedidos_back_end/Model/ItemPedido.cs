
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pedidos_back_end.Model
{
    public class ItemPedido
    {   
        [Key]
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public float? Valor { get; set; }

        public int CardapioId { get; set; }

        [ForeignKey("CardapioId")]

        [JsonIgnore]
        public Cardapio? Cardapio { get; set; }  

        public int PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        [JsonIgnore]
        public Pedido? Pedido{ get; set; }

    }
}