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
    /// Party that owes an amount of money to the (ultimate) creditor.
    /// </summary>
    [DataContract]
    public partial class Debtor : IEquatable<Debtor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Debtor" /> class.
        /// </summary>
        [JsonConstructor]
        protected Debtor() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Debtor" /> class.
        /// </summary>
        /// <param name="identification">Identification assigned by an institution (required).</param>
        /// <param name="name">name.</param>
        public Debtor(string identification = default(string), string name = default(string))
        {
            // to ensure "identification" is required (not null)
            if (identification == null)
            {
                throw new InvalidDataException("identification is a required property for Debtor and cannot be null");
            }
            else
            {
                this.Identification = identification;
            }
            this.Name = name;
        }
        
        /// <summary>
        /// Identification assigned by an institution
        /// </summary>
        /// <value>Identification assigned by an institution</value>
        [DataMember(Name="identification", EmitDefaultValue=false)]
        public string Identification { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Debtor {\n");
            sb.Append("  Identification: ").Append(Identification).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as Debtor);
        }

        /// <summary>
        /// Returns true if Debtor instances are equal
        /// </summary>
        /// <param name="input">Instance of Debtor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Debtor input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Identification == input.Identification ||
                    (this.Identification != null &&
                    this.Identification.Equals(input.Identification))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                return hashCode;
            }
        }

    }

}
