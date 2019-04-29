using UnityEngine;

namespace UnityScriptLab.StateMachine {
  public interface TransitionCondition<TStateMachineOwner> where TStateMachineOwner : MonoBehaviour {
    bool IsFulfilled(TStateMachineOwner owner);
  }
}
