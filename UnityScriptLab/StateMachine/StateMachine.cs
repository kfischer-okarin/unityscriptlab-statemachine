using System;
using System.Collections.Generic;

using UnityEngine;

namespace UnityScriptLab.StateMachine {
  public class StateMachine<TOwner, TState> where TOwner : MonoBehaviour where TState : Enum {
    TOwner owner;
    TState state;

    public TState State { get { return state; } }

    public StateMachine(TOwner owner) {
      this.owner = owner;
    }

    public StateMachine(TOwner owner, TState initialState) : this(owner) {
      state = initialState;
    }

    Dictionary<TState, Transitions> transitions = new Dictionary<TState, Transitions>();

    public void AddTransition(TState from, TState to, TransitionCondition<TOwner> condition) {
      if (!transitions.ContainsKey(from)) {
        transitions[from] = new Transitions();
      }
      transitions[from].Add((to, condition));
    }

    public void Update() {
      owner.SendMessage("HandleState", state, SendMessageOptions.DontRequireReceiver);
      foreach ((TState to, TransitionCondition<TOwner> condition) in transitions[state]) {
        if (condition.IsFulfilled(owner)) {
          owner.SendMessage("HandleStateExit", state, SendMessageOptions.DontRequireReceiver);
          state = to;
          owner.SendMessage("HandleStateEnter", to, SendMessageOptions.DontRequireReceiver);
          break;
        }
      }
    }

    class Transitions : List < (TState, TransitionCondition<TOwner>) > { }
  }
}
