package com.dongeronimo.multiplayer.teste.SharedWorld.controller.graphql;

import com.coxautodev.graphql.tools.GraphQLMutationResolver;
import com.dongeronimo.multiplayer.teste.SharedWorld.model.GameObject;
import com.dongeronimo.multiplayer.teste.SharedWorld.model.Vector3;
import com.dongeronimo.multiplayer.teste.SharedWorld.service.GameObjectService;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
//Mutation for new game object
// mutation {
//     newGameObject (position:{
//         x:10.0
//         y:11.0
//         z:14.0
//     }){
//         id
//         position {
//             x
//             y
//             z
//         }
//     }
//}

@Component
public class GameObjectMutation implements GraphQLMutationResolver {
    @Autowired
    private GameObjectService gameObjectService;

    public GameObject newGameObject(Vector3 position){
        return gameObjectService.createNew(position);
    }
}
