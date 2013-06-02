exec("./skill_Melee.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Melee::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Melee ahead in the direction you're facing.");
Melee.setskillbaricon(%slot);
}

function Melee::onlevelload(%this)
{
echo("Melee loaded");
}

function Melee::create(%this)
{
echo("created Melee");
}

function Melee::destroy(%this)
{
echo("deleted Melee");
}

function Melee::unloadskill(%this)
{
echo("unloaded Melee");
}

function Melee::transformobjects(%this,%playerindex)
{
return;
}
