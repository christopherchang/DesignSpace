﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectMovementOld : MonoBehaviour {
	/*
	public List<Transform> _TargetTransforms = new List<Transform> ();

	public WandController _WCL; //wandcontroller right
	public WandController _WCR; //wandcontroller left

	public bool _MovementEnabled = false;

	private List<Vector3> _Focuspoints = new List<Vector3> ();
	private List<Vector3> _FocuspointsPrev = new List<Vector3> (); //previous frame
	private List<GameObject> _ActiveCursor = new List<GameObject> ();
	private List<WandController> _ActiveWand = new List<WandController> ();
	private bool _ChangeInFocusPointSize = false;

	private bool _DoubleClickActive = false;

	
	// Update is called once per frame
	void Update () {

		if (_MovementEnabled) {

			UpdateFocusPoints ();

			//Rotate && Scale - Two buttons pressed
			if (_WCR.triggerPress && _WCL.triggerPress) {

				if (!(_WCL.touchPress ^ _WCR.touchPress))
				{
					DoTranslate ();
				}
				if (!_WCL.touchPress)
				{
					DoRotate (true);
				}
				if (!_WCR.touchPress)
				{
					DoScale ();
				}
				return;
			}
	
			//Translate - Only one grip button pressed
			if (_WCR.triggerPress ^ _WCL.triggerPress) {
				DoTranslate ();
				return;
			}
				
		}

	}

	private void DoTranslate(bool invert = false, bool limitXZ = false){
		if (_Focuspoints.Count > 0)
		{
			if (_ChangeInFocusPointSize)
			{
				Debug.Log ("skipped frame");
				return;
			}

			Vector3 averagePoint = GetAverage (_Focuspoints);
			Vector3 averagePointPrev = GetAverage (_FocuspointsPrev);

			Vector3 diff = averagePoint - averagePointPrev;
			if (limitXZ)
				diff = new Vector3 (diff.x, 0, diff.y);

			Debug.Log (diff);
			float sign = invert ? -1f : 1f;

			foreach (Transform trans in _TargetTransforms)
			{
				trans.Translate (diff * sign, Space.World);
			}
		}
	}

	private void DoRotate(bool limitXZ = false){
		if (_Focuspoints.Count > 1)
		{
			foreach (Transform trans in _TargetTransforms)
			{
				//get rot angle and axis
				Vector3 oldDir = _FocuspointsPrev [0] - _FocuspointsPrev [1];
				Vector3 newDir = _Focuspoints [0] - _Focuspoints [1];
				if (limitXZ)
				{
					oldDir = new Vector3 (oldDir.x, 0, oldDir.z);
					newDir = new Vector3 (newDir.x, 0, newDir.z);
				}

				Vector3 cross = Vector3.Cross (oldDir, newDir);
				float rotAngle = Vector3.Angle (oldDir, newDir);

				//correction part 1 - get current localpos for focuspoints
				List<Vector3> localPointsPreTransform = new List<Vector3> ();
				foreach (Vector3 pos in _Focuspoints)
				{
					localPointsPreTransform.Add(trans.InverseTransformPoint (pos));
				}
				Vector3 averagePreTransform = GetAverage (_Focuspoints);

				//rotate
				trans.Rotate (cross.normalized, rotAngle, Space.World);

				//correction part 2 - get worldpoints for converted focuspoints and check diff 
				List<Vector3> localPointsPostTransform = new List<Vector3> ();
				for(int i = 0; i < localPointsPreTransform.Count; i++)
				{
					localPointsPostTransform.Add(trans.TransformPoint(localPointsPreTransform[i]));
				}
				Vector3 averagePostTransform = GetAverage (localPointsPostTransform);
			
				Vector3 correction = averagePostTransform -averagePreTransform;
					trans.Translate (-correction, Space.World);
			}
		}
	}

	private void DoScale(){
		if (_Focuspoints.Count > 1)
		{
			foreach (Transform trans in _TargetTransforms)
			{
				//get magintude diff
				float oldMag = Vector3.Magnitude(_FocuspointsPrev [0] - _FocuspointsPrev [1]);
				float newMag = Vector3.Magnitude(_Focuspoints [0] - _Focuspoints [1]);
				float factor = newMag / oldMag;

				//correction part 1 - get current localpos for focuspoints
				List<Vector3> localPointsPreTransform = new List<Vector3> ();
				foreach (Vector3 pos in _Focuspoints)
				{
					localPointsPreTransform.Add(trans.InverseTransformPoint (pos));
				}
				Vector3 averagePreTransform = GetAverage(_Focuspoints);

				//scale
				trans.localScale = new Vector3 (factor * trans.localScale.x, factor * trans.localScale.y, factor * trans.localScale.z);

				//correction part 2 - get worldpoints for converted focuspoints and check diff 
				List<Vector3> localPointsPostTransform = new List<Vector3> ();
				for(int i = 0; i < localPointsPreTransform.Count; i++)
				{
					localPointsPostTransform.Add(trans.TransformPoint(localPointsPreTransform[i]));
				}
				Vector3 averagePostTransform = GetAverage (localPointsPostTransform);

				Vector3 correction = averagePostTransform -averagePreTransform;

				trans.Translate (-correction, Space.World);
			}
		}
	}

	public void UpdateFocusPoints(){
		//_FocuspointsPrev = _Focuspoints;

		_FocuspointsPrev.Clear();
		foreach (Vector3 pos in _Focuspoints)
		{
			_FocuspointsPrev.Add (pos);
		}

		_Focuspoints.Clear();
		_ActiveCursor.Clear ();
		_ActiveWand.Clear ();

		if (_WCL.triggerPress)
		{
			_Focuspoints.Add (_WCL._Cursor.position);
			_ActiveCursor.Add (_WCL._Cursor.gameObject);
			_ActiveWand.Add (_WCL);
		}
		if (_WCR.triggerPress)
		{
			_Focuspoints.Add (_WCR._Cursor.position);
			_ActiveCursor.Add (_WCR._Cursor.gameObject);
			_ActiveWand.Add (_WCR);
		}

		_ChangeInFocusPointSize = _Focuspoints.Count == _FocuspointsPrev.Count ? false : true;
	}

	private Vector3 GetAverage(List<Vector3> list){
		Vector3 averagePoint = new Vector3();
		foreach (Vector3 pos in list)
		{
			averagePoint += pos;
		}
		averagePoint /= list.Count;
		return averagePoint;
	}
*/
}
