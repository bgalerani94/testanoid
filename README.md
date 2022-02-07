
# Architecture Test by Bruno Galerani

## Summary of requested requirements
- Kiss principle
	- The project is as simple as possible, but still containing all the needed features and code requirements.
- Decoupling data and representation
	- The project is better divided now, separating the scripts related to data, representation and core logic.
- Composition over inheritance
	- Composition was mainly used for the scripts in the project.
- Single responsibility principle
	- Tried to divide the responsibilities into specific scripts, so the single responsibility principle could be achieved.
	-  One example for this is the InputMovementController class that can be added to any Physics2D object and it will correctly move with user inputs.
- Application of design patterns where possible
	- It was possible to use some design patterns, such as Observers and Singletons.
	- Created a singleton component to make it easier to user MonoBehaviours as Singletons.

## Important Notes
### Coding Related
- Created different scripts to handle each part of the game, such as the player, the ball, the bricks, the levels, the menus and the scene management.
- About the Player movement:
	- The InputMovementController behaviour is responsible for moving the player (both for desktop/editor and mobile devices).
	- If the user is using a Mobile device to play the game, they can control the player by clicking at the desired side of the screen.
	- If the user is using a Desktop to play the game, they can control the player by using the keyboard's arrows.
- All the inputs are checked in the Update method.
- All the physics movement/calculation are performed in the FixedUpdate method.
- The ball's direction changes according to the point that it has hit the player. This was done in order to follow the classic Arkanoid behavior.
- Added a Platform Effector 2D to make sure that the collision's behavior will happen only on the desired direction, so we can avoid unwanted behaviors, such as the ball somehow colliding with the bottom of the player.
- Used the Observer pattern to trigger events such as the bricks being destroyed or the ball hitting the death zone.
- Developed a visual Level Creator tool with ScriptableObjects
	- The Array2DEditor package was used in order to improve the level creator visual in the Editor.
	- Levels can be created visually in the Editor by defining the height and width of a 2D Array and by selecting the areas where a brick should be created.
	- The LevelScriptableObjects make use of Adressables to be loaded.
- Developed a Transition prefab with an animation that will be played every time that a scene is loaded by it.
- Created an float Extension method to randomly negates a number.
- Developed a SingletonComponent class, so it would be easier to use MonoBehaviours as singletons in the project.
- Created Interfaces for the MonoBehaviours used by the GameController, so it would be easier to Mock and create Unit Test for them.

### UI/Graphics Related
- Tried to keep the assets as simple as possible, as required in the project description
- Changed the colors that are used in the project.
- Changed the canvases so all of them are able to auto adapt to any screen ratio, making them work on both Desktop and Mobile devices.
- Added and made use of TextMeshPro for every texts in the game.
- There are three scenes available: Main Scene, Gameplay Scene and the End Scene
- Before the game starts, there's a countdown and a simple tutorial about the player movement:
	- This countdown can be modified in the Editor to have as much sentences as the developer/artist wants
	- It's possible to change the duration of the countdown in the Editor as well
	- It's possible to change the tutorial description in the Editor as well


## Unity Version
The Unity Editor version was upgraded to the latest LTS available by February 4th (2020.3.27f1) so we can use newer features and also guarantee a better stability.
