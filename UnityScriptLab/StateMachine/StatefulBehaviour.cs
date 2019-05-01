using System;

using UnityEngine;

namespace UnityScriptLab.StateMachine {
  [RequireComponent(typeof(StateMachineRunner))]
  public class StatefulBehaviour<TState> : MonoBehaviour, StateHandler<TState>, StateMachineProvider where TState : Enum {
    StateMachine<TState> stateMachine;
    public Updatable StateMachine {
      get {
        if (stateMachine == null) {
          stateMachine = new StateMachine<TState>(this);
        }
        return stateMachine;
      }
    }

    public void HandleState(TState state) { }
    public void OnStateEnter(TState state) { }
    public void OnStateExit(TState state) { }
  }
}
