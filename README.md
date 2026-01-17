<p align="center">
  <img src="https://www.especial.gr/wp-content/uploads/2019/03/panepisthmio-dut-attikhs.png" alt="UNIWA" width="150"/>
</p>

<p align="center">
  <strong>UNIVERSITY OF WEST ATTICA</strong><br>
  SCHOOL OF ENGINEERING<br>
  DEPARTMENT OF COMPUTER ENGINEERING AND INFORMATICS
</p>

<hr/>

<p align="center">
  <strong>Human-Computer Interaction</strong>
</p>

<h1 align="center" style="letter-spacing: 1px;">
  Virtual Gym
</h1>

<p align="center">
  <strong>Vasileios Evangelos Athanasiou</strong><br>
  Student ID: 19390005
</p>

<p align="center">
  <a href="https://github.com/Ath21" target="_blank">GitHub</a> ·
  <a href="https://www.linkedin.com/in/vasilis-athanasiou-7036b53a4/" target="_blank">LinkedIn</a>
</p>

<p align="center">
  <strong>Viktor Romanyuk</strong><br>
  Student ID: 713242017024
</p>

<p align="center">
  <a href="https://github.com/vromanyu" target="_blank">GitHub</a> ·
  <a href="https://www.linkedin.com/in/viktor-r-2387822a1/" target="_blank">LinkedIn</a>
</p>

<p align="center">
  <strong>Panagiotis Petropoulos</strong><br>
  Student ID: 20390188
</p>

<p align="center">
  <a href="https://github.com/PanosPetrop" target="_blank">GitHub</a> 
</p>

<p align="center">
  <strong>Georgios Theocharis</strong><br>
  Student ID: 19390283
</p>

<p align="center">
  <a href="https://github.com/geotheo01" target="_blank">GitHub</a>
</p>

<p align="center">
  Supervisor: Christos Troussas, Assistant Professor<br>
</p>

<p align="center">
  <a href="https://ice.uniwa.gr/en/emd_person/christos-troussas/" target="_blank">UNIWA Profile</a>  ·
  <a href="https://gr.linkedin.com/in/christos-troussas" target="_blank">LinkedIn</a>
</p>

<p align="center">
  Co-Supervisor: Panagiotis Strousopoulos, Postdoctoral Researcher<br>
</p>

<p align="center">
  <a href="https://scholar.google.com/citations?user=qxVeukgAAAAJ&hl=el" target="_blank">UNIWA Profile</a>
</p>

<p align="center">
  Athens, July 2024
</p>

---

# Project Overview

**Virtual Gym** is an interactive fitness simulation developed using the **Unity Engine (version 2022.3.31f1)**.  
It allows users to perform virtual exercises on various gym equipment, receive guidance from a virtual trainer, and follow personalized nutritional plans.

---

## Table of Contents

| Section | Folder / File | Description |
|--------:|---------------|-------------|
| 1 | `src/` | Unity project source code |
| 1.1 | `src/Assets/Scripts/` | C# source files (.cs) |
| 1.1.1 | `src/Assets/Scripts/Controllers/` | Player and camera control logic |
| 1.1.1.1 | `PlayerController.cs` | Handles player movement and interaction |
| 1.1.1.2 | `CameraController.cs` | Manages camera movement and rotation |
| 1.1.2 | `src/Assets/Scripts/Exercises/` | Exercise mechanics and animations |
| 1.1.2.1 | `ExerciseBase.cs` | Abstract base class for exercises |
| 1.1.2.2 | `TreadmillExercise.cs` | Treadmill exercise logic |
| 1.1.2.3 | `BikeExercise.cs` | Stationary bike exercise logic |
| 1.1.2.4 | `WeightsExercise.cs` | Free-weights exercise logic |
| 1.1.3 | `src/Assets/Scripts/Trainer/` | Virtual trainer behavior |
| 1.1.3.1 | `TrainerController.cs` | Controls trainer guidance and feedback |
| 1.1.4 | `src/Assets/Scripts/User/` | User data and profiles |
| 1.1.4.1 | `UserProfile.cs` | Stores user personal and fitness data |
| 1.1.5 | `src/Assets/Scripts/Nutrition/` | Nutrition and diet planning |
| 1.1.5.1 | `NutritionPlan.cs` | Manages nutritional recommendations |
| 1.1.6 | `src/Assets/Scripts/Utilities/` | Helper and utility classes |
| 1.1.6.1 | `GameManager.cs` | Global game state management |
| 1.1.6.2 | `DataManager.cs` | Saves and loads user progress |
| 2 | `assign/` | Project assignment documents |
| 2.1 | `assign/Final Project_ac.year 2023-2024.pdf` | Final project description (English) |
| 2.2 | `assign/Τελική Εργασία_ακ. έτους 2023-2024.pdf` | Final project description (Greek) |
| 3 | `build/` | Compiled application build |
| 3.1 | `build/Build.zip` | Executable build of the Virtual Gym |
| 4 | `diagram/` | System and task analysis diagrams |
| 4.1 | `diagram/Hierarchical-Task-Analysis.drawio` | Hierarchical Task Analysis (editable) |
| 4.2 | `diagram/Hierarchical-Task-Analysis.png` | Hierarchical Task Analysis (image) |
| 4.3 | `diagram/Ιεραρχική-Ανάλυση-Εργασιών.png` | Hierarchical Task Analysis (Greek) |
| 5 | `docs/` | Project documentation |
| 5.1 | `docs/Technical-Manual.pdf` | Technical manual (English) |
| 5.2 | `docs/User-Manual.pdf` | User manual (English) |
| 5.3 | `docs/Τεχνικό-Εγχειρίδιο.pdf` | Technical manual (Greek) |
| 5.4 | `docs/Εγχειρίδιο-Χρήστη.pdf` | User manual (Greek) |
| 6 | `README.md` | Project documentation |

