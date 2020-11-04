using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FourTwentyWebsite.Model
{
    public class Vendor
    
    {
        
        [JsonPropertyName("vendorId")]
        public int VendorId { get; set; }
        
        [JsonPropertyName("vendorName")] public string VendorName { get; set; }

        [NotNull]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [NotNull]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        
        [Required]
        [JsonPropertyName("eMail")]
        public string Email { get; set; }
        
        [Required]
        [JsonPropertyName("phoneNumber")]
        public int PhoneNumber { get; set; }
        
        [Required]
        [JsonPropertyName("vendorLicense")]
        public string vendorLicense { get; set; }
        
        [Required]
        [JsonPropertyName("city")]
        public string City { get; set; }
        
        [Required]
        [JsonPropertyName("country")]
        public string Country { get; set; }
        
        
    }
   

    public class IsValidEmail{
        public static bool EmailCheck(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                    RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }

    
}