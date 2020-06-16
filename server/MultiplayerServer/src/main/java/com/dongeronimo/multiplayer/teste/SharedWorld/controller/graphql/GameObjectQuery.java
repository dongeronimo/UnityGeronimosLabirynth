package com.dongeronimo.multiplayer.teste.SharedWorld.controller.graphql;

import com.coxautodev.graphql.tools.GraphQLQueryResolver;
import com.dongeronimo.multiplayer.teste.SharedWorld.model.GameObject;
import com.dongeronimo.multiplayer.teste.SharedWorld.service.GameObjectService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
// {
//     getGameObjectById(id:"0384a406-4b41-47ff-80a1-2d9f1df4f62d"){
//         id
//         positionX
//         positionY
//         positionZ
//         children {
//             id
//         }
//     }
//}
@Component
public class GameObjectQuery implements GraphQLQueryResolver {
    @Autowired
    private GameObjectService gameObjectService;

    public GameObject getGameObjectById(String id){
        return gameObjectService.findById(id);
    }
}