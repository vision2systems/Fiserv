using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class AccountValidationPlusOwnership {
    /// <summary>
    /// Gets or Sets Account
    /// </summary>
    [DataMember(Name="account", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "account")]
    public Account Account { get; set; }

    /// <summary>
    /// Gets or Sets Agent
    /// </summary>
    [DataMember(Name="agent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "agent")]
    public Agent Agent { get; set; }

    /// <summary>
    /// Gets or Sets Owner
    /// </summary>
    [DataMember(Name="owner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "owner")]
    public Owner Owner { get; set; }

    /// <summary>
    /// Gets or Sets CashAccountType
    /// </summary>
    [DataMember(Name="cashAccountType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cashAccountType")]
    public string CashAccountType { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AccountValidationPlusOwnership {\n");
      sb.Append("  Account: ").Append(Account).Append("\n");
      sb.Append("  Agent: ").Append(Agent).Append("\n");
      sb.Append("  Owner: ").Append(Owner).Append("\n");
      sb.Append("  CashAccountType: ").Append(CashAccountType).Append("\n");
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
