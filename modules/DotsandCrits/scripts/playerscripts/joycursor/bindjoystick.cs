//haxolution for noisy sticks :)

function rightjoysticky(%value)
{

if (%value==-1)
{
if ($joyobject.axisstate.Y!=-1)
{
//echo("up pressed");
$joyobject.axisstate.Y=-1;
//do stuff
movejoycursor(1,$joyobject.axisstate,true);
}
}

if (%value==1)
{
if ($joyobject.axisstate.Y!=1)
{
//echo("down pressed");
$joyobject.axisstate.Y=1;
//do stuff
movejoycursor(1,$joyobject.axisstate,true);
}
}

if (%value<0&&%value>-1)
{
//echo("nothing pressed");
}

if (%value>0&&%value<1)
{
if ($joyobject.axisstate.Y!=0)
{
//echo("y axis released");
$joyobject.axisstate.Y=0;
//do stuff
movejoycursor(1,$joyobject.axisstate,true);
}
}

}

function rightjoystickx(%value)
{

if (%value==-1)
{
if ($joyobject.axisstate.X!=-1)
{
//echo("left pressed");
$joyobject.axisstate.X=-1;
//do stuff
movejoycursor(0,$joyobject.axisstate,true);
}
}

if (%value==1)
{
if ($joyobject.axisstate.X!=1)
{
//echo("right pressed");
$joyobject.axisstate.X=1;
//do stuff
movejoycursor(0,$joyobject.axisstate,true);
}
}

if (%value<0&&%value>-1)
{
//echo("nothing pressed");
}

if (%value>0&&%value<1)
{
if ($joyobject.axisstate.X!=0)
{
//echo("x axis released");
$joyobject.axisstate.X=0;
//do stuff
movejoycursor(0,$joyobject.axisstate,true);
}
}

}

//GlobalActionMap.bind(joystick,xaxis,"rightjoysticky");
//GlobalActionMap.bind(joystick,yaxis,"rightjoystickx");
GlobalActionMap.bind(joystick,rzaxis,"rightjoysticky");
GlobalActionMap.bind(joystick,zaxis,"rightjoystickx");
