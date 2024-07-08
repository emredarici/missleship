using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatObject : MonoBehaviour
{
    [SerializeField] private float maxDistance;
	[SerializeField] private Vector2 newDistance;
	[SerializeField] private Vector2 rangeScale;

	private void Start()
	{
		UpdateDisplay();
	}

	private void LateUpdate()
	{
		var distance = Vector3.Distance(PlayerScript.Instance.transform.position, transform.position);
		if (distance > maxDistance)
		{
			UpdateDisplay();
		}
	}

	private void UpdateDisplay()
	{
		transform.localScale = Vector3.one * Random.Range(rangeScale.x, rangeScale.y);

		var extra = (Vector3)(Random.insideUnitCircle.normalized * Random.Range(newDistance.x, newDistance.y));
		transform.position = PlayerScript.Instance.transform.position + extra;
	}
}
