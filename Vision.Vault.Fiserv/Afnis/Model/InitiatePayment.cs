using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class InitiateACHDebitPayment {
    /// <summary>
    /// Gets or Sets PaymentInformation
    /// </summary>
    [DataMember(Name="paymentInformation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "paymentInformation")]
    public PaymentInformationDebit PaymentInformation { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class InitiatePayment {\n");
      sb.Append("  PaymentInformation: ").Append(PaymentInformation).Append("\n");
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
