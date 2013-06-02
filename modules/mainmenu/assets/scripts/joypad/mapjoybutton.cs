function mapjoybutton(%buttonindex)
{

%buttonpressed=0;

for (%x=0;%x<$joypadbuttons.getCount();%x++)
{
%button=$joypadbuttons.getObject(%x);
if (%button.state)
{
%buttonpressed=%button;
break;
}
}

if (!%buttonpressed)
{
echo("no button pressed, try again incase of joypad recognition delay");
return;
}

if (%buttonindex==0)//move up
{
GlobalActionMap.bindCmd(joystick,%buttonpressed.name,"moveplayerup(1);","moveplayerupstop(1);");
%buttonpressed.map=0;
echo("mapped "@%buttonpressed.name@" to moveup()");
}
else if (%buttonindex==1)//move down
{
GlobalActionMap.bindCmd(joystick,%buttonpressed.name,"moveplayerdown(1);","moveplayerdownstop(1);");
%buttonpressed.map=1;
echo("mapped "@%buttonpressed.name@" to movedown()");
}
else if (%buttonindex==2)//move left
{
GlobalActionMap.bindCmd(joystick,%buttonpressed.name,"moveplayerleft(1);","moveplayerleftstop(1);");
%buttonpressed.map=2;
echo("mapped "@%buttonpressed.name@" to moveleft()");
}
else if (%buttonindex==3)//move right
{
GlobalActionMap.bindCmd(joystick,%buttonpressed.name,"moveplayerright(1);","moveplayerrightstop(1);");
%buttonpressed.map=3;
echo("mapped "@%buttonpressed.name@" to moveright()");
}
else if (%buttonindex==4)//skill 0 & 4
{
GlobalActionMap.bindCmd(joystick,%buttonpressed.name,"skillkeypressed(1,0);","");
%buttonpressed.map=4;
echo("mapped "@%buttonpressed.name@" to skill 0 & 4");
}
else if (%buttonindex==5)//skill 1 & 5
{
GlobalActionMap.bindCmd(joystick,%buttonpressed.name,"skillkeypressed(1,1);","");
%buttonpressed.map=5;
echo("mapped "@%buttonpressed.name@" to skill 1 & 5");
}
else if (%buttonindex==6)//skill 2 & 6
{
GlobalActionMap.bindCmd(joystick,%buttonpressed.name,"skillkeypressed(1,2);","");
%buttonpressed.map=6;
echo("mapped "@%buttonpressed.name@" to skill 2 & 6");
}
else if (%buttonindex==7)//skill 3 & 7
{
GlobalActionMap.bindCmd(joystick,%buttonpressed.name,"skillkeypressed(1,3);","");
%buttonpressed.map=7;
echo("mapped "@%buttonpressed.name@" to skill 3 & 7");
}
else if (%buttonindex==8)//Toggle Skill Bar Nibble
{
GlobalActionMap.bindCmd(joystick,%buttonpressed.name,"toggleskillnibble(1);","");
%buttonpressed.map=8;
echo("mapped "@%buttonpressed.name@" to toggle skill bar nibble");
}
else if (%buttonindex==9)//tool skill
{
//GlobalActionMap.bindCmd(joystick,%buttonpressed,"toggleskillnibble(1);","");
}

}
