exec("./newgame.cs");
exec("./miscbutton.cs");
exec("./skillslotbuttons.cs");
exec("./clearskillbar.cs");
exec("./saveskillbar.cs");
exec("./loadskillbar.cs");
exec("./joypad/configurejoypad.cs");

function mainmenu::create(%this)
{
//$menumusic=alxPlay(audio_menumusic);
DotsandCrits.add(TamlRead("./../../gui/mainmenu.gui.taml"));
gui_mainmenu.resize(0,0,$resolution.X,$resolution.Y);

//load levels

%levelmodules=ModuleDatabase.findModuleTypes("level",false);

if (!isObject(simset_list_levels))
{
new SimSet(simset_list_levels);
}

simset_list_levels.clear();

%levelcount=getWordCount(%levelmodules);

for (%x=0;%x<%levelcount;%x++)
{
%moduleid=getWord(%levelmodules,%x);
ModuleDatabase.LoadExplicit(%moduleid.ModuleId);
simset_list_levels.add(%moduleid);
gui_list_level.addItem(%moduleid.description);
}

//load player sprites

%playerspritemodules=ModuleDatabase.findModuleTypes("playersprite",false);

if (!isObject(simset_list_playersprites))
{
new SimSet(simset_list_playersprites);
}

simset_list_playersprites.clear();

%playerspritecount=getWordCount(%playerspritemodules);

for (%x=0;%x<%playerspritecount;%x++)
{
%moduleid=getWord(%playerspritemodules,%x);
ModuleDatabase.LoadExplicit(%moduleid.ModuleId);
simset_list_playersprites.add(%moduleid);
gui_list_player1.addItem(%moduleid.description);
gui_list_player2.addItem(%moduleid.description);
}

//load skills

%skillmodules=ModuleDatabase.findModuleTypes("skill",false);

if (!isObject(simset_list_skills))
{
new SimSet(simset_list_skills);
}

simset_list_skills.clear();

%skillcount=getWordCount(%skillmodules);

for (%x=0;%x<%skillcount;%x++)
{
%moduleid=getWord(%skillmodules,%x);
ModuleDatabase.LoadExplicit(%moduleid.ModuleId);
simset_list_skills.add(%moduleid);
gui_list_player1skills.addItem(%moduleid.description);
gui_list_player2skills.addItem(%moduleid.description);
}

}

function mainmenu::destroy(%this)
{
if (isObject(gui_mainmenu))
{
if (gui_mainmenu.isAwake())
{
Canvas.popDialog(gui_mainmenu);
}
}
}
