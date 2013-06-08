function FtA_P1::loadsprite(%this)//change FtA_P1 to your module's name
{
%player=$players.getObject($player_to_load);

deleteplayeranims();

%player.anim_stand_up_selfcast=new SimSet();
%player.anim_stand_down_selfcast=new SimSet();
%player.anim_stand_left_selfcast=new SimSet();
%player.anim_stand_right_selfcast=new SimSet();

%player.anim_run_up_selfcast=new SimSet();
%player.anim_run_down_selfcast=new SimSet();
%player.anim_run_left_selfcast=new SimSet();
%player.anim_run_right_selfcast=new SimSet();

%player.anim_stand_up_targetcast=new SimSet();
%player.anim_stand_down_targetcast=new SimSet();
%player.anim_stand_left_targetcast=new SimSet();
%player.anim_stand_right_targetcast=new SimSet();

%player.anim_run_up_targetcast=new SimSet();
%player.anim_run_down_targetcast=new SimSet();
%player.anim_run_left_targetcast=new SimSet();
%player.anim_run_right_targetcast=new SimSet();

%player.anim_stand_up_melee=new SimSet();
%player.anim_stand_down_melee=new SimSet();
%player.anim_stand_left_melee=new SimSet();
%player.anim_stand_right_melee=new SimSet();

%player.anim_run_up_melee=new SimSet();
%player.anim_run_down_melee=new SimSet();
%player.anim_run_left_melee=new SimSet();
%player.anim_run_right_melee=new SimSet();

%player.anim_stand_up_emote=new SimSet();
%player.anim_stand_down_emote=new SimSet();
%player.anim_stand_left_emote=new SimSet();
%player.anim_stand_right_emote=new SimSet();

%player.anim_run_up_emote=new SimSet();
%player.anim_run_down_emote=new SimSet();
%player.anim_run_left_emote=new SimSet();
%player.anim_run_right_emote=new SimSet();

/////////////////////////////////////////////////////
%player.sprite=new CompositeSprite()
{
class="class_player";
CollisionCallback="true";
SceneGroup=$player_to_load;//player sprite group, 0 for player 1, 1 for player 2
SceneLayer=15;
DefaultFriction="0.0";
playerindex=$player_to_load;
};

%player.sprite.CollisionGroups=bit(!%player.sprite.playerindex)|bit(25)|bit(26)|bit(30);//0=player 1, 1=player 2, 26=world objects, 30=walls

%player.sprite.SetBatchLayout("off");
%player.sprite.SetBatchSortMode("z");
%player.sprite.SetBatchIsolated(true);

DotsandCritsscene.add(%player.sprite);
/////////////////////////////////////////////////////

if ($view==0)
{
%ass=AssetDatabase.acquireAsset("FtA_P1:image_topdown");//change FtA_P1 to your module's name

%player.sprite.Position="0 0";
%player.sprite.setFixedAngle(true);
%player.sprite.clearCollisionShapes();
%player.sprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));
%player.sprite.clearSprites();
%player.spriteid=%player.sprite.addSprite();
%player.sprite.setSpriteLocalPosition(0,0);
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%player.sprite.setSpriteImage("FtA_P1:image_topdown",0);//change FtA_P1 to your module's name
%player.sprite.SetSpriteDepth(1);

AssetDatabase.releaseAsset(%ass.getAssetId());

//if you kept the same naming convention, change FtA_P1 to your module's name
//if not, change the strings to match your animation asset's names
//the movement animations are required
%player.anim_stand_up="FtA_P1:anim_topdownstandup";
%player.anim_stand_down="FtA_P1:anim_topdownstanddown";
%player.anim_stand_left="FtA_P1:anim_topdownstandleft";
%player.anim_stand_right="FtA_P1:anim_topdownstandright";
%player.anim_run_up="FtA_P1:anim_topdownrunup";
%player.anim_run_down="FtA_P1:anim_topdownrundown";
%player.anim_run_left="FtA_P1:anim_topdownrunleft";
%player.anim_run_right="FtA_P1:anim_topdownrunright";
%player.linear_damping=1;

%player.sprite.setLinearDamping(%player.linear_damping);

%player.sprite.setSpriteAnimation(%player.anim_stand_down);
%player.sprite.setUpdateCallback(true);

///////////////////////////////////////////////////////
//create animation simobjects to hold animation references:

//when a skill is called, it can choose which animation to run
//if the animation index or name doesn't exist, the skill should choose a random anim

