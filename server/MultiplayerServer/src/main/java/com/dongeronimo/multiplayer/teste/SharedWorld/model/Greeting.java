package com.dongeronimo.multiplayer.teste.SharedWorld.model;

public class Greeting {
    public static Greeting currentGreeting;

    private String id;
    private String message;

    public String getMessage() {
        return message;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public void setMessage(String message) {
        this.message = message;
    }

}