Unity Mini-Projects

This repository hosts two small Unity projects built around a simple controllable character and lightweight scene mechanics.

* **Bob in Wonderland** — sandbox scene with material-swapping cubes, scale-change interactions, free camera, optional collision SFX, five speed levels. Target 1024×768. Prebuilt EXE included.
* **Project 2 — Treasure Bob** — maze runner with random treasures and traps, score and game-over flow, keyboard camera, five speed levels, 1024×768 windowed. Prebuilt EXE included.&#x20;

## Structure

```
.
├─ BobInWonderland/
│  ├─ Assets/ … (Scripts, Materials, Textures, Audio, Scenes)
│  ├─ excecutable/
│  │  └─ Bob in Wonderland.exe
│  └─ README.md
├─ TreasureBob/
│  ├─ Assets/ … (Scripts, Materials, Textures, Prefabs, Audio, Scenes)
│  ├─ Treasure Bob builder/
│  │  └─ Treasure Bob.exe
│  └─ README.md
└─ README.md  # this file
```

## Quick start

* **Run binaries**

  * Wonderland: `BobInWonderland/excecutable/Bob in Wonderland.exe`
  * Treasure Bob: `TreasureBob/Treasure Bob builder/Treasure Bob.exe`
* **Open in Unity**

  * Open each folder as a separate Unity project via Unity Hub.
  * Load the main scene under `Assets/Scenes` and press **Play**.
* **Target display**

  * Both projects are tuned for **1024×768** windowed. Adjust if needed.&#x20;

## Controls (summary)

* **Bob in Wonderland**

  * Move: `A/D` (X), `S/X` (Z), `W/E` (Y).
  * Speed presets: `1–5`.
  * Camera: arrows to move/orbit, `+/-` to change height.
* **Treasure Bob**

  * Move: `j/l` (X), `i/k` (Z).
  * Speed: `Z/X` through five levels.
  * Camera: arrows (X/Z), `+/-` (Y), `r` rotate.&#x20;

## Building

* Open each project → `File → Build Settings…` → add active scene → set **1024×768** in Game/Player settings → **Build**.&#x20;

## Screenshots and media

```md
## Screenshots
docs/wonderland_scene.png
docs/treasure_run.png
```
