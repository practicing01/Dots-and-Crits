function intrepid::loadsprite(%this)
{
%this.loadass();

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
%ass=AssetDatabase.acquireAsset("intrepid:image_topdown");

%player.sprite.Position="0 0";
%player.sprite.setFixedAngle(true);
%player.sprite.clearCollisionShapes();
%player.sprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));
%player.sprite.clearSprites();
%player.spriteid=%player.sprite.addSprite();
%player.sprite.setSpriteLocalPosition(0,0);
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%player.sprite.setSpriteImage("intrepid:image_topdown",0);
%player.sprite.SetSpriteDepth(1);

AssetDatabase.releaseAsset(%ass.getAssetId());

%player.anim_stand_up="intrepid:anim_topdownstandup";
%player.anim_stand_down="intrepid:anim_topdownstanddown";
%player.anim_stand_left="intrepid:anim_topdownstandleft";
%player.anim_stand_right="intrepid:anim_topdownstandright";
%player.anim_run_up="intrepid:anim_topdownrunup";
%player.anim_run_down="intrepid:anim_topdownrundown";
%player.anim_run_left="intrepid:anim_topdownrunleft";
%player.anim_run_right="intrepid:anim_topdownrunright";
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
anim="intrepid:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_stand_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_stand_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_stand_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_stand_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_run_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_run_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_run_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_run_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_stand_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_stand_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_stand_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_stand_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_run_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_run_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_run_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_run_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_stand_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_stand_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_stand_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_stand_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_run_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_run_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_run_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_run_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_stand_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_stand_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_stand_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_stand_right_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandup";
animname="anim_topdownstandup";
};
%player.anim_run_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstanddown";
animname="anim_topdownstanddown";
};
%player.anim_run_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandleft";
animname="anim_topdownstandleft";
};
%player.anim_run_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_topdownstandright";
animname="anim_topdownstandright";
};
%player.anim_run_right_emote.add(%animobj);

///////////////////////////////////////////////////////
}
else
{

%ass=AssetDatabase.acquireAsset("intrepid:image_sideview");

%player.sprite.Position="0 0";
%player.sprite.setFixedAngle(true);
%player.sprite.clearCollisionShapes();
%player.sprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));
%player.sprite.clearSprites();
%player.spriteid=%player.sprite.addSprite();
%player.sprite.setSpriteLocalPosition(0,0);
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%player.sprite.setSpriteImage("intrepid:image_sideview",0);
%player.sprite.SetSpriteDepth(1);

AssetDatabase.releaseAsset(%ass.getAssetId());

%player.anim_stand_up="intrepid:anim_sideviewstandup";
%player.anim_stand_down="intrepid:anim_sideviewstanddown";
%player.anim_stand_left="intrepid:anim_sideviewstandleft";
%player.anim_stand_right="intrepid:anim_sideviewstandright";
%player.anim_run_up="intrepid:anim_sideviewrunup";
%player.anim_run_down="intrepid:anim_sideviewrundown";
%player.anim_run_left="intrepid:anim_sideviewrunleft";
%player.anim_run_right="intrepid:anim_sideviewrunright";
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
anim="intrepid:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_stand_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_stand_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_stand_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_stand_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_run_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_run_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_run_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_run_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_stand_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_stand_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_stand_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_stand_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_run_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_run_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_run_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_run_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_stand_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_stand_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_stand_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_stand_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_run_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_run_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_run_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_run_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_stand_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_stand_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_stand_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_stand_right_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandup";
animname="anim_sideviewstandup";
};
%player.anim_run_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstanddown";
animname="anim_sideviewstanddown";
};
%player.anim_run_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandleft";
animname="anim_sideviewstandleft";
};
%player.anim_run_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="intrepid:anim_sideviewstandright";
animname="anim_sideviewstandright";
};
%player.anim_run_right_emote.add(%animobj);


///////////////////////////////////////////////////////
}

///////////////////////////////////////////////////////
//set projectile origins

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
