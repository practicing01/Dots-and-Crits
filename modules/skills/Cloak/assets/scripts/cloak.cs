exec("./skill_cloak.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Cloak::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Cloak to surprise or defend.");
Cloak.setskillbaricon(%slot);
}

function Cloak::onlevelload(%this)
{
echo("Cloak loaded");

Cloak.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one simobject per player, containing all custom fields for this skill
{
%fields=new SimObject()
{
cloakstate=false;
};

Cloak.customplayerfields.add(%fields);
}

}

function Cloak::create(%this)
{
echo("created Cloak");
}

function Cloak::destroy(%this)
{
echo("deleted Cloak");
}

function Cloak::unloadskill(%this)
{
echo("unloaded Cloak");

Cloak.customplayerfields.deleteObjects();
Cloak.customplayerfields.delete();

}

function Cloak::transformobjects(%this,%playerindex)
{
return;
}
