BOOK UP is a mission-based interactive simulation built in Unity6, following Kagabo a volunteer who distributes books in a rural village in Africa. Along the way, the player meets obstacles that cost him books and time and the goal is not to win or lose but walk with him and see struggles people like him face.

GCGO statement
Grand Challenge & Global Opportunity: Education and Literacy accessibility in Africa

Mission Statement: Using technology to enhance the literature experience in Africa by creating a digital reading platform that is fun, interesting, and challenging

Problem Context 
The problem is that across rural Rwanda , children face multiple and overlapping barriers to literacy. Books are scarce and most of them are imported in colonizers' languages and they are not able to understand and enjoy them. 

Why it matters: 
I think it matters because early literacy is fundamental and essential to a child's intellectual development. Children in underpriviledged communities deserve that chance too.

How it connects to the GCGO: The simulation shows the problems the children in these communities face, poor infrastructure, language barriers, poverty etc. 

Simulation Overview

The player controls Kagabo as he travels on foot toward a rural school, carrying a bag of books. Along the path he meets a series of obstacles, each of which costs him books and surfaces an awareness message backed by a real statistic about literacy in rural Africa. When he arrives at the school, he turns and points the player's attention to a "Take Action" .

Target users: Students, educators, and the general public and anyone who can benefit from an empathy-building introduction to literacy-access challenges in rural Africa.

Key interactions are the WASD keys and mouse navigation. 

Unity Mechanics Implemented

UI: The game uses Unity's Canvas-based UI throughout. A persistent book-count panel tracks how many books survive the journey. A shared obstacle popup panel is reused across all obstacles, with each zone supplying its own text and statistic. TextMeshPro is used for all text, and a Canvas Scaler set to "Scale With Screen Size" keeps the UI readable across resolutions.

Scripting: The simulation is driven by a set of modular C# scripts. A GameManager script(persisted with DontDestroyOnLoad) tracks the book count across the experience. PlayerController handles movement. ObstacleZone manages each obstacle's popup, statistic, book deduction, and optional reveal of scene objects. EndingSequence orchestrates the finale with a timed coroutine. Supporting scripts handle camera following, scene transitions, and UI updates.

Collision: The simulation is basically based on box colliders. The obstacleZone script has an onTrigger() method that is called whenever the player hits the box collider and displays a UI pop up.

Raycasting: Raycasting is used at the final part of the simulation where the player points at the billboard, then the camera views in to display a message meant for the user. 

Line renderer: When the player points to the billboard, a visible line is drawn from him to the billboard we're supposed to see.

Additional features: 
1. Camera switching between a follow camera and a dedicated end camera for the finale
2. Real-data integration: every obstacle is backed by a documented statistic about literacy access in Africa.

To open the project in Unity (for review/grading):


1. Clone or download the repository:  https://github.com/Inema-Leslie/Mission-Based-Interactive-Simulation
2. Open the project in Unity 6 (6000.x)
3. Open the MeetKagabo scene  from the Scenes folder
4. Press Play in the Unity Editor
5. Use the WASD keys to move around or the mouse

WebGL build:
https://play.unity.com/en/games/adeb1bbf-d3fe-40e3-b843-24ed7fc08675/webglbuild 

Sources and credits
1. Characters and props
https://assetstore.unity.com/packages/3d/environments/landscapes/hills-mountains-and-lakes-terrains-stamps-and-brushes-220273 
https://polyhaven.com/a/rocky_terrain_02 
https://polyhaven.com/a/sparse_grass 
https://www.mixamo.com/#/?genres=&page=3&query=&type=Motion%2CMotionPack  
https://assetstore.unity.com/packages/3d/environments/fantasy/stylized-fantasy-pagan-village-demo-302012 
https://www.mixamo.com/#/?page=1&query=&type=Motion%2CMotionPack 
2. Statistics
https://www.unesco.org/ru/articles/african-book-industry-trends-challenges-opportunities-growth 
https://old.adeanet.org/en/working-groups/books-learning-materials 
https://www.unesco.org/en/articles/africas-book-industry-unesco-highlights-its-economic-and-cultural-potential-new-report 