//need an object for each animation, add each object to the anim set

//you can create as many animations as you want for each gesture
//if you don't want to deal with this you can assign the required animations to these
//(the movement animations)

//the gestures are as follow:
//self-cast, target-cast, melee, emote
//each gesture needs an animation for each direction (up, down, left, right)
//and for both standing/running
//4 gestures * 4 directions * 2 (standing/running) = 32 unique animations
//+ 2 (standing/running) * 4 directions for movement = 40 unique animations.
%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandupselfcast";
animname="anim_topdownstandupselfcast";
};
%player.anim_stand_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstanddownselfcast";
animname="anim_topdownstanddownselfcast";
};
%player.anim_stand_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandleftselfcast";
animname="anim_topdownstandleftselfcast";
};
%player.anim_stand_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandrightselfcast";
animname="anim_topdownstandrightselfcast";
};
%player.anim_stand_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrunupselfcast";
animname="anim_topdownrunupselfcast";
};
%player.anim_run_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrundownselfcast";
animname="anim_topdownrundownselfcast";
};
%player.anim_run_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrunleftselfcast";
animname="anim_topdownrunleftselfcast";
};
%player.anim_run_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrunrightselfcast";
animname="anim_topdownrunrightselfcast";
};
%player.anim_run_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstanduptargetcast";
animname="anim_topdownstanduptargetcast";
};
%player.anim_stand_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstanddowntargetcast";
animname="anim_topdownstanddowntargetcast";
};
%player.anim_stand_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandlefttargetcast";
animname="anim_topdownstandlefttargetcast";
};
%player.anim_stand_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandrighttargetcast";
animname="anim_topdownstandrighttargetcast";
};
%player.anim_stand_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrunuptargetcast";
animname="anim_topdownrunuptargetcast";
};
%player.anim_run_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrundowntargetcast";
animname="anim_topdownrundowntargetcast";
};
%player.anim_run_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrunlefttargetcast";
animname="anim_topdownrunlefttargetcast";
};
%player.anim_run_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrunrighttargetcast";
animname="anim_topdownrunrighttargetcast";
};
%player.anim_run_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandupmelee";
animname="anim_topdownstandupmelee";
};
%player.anim_stand_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstanddownmelee";
animname="anim_topdownstanddownmelee";
};
%player.anim_stand_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandleftmelee";
animname="anim_topdownstandleftmelee";
};
%player.anim_stand_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandrightmelee";
animname="anim_topdownstandrightmelee";
};
%player.anim_stand_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrunupmelee";
animname="anim_topdownrunupmelee";
};
%player.anim_run_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrundownmelee";
animname="anim_topdownrundownmelee";
};
%player.anim_run_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrunleftmelee";
animname="anim_topdownrunleftmelee";
};
%player.anim_run_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownrunrightmelee";
animname="anim_topdownrunrightmelee";
};
%player.anim_run_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_stand_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_stand_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_stand_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_stand_right_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_run_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_run_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_run_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_run_right_emote.add(%animobj);

///////////////////////////////////////////////////////
}
else//the following is the same as above but for sideview camera
{

%ass=AssetDatabase.acquireAsset("FtA_P1:image_sideview");

%player.sprite.Position="0 0";
%player.sprite.setFixedAngle(true);
%player.sprite.clearCollisionShapes();
%player.sprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));
%player.sprite.clearSprites();
%player.spriteid=%player.sprite.addSprite();
%player.sprite.setSpriteLocalPosition(0,0);
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%player.sprite.setSpriteImage("FtA_P1:image_sideview",0);
%player.sprite.SetSpriteDepth(1);

AssetDatabase.releaseAsset(%ass.getAssetId());

%player.anim_stand_up="FtA_P1:anim_sideviewstandup";
%player.anim_stand_down="FtA_P1:anim_sideviewstanddown";
%player.anim_stand_left="FtA_P1:anim_sideviewstandleft";
%player.anim_stand_right="FtA_P1:anim_sideviewstandright";
%player.anim_run_up="FtA_P1:anim_sideviewrunup";
%player.anim_run_down="FtA_P1:anim_sideviewrundown";
%player.anim_run_left="FtA_P1:anim_sideviewrunleft";
%player.anim_run_right="FtA_P1:anim_sideviewrunright";
%player.linear_damping=1;

%player.sprite.setLinearDamping(%player.linear_damping);

