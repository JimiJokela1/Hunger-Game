using UnityEngine;

public class CameraWave : MonoBehaviour
{
	[Range(0f, 5)]
	public float waveAmount = 0.5f;

	[Range(0f, Mathf.PI)]
	public float intensity = 0.5f;

	// LateUpdate is called after Update each frame
	void LateUpdate()
	{
		var grandmaSpeed = GrandmaMovement.Instance.GetComponent<Rigidbody2D>().velocity;
		var wave = waveAmount * Mathf.Sin(Time.time * intensity);
		transform.localEulerAngles = new Vector3(wave, 0f, 0f);

	}
}