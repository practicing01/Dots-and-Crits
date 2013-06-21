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
joycallback(%axisstate,$joyobject.cursorgui.Position);
}
else if (%axisstate.X==-1||%axisstate.X==1)//left or right
{
cancel($joyobject.xmoveschedule.schedulehandle);
$joyobject.xmoveschedule.schedulehandle=schedule(62,0,"movejoycursor",%axistomove,%axisstate,false);
}

}
else
{

if (%axisstate.Y==0)//y release
{
//cancel schedule
cancel($joyobject.ymoveschedule.schedulehandle);
joycallback(%axisstate,$joyobject.cursorgui.Position);
}
else if (%axisstate.Y==-1||%axisstate.Y==1)//up or down
{
cancel($joyobject.ymoveschedule.schedulehandle);
$joyobject.ymoveschedule.schedulehandle=schedule(62,0,"movejoycursor",%axistomove,%axisstate,false);
}

}

return;
}

if (%axistomove==0)
{

if (%axisstate.X==-1)
{
$joyobject.cursorgui.Position.X-=30;
if ($joyobject.cursorgui.Position.X<0){$joyobject.cursorgui.Position.X=0;}
joycallback(%axisstate,$joyobject.cursorgui.Position);
$joyobject.xmoveschedule.schedulehandle=schedule(62,0,"movejoycursor",%axistomove,%axisstate,false);
}
else if (%axisstate.X==1)
{
$joyobject.cursorgui.Position.X+=30;
if ($joyobject.cursorgui.Position.X>$resolution.X){$joyobject.cursorgui.Position.X=$resolution.X;}
joycallback(%axisstate,$joyobject.cursorgui.Position);
$joyobject.xmoveschedule.schedulehandle=schedule(62,0,"movejoycursor",%axistomove,%axisstate,false);
}

}
else
{

if (%axisstate.Y==-1)
{
$joyobject.cursorgui.Position.Y-=30;
if ($joyobject.cursorgui.Position.Y<0){$joyobject.cursorgui.Position.Y=0;}
joycallback(%axisstate,$joyobject.cursorgui.Position);
$joyobject.ymoveschedule.schedulehandle=schedule(62,0,"movejoycursor",%axistomove,%axisstate,false);
}
else if (%axisstate.Y==1)
{
$joyobject.cursorgui.Position.Y+=30;
if ($joyobject.cursorgui.Position.Y>$resolution.Y){$joyobject.cursorgui.Position.Y=$resolution.Y;}
joycallback(%axisstate,$joyobject.cursorgui.Position);
$joyobject.ymoveschedule.schedulehandle=schedule(62,0,"movejoycursor",%axistomove,%axisstate,false);
}

}

}
