#nowarn "3391"

#r "nuget: Raylib-cs"

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

let screenWidth = 800
let screenHeight = 450

type Ball =
    { mutable Position: Vector2
      Radius: float32
      Color: Color option
      Speed: float32 }

let ball: Ball =
    { Position = Vector2(float32 screenWidth / 2.0f, float32 screenHeight / 2.0f)
      Radius = 50.0f
      Speed = 10.0f
      Color = Some Color.Blue }

InitWindow(screenWidth, screenHeight, "raylib [core] example - input keys")
SetTargetFPS 60

let isKeyDown (key: KeyboardKey) : bool = CBool.op_Implicit (IsKeyDown(key))

let (|UP|DOWN|LEFT|RIGHT|NONE|) () =
    if isKeyDown KeyboardKey.Up then UP
    elif isKeyDown KeyboardKey.Down then DOWN
    elif isKeyDown KeyboardKey.Left then LEFT
    elif isKeyDown KeyboardKey.Right then RIGHT
    else NONE

while not (Raylib.WindowShouldClose()) do

    match () with
    | UP -> ball.Position.Y <- ball.Position.Y - ball.Speed
    | DOWN -> ball.Position.Y <- ball.Position.Y + ball.Speed
    | LEFT -> ball.Position.X <- ball.Position.X - ball.Speed
    | RIGHT -> ball.Position.X <- ball.Position.X + ball.Speed
    | NONE -> ()

    BeginDrawing()

    ClearBackground Color.RayWhite
    DrawText("move the ball with arrow keys", 10, 10, 20, Color.DarkGray)
    DrawCircleV(ball.Position, ball.Radius, ball.Color.Value)

    EndDrawing()

CloseWindow()
