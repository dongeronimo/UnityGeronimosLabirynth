package com.dongeronimo.multiplayer.teste.SharedWorld.service;

import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

import com.dongeronimo.multiplayer.teste.SharedWorld.model.GameObject;

import org.springframework.stereotype.Component;


@Component
public class GameObjectService {
    private Map<String, GameObject> gameObjectRepository;
    
    public GameObject findById(String id){
        initRepositoryIfNull();
        return gameObjectRepository.get(id);
    }

    public GameObject createNew(float positionX, float positionY, float positionZ){
        initRepositoryIfNull();
        GameObject newGameObject = new GameObject();
        newGameObject.setPositionX(positionX);
        newGameObject.setPositionY(positionY);
        newGameObject.setPositionZ(positionZ);
        newGameObject.setId(UUID.randomUUID().toString());
        gameObjectRepository.put(newGameObject.getId(), newGameObject);
        return newGameObject;
    }

    private void initRepositoryIfNull(){
        if(gameObjectRepository == null){
            gameObjectRepository = new HashMap<>();
        }
    }
}