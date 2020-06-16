package com.dongeronimo.multiplayer.teste.SharedWorld.model;

import java.util.ArrayList;
import java.util.List;

/**
 * First attempt at representing a game object in the server.
 */
public class GameObject {
    private String id;
    private Float positionX;
    private Float positionY;
    private Float positionZ;
    private GameObject parent;
    private List<GameObject> children;

    public Float getPositionZ() {
        return positionZ;
    }

    public GameObject getParent() {
        return parent;
    }

    public void setParent(GameObject parent) {
        this.parent = parent;
    }

    public List<GameObject> getChildren() {
        if(children == null){
            children = new ArrayList<>();
        }
        return children;
    }

    public void setChildren(List<GameObject> children) {
        this.children = children;
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