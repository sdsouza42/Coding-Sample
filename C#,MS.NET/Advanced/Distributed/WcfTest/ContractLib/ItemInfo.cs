using System.Runtime.Serialization;

namespace ContractLib
{
    [DataContract]
    public class ItemInfo
    {
        [DataMember]
        public double UnitPrice { get; set; }

        [DataMember]
        public int CurrentStock { get; set; }
    }
}
