using System.Collections.Generic;
using MonoMod;
using UnityEngine;

public class patch_BumboUnlockController : BumboUnlockController
{
    [MonoModIgnore]
    private List<int> unlocks;

    
    [MonoModReplace]
    private void Start()
    {
        this.unlocks = new List<int>();
        Cursor.visible = false;
        if ((Object) Object.FindObjectOfType<LoadingController>() != (Object) null)
        {
            this.loadingController = Object.FindObjectOfType<LoadingController>();
            this.loadingController.gameObject.SetActive(false);
        }
        else
        {
            this.loadingController = Object.Instantiate<GameObject>(Resources.Load("Loading") as GameObject)
                .GetComponent<LoadingController>();
            this.loadingController.gameObject.SetActive(false);
        }

        this.app.view.keyLight.intensity = 0.0f;
        this.app.view.fillLight.intensity = 0.0f;
        this.progress = ProgressionController.LoadProgression();
        if (!this.forceUnlock && !this.skipUnlock)
        {
            if (!this.progress.unlocks[6] && this.progress.wins > 0)
            {
                this.progress.unlocks[6] = true;
                this.unlocks.Add(6);
            }

            if (!this.progress.unlocks[7] && this.progress.wins > 3)
            {
                this.progress.unlocks[7] = true;
                this.unlocks.Add(7);
            }

            if (!this.progress.unlocks[8] && this.progress.braveWins > 1 &&
                (this.progress.stoutWins > 1 && this.progress.nimbleWins > 1) &&
                (this.progress.weirdWins > 1 && this.progress.deadWins > 1))
            {
                this.progress.unlocks[8] = true;
                this.unlocks.Add(8);
            }

            if (!this.progress.unlocks[9] && this.progress.braveWins > 0)
            {
                this.progress.unlocks[9] = true;
                this.unlocks.Add(9);
            }

            if (!this.progress.unlocks[10] && this.progress.braveWins > 1)
            {
                this.progress.unlocks[10] = true;
                this.unlocks.Add(10);
            }

            if (!this.progress.unlocks[11] && this.progress.nimbleWins > 0)
            {
                this.progress.unlocks[11] = true;
                this.unlocks.Add(11);
            }

            if (!this.progress.unlocks[12] && this.progress.nimbleWins > 1)
            {
                this.progress.unlocks[12] = true;
                this.unlocks.Add(12);
            }

            if (!this.progress.unlocks[13] && this.progress.stoutWins > 0)
            {
                this.progress.unlocks[13] = true;
                this.unlocks.Add(13);
            }

            if (!this.progress.unlocks[14] && this.progress.stoutWins > 1)
            {
                this.progress.unlocks[14] = true;
                this.unlocks.Add(14);
            }

            if (!this.progress.unlocks[15] && this.progress.weirdWins > 0)
            {
                this.progress.unlocks[15] = true;
                this.unlocks.Add(15);
            }

            if (!this.progress.unlocks[16] && this.progress.weirdWins > 1)
            {
                this.progress.unlocks[16] = true;
                this.unlocks.Add(16);
            }

            if (!this.progress.unlocks[17] && this.progress.deadWins > 0)
            {
                this.progress.unlocks[17] = true;
                this.unlocks.Add(17);
            }

            if (!this.progress.unlocks[18] && this.progress.deadWins > 1)
            {
                this.progress.unlocks[18] = true;
                this.unlocks.Add(18);
            }

            if (!this.progress.unlocks[19] && this.progress.emptyWins > 0)
            {
                this.progress.unlocks[19] = true;
                this.unlocks.Add(19);
            }

            if (!this.progress.unlocks[20] && this.progress.emptyWins > 1)
            {
                this.progress.unlocks[20] = true;
                this.unlocks.Add(20);
            }

            float num = 0.95f;
            for (int index = 21; index < 31; ++index)
            {
                if (this.progress.unlocks[index])
                    num -= 0.05f; //SPIDERBUTT - change to intended 0.05f
            }

            if ((double) num < 0.4f) //SPIDERBUTT - change lower bound to 0.4f to match patch 1.0.5
                num = 0.4f;
            if ((double) Random.Range(0.0f, 1f) > (double) num)
            {
                this.app.view.introPaperView.musicAudio = this.badMusic;
                this.app.view.introPaperView.video.clip = this.app.view.badUnlock;
                this.app.view.goodEnding = false;
            }
            else
            {
                this.app.view.goodEnding = true;
                for (int index = 21; index < 31; ++index)
                {
                    if (!this.progress.unlocks[index])
                    {
                        this.unlocks.Add(index);
                        this.progress.unlocks[index] = true;
                        break;
                    }
                }
            }

            if (this.unlocks.Count > 0)
            {
                this.showUnlock = true;
                ProgressionController.SaveProgression(this.progress);
            }
        }

        this.app.view.introPaperView.video.Play();
        this.app.view.introPaperView.voAudio.Play();
        this.app.view.introPaperView.fxAudio.Play();
        this.app.view.introPaperView.musicAudio.Play();
    }
}