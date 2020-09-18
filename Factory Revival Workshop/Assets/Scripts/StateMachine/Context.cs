using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context  {

	private IState state;

	public Context() {
		state = null;
	}
	public void setState(IState state) {
		this.state = state;
	}

	public IState getState() {
		return state;
	}
}
