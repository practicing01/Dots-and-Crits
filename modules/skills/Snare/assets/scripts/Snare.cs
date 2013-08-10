exec("./skill_Snare.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Snare::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Impair targets velocity.");
Snare.setskillbaricon(%slot);
}

function Snare::onlevelload(%this)
{
echo("Snare loaded");

Snare.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one ScriptObject per player, containing all custom fields for this skill
{
%fields=new ScriptObject()
{
targethandle=-1;
};

Snare.customplayerfields.add(%fields);
}

}

function Snare::create(%this)
{
echo("created Snare");
}

function Snare::destroy(%this)
{
echo("deleted Snare");
}

function Snare::unloadskill(%this)
{
echo("unloaded Snare");

Snare.customplayerfields.deleteObjects();
Snare.customplayerfields.delete();

}

function Snare::transformobjects(%this,%playerindex)
{
return;
}
