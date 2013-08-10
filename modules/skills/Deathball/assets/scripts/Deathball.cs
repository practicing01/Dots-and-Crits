exec("./oncollision.cs");
exec("./skill_Deathball.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Deathball::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Summon a ball of death.");
Deathball.setskillbaricon(%slot);
}

function Deathball::onlevelload(%this)
{
echo("Deathball loaded");

Deathball.deathballass=AssetDatabase.acquireAsset("Deathball:dbForward");

}

function Deathball::create(%this)
{
echo("created Deathball");
}

function Deathball::destroy(%this)
{
echo("deleted Deathball");
}

function Deathball::unloadskill(%this)
{
echo("unloaded Deathball");

AssetDatabase.releaseAsset(Deathball.deathballass.getAssetId());

}

function Deathball::transformobjects(%this,%playerindex)
{
return;
}

function class_deathball::updatehealth(%this)
{
//if (%this.health<=0){%this.safeDelete();}
return;//unkillable :)
}
