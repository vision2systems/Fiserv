using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class UnstructuredInner {
    /// <summary>
    /// Gets or Sets LineNumber
    /// </summary>
    [DataMember(Name="lineNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lineNumber")]
    public int? LineNumber { get; set; }

    /// <summary>
    /// Gets or Sets Value
    /// </summary>
    [DataMember(Name="value", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "value")]
    public string Value { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UnstructuredInner {\n");
      sb.Append("  LineNumber: ").Append(LineNumber).Append("\n");
      sb.Append("  Value: ").Append(Value).Append("\n");
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
