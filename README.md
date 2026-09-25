# GroupRun

A 3D hypercasual mobile endless runner developed with Unity and C#.

The player controls a growing group of characters, navigates through obstacles,
and makes strategic decisions using multiplication and division gates to reach
the end of each level.

## 🎮 Gameplay

<img width="1957" height="887" alt="Screenshot 2026-09-25 at 00 56 38" src="https://github.com/user-attachments/assets/46151d8f-70c3-456a-95c6-dbcd3c2d00f8" />

## ✨ Features

- Touch-based drag movement
- Automatic forward movement
- Group-based character control
- Character multiplication gates
- Character division gates
- Dynamic character spawning and removal
- Various obstacles and traps
- Collision-based gameplay mechanics
- Animated obstacles
- End-game logic
- Mobile-oriented gameplay
- End-game enemy encounter system
- Character count-based win/loss system

## 🛠️ Tech Stack

- **Engine:** Unity 6.5
- **Language:** C#
- **Platform:** Mobile
- **Genre:** Hyper-Casual / Endless Runner
- **Version Control:** Git / GitHub

## 🧑‍💻 Technical Implementation

The project was developed using modular gameplay systems written in C#.

### Player Movement

The player automatically moves forward while horizontal movement
is controlled through touch-based drag input.

### Character Management

The game dynamically manages the number of characters in the group.
Characters can be added or removed during gameplay depending on the
player's interaction with gates and obstacles.

### Multiplication & Division Gates

The game includes gates that modify the number of characters in the group.

- Multiplication gates increase the number of characters.
- Division gates decrease the number of characters.
- The character count is managed dynamically during gameplay.

### Obstacles

Different obstacle types interact with the player group through
Unity's physics and collision systems.

Examples include:

- Spikes
- Moving obstacles
- Hammers
- Fans
- Rotating saw blades

### Game State & End Game

### Game State & End Game

At the end of each level, a predefined number of enemy characters
is spawned to confront the player's group.

The outcome is determined by comparing the number of player characters
with the number of enemy characters.

- If the player's group has more characters, the player wins.
- If the enemy group has more characters, the player loses.
- The result is determined by the numerical advantage between the two groups.

## 🎨 Animation

Unity Animator and animation systems are used for:

- Character animations
- Moving obstacles
- Rotating obstacles
- Environmental interactions
- Gameplay feedback

## ⚡ Performance

Performance optimization was considered throughout development,
particularly for mobile gameplay and dynamic character spawning.

The project uses reusable GameObjects and gameplay logic designed
to minimize unnecessary operations during runtime.

## 📌 Project Status

**Status:** Playable / In Development

The core gameplay systems are implemented and functional.
The project is currently being refined with additional gameplay
mechanics, level elements, and performance improvements.

## 📂 Project Structure

```text
Assets/
├── Animations/
├── Materials/
├── Prefabs/
├── Scenes/
├── Scripts/
│   ├── Player/
│   ├── Obstacles/
│   ├── Gates/
│   └── GameManager/
└── ...
