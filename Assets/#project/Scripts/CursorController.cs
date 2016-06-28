﻿using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

	public WandController _WandController;
	public WandController _WandControllerOther;
	public Transform _PointerAnchor;
	public MeshRenderer _Cursor;
	public LineRenderer _Line;

	public float _LineFactor;

	private bool locked = false;
	private float _StateChangeDistance = 0; //distance of cursor to controller on statechange - used for lockRad and lockRadXZ
	private Vector3 _StateChangePos;
	private Quaternion _StateChangeRot;
	public enum CursorState{
		unlocked, 	
		lockPos, 	//fixed in space
		lockRad, 	//fixed fistance from controller
		lockRadXZ 	//fixed distance from controller but same Z distance
	};
	public CursorState _CursorState = CursorState.unlocked;

	
	// Update is called once per frame
	void Update () {
		
		if ((_WandController.gripDown && _WandControllerOther.gripPress) ||
			(_WandController.gripPress && _WandControllerOther.gripDown))
		{
			SetCursorState (CursorState.lockRadXZ);
			UpdateCursorTransformState ();
		}

		if ((_WandController.gripDown & !_WandControllerOther.gripPress) ||
			(_WandController.gripPress & _WandControllerOther.gripUp))
		{
			SetCursorState (CursorState.lockRad);
			UpdateCursorTransformState ();
		}
			
		if ((_WandController.triggerDown && _WandController.gripPress && !_WandControllerOther.gripPress) ||
			(_WandController.gripDown && _WandController.triggerPress && !_WandControllerOther.gripPress))
		{
			SetCursorState (CursorState.lockRadXZ);
			UpdateCursorTransformState ();
		}

		if (_WandController.gripUp)
		{
			SetCursorState (CursorState.unlocked);
		}


		if (_WandController.rayHit || locked) {

			_Line.SetPosition (0, _PointerAnchor.position);
			_Line.SetPosition (1, _Cursor.transform.position);
			_Line.material.SetTextureOffset("_MainTex", new Vector2(Time.timeSinceLevelLoad*-1f,0f));
			_Line.material.SetTextureScale ("_MainTex", new Vector2((_Cursor.transform.position - _PointerAnchor.position).magnitude*_LineFactor, 1f));

			_Cursor.enabled = true;

			switch (_CursorState){

			case CursorState.lockRad:
				//position
				_Cursor.transform.parent = _PointerAnchor;
				_Cursor.transform.localPosition = new Vector3 (0f, 0f, _StateChangeDistance);
				_Cursor.transform.rotation = _StateChangeRot;
				//appearance
				_Cursor.materials [0].color = Color.red;
				_Line.material.color = Color.red;
				_Line.material.SetColor("_EmissionColor", Color.red);
			break;

			case CursorState.lockRadXZ:
				//position
				_Cursor.transform.parent = _PointerAnchor;
				_Cursor.transform.localPosition = new Vector3 (0f, 0f, _StateChangeDistance);
				_Cursor.transform.position =  new Vector3( _Cursor.transform.position.x , _StateChangePos.y, _Cursor.transform.position.z);
				_Cursor.transform.rotation = _StateChangeRot;
				//appearance
				_Cursor.materials [0].color = Color.red;
				_Line.material.color = Color.black;
				_Line.material.SetColor("_EmissionColor", Color.black);
				_Cursor.transform.parent = null;
			break;

			case CursorState.lockPos:
				//appearance
				_Cursor.materials [0].color = Color.red;
				_Line.material.color = Color.black;
				_Cursor.transform.parent = null;
			break;

			default:
				//position
				_Cursor.transform.position = _WandController.hitPos;
				_Cursor.transform.rotation = Quaternion.FromToRotation (Vector3.up, _WandController.hitNorm);
				//appearance
				_Cursor.materials [0].color = Color.black;
				_Line.material.color = Color.black;
				_Line.material.SetColor("_EmissionColor", Color.black);
				_Cursor.transform.parent = _PointerAnchor;
				break;
			}

		} else {
			//hide the cursor and the line
			_Cursor.enabled = false;
			_Line.SetPosition (0, Vector3.zero);
			_Line.SetPosition (1, Vector3.zero);
		}
	}

	public void SetCursorState(CursorState state){
		_CursorState = state;
		if (state == CursorState.unlocked) {
			locked = false;
		} else {
			locked = true;
		}
	}

	private void UpdateCursorTransformState(){
		_StateChangeDistance = _WandController.hitDistance;
		_StateChangePos = _Cursor.transform.position;
		_StateChangeRot = _Cursor.transform.rotation;
	}
}


