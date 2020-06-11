package com.dongeronimo.multiplayer.teste;

import java.time.LocalTime;
import java.util.HashMap;
import java.util.Map;

import org.springframework.stereotype.Component;
import org.springframework.web.socket.CloseStatus;
import org.springframework.web.socket.TextMessage;
import org.springframework.web.socket.WebSocketSession;
import org.springframework.web.socket.handler.TextWebSocketHandler;



@Component
public class HelloSocketsHandler extends TextWebSocketHandler {
    static Map<String, WebSocketSession> clients;
    @Override
    public void afterConnectionEstablished(WebSocketSession session) throws Exception {
        if(clients == null){
            clients = new HashMap<>();
        }
        clients.put(session.getId(), session);
    }

    @Override
    public void afterConnectionClosed(WebSocketSession session, CloseStatus status) throws Exception {
        clients.remove(session.getId());
    }
    @Override
    protected void handleTextMessage(WebSocketSession session, TextMessage message) throws Exception{
        var sessionId = session.getId();
        var client = clients.get(sessionId);

        String clientMessage = message.getPayload();
        if(clientMessage.startsWith("hello")){
            client.sendMessage(new TextMessage("Hello there"));
        }else if(clientMessage.startsWith("time")){
            var currentTime = LocalTime.now();
            client.sendMessage(new TextMessage(currentTime.toString()));
        }
        else{
            client.sendMessage(new TextMessage("Unknown command"));
        }
        for (Map.Entry<String, WebSocketSession> entry:clients.entrySet()){
            String key = entry.getKey();
            String msg = "client "+key+" sent message to server";
            entry.getValue().sendMessage(new TextMessage(msg));
        }
    }
}