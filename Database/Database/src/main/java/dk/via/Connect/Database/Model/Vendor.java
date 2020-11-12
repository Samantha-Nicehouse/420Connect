package dk.via.Connect.Database.Model;
import java.util.Objects;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "vendor")
public class Vendor {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private int VendorId;
    private int VendorBrandId;
    private String VendorName;
    private String FirstName;
    private String LastName;
    private String EMail;
    private int PhoneNumber;
    private String VendorLicence;
    private String City;
    private String Country;

    public Vendor() {
    }

    public Vendor(int vendorId, int vendorBrandId, String vendorName, String firstName, String lastName, String EMail, int phoneNumber, String vendorLicence, String city, String country) {
        VendorId = vendorId;
        VendorBrandId = vendorBrandId;
        VendorName = vendorName;
        FirstName = firstName;
        LastName = lastName;
        this.EMail = EMail;
        PhoneNumber = phoneNumber;
        VendorLicence = vendorLicence;
        City = city;
        Country = country;
    }

    public int getVendorId() {
        return VendorId;
    }

    public int getVendorBrandId() {
        return VendorBrandId;
    }

    public void setVendorBrandId(int vendorBrandId) {
        VendorBrandId = vendorBrandId;
    }

    public String getVendorName() {
        return VendorName;
    }

    public void setVendorName(String vendorName) {
        VendorName = vendorName;
    }

    public String getFirstName() {
        return FirstName;
    }

    public void setFirstName(String firstName) {
        FirstName = firstName;
    }

    public String getLastName() {
        return LastName;
    }

    public void setLastName(String lastName) {
        LastName = lastName;
    }

    public String getEMail() {
        return EMail;
    }

    public void setEMail(String EMail) {
        this.EMail = EMail;
    }

    public int getPhoneNumber() {
        return PhoneNumber;
    }

    public void setPhoneNumber(int phoneNumber) {
        PhoneNumber = phoneNumber;
    }

    public String getVendorLicence() {
        return VendorLicence;
    }

    public void setVendorLicence(String vendorLicence) {
        VendorLicence = vendorLicence;
    }

    public String getCity() {
        return City;
    }

    public void setCity(String city) {
        City = city;
    }

    public String getCountry() {
        return Country;
    }

    public void setCountry(String country) {
        Country = country;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 79 * hash + Objects.hashCode(this.VendorId);
        hash = 79 * hash + Objects.hashCode(this.VendorBrandId);
        hash = 79 * hash + Objects.hashCode(this.VendorName);
        hash = 79 * hash + Objects.hashCode(this.FirstName);
        hash = 79 * hash + Objects.hashCode(this.LastName);
        hash = 79 * hash + Objects.hashCode(this.EMail);
        hash = 79 * hash + Objects.hashCode(this.PhoneNumber);
        hash = 79 * hash + Objects.hashCode(this.VendorLicence);
        hash = 79 * hash + Objects.hashCode(this.City);
        hash = 79 * hash + Objects.hashCode(this.Country);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Vendor other = (Vendor) obj;
        if (this.getVendorId() != other.getVendorId()) {
            return false;
        }
        if (this.getVendorBrandId() != other.getVendorBrandId()) {
            return false;
        }
        if (!this.getVendorName().equals(other.VendorName)) {
            return false;
        }
        if (!this.getFirstName().equals(other.FirstName)) {
            return false;
        }
        if (!this.getLastName().equals(other.LastName)) {
            return false;
        }
        if (!this.getEMail().equals(other.EMail)) {
            return false;
        }
        if (this.getPhoneNumber() != other.getPhoneNumber()) {
            return false;
        }
        if (!this.getVendorLicence().equals(other.VendorLicence)) {
            return false;
        }
        if (!this.getCity().equals(other.City)) {
            return false;
        }
        if (!this.getCountry().equals(other.Country)) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("Vendor{");
        sb.append("vendorId=").append(getVendorId());
        sb.append(", vendorBrandId='").append(getVendorBrandId());
        sb.append(", vendorName=").append(getVendorName());
        sb.append(", firstName=").append(getFirstName());
        sb.append(", lastName=").append(getLastName());
        sb.append(", eMail=").append(getEMail());
        sb.append(", phoneNumber=").append(getPhoneNumber());
        sb.append(", vendorLicence=").append(getVendorLicence());
        sb.append(", city=").append(getCity());
        sb.append(", country=").append(getCountry());
        sb.append('}');
        return sb.toString();
    }
}