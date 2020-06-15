package com.dongeronimo.multiplayer.teste.SharedWorld.infra;

import com.dongeronimo.multiplayer.teste.HelloSocketsHandler;
import com.dongeronimo.multiplayer.teste.SharedWorld.controller.SharedWorldSocketHandler;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.socket.config.annotation.EnableWebSocket;
import org.springframework.web.socket.config.annotation.WebSocketConfigurer;
import org.springframework.web.socket.config.annotation.WebSocketHandlerRegistry;

@Configuration
@EnableWebSocket
public class WebSocketConfig implements WebSocketConfigurer {
    @Autowired
    private HelloSocketsHandler helloSocketsHandler;
    @Autowired
    private SharedWorldSocketHandler sharedWorldHandler;
    @Override
    public void registerWebSocketHandlers(WebSocketHandlerRegistry registry) {
        registry.addHandler(helloSocketsHandler, "/helloSockets");
        registry.addHandler(sharedWorldHandler, "/shared_world").setAllowedOrigins("*");
    }
    
}