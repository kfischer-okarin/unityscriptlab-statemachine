# UnityScriptLab - State Machine

State Machine that can be easily included with MonoBehaviours.

## Example

```csharp
using UnityScriptLab.StateMachine;

public enum PlayerState {
  Walk,
  Run
}

public class Player : StatefulBehaviour<PlayerState> {
  protected override PlayerState InitialState {
    get {
      return PlayerState.Walk;
    }
  }

  public override void HandleState(PlayerState state) {
    // ...
  }
}
