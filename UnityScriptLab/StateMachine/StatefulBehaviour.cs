using System;

using UnityEngine;

namespace UnityScriptLab.StateMachine {
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

    public virtual void HandleState(TState state) { }
    public virtual void OnStateEnter(TState state) { }
    public virtual void OnStateExit(TState state) { }
  }
}
