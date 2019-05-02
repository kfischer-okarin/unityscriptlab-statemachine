using UnityScriptLab.Input.Value;

namespace UnityScriptLab.StateMachine.Condition {
  public class TriggerInputCondition : TransitionCondition {
    bool value;
    bool targetValue;

    public TriggerInputCondition(TriggerInput trigger, bool targetValue) {
      trigger.Updated += v => value = v;
      this.targetValue = targetValue;
    }

    public bool IsFulfilled { get { return value == targetValue; } }
  }
}
