using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// Identification of a financial institution.
  /// </summary>
  [DataContract]
  public class Agent {
    /// <summary>
    /// Specification of a pre-agreed offering between clearing agents or the channel through which the payment instruction is processed:   * `USABA` - Routing Transit number assigned by the ABA for US financial Institutions.  
    /// </summary>
    /// <value>Specification of a pre-agreed offering between clearing agents or the channel through which the payment instruction is processed:   * `USABA` - Routing Transit number assigned by the ABA for US financial Institutions.  </value>
    [DataMember(Name="clearingSystemIdentification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "clearingSystemIdentification")]
    public string ClearingSystemIdentification { get; set; }

    /// <summary>
    /// Gets or Sets MemberIdentification
    /// </summary>
    [DataMember(Name="memberIdentification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "memberIdentification")]
    public string MemberIdentification { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Agent {\n");
      sb.Append("  ClearingSystemIdentification: ").Append(ClearingSystemIdentification).Append("\n");
      sb.Append("  MemberIdentification: ").Append(MemberIdentification).Append("\n");
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
