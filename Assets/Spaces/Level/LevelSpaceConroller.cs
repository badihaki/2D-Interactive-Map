using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpaceConroller : SpaceController
{
    [field: SerializeField] public SpaceController nextTopSpace { get; private set; }
    [field: SerializeField] public SpaceController nextBottomSpace { get; private set; }
    [field: SerializeField] public SpaceController nextLeftSpace { get; private set; }
    [field: SerializeField] public SpaceController nextRightSpace { get; private set; }
    [field: SerializeField] public int indexOfSceneToLoad { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        CheckIfLevelIsReal();
    }

    private void CheckIfLevelIsReal()
    {
        if (indexOfSceneToLoad < 0) indexOfSceneToLoad = 0;
        if (indexOfSceneToLoad > SceneManager.sceneCount) indexOfSceneToLoad = SceneManager.sceneCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        CheckIfLevelIsReal();

        if (indexOfSceneToLoad != 0)
        {
            SceneManager.LoadScene(indexOfSceneToLoad, LoadSceneMode.Single);
        }
    }
}
