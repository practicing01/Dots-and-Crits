exec("./skill_Lightsaber.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");
exec("./oncollision.cs");
exec("./mousemovement.cs");
exec("./joymovement.cs");

function Lightsaber::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Lightsaber ahead in the direction you're facing.");
Lightsaber.setskillbaricon(%slot);
}

function Lightsaber::onlevelload(%this)
{
echo("Lightsaber loaded");

Lightsaber.Lightsaberass=AssetDatabase.acquireAsset("Lightsaber:image_Lightsaber");

Lightsaber.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one ScriptObject per player, containing all custom fields for this skill
{
%fields=new ScriptObject()
{
Lightsaberon=false;
Lightsabersprite=0;
shoulderrevolutejoint=-1;
elbowrevolutejoint=-1;
saberjoint=-1;
dummyjoint=-1;
shoulderobj=0;
elbowobj=0;
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

%fields.elbowobj=new SceneObject()
{
size="0.5 0.5";
Position="0 0";
Visible="false";
Active="false";
DefaultDensity="1";
LinearDamping=100;
};
%fields.elbowobj.createCircleCollisionShape(%fields.elbowobj.size);
DotsandCritsscene.add(%fields.elbowobj);

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

%fields.Lightsabersprite=new Sprite()
{
Position="0 0";
Size=ScaleAssSizeVectorToCam(Lightsaber.Lightsaberass);
Image="Lightsaber:image_Lightsaber";
class="class_Lightsaber";
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
%fields.Lightsabersprite.SceneGroup=28;//player 0 projectiles
%fields.Lightsabersprite.setCollisionGroups(1,25,26,29,30);//1=player 2, 29=player 2 projectiles, 30=walls, 26=world objects
%fields.shoulderobj.SceneGroup=28;
%fields.shoulderobj.setCollisionGroups(1,25,26,29,30);
%fields.elbowobj.SceneGroup=28;
%fields.elbowobj.setCollisionGroups(1,25,26,29,30);
%fields.mountobj.SceneGroup=28;
%fields.mountobj.setCollisionGroups(1,25,26,29,30);
%fields.dummyobj.SceneGroup=28;
%fields.dummyobj.setCollisionGroups(1,25,26,29,30);
}
else//player 1 casted
{
%fields.Lightsabersprite.SceneGroup=29;//player 1 projectiles
%fields.Lightsabersprite.setCollisionGroups(0,25,26,28,30);//0=player 1, 28=player 1 projectiles, 30=walls, 26=world objects
%fields.shoulderobj.SceneGroup=29;
%fields.shoulderobj.setCollisionGroups(0,25,26,28,30);
%fields.elbowobj.SceneGroup=29;
%fields.elbowobj.setCollisionGroups(0,25,26,28,30);
%fields.mountobj.SceneGroup=29;
%fields.mountobj.setCollisionGroups(0,25,26,28,30);
%fields.dummyobj.SceneGroup=29;
%fields.dummyobj.setCollisionGroups(0,25,26,28,30);
}

DotsandCritsscene.add(%fields.Lightsabersprite);
%fields.Lightsabersprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(Lightsaber.Lightsaberass));

//player 1 uses mouse player 2 uses joystick
if (!%x)//player 0 casted
{
%fields.Lightsabersprite.setUseInputEvents(true);

DotsandCritswindow.addInputListener(%fields.Lightsabersprite);
scenewindow_player1.addInputListener(%fields.Lightsabersprite);
}
else
{
$joycallbackobjlist.add(%fields.Lightsabersprite);
}

Lightsaber.customplayerfields.add(%fields);
}

}

function Lightsaber::create(%this)
{
echo("created Lightsaber");
}

function Lightsaber::destroy(%this)
{
echo("deleted Lightsaber");
}

function Lightsaber::unloadskill(%this)
{
echo("unloaded Lightsaber");

AssetDatabase.releaseAsset(Lightsaber.Lightsaberass.getAssetId());

for (%x=0;%x<$numofplayers;%x++)
{
%customfieldobj=Lightsaber.customplayerfields.getObject(%x);
DotsandCritsscene.deleteJoint(%customfieldobj.shoulderrevolutejoint);
DotsandCritsscene.deleteJoint(%customfieldobj.elbowrevolutejoint);
DotsandCritsscene.deleteJoint(%customfieldobj.saberjoint);
DotsandCritsscene.deleteJoint(%customfieldobj.dummyjoint);
%customfieldobj.Lightsabersprite.safeDelete();
%customfieldobj.shoulderobj.safeDelete();
%customfieldobj.elbowobj.safeDelete();
%customfieldobj.mountobj.safeDelete();
%customfieldobj.dummyobj.safeDelete();
}

Lightsaber.customplayerfields.deleteObjects();
Lightsaber.customplayerfields.delete();

}

function Lightsaber::transformobjects(%this,%playerindex)
{
return;
}
