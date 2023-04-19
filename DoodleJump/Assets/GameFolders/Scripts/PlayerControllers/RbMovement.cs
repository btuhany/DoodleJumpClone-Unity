using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbMovement
{
	Rigidbody2D _rb;
	public RbMovement(Rigidbody2D rb)
	{
		_rb = rb;
	}
	public void HorizontalMovement(float value)
	{
		_rb.velocity = new Vector2(value, _rb.velocity.y);
	}
	public void VerticalForce(float value)
	{
		_rb.velocity = new Vector2(_rb.velocity.x, 0);
		_rb.AddForce(Vector2.up * value);
	}
}
