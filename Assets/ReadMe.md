# How to use features

## Camera

    - Add the Cam Behaviour script to the main camera(in the scene)

## Ground

    - Add the "Ground" and all objects that don't move (wall, bed...)
    - Go in the NavMeshSurface component 
    - Clear then Bake

    If you move objects that don't move you have to redo all the previous steps

## Canvas

    - Add the "Canvas" prefab to the scene
    - Put it in the player, in the player movement script (joystick controller)

## Player

    - Add the "Player" prefab to the scene
    - Remember to put the canva in the player movement scrip (joystick controller)

## Baby

    - Add the "Baby" prefab to the scene

## Mercy

    - Add the "Mercy" prefab to the scene
    - Put the player in the Mercy Behaviour script (player)
    - Put the MercyPath in the Mercy Behaviour script (path)

## MercyPath

    - Create a MercyPath object in the MercyPath folder
    - Add all the points (vector 3) of the mercy path in the "points" list