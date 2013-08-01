function catragdoll::loaddwo(%this)
{

%player=$players.getObject(0);
%playerspritesize=%player.sprite.getSpriteSize();

%headass=AssetDatabase.acquireAsset("catragdoll:image_head");

%head=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%headass);
Image="catragdoll:image_head";
class="class_catragdollbodypart";
health=100;
//CollisionCallback=true;
SceneGroup=26;//dynamic world object
//FixedAngle=true;
SceneLayer=15;
Bullet=true;
};
DotsandCritsscene.add(%head);
%head.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%headass));

%headsize=%head.getSize();

//set position
if (%player.curdir==0)//up
{
%head.Position.Y-=(%playerspritesize.Y)+(%headsize.Y/2);
}
else if (%player.curdir==1)//down
{
%head.Position.Y+=(%playerspritesize.Y)+(%headsize.Y/2);
}
else if (%player.curdir==2)//left
{
%head.Position.X+=(%playerspritesize.X)+(%headsize.X/2);
}
else if (%player.curdir==3)//right
{
%head.Position.X-=(%playerspritesize.X)+(%headsize.X/2);
}

AssetDatabase.releaseAsset(%headass.getAssetId());

///////////////////////////////////////////////////////

%bodyass=AssetDatabase.acquireAsset("catragdoll:image_body");

%body=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%bodyass);
Image="catragdoll:image_body";
class="class_catragdollbodypart";
health=100;
//CollisionCallback=true;
SceneGroup=26;//dynamic world object
//FixedAngle=true;
SceneLayer=16;
Bullet=true;
};
DotsandCritsscene.add(%body);
%body.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%bodyass));

%bodysize=%body.getSize();

//set position
if (%player.curdir==0)//up
{
%body.Position.Y-=(%playerspritesize.Y)+(%bodysize.Y/2);
}
else if (%player.curdir==1)//down
{
%body.Position.Y+=(%playerspritesize.Y)+(%bodysize.Y/2);
}
else if (%player.curdir==2)//left
{
%body.Position.X+=(%playerspritesize.X)+(%bodysize.X/2);
}
else if (%player.curdir==3)//right
{
%body.Position.X-=(%playerspritesize.X)+(%bodysize.X/2);
}

AssetDatabase.releaseAsset(%bodyass.getAssetId());

///////////////////////////////////////////////////////

%leftarmass=AssetDatabase.acquireAsset("catragdoll:image_leftarm");

%leftarm=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%leftarmass);
Image="catragdoll:image_leftarm";
class="class_catragdollbodypart";
health=100;
//CollisionCallback=true;
SceneGroup=26;//dynamic world object
//FixedAngle=true;
SceneLayer=15;
Bullet=true;
};
DotsandCritsscene.add(%leftarm);
%leftarm.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%leftarmass));

%leftarmsize=%leftarm.getSize();

//set position
if (%player.curdir==0)//up
{
%leftarm.Position.Y-=(%playerspritesize.Y)+(%leftarmsize.Y/2);
}
else if (%player.curdir==1)//down
{
%leftarm.Position.Y+=(%playerspritesize.Y)+(%leftarmsize.Y/2);
}
else if (%player.curdir==2)//left
{
%leftarm.Position.X+=(%playerspritesize.X)+(%leftarmsize.X/2);
}
else if (%player.curdir==3)//right
{
%leftarm.Position.X-=(%playerspritesize.X)+(%leftarmsize.X/2);
}

AssetDatabase.releaseAsset(%leftarmass.getAssetId());

///////////////////////////////////////////////////////

%leftlegass=AssetDatabase.acquireAsset("catragdoll:image_leftleg");

%leftleg=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%leftlegass);
Image="catragdoll:image_leftleg";
class="class_catragdollbodypart";
health=100;
//CollisionCallback=true;
SceneGroup=26;//dynamic world object
//FixedAngle=true;
SceneLayer=15;
Bullet=true;
};
DotsandCritsscene.add(%leftleg);
%leftleg.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%leftlegass));

%leftlegsize=%leftleg.getSize();

