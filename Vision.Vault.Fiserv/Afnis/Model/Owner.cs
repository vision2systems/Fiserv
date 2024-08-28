using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// Party that legally owns the account.
  /// </summary>
  [DataContract]
  public class Owner {
    /// <summary>
    /// Surname is a name added to a given name and is part of a personal name. In many cases, a surname is a family name
    /// </summary>
    /// <value>Surname is a name added to a given name and is part of a personal name. In many cases, a surname is a family name</value>
    [DataMember(Name="surname", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "surname")]
    public string Surname { get; set; }

    /// <summary>
    /// Name given at birth
    /// </summary>
    /// <value>Name given at birth</value>
    [DataMember(Name="givenName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "givenName")]
    public string GivenName { get; set; }

    /// <summary>
    /// Second name of a person
    /// </summary>
    /// <value>Second name of a person</value>
    [DataMember(Name="middleName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "middleName")]
    public string MiddleName { get; set; }

    /// <summary>
    /// Suffix for name
    /// </summary>
    /// <value>Suffix for name</value>
    [DataMember(Name="nameSuffix", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nameSuffix")]
    public string NameSuffix { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Owner {\n");
      sb.Append("  Surname: ").Append(Surname).Append("\n");
      sb.Append("  GivenName: ").Append(GivenName).Append("\n");
      sb.Append("  MiddleName: ").Append(MiddleName).Append("\n");
      sb.Append("  NameSuffix: ").Append(NameSuffix).Append("\n");
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
