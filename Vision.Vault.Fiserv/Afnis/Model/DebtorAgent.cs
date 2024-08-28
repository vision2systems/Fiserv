/* 
 * Initiate Payment API
 *
 * Afinis is a diverse group of organizations working to support advancement and use of API standardization in the financial services industry. Utilization of this API requires a developer to [register](https://www.afinis.org/user/register) their application.
 *
 * OpenAPI spec version: 1.0.7
 * Contact: info@afinis.org
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Vision.Vault.Treasury.Afnis.Model
{
    /// <summary>
    /// Financial institution servicing an account for the debtor.
    /// </summary>
    [DataContract]
    public partial class DebtorAgent :  IEquatable<DebtorAgent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebtorAgent" /> class.
        /// </summary>
        [JsonConstructor]
        protected DebtorAgent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DebtorAgent" /> class.
        /// </summary>
        /// <param name="clearingSystemIdentification">Specification of a pre-agreed offering between clearing agents or the channel through which the payment instruction is processed (required).</param>
        /// <param name="memberIdentification">Identification of a member of a clearing system  e.g., a U.S. transit routing number or Canadian Payments Association Routing Number (required).</param>
        public DebtorAgent(string clearingSystemIdentification = default(string), string memberIdentification = default(string))
        {
            // to ensure "clearingSystemIdentification" is required (not null)
            if (clearingSystemIdentification == null)
            {
                throw new InvalidDataException("clearingSystemIdentification is a required property for DebtorAgent and cannot be null");
            }
            else
            {
                this.ClearingSystemIdentification = clearingSystemIdentification;
            }
            // to ensure "memberIdentification" is required (not null)
            if (memberIdentification == null)
            {
                throw new InvalidDataException("memberIdentification is a required property for DebtorAgent and cannot be null");
            }
            else
            {
                this.MemberIdentification = memberIdentification;
            }
        }
        
        /// <summary>
        /// Specification of a pre-agreed offering between clearing agents or the channel through which the payment instruction is processed
        /// </summary>
        /// <value>Specification of a pre-agreed offering between clearing agents or the channel through which the payment instruction is processed</value>
        [DataMember(Name="clearingSystemIdentification", EmitDefaultValue=false)]
        public string ClearingSystemIdentification { get; set; }

        /// <summary>
        /// Identification of a member of a clearing system  e.g., a U.S. transit routing number or Canadian Payments Association Routing Number
        /// </summary>
        /// <value>Identification of a member of a clearing system  e.g., a U.S. transit routing number or Canadian Payments Association Routing Number</value>
        [DataMember(Name="memberIdentification", EmitDefaultValue=false)]
        public string MemberIdentification { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DebtorAgent {\n");
            sb.Append("  ClearingSystemIdentification: ").Append(ClearingSystemIdentification).Append("\n");
            sb.Append("  MemberIdentification: ").Append(MemberIdentification).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DebtorAgent);
        }

        /// <summary>
        /// Returns true if DebtorAgent instances are equal
        /// </summary>
        /// <param name="input">Instance of DebtorAgent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DebtorAgent input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ClearingSystemIdentification == input.ClearingSystemIdentification ||
                    (this.ClearingSystemIdentification != null &&
                    this.ClearingSystemIdentification.Equals(input.ClearingSystemIdentification))
                ) && 
                (
                    this.MemberIdentification == input.MemberIdentification ||
                    (this.MemberIdentification != null &&
                    this.MemberIdentification.Equals(input.MemberIdentification))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ClearingSystemIdentification != null)
                    hashCode = hashCode * 59 + this.ClearingSystemIdentification.GetHashCode();
                if (this.MemberIdentification != null)
                    hashCode = hashCode * 59 + this.MemberIdentification.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
     
    }

}