//set position
if (%player.curdir==0)//up
{
%leftleg.Position.Y-=(%playerspritesize.Y)+(%leftlegsize.Y/2);
}
else if (%player.curdir==1)//down
{
%leftleg.Position.Y+=(%playerspritesize.Y)+(%leftlegsize.Y/2);
}
else if (%player.curdir==2)//left
{
%leftleg.Position.X+=(%playerspritesize.X)+(%leftlegsize.X/2);
}
else if (%player.curdir==3)//right
{
%leftleg.Position.X-=(%playerspritesize.X)+(%leftlegsize.X/2);
}

AssetDatabase.releaseAsset(%leftlegass.getAssetId());

///////////////////////////////////////////////////////

%rightarmass=AssetDatabase.acquireAsset("catragdoll:image_rightarm");

%rightarm=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%rightarmass);
Image="catragdoll:image_rightarm";
class="class_catragdollbodypart";
health=100;
//CollisionCallback=true;
SceneGroup=26;//dynamic world object
//FixedAngle=true;
SceneLayer=15;
Bullet=true;
};
DotsandCritsscene.add(%rightarm);
%rightarm.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%rightarmass));

%rightarmsize=%rightarm.getSize();

//set position
if (%player.curdir==0)//up
{
%rightarm.Position.Y-=(%playerspritesize.Y)+(%rightarmsize.Y/2);
}
else if (%player.curdir==1)//down
{
%rightarm.Position.Y+=(%playerspritesize.Y)+(%rightarmsize.Y/2);
}
else if (%player.curdir==2)//left
{
%rightarm.Position.X+=(%playerspritesize.X)+(%rightarmsize.X/2);
}
else if (%player.curdir==3)//right
{
%rightarm.Position.X-=(%playerspritesize.X)+(%rightarmsize.X/2);
}

AssetDatabase.releaseAsset(%rightarmass.getAssetId());

///////////////////////////////////////////////////////

%rightlegass=AssetDatabase.acquireAsset("catragdoll:image_rightleg");

%rightleg=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%rightlegass);
Image="catragdoll:image_rightleg";
class="class_catragdollbodypart";
health=100;
//CollisionCallback=true;
SceneGroup=26;//dynamic world object
//FixedAngle=true;
SceneLayer=15;
Bullet=true;
};
DotsandCritsscene.add(%rightleg);
%rightleg.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%rightlegass));

%rightlegsize=%rightleg.getSize();

//set position
if (%player.curdir==0)//up
{
%rightleg.Position.Y-=(%playerspritesize.Y)+(%rightlegsize.Y/2);
}
else if (%player.curdir==1)//down
{
%rightleg.Position.Y+=(%playerspritesize.Y)+(%rightlegsize.Y/2);
}
else if (%player.curdir==2)//left
{
%rightleg.Position.X+=(%playerspritesize.X)+(%rightlegsize.X/2);
}
else if (%player.curdir==3)//right
{
%rightleg.Position.X-=(%playerspritesize.X)+(%rightlegsize.X/2);
}

AssetDatabase.releaseAsset(%rightlegass.getAssetId());

///////////////////////////////////////////////////////

%tailass=AssetDatabase.acquireAsset("catragdoll:image_tail");

%tail=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%tailass);
Image="catragdoll:image_tail";
class="class_catragdollbodypart";
health=100;
//CollisionCallback=true;
SceneGroup=26;//dynamic world object
//FixedAngle=true;
SceneLayer=15;
Bullet=true;
};
DotsandCritsscene.add(%tail);
%tail.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%tailass));

%tailsize=%tail.getSize();

//set position
if (%player.curdir==0)//up
{
%tail.Position.Y-=(%playerspritesize.Y)+(%tailsize.Y/2);
}
else if (%player.curdir==1)//down
{
%tail.Position.Y+=(%playerspritesize.Y)+(%tailsize.Y/2);
}
else if (%player.curdir==2)//left
{
%tail.Position.X+=(%playerspritesize.X)+(%tailsize.X/2);
}
else if (%player.curdir==3)//right
{
%tail.Position.X-=(%playerspritesize.X)+(%tailsize.X/2);
}

AssetDatabase.releaseAsset(%tailass.getAssetId());

///////////////////////////////////////////////////////

