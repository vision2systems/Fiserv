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
    /// DebtorAccount
    /// </summary>
    [DataContract]
    public partial class DebtorAccount 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebtorAccount" /> class.
        /// </summary>
        [JsonConstructor]
        protected DebtorAccount() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DebtorAccount" /> class.
        /// </summary>
        /// <param name="identification">Unambiguous identification of the account of the debtor to which a debit entry will be made as a result of the transaction. (required).</param>
        public DebtorAccount(string identification = default(string))
        {
            // to ensure "identification" is required (not null)
            if (identification == null)
            {
                throw new InvalidDataException("identification is a required property for DebtorAccount and cannot be null");
            }
            else
            {
                this.Identification = identification;
            }
        }
        
        /// <summary>
        /// Unambiguous identification of the account of the debtor to which a debit entry will be made as a result of the transaction.
        /// </summary>
        /// <value>Unambiguous identification of the account of the debtor to which a debit entry will be made as a result of the transaction.</value>
        [DataMember(Name="identification", EmitDefaultValue=false)]
        public string Identification { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DebtorAccount {\n");
            sb.Append("  Identification: ").Append(Identification).Append("\n");
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
            return this.Equals(input as DebtorAccount);
        }

        /// <summary>
        /// Returns true if DebtorAccount instances are equal
        /// </summary>
        /// <param name="input">Instance of DebtorAccount to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DebtorAccount input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Identification == input.Identification ||
                    (this.Identification != null &&
                    this.Identification.Equals(input.Identification))
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
                if (this.Identification != null)
                    hashCode = hashCode * 59 + this.Identification.GetHashCode();
                return hashCode;
            }
        }

        
    }

}
