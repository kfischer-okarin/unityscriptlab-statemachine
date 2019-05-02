using NSubstitute;

using NUnit.Framework;

using UnityScriptLab.StateMachine;

namespace Tests.StateMachine {
  public class StateMachineTests {
    public enum Color {
      Red,
      Blue
    }

    StateMachine<Color> stateMachine;
    StateHandler<Color> handler;

    [SetUp]
    public void Init() {
      handler = Substitute.For<StateHandler<Color>>();
      stateMachine = new StateMachine<Color>(handler, Color.Red);
    }

    [Test]
    public void UpdateTest() {
      TransitionCondition condition = Substitute.For<TransitionCondition>();
      stateMachine.AddTransition(Color.Red, Color.Blue, condition);

      stateMachine.Update();
      handler.Received().HandleState(Color.Red);
      handler.DidNotReceiveWithAnyArgs().OnStateEnter(Color.Red);
      handler.DidNotReceiveWithAnyArgs().OnStateExit(Color.Red);

      condition.IsFulfilled.Returns(true);
      stateMachine.Update();
      handler.Received().HandleState(Color.Red);
      handler.Received().OnStateExit(Color.Red);
      handler.Received().OnStateEnter(Color.Blue);
    }
  }
}
