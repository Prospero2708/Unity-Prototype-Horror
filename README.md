# Unity 3D Gameplay Mechanics & Utilities

A curated repository of optimized, production-ready C# scripts for Unity 3D. This library focuses on **Event-Driven Architecture (New Input System)**, performance optimization, integration with the modern **AI Navigation (NavMesh)** package.

* **`InputRead.cs`** — Centralized input manager utilizing the **New Input System**. Converts raw player input into clean C# events (`Action`). Includes symmetrical event unsubscription in `OnDisable` to prevent memory leaks.
----------------
* **`movement.cs`** — Advanced physics-based 3D character controller. Seamlessly consumes vector events from `InputRead` to manage `Rigidbody` states via `linearVelocity`. Features a built-in **momentum/sprint scaling system** that dynamically increases player speed and camera-bobbing animation frequency based on button-hold duration.
----------------
* **`CameraLook.cs`** — A highly optimized First/Third-person mouse look controller. It features independent axis rotation (yaw applied to the player root, pitch applied to the camera) and configurable vertical clamping. Most importantly, it utilizes a **frame-rate independent exponential smoothing function** (`1f - Mathf.Exp(-factor * Time.deltaTime)`) for fluid interpolation, completely eliminating camera jitter regardless of target hardware performance.

* **`Agent.cs`** — AI agent controller powered by **NavMeshAgent**. Manages movement across baked NavMesh surfaces. Allows the character to reach the target and changes their animation speed.
----------------
* **`CalculateDistance.cs`** — An optimized utility script that calculates distances between key game objects to feed AI logic and distance-based triggers.

* **`interaction.cs`** — A reusable interaction component. It casts a `Physics.Raycast` from the camera's viewport center to detect and trigger interactive world objects.

* **`TimerScript.cs`** — A custom tick-based timer system designed to offload heavy calculations from the standard `Update` loop to low-frequency intervals (every 0.5 seconds).
----------------
* **`GrainEffect.cs`** — Post-processing controller for distance-based grain effects. Subscribes to `TimerScript` and utilizes aggressive profile caching (`currentProfile`) to completely eliminate redundant CPU overhead in idle frames.