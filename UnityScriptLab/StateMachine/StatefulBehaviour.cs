using System;

using UnityEngine;

namespace UnityScriptLab.StateMachine {
  /// <summary>
  /// Extend this class instead of MonoBehaviour to have a MonoBehaviour with a StateMachine included.
  /// Override HandleState, OnStateEnter and/or OnStateExit to handle state changes.
  /// </summary>
  [RequireComponent(typeof(StateMachineRunner))]
  public abstract class StatefulBehaviour<TState> : MonoBehaviour, StateHandler<TState>, StateMachineProvider where TState : Enum {
    StateMachine<TState> stateMachine;
    public Updatable StateMachine {
      get {
        if (stateMachine == null) {
          stateMachine = new StateMachine<TState>(this, InitialState);
        }
        return stateMachine;
      }
    }

    protected abstract TState InitialState { get; }

    /// <summary>
    /// Executed before every Update().
    /// </summary>
    public virtual void HandleState(TState state) { }
    /// <summary>
    /// Executed when entering the state.
    /// </summary>
    public virtual void OnStateEnter(TState state) { }
    /// <summary>
    /// Executed when leaving the state.
    /// </summary>
    public virtual void OnStateExit(TState state) { }
  }
}
