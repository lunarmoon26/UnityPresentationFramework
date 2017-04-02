# Unity Presentation Framework
An All-in-One Presentation Solution for Realtime Big Data Visualization

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

## Version 1.1 Updates

*	Added Custom Editor on PlayerController, simplified the steps of adding/removing/reordering slides
*	Removed "Hidden" flag in AbstractSlideController, using Unity's native gameObject.activeSelf to enable/disable slides
* Click each row in "Slides" section of PlayerController Custom Editor to Preview selected slide
*	Minor bug fixes


## Usage

### Using Default Templates
1.	Copy "Empty Presentation" Scene and rename it to your presentation topic or whatever
2.  Click on "Player" in the Hierarchy window
3.  Click "+" in "Slides" panel in Inspector, select a template from Default Theme
4.	Customize the content
5.	Repeat 2) - 4) for other slides in your presentation
6.	Hit play, now you can play the presentation (RMB and LMB to navigate to Next/Previous slide)
7.  On "Player" Inspector, drag & drop to reorder slides if necessary
7.	You can build the presentation to a .exe or WebGL file.

### Developing New Template (For programmers)
1.	Create an empty gameObject "YourSlide" and attach "YourSlide.cs" that inherits "AbstractSlide.cs"
2.	Create more gameObject like TextMesh, Globe, ParticleEffect, etc. under the "YourSlide". (Please refer to "Assets/Themes/Default/Prefabs")
3.	Put YourAwesomeTemplate.prefab under "Assets/Themes/Default/Templates"
4.	Use your template in the scene, hit play, there you go

### Developing New Theme (For programmers)
1.	Create a new folder in Assets/Themes, name to your theme
2.	Please refer to the folder structure of "Assets/Themes/Default/Prefabs"
3.	There at least should be a "Templates" directory in your theme folder


## Documentation And Tips

(Documentation still in progress)

1.	For those who wish to change the texture of the Globe element. The UV is compatible with standard earth [Equirectangular Projection](https://en.wikipedia.org/wiki/Equirectangular_projection) texture (Refer to NASA’s Texture [here](http://visibleearth.nasa.gov/view.php?id=74192)).


## Future Works
* Entering and Exiting Animation
* Preview animation
* Proxy that can fetch data via web services
* Data Driven gameObject creation (inspired by D3.js)
* VR/AR support

## Contributing

1.	Fork it!
2.	Create your new feature branch: `git checkout -b my-new-feature`
3.	Commit your changes: `git commit -am 'Add some feature'`
4.	Push to the branch: `git push origin my-new-feature`
5.	Submit a pull request :D


## Credits

Hope you enjoy this little project. Feel free to build your own presentation templates under the framework, or include in your own project. Let me know your thoughts by jackchang26@gmail.com thanks! -Jack Zhang

