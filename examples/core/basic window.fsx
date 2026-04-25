#nowarn "3391"


#r "nuget: Raylib-cs"

open Raylib_cs
open System.Numerics
open type Raylib_cs.Raylib

let screenWidth: int = 800
let screenHeight: int = 450

InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window")
SetTargetFPS 60

let isArrowKey (key: KeyboardKey) : bool = CBool.op_Implicit (IsKeyDown key)

let mutable ballPosition =
    Vector2(float32 screenWidth / 2.0f, float32 screenHeight / 2.0f)

while not (Raylib.WindowShouldClose()) do
    let speed = 10.0f

    if isArrowKey KeyboardKey.Right then
        ballPosition.X <- ballPosition.X + speed

    if isArrowKey KeyboardKey.Left then
        ballPosition.X <- ballPosition.X - speed

    if isArrowKey KeyboardKey.Up then
        ballPosition.Y <- ballPosition.Y - speed

    if isArrowKey KeyboardKey.Down then
        ballPosition.Y <- ballPosition.Y + speed

    BeginDrawing()
    ClearBackground Color.RayWhite

    DrawText("move the ball with arrow keys", 10, 10, 20, Color.DarkGray)
    DrawCircleV(ballPosition, 50.0f, Color.Maroon)

    EndDrawing()

CloseWindow()
