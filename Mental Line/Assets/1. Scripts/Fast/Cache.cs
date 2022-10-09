using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class YieldInstructionCache
{
	class FloatComparer : IEqualityComparer<float>
	{
		bool IEqualityComparer<float>.Equals(float x, float y) { return x == y; }
		int IEqualityComparer<float>.GetHashCode(float obj) { return obj.GetHashCode(); }

	}//	class FloatComparer : IEqualityComparer<float>
	 //----------------------------------------------------
	public static readonly WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();
	public static readonly WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
	static readonly Dictionary<float, WaitForSeconds> _timeInterval = new Dictionary<float, WaitForSeconds>(new FloatComparer());
	//----------------------------------------------------
	public static WaitForSeconds WaitForSeconds(float seconds)
	{
		WaitForSeconds wfs;

		if (!_timeInterval.TryGetValue(seconds, out wfs))
			_timeInterval.Add(seconds, wfs = new WaitForSeconds(seconds));

		return wfs;

	}
}//	internal static class YieldInstructionCache
 //==========================================================================
/*
//	Usage.
yield return YieldInstructionCache._waitForEndOfFrame;
yield return YieldInstructionCache._waitForFixedUpdate;
yield return YieldInstructionCache.WaitForSeconds( 0.1f );
yield return YieldInstructionCache.WaitForSeconds( secnods );
*/
