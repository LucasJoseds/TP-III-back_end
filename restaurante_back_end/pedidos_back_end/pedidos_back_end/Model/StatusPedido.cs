using System.Runtime.Serialization;

namespace pedidos_back_end.Model
{
    public enum StatusPedido
    {
        [EnumMember(Value = "Preparando")] 
        Preparando,

        [EnumMember(Value = "Entregue")]
        Entregue,

        [EnumMember(Value = "Cancelado")]
        Cancelado
    }
}