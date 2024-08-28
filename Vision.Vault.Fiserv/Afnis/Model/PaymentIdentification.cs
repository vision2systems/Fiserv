using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class PaymentIdentification {
    /// <summary>
    /// Unique identification as assigned by an instructing party for an instructed party to unambiguously identify the instruction.
    /// </summary>
    /// <value>Unique identification as assigned by an instructing party for an instructed party to unambiguously identify the instruction.</value>
    [DataMember(Name="instructionIdentification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "instructionIdentification")]
    public string InstructionIdentification { get; set; }

    /// <summary>
    /// Unique identification assigned by the initiating party to unambiguously identify the transaction. This identification is passed on, unchanged, throughout the entire end-to-end chain.
    /// </summary>
    /// <value>Unique identification assigned by the initiating party to unambiguously identify the transaction. This identification is passed on, unchanged, throughout the entire end-to-end chain.</value>
    [DataMember(Name="endToEndIdentification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "endToEndIdentification")]
    public string EndToEndIdentification { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentIdentification {\n");
      sb.Append("  InstructionIdentification: ").Append(InstructionIdentification).Append("\n");
      sb.Append("  EndToEndIdentification: ").Append(EndToEndIdentification).Append("\n");
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
