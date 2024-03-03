# StockfishVox - Simple Unity/Stockfish Bridge

## Description
This repository provides a simple Unity project template for integrating the Stockfish chess engine into your Unity applications. The project contains a single script, "StockfishVox.cs", which demonstrates how to launch Stockfish as an external process within Unity and communicate with it by sending commands and capturing its output.

### Key Features:
- Launches Stockfish as an external process from Unity.
- Sends commands to Stockfish and captures its output to mirror within Unity editor console.
- Demonstrates basic integration of external processes with Unity applications.

## Usage
1. Clone or download the repository.
2. Open the Unity project in the Unity Editor.
3. Attach the `"StockfishVox.cs"` script to an empty GameObject in your scene.
4. Run the Unity project to launch Stockfish.
5. Find fun things to do with [UCI commands](https://disservin.github.io/stockfish-docs/stockfish-wiki/UCI-&-Commands.html)

### Steer Stockfish with UCI Commands
The script `"StockfishVox.cs"` makes it simple to send UCI (Universal Chess Interface) commands to Stockfish. By iterating on the `"SendCommandToStockfish"` method with different UCI commands, you can steer Stockfish in more imaginative ways, allowing for dynamic interactions and gameplay mechanics in your Unity projects.

For instance, in the same way that `SendCommandToStockfish("uci");` is called within `StockfishVox.cs`, you could issue the commands:
```csharp 
SendCommandToStockfish("uci");
SendCommandToStockfish("isready");
SendCommandToStockfish("ucinewgame");
SendCommandToStockfish("position startpos");
```

to set up a standard chessboard for further manipulation and analysis.

### Debug Stockfish in Unity
Stockfish output is printed to the Unity console, effectively mirroring it within the Editor.


