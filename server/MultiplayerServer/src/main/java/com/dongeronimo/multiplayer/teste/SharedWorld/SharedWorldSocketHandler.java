package com.dongeronimo.multiplayer.teste.SharedWorld;

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
    @Override
    public void afterConnectionEstablished(WebSocketSession session) throws Exception {
        clientManager.insertNewClient(session);
    }

    @Override
    public void afterConnectionClosed(WebSocketSession session, CloseStatus status) throws Exception {
        clientManager.removeClient(session.getId());
    }

    @Override
    protected void handleTextMessage(WebSocketSession session, TextMessage message) throws Exception {
        WebSocketSession clientThatSentMsg = clientManager.getClient(session.getId());
        getIdHandler.dealWithRequestId(clientThatSentMsg, message);
        logger.info("Client "+session.getId()+" sent "+message.getPayload());
    }
}