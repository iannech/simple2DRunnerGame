using UnityEngine;
using System.Collections;


public  static class AnimatorExtensions  {

    //
    // Go to state only if it is not already in the state
    //
    public static void goToStateIfNotAlreadyThere ( this Animator self, int StateHash)
    {
        if (self.GetCurrentAnimatorStateInfo( 0 ).fullPathHash != StateHash)
            self.Play(StateHash);
    }
}
