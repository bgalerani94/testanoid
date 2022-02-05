#Architecture Test by Bruno Galerani

##Summary of requested requirements
- Kiss principle
	* The points will be listed here
- Decoupling data and representation
	- The points will be listed here
- Composition over inheritance
	- The points will be listed here
- Single responsibility principle
	- The points will be listed here
- Application of design patterns where possible
	- The points will be listed here

##Important Notes
- The ball's direction changes according to the point that it has hit the player. This was done in order to follow the classic Arkanoid behavior.
- About the Player movement:
	* If the user is using a Mobile device to play the game, they can control the player by clicking at the desired side of the screen.
	* If the user is using a Desktop to play the game, they can control the player by using the keyboard's arrows
- Added a Platform Effector 2D to make sure that the collision's behavior will happen only on the desired direction, so we can avoid unwanted behaviors, such as the ball somehow colliding with the bottom of the player.
- Created some Extensions methods that could be useful.
- The Array2DEditor package was used in order to improve the level creator visual in the Editor.

##Unity Version
The Unity Editor version was upgraded to the latest LTS available by February 4th (2020.3.27f1) so we can use newer features and also guarantee a better stability.