%head.Position.Y+=%bodysize.Y/2;
%tail.Position.Y-=%bodysize.Y/2;
%leftarm.Position.X-=%bodysize.X/2;
%leftarm.Position.Y+=%bodysize.Y/4;
%leftleg.Position.X-=%bodysize.X/4;
%leftleg.Position.Y-=%bodysize.Y/2;
%rightarm.Position.X+=%bodysize.X/2;
%rightarm.Position.Y+=%bodysize.Y/4;
%rightleg.Position.X+=%bodysize.X/4;
%rightleg.Position.Y-=%bodysize.Y/2;

///////////////////////////////////////////////////////

DotsandCritsscene.createDistanceJoint(%head,%body,
%head.getLocalPoint(%body.Position),"0 0",0.1,3,0.0,true);

DotsandCritsscene.createDistanceJoint(%tail,%body,
%tail.getLocalPoint(%body.Position),"0 0",0.1,3,0.0,true);

DotsandCritsscene.createDistanceJoint(%leftarm,%body,
%leftarm.getLocalPoint(%body.Position),"0 0",0.1,3,0.0,true);

DotsandCritsscene.createDistanceJoint(%leftleg,%body,
%leftleg.getLocalPoint(%body.Position),"0 0",0.1,3,0.0,true);

DotsandCritsscene.createDistanceJoint(%rightarm,%body,
%rightarm.getLocalPoint(%body.Position),"0 0",0.1,3,0.0,true);

DotsandCritsscene.createDistanceJoint(%rightleg,%body,
%rightleg.getLocalPoint(%body.Position),"0 0",0.1,3,0.0,true);

/*DotsandCritsscene.createRopeJoint(%head,%body,
%head.getLocalPoint(%body.Position),"0 0",0.1,false);

DotsandCritsscene.createRopeJoint(%tail,%body,
%tail.getLocalPoint(%body.Position),"0 0",0.1,false);

DotsandCritsscene.createRopeJoint(%leftarm,%body,
%leftarm.getLocalPoint(%body.Position),"0 0",0.1,false);

DotsandCritsscene.createRopeJoint(%leftleg,%body,
%leftleg.getLocalPoint(%body.Position),"0 0",0.1,false);

DotsandCritsscene.createRopeJoint(%rightarm,%body,
%rightarm.getLocalPoint(%body.Position),"0 0",0.1,false);

DotsandCritsscene.createRopeJoint(%rightleg,%body,
%rightleg.getLocalPoint(%body.Position),"0 0",0.1,false);*/

/*%headjoint=DotsandCritsscene.createRevoluteJoint(%head,%body,
%head.getLocalPoint(%body.Position),"0 0",false);

//DotsandCritsscene.setRevoluteJointLimit(%headjoint,true,90,270);

%tailjoint=DotsandCritsscene.createRevoluteJoint(%tail,%body,
%tail.getLocalPoint(%body.Position),"0 0",false);

//DotsandCritsscene.setRevoluteJointLimit(%tailjoint,true,90,270);

%leftarmjoint=DotsandCritsscene.createRevoluteJoint(%leftarm,%body,
%leftarm.getLocalPoint(%body.Position),"0 0",false);

//DotsandCritsscene.setRevoluteJointLimit(%leftarmjoint,true,180,360);

%leftlegjoint=DotsandCritsscene.createRevoluteJoint(%leftleg,%body,
%leftleg.getLocalPoint(%body.Position),"0 0",false);

//DotsandCritsscene.setRevoluteJointLimit(%leftlegjoint,true,180,270);

%rightarmjoint=DotsandCritsscene.createRevoluteJoint(%rightarm,%body,
%rightarm.getLocalPoint(%body.Position),"0 0",false);

//DotsandCritsscene.setRevoluteJointLimit(%rightarmjoint,true,0,180);

%rightlegjoint=DotsandCritsscene.createRevoluteJoint(%rightleg,%body,
%rightleg.getLocalPoint(%body.Position),"0 0",false);

//DotsandCritsscene.setRevoluteJointLimit(%rightlegjoint,true,90,180);*/

///////////////////////////////////////////////////////

%head.playAnimation("catragdoll:anim_head");
%body.playAnimation("catragdoll:anim_body");
%leftarm.playAnimation("catragdoll:anim_leftarm");
%leftleg.playAnimation("catragdoll:anim_leftleg");
%rightarm.playAnimation("catragdoll:anim_rightarm");
%rightleg.playAnimation("catragdoll:anim_rightleg");
%tail.playAnimation("catragdoll:anim_tail");

}//end loaddwo
