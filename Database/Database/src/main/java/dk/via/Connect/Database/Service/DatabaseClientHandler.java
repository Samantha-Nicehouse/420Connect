package dk.via.Connect.Database.Service;

import com.google.gson.Gson;
import dk.via.Connect.Database.DTO.VendorDTO;
import dk.via.Connect.Database.Model.VendorDAO;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.SocketException;
import java.nio.charset.Charset;


public class DatabaseClientHandler implements Runnable {
    Socket client;
    VendorDAO dataAccessObj;
    Gson gson;
    private BufferedReader in;
    private PrintWriter out;
    private boolean running;

    public DatabaseClientHandler(Socket client, VendorDAO dataAccessObj) throws IOException {
        this.client = client;
        this.dataAccessObj = dataAccessObj;
        gson = new Gson();
        this.in = new BufferedReader(
                new InputStreamReader(this.client.getInputStream(), Charset.forName("ASCII")
                ));
        this.out = new PrintWriter(this.client.getOutputStream(), true);
    }

    @Override
    public void run() {
        // waiti for a client request
        running = true;
        while (running)
        {
            try
            {
                String request = in.readLine();
                System.out.println("Client> " + request);
                String reply = serviceRequest(request);
                System.out.println("Server> " + reply);
                out.println(reply);
                if (request.contentEquals("quit"))
                {
                    close();
                }
            }
            catch (Exception e)
            {
                System.out.println("Client error ");
                e.printStackTrace();
                close();
            }
        }
        close();
    }

    private String serviceRequest(String request) {
       VendorDTO dto = gson.fromJson(request, VendorDTO.class);
       boolean success = dataAccessObj.create(dto.getVendorName(), dto.getFirstName(), dto.getLastName(), dto.getEmail(), dto.getPhoneNumber(),
        dto.getVendorLicence(), dto.getCity(), dto.getCountry(), dto.getUsername(),  dto.getPassword());
       return success ? "Vendor has been created successfully" : "Ērror creating vendor";
    }

    public void close()
    {
        running = false;
        try
        {
            in.close();
            out.close();
            this.client.close();
        }
        catch (IOException e)
        {
            //
        }
    }
}
