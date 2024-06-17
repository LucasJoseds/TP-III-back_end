using System.Runtime.Serialization;

namespace pedidos_back_end.Model
{
    public enum StatusPedido
    {
        [EnumMember(Value = "Aguardando")]
        Aguardando,

        [EnumMember(Value = "Preparando")] 
        Preparando,

        [EnumMember(Value = "Finalizado")]
        Finalizado,

        [EnumMember(Value = "Cancelado")]
        Cancelado
    }
}