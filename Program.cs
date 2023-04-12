using System;
using System.Linq;
using System.Text;
using System.Threading;

using OpenTK.Input;

static void InitGamepads() {
	for (var i = 0; i < 4; i++) {
		Console.WriteLine(Joystick.GetGuid(i));
		_ = GamePad.GetState(i);
	}
}

static void PrintState() {
	const string FFMT = "0.0000 ";
	var state = GamePad.GetState(0);
	StringBuilder sb = new();
	sb.Append(state.IsConnected ? " C " : "DC ");
	sb.Append(state.Buttons.A == ButtonState.Pressed ? "A " : ". ");
	sb.Append(state.Buttons.B == ButtonState.Pressed ? "B " : ". ");
	sb.Append(state.Buttons.X == ButtonState.Pressed ? "X " : ". ");
	sb.Append(state.Buttons.Y == ButtonState.Pressed ? "Y " : ". ");
	sb.Append(state.DPad.Up == ButtonState.Pressed ? "DU " : ".  ");
	sb.Append(state.DPad.Down == ButtonState.Pressed ? "DD " : ".  ");
	sb.Append(state.DPad.Left == ButtonState.Pressed ? "DL " : ".  ");
	sb.Append(state.DPad.Right == ButtonState.Pressed ? "DR " : ".  ");
	sb.Append(state.Buttons.Start == ButtonState.Pressed ? "S " : ". ");
	sb.Append(state.Buttons.Back == ButtonState.Pressed ? "s " : ". ");
	sb.Append(state.Buttons.BigButton == ButtonState.Pressed ? "H " : ". ");
	sb.Append(state.Buttons.LeftShoulder == ButtonState.Pressed ? "LB " : ".  ");
	sb.Append(state.Triggers.Left.ToString(FFMT));
	sb.Append(state.Buttons.RightShoulder == ButtonState.Pressed ? "RB  " : ".  ");
	sb.Append(state.Triggers.Right.ToString(FFMT));
	sb.Append((state.ThumbSticks.Left.X / 10000.0f).ToString(FFMT));
	sb.Append((state.ThumbSticks.Left.Y / 10000.0f).ToString(FFMT));
	sb.Append(state.Buttons.LeftStick == ButtonState.Pressed ? "L3 " : ".  ");
	sb.Append((state.ThumbSticks.Right.X / 10000.0f).ToString(FFMT));
	sb.Append((state.ThumbSticks.Right.Y / 10000.0f).ToString(FFMT));
	sb.Append(state.Buttons.RightStick == ButtonState.Pressed ? "R3 " : ".  ");
	Console.WriteLine(sb.ToString());
}

InitGamepads();
var running = true;
Console.CancelKeyPress += (_, _) => running = false;
while (running) {
	PrintState();
	Thread.Sleep(1000/*ms*/);
}
