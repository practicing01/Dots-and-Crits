exec("./skill_Dot.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Dot::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Dot ahead in the direction you're facing.");
Dot.setskillbaricon(%slot);
}

function Dot::onlevelload(%this)
{
echo("Dot loaded");

Dot.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one ScriptObject per player, containing all custom fields for this skill
{
%fields=new ScriptObject()
{
targethandle=-1;
};

Dot.customplayerfields.add(%fields);
}

}

function Dot::create(%this)
{
echo("created Dot");
}

function Dot::destroy(%this)
{
echo("deleted Dot");
}

function Dot::unloadskill(%this)
{
echo("unloaded Dot");

Dot.customplayerfields.deleteObjects();
Dot.customplayerfields.delete();

}

function Dot::transformobjects(%this,%playerindex)
{
return;
}
