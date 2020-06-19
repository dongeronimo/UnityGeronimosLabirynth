package com.dongeronimo.multiplayer.teste.SharedWorld.service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.stream.Collectors;

import com.dongeronimo.multiplayer.teste.SharedWorld.model.GameObject;
import com.dongeronimo.multiplayer.teste.SharedWorld.model.Vector3;

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
        newGameObject.setPosition(new Vector3());
        newGameObject.setId(UUID.randomUUID().toString());
        gameObjectRepository.put(newGameObject.getId(), newGameObject);
        return newGameObject;
    }

    private void initRepositoryIfNull(){
        if(gameObjectRepository == null){
            gameObjectRepository = new HashMap<>();
        }
    }

	public List<GameObject> findAll() {
        initRepositoryIfNull();
        List<GameObject> lst = gameObjectRepository.keySet().stream().map(k->gameObjectRepository.get(k)).collect(Collectors.toList());
        return lst;
	}
}