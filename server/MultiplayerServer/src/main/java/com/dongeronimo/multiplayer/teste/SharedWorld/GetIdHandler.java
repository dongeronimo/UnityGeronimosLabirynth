package com.dongeronimo.multiplayer.teste.SharedWorld;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;

import org.springframework.stereotype.Component;
import org.springframework.web.socket.TextMessage;
import org.springframework.web.socket.WebSocketSession;

@Component
public class GetIdHandler {
    public void dealWithRequestId(WebSocketSession clientSessionRequestingId, TextMessage message) throws IOException{
        if(message.getPayload().equals("getId")){
            String json = buildRequestIdJson(clientSessionRequestingId.getId());
            sendMessageToClient(clientSessionRequestingId, json);
        }
    }
    private String buildRequestIdJson(String clientId) throws JsonProcessingException {
        Map<String, String> elements = new HashMap<>();
        elements.put("type", "getId");
        elements.put("id", clientId);
        ObjectMapper objectMapper = new ObjectMapper();
        String json = objectMapper.writeValueAsString(elements);
        return json;
    }

    private void sendMessageToClient(WebSocketSession client, String message) throws IOException {
        client.sendMessage(new TextMessage(message));
    }
}