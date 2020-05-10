/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


Main.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
//using System.Linq;
using System.Collections;
using System.Collections.Generic;
//using UniRx;
//using UniRx.Triggers;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

// namespace jigaX{
public class Main : MonoBehaviour {

	[SerializeField]
	Text text;

    void Awake()
	{
        UpdateText();
	}

    public void UpdateText()
	{
        Debug.Log("UpdateText");
		text.text = NativeIntentParameterApi.GetUrlString();
	}



# if UNITY_EDITOR
	[CustomEditor( typeof( Main ) )]
	public class MainInspector : Editor{
		public override void OnInspectorGUI()
		{
			var script = target as Main;


			DrawDefaultInspector();
		}
		Main Instance{
			get{return (Main)target; }
		}
	}
# endif
}

public class NativeIntentParameterApi
{
	[System.Runtime.InteropServices.DllImport("__Internal")]
	private static extern string getUrlString();

	public static string GetUrlString()
	{
#if UNITY_EDITOR
		return "iOS only";
#endif
		return getUrlString();
	}
}


// } // namespace