using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specs : MonoBehaviour
{
    /* Game Dev Notes for Mission Demolition
     * Imagine that we're going make a prototye
     * And these are our notes after talking with
     * our Designer
     * 
     * Core mechanic:
        1. When player mouse pointer is in range of slingshot - slingshot will glow
        2. If player presses the left mouse button while slingshot is glowing - instantiate 
            a projectile at location of mouse pointer
        3. As player moves and drags the mouse with the button held down the projectile follows, 
            yet will remain within limits of the sphere collider of the slingshot
        3a. Camera
            Full Behavior:
            cam sits at initial pos. doesnt move durring aimingmode
            once projectile launched cam follows (with some easing - more natural feel)
            as cam moves up into the air, need to “zoom out” so we can still see the ground
            when projectile at rest, stop following and return to initial pos
            Some problems:
            Projectile flies past end of ground
            Projectile neither bounces or stops once it hits ground
            When projectile is launched camera jumps to pos of projectile (looks bad)
            When projectile is at certain height all we see is sky (hard to tell how high projectile is)


        4. A white line will stretch from each arm of the slingshot around the projectile to 
            make it look more like an actual slingshot
        5. When player releases mouse button - projectile fired from slingshot
        6. A castle will be set up several meters away. Players goal is to knock down the castle 
            and hit a target area inside
        7. Player can fire as many shots as she likes to hit the goal. Each shot will leave a trail 
            so player can judge next shot better
    */

}
