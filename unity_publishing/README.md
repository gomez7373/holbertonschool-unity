# Unity - Publishing (Maze)

This project explores publishing a Unity game for multiple platforms (Windows, Mac, Linux, and Android). The game is a 3D maze that starts with a splash logo screen, loads a menu scene, and then loads the maze scene.

---

## Learning Objectives

- How to publish a build
- How to reorder scenes in a build
- How to build standalone applications for Windows, Mac, and Linux
- How to edit a project’s Quality Settings
- How to add an icon and logo to a build
- What the Profiler is and how to use it to check performance
- What to consider when developing for different platforms

---

## Requirements

- `README.md` at the root of the project folder
- Unity default `.gitignore`
- Push the entire `unity_publishing` project folder
- Scenes and project assets organized as required
- Public classes and members use XML documentation tags
- Private classes and members are documented (without XML tags)

---

## Project Structure

```
unity_publishing/
├── Assets/
│   ├── Images/
│   │   ├── mazeicon.png
│   │   └── mazelogo.png
│   ├── menu.unity
│   └── maze.unity
├── Builds/
│   ├── Windows/
│   ├── Linux/
│   ├── Mac/
│   └── movil/
└── ProjectSettings/
```

---

## Task 0: Quality Settings

The project Quality Settings include three quality levels:

- Low
- Medium
- High

---

## Task 1: Player Settings (PC, Mac & Linux Standalone)

- Company Name: Sheila Gómez Cubero
- Product Name: Maze
- Default Icon: `Assets/Images/mazeicon.png`
- Default Screen Width: 1024
- Default Screen Height: 768
- Resizable Window: On

### Splash Screen

- Splash Style: Light on Dark
- Animation: Dolly
- Draw Mode: Unity Logo Below
- Logo: `Assets/Images/mazelogo.png`
- Logo Duration: 4

---

## Task 2: Build Settings

### Scenes in Build (order)

1. menu
2. maze

### Builds

Builds are stored in the `Builds/` directory at the root of the project.

- Windows build: x86_64
- Linux build: x86_64
- Mac build: .app
- Development Build: unchecked

### ZIP Files

- Maze_Windows_x86_64.zip → LINK HERE
- Maze_Linux_x86_64.zip → LINK HERE
- Maze_Mac.zip → LINK HERE

---

## Task 3: Mobile Maze (Android)

An Android build is generated from the same Unity project.

### Mobile Requirements

- Landscape orientation
- Touch-based joystick controls
- Menu buttons usable with touch
- Android back button opens the menu
- Core maze gameplay remains unchanged

## Author

Sheila Gómez

