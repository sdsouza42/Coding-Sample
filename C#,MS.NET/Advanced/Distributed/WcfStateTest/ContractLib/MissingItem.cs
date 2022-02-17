using System.Runtime.Serialization;

namespace ContractLib
{
    [DataContract]
    public class MissingItem
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public bool IsOutOfStock { get; set; }
    }
}
