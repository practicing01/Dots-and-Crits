exec("./buttonstate.cs");
exec("./resetjoypad.cs");
exec("./mapjoybutton.cs");

function exitjoypadconfig()
{
Canvas.popDialog(gui_joypadconfig);
Canvas.pushDialog(gui_mainmenu);
Canvas.pushDialog(gui_skillbar);

%joyconfigfile=new FileObject();
%joyconfigfile.OpenForWrite("./joypadconfig.txt");
for (%x=0;%x<$joypadbuttons.getCount();%x++)
{
%joyconfigfile.writeline($joypadbuttons.getObject(%x).map);
}
%joyconfigfile.close();
%joyconfigfile.delete();

}

if (isObject(gui_joypadconfig))
{
gui_joypadconfig.delete();
}
DotsandCrits.add(TamlRead("./joypadconfig.gui.taml"));

function gui_mainmenu::configurejoypad(%this)
{
echo("configure joypad");
resetjoypad();
Canvas.popDialog(gui_mainmenu);
Canvas.popDialog(gui_skillbar);
Canvas.pushDialog(gui_joypadconfig);
}
