namespace UnityScriptLab.StateMachine {
  public interface TransitionCondition {
    bool IsFulfilled { get; }
  }
}
