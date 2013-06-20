function movejoycursor(%axistomove,%axisstate,%newiteration)
{

if (%newiteration)//first check
{

if (%axistomove==0)
{

if (%axisstate.X==0)//x release
{
//cancel schedule
cancel($joyobject.xmoveschedule.schedulehandle);
}
else if (%axisstate.X==-1)//left
{
cancel($joyobject.xmoveschedule.schedulehandle);
$joyobject.xmoveschedule.schedulehandle=schedule(75,0,"movejoycursor",%axistomove,%axisstate,false);
}
else if (%axisstate.X==1)//right
{
cancel($joyobject.xmoveschedule.schedulehandle);
$joyobject.xmoveschedule.schedulehandle=schedule(75,0,"movejoycursor",%axistomove,%axisstate,false);
}

}
else
{

if (%axisstate.Y==0)//y release
{
//cancel schedule
cancel($joyobject.ymoveschedule.schedulehandle);
}
else if (%axisstate.Y==-1)//up
{
cancel($joyobject.ymoveschedule.schedulehandle);
$joyobject.ymoveschedule.schedulehandle=schedule(75,0,"movejoycursor",%axistomove,%axisstate,false);
}
else if (%axisstate.Y==1)//down
{
cancel($joyobject.ymoveschedule.schedulehandle);
$joyobject.ymoveschedule.schedulehandle=schedule(75,0,"movejoycursor",%axistomove,%axisstate,false);
}

}

return;
}

if (%axistomove==0)
{

if (%axisstate.X==-1)
{
$joyobject.cursorgui.Position.X-=30;
$joyobject.xmoveschedule.schedulehandle=schedule(75,0,"movejoycursor",%axistomove,%axisstate,false);
}
else if (%axisstate.X==1)
{
$joyobject.cursorgui.Position.X+=30;
$joyobject.xmoveschedule.schedulehandle=schedule(75,0,"movejoycursor",%axistomove,%axisstate,false);
}

}
else
{

if (%axisstate.Y==-1)
{
$joyobject.cursorgui.Position.Y-=30;
$joyobject.ymoveschedule.schedulehandle=schedule(75,0,"movejoycursor",%axistomove,%axisstate,false);
}
else if (%axisstate.Y==1)
{
$joyobject.cursorgui.Position.Y+=30;
$joyobject.ymoveschedule.schedulehandle=schedule(75,0,"movejoycursor",%axistomove,%axisstate,false);
}

}

}
