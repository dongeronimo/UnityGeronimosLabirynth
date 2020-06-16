package com.dongeronimo.multiplayer.teste.SharedWorld.controller.graphql;

import com.coxautodev.graphql.tools.GraphQLMutationResolver;
import com.dongeronimo.multiplayer.teste.SharedWorld.model.GameObject;
import com.dongeronimo.multiplayer.teste.SharedWorld.service.GameObjectService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

// mutation {
//     newGameObject(positionX:1.0, positionY:2.0, positionZ:3.4){
//         id
//         positionX
//         positionY
//         positionZ
//     }
// }

@Component
public class GameObjectMutation implements GraphQLMutationResolver {
    @Autowired
    private GameObjectService gameObjectService;
    //newGameObject(positionX:Float!, positionY:Float!, positionZ: Float!):GameObject!
    public GameObject newGameObject(float positionX, float positionY, float positionZ){
        return gameObjectService.createNew(positionX, positionX, positionZ);
    }
}