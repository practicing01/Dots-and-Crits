exec("./oncollision.cs");
exec("./skill_Bombermine.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");
exec("./onanimationend.cs");

function Bombermine::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Plant a Bombermine that explodes when touched.");
Bombermine.setskillbaricon(%slot);
}

function Bombermine::onlevelload(%this)
{
echo("loaded Bombermine Bombermines");

Bombermine.Bombermineass=AssetDatabase.acquireAsset("Bombermine:image_Bombermine");

}

function Bombermine::create(%this)
{
echo("created Bombermine");
}

function Bombermine::destroy(%this)
{
echo("deleted Bombermine");
}

function Bombermine::unloadskill(%this)
{
echo("unloaded Bombermine");

AssetDatabase.releaseAsset(Bombermine.Bombermineass.getAssetId());

}

function Bombermine::transformobjects(%this,%playerindex)
{
return;
}

function class_Bombermine::updatehealth(%this)
{
if (%this.health<=0){%this.playAnimation("Bombermine:anim_explode");}
}
