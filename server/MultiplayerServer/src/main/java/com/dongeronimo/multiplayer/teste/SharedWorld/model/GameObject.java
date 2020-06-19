package com.dongeronimo.multiplayer.teste.SharedWorld.model;

import java.util.ArrayList;
import java.util.List;


/**
 * First attempt at representing a game object in the server.
 */

public class GameObject {
    private String id;
    private Vector3 position;
    private GameObject parent;
    private List<GameObject> children;

    public GameObject(){
        position = new Vector3();
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
    
    public Vector3 getPosition(){
        return position;
    }
    public void setPosition(Vector3 pos){
        position = pos;
    }
    @Override
    public boolean equals(Object o){
        if(o==null || o instanceof GameObject == false){
            return false;
        }else{
            return ((GameObject)o).id.equals(this.id);
        }
    }
    @Override
    public int hashCode(){
        return id.hashCode();
    }
}