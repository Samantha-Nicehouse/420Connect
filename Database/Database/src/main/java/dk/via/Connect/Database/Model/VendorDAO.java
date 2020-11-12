package dk.via.Connect.Database.Model;

import org.postgresql.Driver;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class VendorDAO {

    private String jdbcURL;
    private String username;
    private String password;

    public VendorDAO(String jdbcURL, String username, String password) throws Exception {
        this.jdbcURL = jdbcURL;
        this.username = username;
        this.password = password;
        try {
            DriverManager.registerDriver(new Driver());
        } catch ( SQLException e) {
            throw new Exception("No JDBC driver", e);
        }
    }

    public VendorDAO(String jdbcURL) throws Exception {
        this(jdbcURL, null, null);
    }

    public VendorDAO(){
        this.jdbcURL = "jdbc:postgresql:/ostgr/b8zxgsmnlkoj6ypd21ro-pesql.services.clever-cloud.com/b8zxgsmnlkoj6ypd21ro";
        this.username = "u1qvxb47lih4lpp0hmzp";
        this.password = "L9CBWOWE3tlB0kpuncgG";
    }

    protected Connection getConnection() throws SQLException {
        if (username == null) {
            return DriverManager.getConnection(jdbcURL);
        } else {
            return DriverManager.getConnection(jdbcURL, username, password);
        }
    }

    // create a Vendor
    // update a vendor attribute
    // retrieve a vendor by a field
    // retrieve all vendors
    // delete a vendor
    public boolean create(String vendorName, String firstName, String lastName, String email, int phoneNumber,
                          String vendorLicence, String city, String country, String username, String password) {
        String vendorsql = "insert into vendor (vendorname, vendorlicense, city, state, country) values(?,?,?,?,?) ";
        String vendoradminsql = "insert into vendoradmin (username, pass, email, fname, lname, phone, vendid) values(?,?,?,?,?,?,?)";

        try {
            PreparedStatement preparedStatementVendor = getConnection().prepareStatement(vendorsql);
            preparedStatementVendor.setString(1, vendorName);
            preparedStatementVendor.setString(2, vendorLicence);
            preparedStatementVendor.setString(3, city);
            preparedStatementVendor.setString(4, city);
            preparedStatementVendor.setString(5, country);
            PreparedStatement preparedStatementVendorAdmin = getConnection().prepareStatement(vendoradminsql);
            preparedStatementVendorAdmin.setString(1, username);
            preparedStatementVendorAdmin.setString(2, password);
            preparedStatementVendorAdmin.setString(3, email);
            preparedStatementVendorAdmin.setString(4, firstName);
            preparedStatementVendorAdmin.setString(5, lastName);
            preparedStatementVendorAdmin.setInt(6, phoneNumber);

            int result = preparedStatementVendor.executeUpdate();
            System.out.println("Ŗesult Vendor " + result);

            int result2 = preparedStatementVendorAdmin.executeUpdate();
            System.out.println("Ŗesult Vendor Admin" + result2);
            return true;
        }
        catch (SQLException e) {
            e.printStackTrace();
            return false;
        }

    }

/*
    public T mapSingle(DataMapper<T> mapper, String sql, Object... parameters) throws RemoteException {
        try (Connection connection = getConnection()) {
            PreparedStatement stat = prepare(connection, sql, parameters);
            ResultSet rs = stat.executeQuery();
            if(rs.next()) {
                return mapper.create(rs);
            } else {
                return null;
            }
        } catch (SQLException e) {
            throw new RemoteException(e.getMessage(), e);
        }
    }

    public List<T> map(DataMapper<T> mapper, String sql, Object... parameters) throws RemoteException {
        try (Connection connection = getConnection()) {
            PreparedStatement stat = prepare(connection, sql, parameters);
            ResultSet rs = stat.executeQuery();
            LinkedList<T> allCars = new LinkedList<>();
            while(rs.next()) {
                allCars.add(mapper.create(rs));
            }
            return allCars;
        } catch (SQLException e) {
            throw new RemoteException(e.getMessage(), e);
        }
    }

 */
    /*
    String url = "jdbc:postgresql://localhost/test";
    Properties props = new Properties();
    props.setProperty("user","fred");
props.setProperty("password","secret");
props.setProperty("ssl","true");
    Connection conn = DriverManager.getConnection(url, props);

    String url = "jdbc:postgresql://localhost/test?user=fred&password=secret&ssl=true";
    Connection conn = DriverManager.getConnection(url);
*/
}
