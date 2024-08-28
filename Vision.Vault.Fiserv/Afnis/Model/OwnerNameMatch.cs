using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class OwnerNameMatch
  {
    /// <summary>
    /// Gets or Sets SurnameMatch
    /// </summary>
    [DataMember(Name="surnameMatch", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "surnameMatch")]
    public string SurnameMatch { get; set; }

    /// <summary>
    /// Gets or Sets GivenNameMatch
    /// </summary>
    [DataMember(Name="givenNameMatch", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "givenNameMatch")]
    public string GivenNameMatch { get; set; }

    /// <summary>
    /// Gets or Sets MiddleNameMatch
    /// </summary>
    [DataMember(Name="middleNameMatch", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "middleNameMatch")]
    public string MiddleNameMatch { get; set; }

    /// <summary>
    /// Gets or Sets NameSuffixMatch
    /// </summary>
    [DataMember(Name="nameSuffixMatch", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nameSuffixMatch")]
    public string NameSuffixMatch { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Response200OwnerNameMatch {\n");
      sb.Append("  SurnameMatch: ").Append(SurnameMatch).Append("\n");
      sb.Append("  GivenNameMatch: ").Append(GivenNameMatch).Append("\n");
      sb.Append("  MiddleNameMatch: ").Append(MiddleNameMatch).Append("\n");
      sb.Append("  NameSuffixMatch: ").Append(NameSuffixMatch).Append("\n");
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
