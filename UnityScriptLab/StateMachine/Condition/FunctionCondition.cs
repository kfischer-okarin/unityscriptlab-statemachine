using System;

namespace UnityScriptLab.StateMachine.Condition {
  public class FunctionCondition : TransitionCondition {
    Func<bool> function;

    public FunctionCondition(Func<bool> function) {
      this.function = function;
    }

    public bool IsFulfilled { get { return function(); } }
  }
}