%player.sprite.setSpriteAnimation(%player.anim_stand_down);
%player.sprite.setUpdateCallback(true);
///////////////////////////////////////////////////////
//when a skill is called, it can choose which animation to run
//if the animation index doesn't exist, the skill should choose a random anim
//create animation simobjects to hold animation references

//need an object for each animation, add each object to the anim set
%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandupselfcast";
animname="anim_sideviewstandupselfcast";
};
%player.anim_stand_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstanddownselfcast";
animname="anim_sideviewstanddownselfcast";
};
%player.anim_stand_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandleftselfcast";
animname="anim_sideviewstandleftselfcast";
};
%player.anim_stand_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandrightselfcast";
animname="anim_sideviewstandrightselfcast";
};
%player.anim_stand_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrunupselfcast";
animname="anim_sideviewrunupselfcast";
};
%player.anim_run_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrundownselfcast";
animname="anim_sideviewrundownselfcast";
};
%player.anim_run_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrunleftselfcast";
animname="anim_sideviewrunleftselfcast";
};
%player.anim_run_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrunrightselfcast";
animname="anim_sideviewrunrightselfcast";
};
%player.anim_run_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstanduptargetcast";
animname="anim_sideviewstanduptargetcast";
};
%player.anim_stand_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstanddowntargetcast";
animname="anim_sideviewstanddowntargetcast";
};
%player.anim_stand_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandlefttargetcast";
animname="anim_sideviewstandlefttargetcast";
};
%player.anim_stand_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandrighttargetcast";
animname="anim_sideviewstandrighttargetcast";
};
%player.anim_stand_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrunuptargetcast";
animname="anim_sideviewrunuptargetcast";
};
%player.anim_run_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrundowntargetcast";
animname="anim_sideviewrundowntargetcast";
};
%player.anim_run_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrunlefttargetcast";
animname="anim_sideviewrunlefttargetcast";
};
%player.anim_run_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrunrighttargetcast";
animname="anim_sideviewrunrighttargetcast";
};
%player.anim_run_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandupmelee";
animname="anim_sideviewstandupmelee";
};
%player.anim_stand_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstanddownmelee";
animname="anim_sideviewstanddownmelee";
};
%player.anim_stand_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandleftmelee";
animname="anim_sideviewstandleftmelee";
};
%player.anim_stand_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandrightmelee";
animname="anim_sideviewstandrightmelee";
};
%player.anim_stand_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrunupmelee";
animname="anim_sideviewrunupmelee";
};
%player.anim_run_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrundownmelee";
animname="anim_sideviewrundownmelee";
};
%player.anim_run_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrunleftmelee";
animname="anim_sideviewrunleftmelee";
};
%player.anim_run_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewrunrightmelee";
animname="anim_sideviewrunrightmelee";
};
%player.anim_run_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_stand_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_stand_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_stand_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_stand_right_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_run_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_run_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_run_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="FtA_P1:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_run_right_emote.add(%animobj);

///////////////////////////////////////////////////////
}

///////////////////////////////////////////////////////
//set projectile origins:

//here you can set the vector where projectiles launch from
//each direction (up,down,left,right) has a simset containing
//the vectors.  projectile skills can randomly choose which
//vector to use or specify one

for (%y=0;%y<%player.projectileorigindirset.getCount();%y++)
{
%dirset=%player.projectileorigindirset.getObject(%y);
%dirset.deleteObjects();
}

%spritesize=%player.sprite.getSpriteSize();

//up origins (can have multiple origins)
%projectileorigin=new ScriptObject()
{
x=0;
y=%spritesize.Y/2;//units above the players origin
};

%dirset=%player.projectileorigindirset.getObject(0);
%dirset.add(%projectileorigin);

//down origins (can have multiple origins)
%projectileorigin=new ScriptObject()
{
x=0;
y=-(%spritesize.Y/2);//units below the players origin
};

%dirset=%player.projectileorigindirset.getObject(1);
%dirset.add(%projectileorigin);

//left origins (can have multiple origins)
%projectileorigin=new ScriptObject()
{
x=-(%spritesize.X/2);//units left of players origin
y=0;
};

%dirset=%player.projectileorigindirset.getObject(2);
%dirset.add(%projectileorigin);

//right origins (can have multiple origins)
%projectileorigin=new ScriptObject()
{
x=%spritesize.X/2;//units right of players origin
y=0;
};

%dirset=%player.projectileorigindirset.getObject(3);
%dirset.add(%projectileorigin);

///////////////////////////////////////////////////////

}//end loadsprite(%this)
