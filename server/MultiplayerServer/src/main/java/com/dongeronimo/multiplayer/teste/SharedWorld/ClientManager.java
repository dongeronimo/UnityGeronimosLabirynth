package com.dongeronimo.multiplayer.teste.SharedWorld;

import java.util.HashMap;
import java.util.Map;

import org.springframework.stereotype.Component;
import org.springframework.web.socket.WebSocketSession;
@Component
public class ClientManager {
    public static Map<String, WebSocketSession> clients;

    private void createClientTableIfNeeeded(){
        if(clients == null){
            clients = new HashMap<>();
        }
    }
    public void insertNewClient(WebSocketSession session){
        createClientTableIfNeeeded();
        clients.put(session.getId(), session);
    }
    public void removeClient(String clientKey){
        clients.remove(clientKey);
    }
    public WebSocketSession getClient(String key){
        return clients.get(key);
    }
}