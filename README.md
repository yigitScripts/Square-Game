# 🟦 Strategic Squares (Advanced Dots & Boxes)

A sophisticated console-based strategy game inspired by the classic **Dots and Boxes**. Developed in C#, this project takes the traditional gameplay to the next level with a multi-stage round system, dynamic map alterations, and an AI opponent.

## 🚀 Features

* **Multi-Stage Gameplay:** Unlike the classic game, each turn consists of 3 distinct stages:
    1.  **Stage 1:** Strategic line placement to form squares.
    2.  **Stage 2:** Free placement (non-regular moves allowed).
    3.  **Stage 3 (Chaos Event):** The game dynamically inserts a random 5x5 grid structure into the main map, altering the board state.
* **AI Opponent:** A programmed bot that calculates moves, detects potential squares, and competes against the player.
* **Dynamic Scoring:**
    * **Player (P):** Captured squares are marked in **Blue**.
    * **Computer (C):** Captured squares are marked in **Red**.
    * **Penalties:** Incorrect moves result in score deductions.
* **Visual Feedback:** Uses standard console colors to differentiate between empty space, lines, and captured territories.
* **Difficulty Levels:**
    * Easy (5 Trials)
    * Moderate (50 Trials)
    * Hard (500 Trials)

## 🎮 How to Play

### Controls
* **Arrow Keys (⬆️⬇️⬅️➡️):** Move the cursor across the grid nodes (`+`).
* **Spacebar:** Place a line (horizontal `-` or vertical `|`) between nodes.
* **Enter:** Skip/Confirm stage.

### The Objective
Connect adjacent dots with lines. When a player completes the fourth side of a 1x1 box, they earn a point and mark that box. The player with the most boxes at the end wins. Be careful of the **Stage 3** random events that can block your path or gift squares to the opponent!

## 🛠 Technology Stack

* **Language:** C#
* **Framework:** .NET Framework / .NET Core
* **Interface:** System.Console

## ⚙️ Installation & Usage

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/yigitScripts/Advanced-Console-Squares.git](https://github.com/yigitScripts/Advanced-Console-Squares.git)
    ```
2.  **Open the project:**
    Open the solution in **Visual Studio** or **VS Code**.
3.  **Run:**
    * **Visual Studio:** Press `F5`.
    * **Terminal:**
        ```bash
        dotnet run
        ```

## 📸 Gameplay Mechanics

The game grid is generated procedurally:
```text
+ - +   +   +
| P |   | C |
+ - + - + - +
+ : Nodes

| / - : Lines

P : Player Owned

C : Computer Owned

: : Pre-existing/Ownerless squares
