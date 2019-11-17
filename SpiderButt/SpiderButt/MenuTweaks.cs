using UnityEngine;

public class patch_PauseButtonView : PauseButtonView
{
    public void NewGame()
    {
        this.app.Notify("gameover.retry", (Object) this);
    }

    public void Continue()
    {
        this.app.view.menuView.SetActive(false);
        this.app.model.paused = false;
        MonoBehaviour.print((object) "CONTINUE");
    }

    public void ExitGame()
    {
        this.app.Notify("gameover.exittomenu", (Object) this);
    }
}