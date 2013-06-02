exec("./setguihandles.cs");
exec("./repositionskillbar.cs");
exec("./toggleskillnibble.cs");

GlobalActionMap.bindCmd(keyboard,"space","toggleskillnibble(0);","");
GlobalActionMap.bindCmd(joystick,"button4","toggleskillnibble(1);","");

function skillbar::create(%this)
{
DotsandCrits.add(TamlRead("./../gui/skillbar.gui.taml"));

gui_skillbar.resize(0,0,$resolution.X,$resolution.Y);

}

function skillbar::destroy(%this)
{
if (isObject(gui_skillbar))
{
if (gui_skillbar.isAwake())
{
Canvas.popDialog(gui_skillbar);
}
}
}
