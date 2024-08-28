using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class RemittanceInformationInner {
    /// <summary>
    /// Gets or Sets Unstructured
    /// </summary>
    [DataMember(Name="unstructured", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unstructured")]
    public Unstructured Unstructured { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RemittanceInformationInner {\n");
      sb.Append("  Unstructured: ").Append(Unstructured).Append("\n");
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
