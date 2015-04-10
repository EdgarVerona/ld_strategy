using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Bots;

[Serializable]
public class MeleeBotStateMachine : BotStateMachine
{
	public float MaxSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void OnPositionGoal(Vector2 goalPosition, Vector2 deltaFromGoal)
	{
		Vector2 velocityToGoal = goalPosition * this.MaxSpeed * Time.deltaTime;

		_rigidBody.velocity = velocityToGoal;
	}

	protected override void OnPositionGoalComplete()
	{
		Console.WriteLine("Position reached");
		_rigidBody.velocity = new Vector2(0, 0);
	}

	protected override void OnEnemyGoal(GameObject enemy)
	{
		Vector2 velocityToGoal = new Vector2(enemy.transform.position.x, enemy.transform.position.y) * this.MaxSpeed * Time.deltaTime;

		_rigidBody.velocity = velocityToGoal;
	}

	protected override void OnEnemyGoalComplete()
	{
		Console.WriteLine("Enemy reached");
		_rigidBody.velocity = new Vector2(0, 0);
	}

	protected override void OnIdle()
	{

	}
}
