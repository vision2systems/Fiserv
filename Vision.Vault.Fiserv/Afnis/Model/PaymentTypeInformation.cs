using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Vision.Vault.Treasury.Afnis.Model {

    public enum PaymentInformationSequenceType
    {
        OOFF,
        RECUR,
        FNAL,
        FRST,
        RCUR
    }




  /// <summary>
  /// Set of elements used to further specify the type of transaction.
  /// </summary>
  [DataContract]
  public class PaymentTypeInformation {
    /// <summary>
    /// Gets or Sets LocalInstrument
    /// </summary>
    [DataMember(Name="localInstrument", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "localInstrument")]
    public string LocalInstrument { get; set; }

    /// <summary>
    /// Gets or Sets SequenceType
    /// OOFF: One-Off Payment
    /// RECUR: Recurring Payment
    /// FNAL: Final Payment
    /// FRST: First Payment
    /// RCUR: Recurring Payment
    /// </summary>
    [DataMember(Name="sequenceType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sequenceType")]
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public PaymentInformationSequenceType SequenceType { get; set; }

    /// <summary>
    /// Gets or Sets CategoryPurpose
    /// </summary>
    [DataMember(Name="categoryPurpose", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "categoryPurpose")]
    public CategoryPurpose CategoryPurpose { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PaymentTypeInformation {\n");
      sb.Append("  LocalInstrument: ").Append(LocalInstrument).Append("\n");
      sb.Append("  SequenceType: ").Append(SequenceType).Append("\n");
      sb.Append("  CategoryPurpose: ").Append(CategoryPurpose).Append("\n");
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
