# Unity Presentation Framework

## Why Presentation in Unity

Conventional presentation like Microsoft Power Point, Prezi only utilize 2D plane. Game engines not only give us another dimension of freedom, but its Particle System, Physical Effect, Programmability, etc. provide richness of data visualization.

Due to the highly customizable property, it is capable for Physics, Big Data, Business Intelligence and Arts presentations. It is a superset of standard 2D presentation editor.

Furthermore, Unity is free. It supports WebGL, thus the presentation can be deployed on your webpages. Thanks for .NET framework's support, your presentation can also take real-time data from web services and stream to the presentation.


## Installation

Clone the project to your machine and open with Unity 3D (5.4)


## Version 1.0 Features

*	Auto Play/Manual Play Mode
*	Default Theme including 4 Templates (Master Slide)
*	Reusable Prefab of Charts:
 * Globe that maps real-world coordinates
 *	US map that can highlight states separately
 * Particle Cloud showing Percentage
 * Matrix of Icosphere showing Percentage
* CoreAnimation script that enables auto-rotation and micro-motion of elements


## Usage

### Using Default Theme
1.	Copy "Empty Presentation" Scene and rename it to your presentation topic or whatever
2.	Drag a master prefab from "/Default Theme" folder to the scene
3.	Customize the content
4.	Repeat 2) - 3) for other slides in your presentation
5.	Drag each slide root from Hierarchy window to "Player" object's "Targets" array
6.	Hit play, now you can play the presentation (RMB and LMB to navigate to Next/Previous slide)
7.	You can build the presentation to a .exe or WebGL file.

### Developing New Template (For programmers)
1.	Create an empty gameObject "YourSlide" and attach "YourSlide.cs" that inherits "AbstractSlide.cs"
2.	Create more gameObject like TextMesh, Globe, ParticleEffect, etc. under the "YourSlide". (Please refer to /Default Theme/Prefabs)
3.	Add YourSlide to "Player"'s Targets array
4.	Hit play, there you go


## Documentation And Tips

(Documentation still in progress)

1.	For those who wish to change the texture of the Globe element. The UV is compatible with standard Earth texture (Refer to NASA’s Texture at: http://visibleearth.nasa.gov/view.php?id=74192).
2.	Always create the new slide with transform(0,0,0) since you can view from game camera in case any thing is out of boundary.


## Future Works
* Entering and Exiting Animation
* Easy of Use Custom Editor and Previews
* Proxy that can fetch data via web services


## Contributing

1.	Fork it!
2.	Create your new feature branch: `git checkout -b my-new-feature`
3.	Commit your changes: `git commit -am 'Add some feature'`
4.	Push to the branch: `git push origin my-new-feature`
5.	Submit a pull request :D


## Credits

Hope you enjoy this little project. Feel free to build your own presentation templates under the framework, or include in your own project. Let me know your thoughts by jackchang26@gmail.com thanks! -Jack

