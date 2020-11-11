﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace dk.via._420Connect.Model
{
    public class Vendor
    
    {
        [Key]
        [JsonPropertyName("vendorId")]
        public int VendorId { get; set; }

        [JsonPropertyName("vendorBrandId")]
        public int VendorBrandId { get; set; }

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
        
        public void Update(Vendor vendorToUpdate)
        {
            VendorId = vendorToUpdate.VendorId;
            VendorBrandId = vendorToUpdate.VendorBrandId;
            VendorName = vendorToUpdate.VendorName;
            FirstName = vendorToUpdate.FirstName;
            LastName = vendorToUpdate.LastName;
            Email = vendorToUpdate.Email;
            PhoneNumber = vendorToUpdate.PhoneNumber;
            vendorLicense = vendorToUpdate.vendorLicense;
            City = vendorToUpdate.City;
            Country = vendorToUpdate.Country;
        }

        public byte[] ToBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(VendorId);
                bw.Write(VendorBrandId);
                bw.Write(VendorName);
                bw.Write(FirstName);
                bw.Write(LastName);
                bw.Write(Email);
                bw.Write(PhoneNumber);
                bw.Write(vendorLicense);
                bw.Write(City);
                bw.Write(Country);

                return ms.ToArray();
            }
        }

        public static Vendor FromBytes(byte[] buffer)
        {
            Vendor retVal = new Vendor();

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);
                retVal.VendorId = br.ReadInt32();
                retVal.VendorBrandId = br.ReadInt32();
                retVal.VendorName = br.ReadString();
                retVal.FirstName = br.ReadString();
                retVal.LastName = br.ReadString();
                retVal.Email = br.ReadString();
                retVal.PhoneNumber = br.ReadInt32();
                retVal.vendorLicense = br.ReadString();
                retVal.City = br.ReadString();
                retVal.Country = br.ReadString();
            }

            return retVal;
        }

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