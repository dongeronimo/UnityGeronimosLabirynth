package com.dongeronimo.multiplayer.teste.SharedWorld.controller.graphql;

import com.coxautodev.graphql.tools.GraphQLQueryResolver;
import com.dongeronimo.multiplayer.teste.SharedWorld.model.Greeting;

import org.springframework.stereotype.Component;
@Component
public class GreetingQuery implements GraphQLQueryResolver {
    
    public Greeting getGreeting(String id){
        return Greeting.currentGreeting;
    }
}