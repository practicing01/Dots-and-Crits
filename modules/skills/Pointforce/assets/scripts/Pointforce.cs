exec("./skill_Pointforce.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Pointforce::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Pointforce ahead in the direction you're facing.");
Pointforce.setskillbaricon(%slot);
}

function Pointforce::onlevelload(%this)
{
echo("Pointforce loaded");

Pointforce.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one ScriptObject per player, containing all custom fields for this skill
{
%fields=new ScriptObject()
{
controllerhandle=0;
};

Pointforce.customplayerfields.add(%fields);
}

}

function Pointforce::create(%this)
{
echo("created Pointforce");
}

function Pointforce::destroy(%this)
{
echo("deleted Pointforce");
}

function Pointforce::unloadskill(%this)
{
echo("unloaded Pointforce");

Pointforce.customplayerfields.deleteObjects();
Pointforce.customplayerfields.delete();

}

function Pointforce::transformobjects(%this,%playerindex)
{

%customfieldobj=Pointforce.customplayerfields.getObject(%playerindex);

if (%customfieldobj.controllerhandle)
{

%player=$players.getObject(%playerindex);

if (%player.curdir==0)
{
%customfieldobj.controllerhandle.Position="0 30";
}
else if (%player.curdir==1)
{
%customfieldobj.controllerhandle.Position="0 -30";
}
else if (%player.curdir==2)
{
%customfieldobj.controllerhandle.Position="-30 0";
}
else if (%player.curdir==3)
{
%customfieldobj.controllerhandle.Position="30 0";
}

}

}