---

## Features

- **Interactive Exercises**  
  Perform workouts on treadmills, bicycles, bars, weights, and more.

- **Fitness Instructor**  
  Receive personalized gym programs based on user-provided data such as **weight, age, and height**.

- **Virtual Nutritionist**  
  Access dietary advice and nutrition programs tailored to the user’s fitness status.

- **In-Game Economy**  
  Earn in-game currency by completing exercises and spend it on fitness products at the vending machine.

- **Dynamic Animations**  
  Realistic walking, running, and exercise animations implemented using the **Unity Animator**.

---

## Controls

| Action         | Control                         |
|----------------|----------------------------------|
| Movement       | `WASD` or Arrow Keys             |
| Camera         | Mouse Movement                   |
| Interaction    | `E` key (e.g., exit door)        |
| Inventory      | `D` key                          |
| Online Help    | `F1` key                         |
| Exit Menu      | `Esc` key                        |

---

## Technical Details

- **Engine:** Unity  
- **Programming Language:** C#  
- **Assets:**  
  - 3D models sourced from **Sketchfab** (gym environment)  
  - Character animations sourced from **Mixamo**

### Architecture

- **State Machine**  
  Uses a node-based Animator to transition between states such as *Idle*, *Walking*, and various exercise actions based on user input and collisions.

- **Collision System**  
  Triggers specific exercise modes when the player enters the collision zone of gym equipment.

---

# Installation & Setup Guide  

This guide explains how to **install, configure, and run** the **Virtual Gym** project.  
The application is developed with **Unity** and **does NOT require WebGL**.  
A **pre-built Windows executable (.exe)** is already included in the repository.

---

## Prerequisites

### 1. Operating System
- **Windows 10 / Windows 11** (required for running the `.exe` build)

### 2. Software (Optional – for development only)

If you **only want to run the application**, no additional software is required.  
If you want to **open or modify the project**, you will need:

#### Unity Hub
- https://unity.com/download

#### Unity Editor
- Install the **exact Unity version** defined in:
ProjectSettings/ProjectVersion.txt

> Do **not upgrade** the Unity version unless explicitly required.

---

## Steps to Run from Source

A **ready-to-run executable** is already provided.

### 1. Clone or Download the Repository

```bash
git clone https://github.com/Human-Computer-Interaction/Virtual-Gym.git
```
or download the ZIP and extract it.

### 2. Run the Executable
Navigate to the `build/` directory

Locate the application file:
```bash
VirtualGym.exe
```
Double-click the .exe file to launch the application

> No Unity installation is required to run the executable

#### Or

1. **Add Project**  
   Open Unity Hub and select **Add**, then choose the `Virtual-Gym` project folder.

2. **Build Application**  
   - Open the project in the Unity Editor.  
   - Press `Ctrl + Shift + B` to open **Build Settings**.  
   - Press `Ctrl + B` to build and run the executable.

3. **Launch**  
   Navigate to the generated **Build** folder and run `VirtualGym.exe`.

---

## Development Setup (Optional)
Only follow this section if you want to edit, inspect, or extend the project.

### 1. Open Project in Unity
1. Launch Unity Hub
2. Click Add → Add project from disk
3. Select the Virtual-Gym project folder
4. Open the project using the specified Unity version

### 2. Run Inside Unity Editor
1. Open the main scene (usually located in `Assets/Scenes/`)
2. Press the ▶ Play button
3. Interact with the Virtual Gym environment

---

## Building the Project (Optional)
To rebuild the executable:
1. File → Build Settings
2. Platform: PC, Mac & Linux Standalone
3. Target Platform: Windows
4. Architecture: x86_64
5. Click Build

The output will generate a new .exe inside a selected folder.

---

## Open the Manuals
1. Navigate to the `docs/` directory
2. Open the report corresponding to your preferred language:
    - English: `User-Manual.pdf`, `Technical-Manual.pdf`
    - Greek: `Εγχειρίδιο-Χρήστη.pdf`, `Τεχνικό-Εγχειρίδιο.pdf`