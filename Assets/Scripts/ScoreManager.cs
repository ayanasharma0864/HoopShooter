# HoopShooter – 3D Basketball Shooting Game

A 3D basketball shooting game built in Unity. Aim, charge your shot, and score as many baskets as you can before the 60-second timer runs out.

Made as the extra project (Project #6, Basketball Shooting Game) for the SWAYAM course assignment.

## Gameplay

- Move the ball left and right, charge the power, and shoot at the hoop.
- A basket counts only when the ball passes through the top zone and then the bottom zone of the rim, so shots that bounce off the rim don't count.
- You have 60 seconds. When time is up, your final score is shown and you can restart.

## Controls

| Key | Action |
|---|---|
| A / D (or Left / Right arrows) | Move the ball sideways |
| Hold Space | Charge shot power |
| Release Space | Shoot |
| R | Restart (after time is up) |

## Features

- Physics-based ball movement with gravity and bounce
- Trigger-based scoring (two zones inside the hoop)
- Live score and countdown timer UI
- Game-over screen with restart
- Sound effects: bounce, swish and buzzer
- Particle burst when you score

## Concepts Demonstrated

| Concept | Where it is used |
|---|---|
| GameObjects, Transform, hierarchy | Court, backboard, rim (parent with four child bars) |
| Materials and lighting | Orange ball and rim, directional light |
| Rigidbody and gravity | Ball physics, `AddForce` |
| Colliders | Ball, rim and backboard |
| Trigger colliders | `TopZone` / `BottomZone`, `OnTriggerEnter` |
| C# scripting | `BallThrower`, `ScoreManager`, `ZoneTrigger` |
| Input handling | Movement, charge and release to shoot |
| Collision events | `OnCollisionEnter` for bounce sound |
| UI (TextMeshPro, Canvas) | Score, timer, game-over message |
| Game state, scene management | Timer, game over, restart |
| Audio | `AudioSource`, `PlayOneShot` |
| Particle systems | Score burst |

## Scripts

- `BallThrower.cs` – moves, charges and throws the ball, resets it, plays the bounce sound.
- `ScoreManager.cs` – score, timer, game over, restart, swish/buzzer sounds, score effect.
- `ZoneTrigger.cs` – tells the ScoreManager when the ball enters the top or bottom zone.

## How to Run

1. Install Unity 6 (project created with Unity 6000.6, Universal Render Pipeline).
2. Clone this repository and open the folder in Unity Hub.
3. Open `Assets/Scenes/Main.unity` and press Play.

## Credits

- Bounce sound: "BasketballBounce.wav" by Blankened, freesound.org (check the licence on the page).
- Swish sound: [name, author, source link]
- Buzzer sound: [name, author, source link]

## AI Assistance

This project was built with help from an AI assistant (Claude by Anthropic) for guidance and code. I assembled the scene in Unity, tested and tuned the game, and went through the code to understand it. [Edit this to match your course's AI policy.]

## Author

Ayana Sharma, E25B070915, Newton School Of Technology.