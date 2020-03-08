using System.Collections.Generic;
using UnityEngine;

public class Game : PersistableObject {
	public PersistentStorage storage;
	public PersistableObject prefab;
	public KeyCode createKey = KeyCode.C;
	public KeyCode newGameKey = KeyCode.N;
	public KeyCode saveKey = KeyCode.S;
	List<PersistableObject> objects;
	public KeyCode loadKey = KeyCode.L;

	void Awake() {
		objects = new List<PersistableObject>();
	}

	void Update() {
		if (Input.GetKeyDown(createKey)) {
			CreateObject();
		} else if (Input.GetKey(newGameKey)) {
			BeginNewGame();
		} else if (Input.GetKeyDown(saveKey)) {
			storage.Save(this);
		} else if (Input.GetKeyDown(loadKey)) {
			BeginNewGame();
			storage.Load(this);
		}
	}

	void CreateObject() {
		PersistableObject o = Instantiate(prefab);
		Transform t = o.transform;
		t.localPosition = Random.insideUnitSphere * 5f;
		t.localRotation = Random.rotation;
		t.localScale = Vector3.one * Random.Range(0.1f, 1f);
		objects.Add(o);
	}

	void BeginNewGame() {
		for (int i = 0; i < objects.Count; i++) {
			Destroy(objects[i].gameObject);
		}
		objects.Clear();
	}

	public override void Save(GameDataWriter writer) {
		writer.Write(objects.Count);
		for (int i = 0; i < objects.Count; i++) {
			objects[i].Save(writer);
		}
	}

	public override void Load(GameDataReader reader) {
		int count = reader.ReadInt();
		for (int i = 0; i < count; i++) {
			PersistableObject o = Instantiate(prefab);
			o.Load(reader);
			objects.Add(o);
		}
	}
}