package com.dongeronimo.multiplayer.teste.SharedWorld.controller.graphql;

import com.coxautodev.graphql.tools.GraphQLMutationResolver;
import com.dongeronimo.multiplayer.teste.SharedWorld.model.Greeting;

import org.springframework.stereotype.Component;

@Component
public class GreetingMutation implements GraphQLMutationResolver {
    public Greeting newGreeting(String message){
        Greeting greeting = new Greeting();
        greeting.setMessage(message);
        greeting.setId(Double.toString(Math.random()));
        Greeting.currentGreeting = greeting;
        return greeting;
    }
}