exec("./skill_Lightsaber2.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");
exec("./oncollision.cs");
exec("./mousemovement.cs");
exec("./joymovement.cs");

function Lightsaber2::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("A weapon for a more civilized time. Style 2");
Lightsaber2.setskillbaricon(%slot);
}

function Lightsaber2::onlevelload(%this)
{
echo("Lightsaber2 loaded");

Lightsaber2.Lightsaber2ass=AssetDatabase.acquireAsset("Lightsaber2:image_Lightsaber2");

Lightsaber2.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one ScriptObject per player, containing all custom fields for this skill
{
%fields=new ScriptObject()
{
Lightsaber2on=false;
Lightsaber2sprite=0;
shoulderrevolutejoint=-1;
saberjoint=-1;
dummyjoint=-1;
shoulderobj=0;
mountobj=0;
dummyobj=0;
mouseprevpos="0 0";
dragiteration=0;
};

%fields.shoulderobj=new SceneObject()
{
size="1 1";
Position="0 0";
Visible="false";
Active="false";
DefaultDensity="5";
LinearDamping=100;
};
%fields.shoulderobj.createCircleCollisionShape(%fields.shoulderobj.size);
DotsandCritsscene.add(%fields.shoulderobj);

%fields.mountobj=new SceneObject()
{
size="1 1";
Position="0 0";
Visible="false";
Active="false";
SleepingAllowed=false;
};
%fields.mountobj.createCircleCollisionShape(%fields.mountobj.size);
DotsandCritsscene.add(%fields.mountobj);

%fields.dummyobj=new SceneObject()
{
size="1 1";
Position="0 0";
Visible="false";
Active="false";
LinearDamping=100;
};
%fields.dummyobj.createCircleCollisionShape(%fields.dummyobj.size);
DotsandCritsscene.add(%fields.dummyobj);

%fields.Lightsaber2sprite=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(Lightsaber2.Lightsaber2ass);
Image="Lightsaber2:image_Lightsaber2";
class="class_Lightsaber2";
CollisionCallback="true";
SceneLayer=16;
GravityScale="0";
DefaultDensity=0.1;
//DefaultRestitution=1;
Visible="false";
Active="false";
parentScriptObject=%fields;
LinearDamping=10;
};

if (!%x)//player 0 casted
{
%fields.Lightsaber2sprite.SceneGroup=28;//player 0 projectiles
%fields.Lightsaber2sprite.setCollisionGroups(1,25,26,29,30);//1=player 2, 29=player 2 projectiles, 30=walls, 26=world objects
%fields.shoulderobj.SceneGroup=28;
%fields.shoulderobj.setCollisionGroups(1,25,26,29,30);
%fields.mountobj.SceneGroup=28;
%fields.mountobj.setCollisionGroups(1,25,26,29,30);
%fields.dummyobj.SceneGroup=28;
%fields.dummyobj.setCollisionGroups(1,25,26,29,30);
}
else//player 1 casted
{
%fields.Lightsaber2sprite.SceneGroup=29;//player 1 projectiles
%fields.Lightsaber2sprite.setCollisionGroups(0,25,26,28,30);//0=player 1, 28=player 1 projectiles, 30=walls, 26=world objects
%fields.shoulderobj.SceneGroup=29;
%fields.shoulderobj.setCollisionGroups(0,25,26,28,30);
%fields.mountobj.SceneGroup=29;
%fields.mountobj.setCollisionGroups(0,25,26,28,30);
%fields.dummyobj.SceneGroup=29;
%fields.dummyobj.setCollisionGroups(0,25,26,28,30);
}

DotsandCritsscene.add(%fields.Lightsaber2sprite);
%fields.Lightsaber2sprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(Lightsaber2.Lightsaber2ass));

//player 1 uses mouse player 2 uses joystick
if (!%x)//player 0 casted
{
%fields.Lightsaber2sprite.setUseInputEvents(true);

DotsandCritswindow.addInputListener(%fields.Lightsaber2sprite);
scenewindow_player1.addInputListener(%fields.Lightsaber2sprite);
}
else
{
$joycallbackobjlist.add(%fields.Lightsaber2sprite);
}

Lightsaber2.customplayerfields.add(%fields);
}

}

function Lightsaber2::create(%this)
{
echo("created Lightsaber2");
}

function Lightsaber2::destroy(%this)
{
echo("deleted Lightsaber2");
}

function Lightsaber2::unloadskill(%this)
{
echo("unloaded Lightsaber2");

AssetDatabase.releaseAsset(Lightsaber2.Lightsaber2ass.getAssetId());

for (%x=0;%x<$numofplayers;%x++)
{
%customfieldobj=Lightsaber2.customplayerfields.getObject(%x);
DotsandCritsscene.deleteJoint(%customfieldobj.shoulderrevolutejoint);
DotsandCritsscene.deleteJoint(%customfieldobj.saberjoint);
DotsandCritsscene.deleteJoint(%customfieldobj.dummyjoint);
%customfieldobj.Lightsaber2sprite.safeDelete();
%customfieldobj.shoulderobj.safeDelete();
%customfieldobj.mountobj.safeDelete();
%customfieldobj.dummyobj.safeDelete();
}

Lightsaber2.customplayerfields.deleteObjects();
Lightsaber2.customplayerfields.delete();

}

function Lightsaber2::transformobjects(%this,%playerindex)
{
return;
}
