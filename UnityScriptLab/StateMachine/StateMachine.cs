using System;
using System.Collections.Generic;

namespace UnityScriptLab.StateMachine {
  using Condition;

  public class StateMachine<TState> : Updatable where TState : Enum {
    StateHandler<TState> handler;
    TState state;

    Dictionary<TState, Transitions> transitions = new Dictionary<TState, Transitions>();

    public StateMachine(StateHandler<TState> handler, TState initialState) {
      this.handler = handler;
      foreach (TState state in Enum.GetValues(typeof(TState))) {
        transitions[state] = new Transitions();
      }
      state = initialState;
    }

    public void AddTransition(TState from, TState to, TransitionCondition condition) {
      transitions[from].Add((to, condition));
    }
    public void AddTransition(TState from, TState to, Func<bool> condition) {
      transitions[from].Add((to, new FunctionCondition(condition)));
    }

    public void Update() {
      handler.HandleState(state);
      foreach ((TState to, TransitionCondition condition) in transitions[state]) {
        if (condition.IsFulfilled) {
          handler.OnStateExit(state);
          state = to;
          handler.OnStateEnter(state);
          break;
        }
      }
    }

    class Transitions : List < (TState, TransitionCondition) > { }
  }
}
