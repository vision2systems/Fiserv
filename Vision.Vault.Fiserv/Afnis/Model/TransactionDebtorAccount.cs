using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TransactionDebtorAccount {
    /// <summary>
    /// Unambiguous identification of the account of the debtor to which a debit entry will be made as a result of the transaction
    /// </summary>
    /// <value>Unambiguous identification of the account of the debtor to which a debit entry will be made as a result of the transaction</value>
    [DataMember(Name="identification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "identification")]
    public string Identification { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TransactionDebtorAccount {\n");
      sb.Append("  Identification: ").Append(Identification).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
