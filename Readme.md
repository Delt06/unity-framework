# Unity Game Development Framework

## ```GameEvent<T> : IRaiseableEvent<T>```

An asset that can be raised and reacted to by any object inside the scene.

### Guidelines to implement custom event:

- Define class for event itself:
  - Inherit from ```GameEvent<T>``` specifying actual argument type.
  - Mark it via ```[CreateAssetMenu(menuName: CustomPath + "*ArgsType*")]``` attribute to allow creation via Editor.

- Define class for UnityEvent:
  - Inherit from ```UnityEvent<T>``` specifying actual argument type.
  - Mark it via ```[Serializable]``` attribute to allow Edtitor serialization.

- Define class for EventListenerComponent:
  - Inherit from ```EventListenerComponent<TArgs, TGameEvent, TUnityEvent>``` specifying actual types: your argument type for ```TArgs```, custom GameEvent for ```TGameEvent```, custom UnityEvent for ```TUnityEvent```.
  - *Optionally*: Mark it with ```[AddComponentMenu(CustomPath + "*ArgsType*")]``` attribute to add it to common component structure.

## ```Variable<T>``` and ```Reference<TValue, TVariable>```

### ```Varible<T>```

An asset, which stores global data. 

### ```Reference<TValue, TVariable>```

Can store both Varible and constant (simple field). Allows to choose, which one will be used. 

## ```BaseComponent``` and ```DependentComponent```

### ```BaseComponent : IBaseObject```
A parent object for dependent objects.

- On Awake(), initializes all visible dependents. 
- Stores cached links to all dependents.

### ```DependentComponent : IDependentObject```
Objects, which can initialized and located by its parent.

### ```PoolComponent : ISpawner<IBaseObject>```
Pool of objects. Instructions to use:
- Create prefab with a ```PoolBaseComponent``` as its base.
- Add a ```Pool Component``` to the scene. Set your prefab as pool's prefab. Adjust size if needed.
- Create a ```PoolReference``` asset. 
- Add a ```PoolReferenceSetter``` to the scene. Set your pool and pool references.
- Use the created ```PoolReference.Spawn()``` where needed.
