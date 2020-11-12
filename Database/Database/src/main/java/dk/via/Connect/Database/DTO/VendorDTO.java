package dk.via.Connect.Database.DTO;

public class VendorDTO {


    private String vendorName;
    private String firstName;
    private String lastName;
    private String email;
    private int phoneNumber;
    private String vendorLicence;
    private String city;
    private String country;

    private String username;
    private String password;

    public VendorDTO() {
    }

    public VendorDTO(String vendorName, String firstName, String lastName, String email, int phoneNumber, String vendorLicence, String city, String country) {
        this.vendorName = vendorName;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.vendorLicence = vendorLicence;
        this.city = city;
        this.country = country;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getVendorName() {
        return vendorName;
    }

    public void setVendorName(String vendorName) {
        this.vendorName = vendorName;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public int getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(int phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getVendorLicence() {
        return vendorLicence;
    }

    public void setVendorLicence(String vendorLicence) {
        this.vendorLicence = vendorLicence;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }
}
