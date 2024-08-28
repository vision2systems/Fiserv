using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 200 - OK
  /// </summary>
  [DataContract]
  public class AccountOwnershipResponse {
    /// <summary>
    /// Status of account being validated
    /// </summary>
    /// <value>Status of account being validated</value>
    [DataMember(Name="accountStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountStatus")]
    public string AccountStatus { get; set; }

    /// <summary>
    /// Gets or Sets OwnerNameMatch
    /// </summary>
    [DataMember(Name="ownerNameMatch", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ownerNameMatch")]
    public OwnerNameMatch OwnerNameMatch { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Response200 {\n");
      sb.Append("  AccountStatus: ").Append(AccountStatus).Append("\n");
      sb.Append("  OwnerNameMatch: ").Append(OwnerNameMatch).Append("\n");
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
