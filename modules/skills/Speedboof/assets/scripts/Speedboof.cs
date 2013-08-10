exec("./skill_Speedboof.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Speedboof::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Increase your velocity.");
Speedboof.setskillbaricon(%slot);
}

function Speedboof::onlevelload(%this)
{
echo("Speedboof loaded");
}

function Speedboof::create(%this)
{
echo("created Speedboof");
}

function Speedboof::destroy(%this)
{
echo("deleted Speedboof");
}

function Speedboof::unloadskill(%this)
{
echo("unloaded Speedboof");
}

function Speedboof::transformobjects(%this,%playerindex)
{
return;
}
