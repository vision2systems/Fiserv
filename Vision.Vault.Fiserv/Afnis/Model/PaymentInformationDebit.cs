using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentInformationDebit {
    /// <summary>
    /// Gets or Sets PaymentInformationIdentification
    /// </summary>
    [DataMember(Name="paymentInformationIdentification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "paymentInformationIdentification")]
    public string PaymentInformationIdentification { get; set; }

    /// <summary>
    /// Gets or Sets Creditor
    /// </summary>
    [DataMember(Name="creditor", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creditor")]
    public Creditor Creditor { get; set; }

    /// <summary>
    /// Gets or Sets CreditorAccount
    /// </summary>
    [DataMember(Name="creditorAccount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creditorAccount")]
    public CreditorAccount CreditorAccount { get; set; }

    /// <summary>
    /// Gets or Sets DirectDebitTransactionInformation
    /// </summary>
    [DataMember(Name="directDebitTransactionInformation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "directDebitTransactionInformation")]
    public List<DirectDebitTransactionInformation> DirectDebitTransactionInformation { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentInformationDebit {\n");
      sb.Append("  PaymentInformationIdentification: ").Append(PaymentInformationIdentification).Append("\n");
      sb.Append("  Creditor: ").Append(Creditor).Append("\n");
      sb.Append("  CreditorAccount: ").Append(CreditorAccount).Append("\n");
      sb.Append("  DirectDebitTransactionInformation: ").Append(DirectDebitTransactionInformation).Append("\n");
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
