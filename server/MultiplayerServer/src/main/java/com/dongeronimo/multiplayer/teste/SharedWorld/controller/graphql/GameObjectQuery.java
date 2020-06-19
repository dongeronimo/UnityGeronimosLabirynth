package com.dongeronimo.multiplayer.teste.SharedWorld.controller.graphql;

import com.coxautodev.graphql.tools.GraphQLQueryResolver;
import com.dongeronimo.multiplayer.teste.SharedWorld.model.GameObject;
import com.dongeronimo.multiplayer.teste.SharedWorld.service.GameObjectService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
// {
//     getGameObjectById(id:"44351c53-0167-4bfc-a770-e20f85ab43eb"){
//}
@Component
public class GameObjectQuery implements GraphQLQueryResolver {
    @Autowired
    private GameObjectService gameObjectService;

    public GameObject getGameObjectById(String id){
        return gameObjectService.findById(id);
    }
}