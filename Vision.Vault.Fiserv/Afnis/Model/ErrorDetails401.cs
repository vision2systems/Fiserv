using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ErrorDetails401 {
    /// <summary>
    /// A programmatic error code
    /// </summary>
    /// <value>A programmatic error code</value>
    [DataMember(Name="errorcode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "errorcode")]
    public decimal? Errorcode { get; set; }

    /// <summary>
    /// A human readable description of the problem
    /// </summary>
    /// <value>A human readable description of the problem</value>
    [DataMember(Name="message", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ErrorDetails401 {\n");
      sb.Append("  Errorcode: ").Append(Errorcode).Append("\n");
      sb.Append("  Message: ").Append(Message).Append("\n");
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
