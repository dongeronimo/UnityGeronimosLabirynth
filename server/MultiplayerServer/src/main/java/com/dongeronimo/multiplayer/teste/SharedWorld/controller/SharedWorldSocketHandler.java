package com.dongeronimo.multiplayer.teste.SharedWorld.controller;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.dongeronimo.multiplayer.teste.SharedWorld.infra.ClientManager;
import com.dongeronimo.multiplayer.teste.SharedWorld.model.GameObject;
import com.dongeronimo.multiplayer.teste.SharedWorld.service.GameObjectService;
import com.fasterxml.jackson.databind.ObjectMapper;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.web.socket.CloseStatus;
import org.springframework.web.socket.TextMessage;
import org.springframework.web.socket.WebSocketSession;
import org.springframework.web.socket.handler.TextWebSocketHandler;
@Component
public class SharedWorldSocketHandler extends TextWebSocketHandler {
    private Logger logger = LoggerFactory.getLogger(SharedWorldSocketHandler.class);
    @Autowired
    private ClientManager clientManager;
    @Autowired
    private GetIdHandler getIdHandler;

    @Autowired
    private GameObjectService gameObjectService;
    @Override
    public void afterConnectionEstablished(WebSocketSession session) throws Exception {
        clientManager.insertNewClient(session);
        logger.info("Client "+session.getId()+" logged");
    }

    @Override
    public void afterConnectionClosed(WebSocketSession session, CloseStatus status) throws Exception {
        clientManager.removeClient(session.getId());
        logger.info("Client "+session.getId()+" left");
    }


    @Override
    protected void handleTextMessage(WebSocketSession session, TextMessage message) throws Exception {
        WebSocketSession clientThatSentMsg = clientManager.getClient(session.getId());
        Map<String, String> requestData = new ObjectMapper().readValue(message.getPayload(), HashMap.class);
        String type = requestData.get("type");
        if(type.equals("idRequest")){
            getIdHandler.dealWithRequestId(clientThatSentMsg);
        }
        if(type.equals("worldRequest")){
            //TODO: Deal with request by sending the current world to the player
            List<GameObject> gameObjects = gameObjectService.findAll();
            String gameObjectList = new ObjectMapper().writeValueAsString(gameObjects);
            Map<String, String> response = new HashMap<>();
            response.put("type", "worldRequest");
            response.put("gameObjects", gameObjectList);
            clientThatSentMsg.sendMessage(new TextMessage(new ObjectMapper().writeValueAsString(response)));
        }
        logger.info("Client "+session.getId()+" sent "+message.getPayload());
    }
}