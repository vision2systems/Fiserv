using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class InitiatePaymentResponse {
    /// <summary>
    /// Payment initiation has been received by the receiving agent.
    /// </summary>
    /// <value>Payment initiation has been received by the receiving agent.</value>
    [DataMember(Name="transactionStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transactionStatus")]
    public string TransactionStatus { get; set; }

    /// <summary>
    /// Callback URL get transaction status.
    /// </summary>
    /// <value>Callback URL get transaction status.</value>
    [DataMember(Name="callback", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "callback")]
    public string Callback { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class InitiatePaymentResponse {\n");
      sb.Append("  TransactionStatus: ").Append(TransactionStatus).Append("\n");
      sb.Append("  Callback: ").Append(Callback).Append("\n");
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
