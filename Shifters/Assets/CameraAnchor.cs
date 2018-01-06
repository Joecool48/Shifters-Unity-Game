using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraAnchor : MonoBehaviour {
	public enum AnchorType {
		BottomLeft,
		BottomCenter,
		BottomRight,
		MiddleLeft,
		MiddleCenter,
		MiddleRight,
		TopLeft,
		TopCenter,
		TopRight,
	};
	public AnchorType anchorType;
	public Vector3 anchorOffset;

	IEnumerator updateAnchorRoutine; //Coroutine handle so we don't start it if it's already running

	// Use this for initialization
	void Start () {
		updateAnchorRoutine = UpdateAnchorAsync();
		StartCoroutine(updateAnchorRoutine);
	}

	/// <summary>
	/// Coroutine to update the anchor only once CameraFit.Instance is not null.
	/// </summary>
	IEnumerator UpdateAnchorAsync() {
		uint cameraWaitCycles = 0;
		while(ViewportHandle.Instance == null) {
			++cameraWaitCycles;
			yield return new WaitForEndOfFrame();
		}
		if (cameraWaitCycles > 0) {
			print(string.Format("CameraAnchor found CameraFit instance after waiting {0} frame(s). You might want to check that CameraFit has an earlie execution order.", cameraWaitCycles));
		}
		UpdateAnchor();
		updateAnchorRoutine = null;
	}

	void UpdateAnchor() {
		switch(anchorType) {
		case AnchorType.BottomLeft:
			SetAnchor(ViewportHandle.Instance.BottomLeft);
			break;
		case AnchorType.BottomCenter:
			SetAnchor(ViewportHandle.Instance.BottomCenter);
			break;
		case AnchorType.BottomRight:
			SetAnchor(ViewportHandle.Instance.BottomRight);
			break;
		case AnchorType.MiddleLeft:
			SetAnchor(ViewportHandle.Instance.MiddleLeft);
			break;
		case AnchorType.MiddleCenter:
			SetAnchor(ViewportHandle.Instance.MiddleCenter);
			break;
		case AnchorType.MiddleRight:
			SetAnchor(ViewportHandle.Instance.MiddleRight);
			break;
		case AnchorType.TopLeft:
			SetAnchor(ViewportHandle.Instance.TopLeft);
			break;
		case AnchorType.TopCenter:
			SetAnchor(ViewportHandle.Instance.TopCenter);
			break;
		case AnchorType.TopRight:
			SetAnchor(ViewportHandle.Instance.TopRight);
			break;
		}
	}

	void SetAnchor(Vector3 anchor) {
		Vector3 newPos = anchor + anchorOffset;
		if (!transform.position.Equals(newPos)) {
			transform.position = newPos;
		}
	}

	#if UNITY_EDITOR
	// Update is called once per frame
	void Update () {
		if (updateAnchorRoutine == null) {
			updateAnchorRoutine = UpdateAnchorAsync();
			StartCoroutine(updateAnchorRoutine);
		}
	}
	#endif
}
