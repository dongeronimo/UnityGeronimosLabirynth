package com.dongeronimo.multiplayer.teste.SharedWorld.model;
/**
 * First attempt at representing a game object in the server.
 */
public class GameObject {
    private String id;
    private Float positionX;
    private Float positionY;
    private Float positionZ;

    public Float getPositionZ() {
        return positionZ;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Float getPositionX() {
        return positionX;
    }

    public void setPositionX(Float positionX) {
        this.positionX = positionX;
    }

    public Float getPositionY() {
        return positionY;
    }

    public void setPositionY(Float positionY) {
        this.positionY = positionY;
    }

    public void setPositionZ(Float positionZ) {
        this.positionZ = positionZ;
    }


}