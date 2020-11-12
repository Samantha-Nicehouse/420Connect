package dk.via.Connect.Database.Service;

import dk.via.Connect.Database.Model.VendorDAO;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
    int PORT = 4012;
    boolean running;
    VendorDAO dao;
    // This is the listener for socket connections from
    // the C# web layer
    // This spurns a new thread when a new client connection comes in
    public Server(){
        try {
            dao = new VendorDAO();
            ServerSocket serverSocket = new ServerSocket(PORT);

            running = true;
            while (running)
            {
                System.out.println("Waiting for a client...");
                Socket client = serverSocket.accept();
                DatabaseClientHandler clientHandler = new DatabaseClientHandler(client, dao);
                Thread clientThread = new Thread(clientHandler);
                clientThread.setDaemon(true);
                clientThread.start();
            }

        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}
