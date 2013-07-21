exec("./Wavedecay.cs");
exec("./onanimationend.cs");
exec("./oncollision.cs");
exec("./onmovetocomplete.cs");
exec("./skill_Wave.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Wave::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Shell the target with a Wave of radiation.");
Wave.setskillbaricon(%slot);
}

function Wave::onlevelload(%this)
{
echo("loaded Wave Waves");

if (!$view)
{
Wave.top_Waveass=AssetDatabase.acquireAsset("Wave:image_topdown_Wave");
Wave.top_explosionass=AssetDatabase.acquireAsset("Wave:image_topdown_explosion");
}
else
{
Wave.side_Waveass=AssetDatabase.acquireAsset("Wave:image_sideview_Wave");
Wave.side_explosionass=AssetDatabase.acquireAsset("Wave:image_sideview_explosion");
}

}

function Wave::create(%this)
{
echo("created Wave");
}

function Wave::destroy(%this)
{
echo("deleted Wave");
}

function Wave::unloadskill(%this)
{
echo("unloaded Wave");

if (!$view)
{
AssetDatabase.releaseAsset(Wave.top_Waveass.getAssetId());
AssetDatabase.releaseAsset(Wave.top_explosionass.getAssetId());
}
else
{
AssetDatabase.releaseAsset(Wave.side_Waveass.getAssetId());
AssetDatabase.releaseAsset(Wave.side_explosionass.getAssetId());
}

}

function Wave::transformobjects(%this,%playerindex)
{
return;
}
