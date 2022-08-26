# Tripledot Client Engineering SOLID Workshop

    Try to do as little work as possible to achieve each of the objectives.

## Objective 1

Get familiar with the project.
- Open the main scene.
- Get familiar with the buttons.
- Check the core classes.

## Objective 2

Add logging to the spawners.
- Make sure that after an enemy is spawned its **EnemyType** is logged out to the console.
- If a boss is spawned both its **EnemyType** and **BossType** should be logged out to the console.

## Objective 3

Add analytics to the spawners.
- Every time a type of an enemy is spawned (has to be **IEnemy** and not IBoss) for the first time a **NEW_ENEMY_ENCOUNTERED** event should be logged (Console is enough for now) with the **EnemyType** of the enemy encountered.
- Every time a type of a boss is spawned for the first time a **NEW_BOSS_TYPE_ENCOUNTERED** event should be logged (Console is enough for now) with the **BossType** encountered.
- Every time an enemy is spawned an **ENEMY_SPAWNED** event with the **EnemyType** should be logged.
- Every time a boss is spawned a **BOSS_SPAWNED** event with the **EnemyType** and **BossType** should be logged.

## Objective 4

Create a way to switch to an Alternative app flow.  
When running in alternative app flow Logs and Analytics about IEnemy spawning should look different.  
(Use a different style of logs increase size of text for example)  
Tracking and logging of IBoss spawning should remain the same.

## Objective 5

Refactor analytics for enemy spawning so that a bosses count as Enemies but only for the purpose of the NEW_ENEMY_ENCOUNTERED event.    
So if an Orc boss is spawned and no Orc enemy was spawned before the NEW_ENEMY_ENCOUNTERED should also be logged.

## Objective 6

Update the Spawner to be configurable in a way that doesn't violate SOLID principles.
- Remove any classes that might have became unnecessary after the refactor.

## Secret Objective

If you haven't already...  
Add tests to the project.
- verify that the analytics events fire properly when spawning happens.
- verify that the spawners create the right creatures with the right stats when configured.

### Test to write:
  - NEW_ENEMY_ENCOUNTERED is logged when an Enemy or a Boss of a specific EnemyType is spawned for the first time.
  - NEW_BOSS_TYPE_ENCOUNTERED is logged when a new BossType boss is spawned for the first time.
  - ENEMY_SPAWNED is logged when an enemy is spawned.
  - BOSS_SPAWNED is logged when a boss is spawned.
  - When spawning a specific EnemyType the returned creature is of that Type.
  - When spawning an unknown type the spawning fails and returns null.
  - When spawning a boss both EnemyType and BossTypes are as expected.
  - When spawning random bosses spawned creatures are not all the same.
