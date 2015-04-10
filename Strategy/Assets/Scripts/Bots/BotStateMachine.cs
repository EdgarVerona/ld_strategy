using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Bots
{
	public enum BotState
	{
		Idle,
		EnemyGoal,
		PositionGoal
	}

	[RequireComponent(typeof(Rigidbody2D), typeof(Transform))]
	[Serializable]
	public abstract class BotStateMachine : MonoBehaviour
	{
		protected Vector2 _goalPosition = new Vector2(0, 0);
		protected GameObject _enemy = null;
		protected BotState _state = BotState.Idle;

		protected Transform _transform;
		protected Rigidbody2D _rigidBody;

		public virtual void Awake()
		{
			_transform = GetComponent<Transform>();
			_rigidBody = GetComponent<Rigidbody2D>();
			_state = BotState.Idle;
		}

		public void FixedUpdate()
		{
			EvaluateStateMachine();
		}

		public void SetGoalPosition(Vector2 goalPosition)
		{
			_goalPosition = goalPosition;

			_state = BotState.PositionGoal;
		}

		public void SetEnemyPosition(GameObject enemy)
		{
			_enemy = enemy;

			_state = BotState.EnemyGoal;
		}

		private void EvaluateStateMachine()
		{
			switch (_state)
			{
				case BotState.Idle:
					OnIdle();
					break;
				case BotState.EnemyGoal:
					if (_enemy == null || !_enemy.activeInHierarchy)
					{
						_state = BotState.Idle;
						_enemy = null;
						OnEnemyGoalComplete();
					}
					else
					{
						OnEnemyGoal(_enemy);
					}
					break;
				case BotState.PositionGoal:
					
					var deltaFromGoal = new Vector2(_transform.position.x, _transform.position.y) - _goalPosition;

					if (deltaFromGoal.magnitude <= 0.1f)
					{
						_state = BotState.Idle;
						OnPositionGoalComplete();
					}
					else
					{
						OnPositionGoal(_goalPosition, deltaFromGoal);
					}
					break;
			}
		}

		protected abstract void OnPositionGoal(Vector2 goalPosition, Vector2 deltaFromGoal);

		protected abstract void OnPositionGoalComplete();

		protected abstract void OnEnemyGoal(GameObject enemy);

		protected abstract void OnEnemyGoalComplete();

		protected abstract void OnIdle();

	}
}
