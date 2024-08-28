using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentInformationCredit {


      public PaymentInformationCredit()
      {
          
          Debtor = new Debtor();
          DebtorAccount = new DebtorAccount();
          CreditTransferTransactionInformation = new List<CreditTransferTransactionInformation>();
    }
    /// <summary>
    /// Gets or Sets PaymentInformationIdentification
    /// </summary>
    [DataMember(Name="paymentInformationIdentification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "paymentInformationIdentification")]
    public string PaymentInformationIdentification { get; set; }

    /// <summary>
    /// Gets or Sets Debtor
    /// </summary>
    [DataMember(Name="debtor", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "debtor")]
    public Debtor Debtor { get; set; }

    /// <summary>
    /// Gets or Sets DebtorAccount
    /// </summary>
    [DataMember(Name="debtorAccount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "debtorAccount")]
    public DebtorAccount DebtorAccount { get; set; }

    /// <summary>
    /// Gets or Sets CreditTransferTransactionInformation
    /// </summary>
    [DataMember(Name="creditTransferTransactionInformation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creditTransferTransactionInformation")]
    public List<CreditTransferTransactionInformation> CreditTransferTransactionInformation { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentInformationCredit {\n");
      sb.Append("  PaymentInformationIdentification: ").Append(PaymentInformationIdentification).Append("\n");
      sb.Append("  Debtor: ").Append(Debtor).Append("\n");
      sb.Append("  DebtorAccount: ").Append(DebtorAccount).Append("\n");
      sb.Append("  CreditTransferTransactionInformation: ").Append(CreditTransferTransactionInformation).Append("\n");
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
