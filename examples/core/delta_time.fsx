#nowarn "3391"


#r "nuget: Raylib-cs"

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

type Ball =
    { mutable Position: Vector2
      Color: Color option
      Radius: float }

let screenWidth: int = 800
let screenHeight: int = 450
let mutable fps: int = 60

InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window")
SetTargetFPS fps

let isKeyDown (key: KeyboardKey) : bool = CBool.op_Implicit (IsKeyDown(key))

let mutable deltaBall: Ball =
    { Position = Vector2(0.0f, float32 screenHeight / 3f)
      Color = Some Color.Red
      Radius = 50.0 }

let mutable frameTightBall: Ball =
    { Position = Vector2(0.0f, deltaBall.Position.Y + 180.0f)
      Color = Some Color.Blue
      Radius = 50.0 }

while not (Raylib.WindowShouldClose()) do

    let mouseWheelMotion = GetMouseWheelMove()

    if mouseWheelMotion <> 0.0f then
        fps <- fps + (int mouseWheelMotion)

        if fps < 0 then
            fps <- 0

        SetTargetFPS fps

    let dt: float32 = GetFrameTime()
    let speed: float32 = 100.0f
    deltaBall.Position.X <- deltaBall.Position.X + dt * 0.6f * speed
    frameTightBall.Position.X <- frameTightBall.Position.X + 0.1f * speed

    if deltaBall.Position.X > float32 screenWidth then
        deltaBall.Position.X <- 0.0f

    if frameTightBall.Position.X > float32 screenWidth then
        frameTightBall.Position.X <- 0.0f

    BeginDrawing()
    ClearBackground Color.Gold

    DrawText("Move the mousewheel to change fps", 10, 10, 20, Color.DarkGray)
    DrawText($"FPS: {fps}", 40, 40, 20, Color.DarkGray)
    DrawCircleV(deltaBall.Position, float32 deltaBall.Radius, deltaBall.Color.Value)
    DrawCircleV(frameTightBall.Position, float32 frameTightBall.Radius, frameTightBall.Color.Value)

    EndDrawing()

CloseWindow()
