using UnityScriptLab.Input;

namespace UnityScriptLab.StateMachine.Condition {
  public class OnInputAction : TransitionCondition {
    bool value;
    bool targetValue;

    public OnInputAction(InputAction<bool> trigger, bool targetValue) {
      trigger.Triggered += (v, _) => value = v;
      this.targetValue = targetValue;
    }

    public bool IsFulfilled { get { return value == targetValue; } }
  }
}
