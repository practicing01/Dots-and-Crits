function GillBalentine::loadsprite(%this)//change GillBalentine to your module's name
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
%ass=AssetDatabase.acquireAsset("GillBalentine:image_td_down_stand");//change GillBalentine to your module's name

%player.sprite.Position="0 0";
%player.sprite.setFixedAngle(true);
%player.sprite.clearCollisionShapes();
%player.sprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));
%player.sprite.clearSprites();
%player.spriteid=%player.sprite.addSprite();
%player.sprite.setSpriteLocalPosition(0,0);
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%player.sprite.SetSpriteDepth(1);

AssetDatabase.releaseAsset(%ass.getAssetId());

//if you kept the same naming convention, change GillBalentine to your module's name
//if not, change the strings to match your animation asset's names
//the movement animations are required
%player.anim_stand_up="GillBalentine:anim_td_up_stand";
%player.anim_stand_down="GillBalentine:anim_td_down_stand";
%player.anim_stand_left="GillBalentine:anim_td_left_stand";
%player.anim_stand_right="GillBalentine:anim_td_right_stand";
%player.anim_run_up="GillBalentine:anim_td_up_run";
%player.anim_run_down="GillBalentine:anim_td_down_run";
%player.anim_run_left="GillBalentine:anim_td_left_run";
%player.anim_run_right="GillBalentine:anim_td_right_run";
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
anim="GillBalentine:anim_td_up_stand_selfcast";
animname="anim_td_up_stand_selfcast";
};
%player.anim_stand_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_down_stand_selfcast";
animname="anim_td_down_stand_selfcast";
};
%player.anim_stand_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_left_stand_selfcast";
animname="anim_td_left_stand_selfcast";
};
%player.anim_stand_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_right_stand_selfcast";
animname="anim_td_right_stand_selfcast";
};
%player.anim_stand_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_up_run_selfcast";
animname="anim_td_up_run_selfcast";
};
%player.anim_run_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_down_run_selfcast";
animname="anim_td_down_run_selfcast";
};
%player.anim_run_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_left_run_selfcast";
animname="anim_td_left_run_selfcast";
};
%player.anim_run_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_right_run_selfcast";
animname="anim_td_right_run_selfcast";
};
%player.anim_run_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_up_stand_targetcast";
animname="anim_td_up_stand_targetcast";
};
%player.anim_stand_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_down_stand_targetcast";
animname="anim_td_down_stand_targetcast";
};
%player.anim_stand_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_left_stand_targetcast";
animname="anim_td_left_stand_targetcast";
};
%player.anim_stand_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_right_stand_targetcast";
animname="anim_td_right_stand_targetcast";
};
%player.anim_stand_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_up_run_targetcast";
animname="anim_td_up_run_targetcast";
};
%player.anim_run_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_down_run_targetcast";
animname="anim_td_down_run_targetcast";
};
%player.anim_run_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_left_run_targetcast";
animname="anim_td_left_run_targetcast";
};
%player.anim_run_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_right_run_targetcast";
animname="anim_td_right_run_targetcast";
};
%player.anim_run_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_up_stand_melee";
animname="anim_td_up_stand_melee";
};
%player.anim_stand_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_down_stand_melee";
animname="anim_td_down_stand_melee";
};
%player.anim_stand_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_left_stand_melee";
animname="anim_td_left_stand_melee";
};
%player.anim_stand_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_right_stand_melee";
animname="anim_td_right_stand_melee";
};
%player.anim_stand_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_up_run_melee";
animname="anim_td_up_run_melee";
};
%player.anim_run_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_down_run_melee";
animname="anim_td_down_run_melee";
};
%player.anim_run_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_left_run_melee";
animname="anim_td_left_run_melee";
};
%player.anim_run_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_right_run_melee";
animname="anim_td_right_run_melee";
};
%player.anim_run_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_up_stand";
animname="anim_td_up_stand";
};
%player.anim_stand_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_down_stand";
animname="anim_td_down_stand";
};
%player.anim_stand_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_left_stand";
animname="anim_td_left_stand";
};
%player.anim_stand_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_right_stand";
animname="anim_td_right_stand";
};
%player.anim_stand_right_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_up_run";
animname="anim_td_up_run";
};
%player.anim_run_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_down_run";
animname="anim_td_down_run";
};
%player.anim_run_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_left_run";
animname="anim_td_left_run";
};
%player.anim_run_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_td_right_run";
animname="anim_td_right_run";
};
%player.anim_run_right_emote.add(%animobj);

