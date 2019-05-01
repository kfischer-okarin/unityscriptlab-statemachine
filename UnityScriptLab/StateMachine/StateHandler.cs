using System;

namespace UnityScriptLab.StateMachine {
  public interface StateHandler<TState> where TState : Enum {
    void HandleState(TState state);
    void OnStateEnter(TState state);
    void OnStateExit(TState state);
  }
}
