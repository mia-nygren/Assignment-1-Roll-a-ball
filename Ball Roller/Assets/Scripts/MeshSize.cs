using UnityEngine;
using System.Collections;

public class MeshSize : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3 objectSize = Vector3.Scale (transform.localScale, mesh.bounds.size); 
		Debug.Log (" The mesh with the name:" + this.name + " has the size of: " + objectSize);
	}
	

	/*  http://answers.unity3d.com/questions/35753/how-do-i-find-the-size-of-a-gameobject.html
	 Well I came here looking for an objects unit size. I tried Mesh.size, but wasn't the objects unit size. 
	 Since it tells you the size of the mesh, not of the scaled mesh. So if you just multiply Mesh.size by transform.localScale, you will get the objects unit size.
	 

	 Example: a plane in unity is 1, 1, 1 and it's unit (or mesh size) is 10, 0.00002(ish), 10. So if you scale the plans x by 5. It's unit size is 50 even AFTER scaling these are the sizes.

	 mesh.bounds.size.x = 10
	 transform.localScale.x = 5
	so

	 mesh.bounds.size.x * transform.localScale.x = 50
*/

}