///////////////////////////////////////////////////////
}
else//the following is the same as above but for sideview camera
{

%ass=AssetDatabase.acquireAsset("GillBalentine:image_sv_down_stand");

%player.sprite.Position="0 0";
%player.sprite.setFixedAngle(true);
%player.sprite.clearCollisionShapes();
%player.sprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));
%player.sprite.clearSprites();
%player.spriteid=%player.sprite.addSprite();
%player.sprite.setSpriteLocalPosition(0,0);
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%player.sprite.SetSpriteDepth(1);

AssetDatabase.releaseAsset(%ass.getAssetId());

%player.anim_stand_up="GillBalentine:anim_sv_up_stand";
%player.anim_stand_down="GillBalentine:anim_sv_down_stand";
%player.anim_stand_left="GillBalentine:anim_sv_left_stand";
%player.anim_stand_right="GillBalentine:anim_sv_right_stand";
%player.anim_run_up="GillBalentine:anim_sv_up_run";
%player.anim_run_down="GillBalentine:anim_sv_down_run";
%player.anim_run_left="GillBalentine:anim_sv_left_run";
%player.anim_run_right="GillBalentine:anim_sv_right_run";
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
anim="GillBalentine:anim_sv_up_stand_selfcast";
animname="anim_sv_up_stand_selfcast";
};
%player.anim_stand_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_down_stand_selfcast";
animname="anim_sv_down_stand_selfcast";
};
%player.anim_stand_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_left_stand_selfcast";
animname="anim_sv_left_stand_selfcast";
};
%player.anim_stand_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_right_stand_selfcast";
animname="anim_sv_right_stand_selfcast";
};
%player.anim_stand_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_up_run_selfcast";
animname="anim_sv_up_run_selfcast";
};
%player.anim_run_up_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_down_run_selfcast";
animname="anim_sv_down_run_selfcast";
};
%player.anim_run_down_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_left_run_selfcast";
animname="anim_sv_left_run_selfcast";
};
%player.anim_run_left_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_right_run_selfcast";
animname="anim_sv_right_run_selfcast";
};
%player.anim_run_right_selfcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_up_stand_targetcast";
animname="anim_sv_up_stand_targetcast";
};
%player.anim_stand_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_down_stand_targetcast";
animname="anim_sv_down_stand_targetcast";
};
%player.anim_stand_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_left_stand_targetcast";
animname="anim_sv_left_stand_targetcast";
};
%player.anim_stand_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_right_stand_targetcast";
animname="anim_sv_right_stand_targetcast";
};
%player.anim_stand_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_up_run_targetcast";
animname="anim_sv_up_run_targetcast";
};
%player.anim_run_up_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_down_run_targetcast";
animname="anim_sv_down_run_targetcast";
};
%player.anim_run_down_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_left_run_targetcast";
animname="anim_sv_left_run_targetcast";
};
%player.anim_run_left_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_right_run_targetcast";
animname="anim_sv_right_run_targetcast";
};
%player.anim_run_right_targetcast.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_up_stand_melee";
animname="anim_sv_up_stand_melee";
};
%player.anim_stand_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_down_stand_melee";
animname="anim_sv_down_stand_melee";
};
%player.anim_stand_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_left_stand_melee";
animname="anim_sv_left_stand_melee";
};
%player.anim_stand_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_right_stand_melee";
animname="anim_sv_right_stand_melee";
};
%player.anim_stand_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_up_run_melee";
animname="anim_sv_up_run_melee";
};
%player.anim_run_up_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_down_run_melee";
animname="anim_sv_down_run_melee";
};
%player.anim_run_down_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_left_run_melee";
animname="anim_sv_left_run_melee";
};
%player.anim_run_left_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_right_run_melee";
animname="anim_sv_right_run_melee";
};
%player.anim_run_right_melee.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_up_stand";
animname="anim_sv_up_run_stand";
};
%player.anim_stand_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_down_stand";
animname="anim_sv_down_stand";
};
%player.anim_stand_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_left_stand";
animname="anim_sv_left_stand";
};
%player.anim_stand_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_right_stand";
animname="anim_sv_right_stand";
};
%player.anim_stand_right_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_up_run";
animname="anim_sv_up_run";
};
%player.anim_run_up_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_down_run";
animname="anim_sv_down_run";
};
%player.anim_run_down_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_left_run";
animname="anim_sv_left_run";
};
%player.anim_run_left_emote.add(%animobj);

%animobj=new ScriptObject()
{
anim="GillBalentine:anim_sv_right_run";
animname="anim_sv_right_run";
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
