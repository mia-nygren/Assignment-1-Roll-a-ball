using UnityEngine;
using System.Collections;

public class Counter {
	private int count = 0;
	private int increaseValue; 

	public Counter(){
		this.increaseValue = 1; 
	}
	public Counter(int increaseValue) {
		this.increaseValue = increaseValue; 
	}

	public void Increase() {
		count+=increaseValue;
	}

	public int GetValue() {
		return count;
	}

	public void SetValue(int number) {
		count = number;
	}

	public void Reset() {
		count = 0;
	}
		
}