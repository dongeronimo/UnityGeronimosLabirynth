package com.dongeronimo.multiplayer.teste.SharedWorld;

import java.util.HashMap;
import java.util.Map;

import org.springframework.web.socket.CloseStatus;
import org.springframework.web.socket.TextMessage;
import org.springframework.web.socket.WebSocketSession;
import org.springframework.web.socket.handler.TextWebSocketHandler;

public class SharedWorldSocketHandler extends TextWebSocketHandler {
    static Map<String, WebSocketSession> clients;
    @Override
    public void afterConnectionEstablished(WebSocketSession session) throws Exception {
        createClientTableIfNeeeded();
        insertNewClient(session);
    }

    @Override
    public void afterConnectionClosed(WebSocketSession session, CloseStatus status) throws Exception {
        removeClient(session.getId());
    }

    @Override
    protected void handleTextMessage(WebSocketSession session, TextMessage message) throws Exception {
        WebSocketSession clientThatSentMsg = getClient(session.getId());
        
    }

    private void createClientTableIfNeeeded(){
        if(clients == null){
            clients = new HashMap<>();
        }
    }
    private void insertNewClient(WebSocketSession session){
        clients.put(session.getId(), session);
    }
    private void removeClient(String clientKey){
        clients.remove(clientKey);
    }
    private WebSocketSession getClient(String key){
        return clients.get(key);
    }
}