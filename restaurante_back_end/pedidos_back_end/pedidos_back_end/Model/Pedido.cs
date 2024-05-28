
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pedidos_back_end.Model
{
    public class Pedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataPedido { get; set; }

        [EnumDataType(typeof(StatusPedido))]
        public StatusPedido Status { get; set; }
        
        [ForeignKey("ClienteId")]
        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        public ICollection<ItemPedido>? Itens { get; set; }
        public int NumeroMesa {get ; set;}
    }
}