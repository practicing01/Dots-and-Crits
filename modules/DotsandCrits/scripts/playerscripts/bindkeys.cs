GlobalActionMap.bindCmd(keyboard,"w","moveplayerup(0);","moveplayerupstop(0);");
GlobalActionMap.bindCmd(keyboard,"s","moveplayerdown(0);","moveplayerdownstop(0);");
GlobalActionMap.bindCmd(keyboard,"a","moveplayerleft(0);","moveplayerleftstop(0);");
GlobalActionMap.bindCmd(keyboard,"d","moveplayerright(0);","moveplayerrightstop(0);");

GlobalActionMap.bindCmd(keyboard,"up","skillkeypressed(0,0);","");
GlobalActionMap.bindCmd(keyboard,"down","skillkeypressed(0,1);","");
GlobalActionMap.bindCmd(keyboard,"left","skillkeypressed(0,2);","");
GlobalActionMap.bindCmd(keyboard,"right","skillkeypressed(0,3);","");

GlobalActionMap.bindCmd(joystick,"button0","skillkeypressed(1,0);","");
GlobalActionMap.bindCmd(joystick,"button2","skillkeypressed(1,1);","");
GlobalActionMap.bindCmd(joystick,"button3","skillkeypressed(1,2);","");
GlobalActionMap.bindCmd(joystick,"button1","skillkeypressed(1,3);","");

GlobalActionMap.bindCmd(joystick,upov,"moveplayerup(1);","moveplayerupstop(1);");
GlobalActionMap.bindCmd(joystick,dpov,"moveplayerdown(1);","moveplayerdownstop(1);");
GlobalActionMap.bindCmd(joystick,lpov,"moveplayerleft(1);","moveplayerleftstop(1);");
GlobalActionMap.bindCmd(joystick,rpov,"moveplayerright(1);","moveplayerrightstop(1);");

%joyconfigfile=new FileObject();
%joyconfigfile.OpenForRead("./../../../mainmenu/assets/scripts/joypad/joypadconfig.txt");
for (%x=0;%x<$joypadbuttons.getCount();%x++)
{
%buttonmap=%joyconfigfile.readline();
if (%buttonmap!=-1)
{
%butt=$joypadbuttons.getObject(%x);
%prevbuttonstate=%butt.state;

%butt.state=true;
mapjoybutton(%buttonmap);
%butt.state=%prevbuttonstate;
}
}
%joyconfigfile.close();
%joyconfigfile.delete();
