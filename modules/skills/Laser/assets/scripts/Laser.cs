exec("./oncollision.cs");
exec("./skill_Laser.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Laser::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Shell the target with a Laser of radiation.");
Laser.setskillbaricon(%slot);
}

function Laser::onlevelload(%this)
{
echo("loaded Laser Lasers");

Laser.top_Laserass=AssetDatabase.acquireAsset("Laser:image_topdown_Laser");
Laser.top_explosionass=AssetDatabase.acquireAsset("Laser:image_topdown_explosion");

Laser.side_Laserass=AssetDatabase.acquireAsset("Laser:image_sideview_Laser");
Laser.side_explosionass=AssetDatabase.acquireAsset("Laser:image_sideview_explosion");

Laser.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one simobject per player, containing all custom fields for this skill
{
%fields=new SimObject()
{
schedulehandle=0;
dest="0 0";
originindex=0;
firing=false;
spritehandle=0;
size="0 0";
};

Laser.customplayerfields.add(%fields);
}

}

function Laser::create(%this)
{
echo("created Laser");
}

function Laser::destroy(%this)
{
echo("deleted Laser");
}

function Laser::unloadskill(%this)
{
echo("unloaded Laser");

AssetDatabase.releaseAsset(Laser.top_Laserass.getAssetId());
AssetDatabase.releaseAsset(Laser.top_explosionass.getAssetId());

AssetDatabase.releaseAsset(Laser.side_Laserass.getAssetId());
AssetDatabase.releaseAsset(Laser.side_explosionass.getAssetId());

for (%x=0;%x<$numofplayers;%x++)
{
%customfieldobj=Laser.customplayerfields.getObject(%x);
cancel(%customfieldobj.schedulehandle);
}

Laser.customplayerfields.deleteObjects();
Laser.customplayerfields.delete();

}

function Laser::transformobjects(%this,%playerindex)
{
return;
}

function updatetransformation(%playerindex)
{
%customfieldobj=Laser.customplayerfields.getObject(%playerindex);

%player=$players.getObject(%playerindex);

%dirset=0;

if (%player.curdir==0)
{
%dirset=%player.projectileorigindirset.getObject(0);
}
else if (%player.curdir==1)
{
%dirset=%player.projectileorigindirset.getObject(1);
}
else if (%player.curdir==2)
{
%dirset=%player.projectileorigindirset.getObject(2);
}
else if (%player.curdir==3)
{
%dirset=%player.projectileorigindirset.getObject(3);
}

%origin="0 0";

if (%customfieldobj.originindex<%dirset.getCount())
{
%origin=%dirset.getObject(%customfieldobj.originindex);
}
else
{
%customfieldobj.originindex=getRandom(0,%dirset.getCount()-1);
%origin=%dirset.getObject(%customfieldobj.originindex);
}

%customfieldobj.spritehandle.Position.X=%player.sprite.Position.X+%origin.x;
%customfieldobj.spritehandle.Position.Y=%player.sprite.Position.Y+%origin.y;

%customfieldobj.spritehandle.Size=%customfieldobj.size;

%customfieldobj.spritehandle.Size.Y+=Vector2Distance(%customfieldobj.spritehandle.Position,%customfieldobj.dest);
%customfieldobj.spritehandle.Angle=Vector2AngleToPoint(%customfieldobj.spritehandle.Position,%customfieldobj.dest);
%vec2dir=Vector2Direction(%customfieldobj.spritehandle.Angle,%customfieldobj.spritehandle.Size.Y/2);
%customfieldobj.spritehandle.Position.X+=%vec2dir.X;
%customfieldobj.spritehandle.Position.Y+=-%vec2dir.Y;

%customfieldobj.spritehandle.clearCollisionShapes();

%shapeindex=%customfieldobj.spritehandle.createPolygonBoxCollisionShape(%customfieldobj.spritehandle.Size);
%customfieldobj.spritehandle.setCollisionShapeIsSensor(%shapeindex,true);


%customfieldobj.schedulehandle=schedule(62,0,"updatetransformation",%playerindex);

}
