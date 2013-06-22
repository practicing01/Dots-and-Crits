function createDotsandCritswindow()
{

if (!isObject(DotsandCritswindow))
{
new SceneWindow(DotsandCritswindow);

DotsandCritswindow.Profile=DotsandCritswindowprofile;

Canvas.setContent(DotsandCritswindow);
}

DotsandCritswindow.stopCameraMove();
DotsandCritswindow.dismount();
DotsandCritswindow.setViewLimitOff();
DotsandCritswindow.setRenderGroups($allBits);
DotsandCritswindow.setRenderLayers($allBits);
DotsandCritswindow.setObjectInputEventGroupFilter($allBits);
DotsandCritswindow.setObjectInputEventLayerFilter($allBits);
DotsandCritswindow.setLockMouse(true);
DotsandCritswindow.setCameraPosition(0,0);

$resolution=getRes();
%y_times_100=100*$resolution.Y;
%cam_y=%y_times_100/$resolution.X;

DotsandCritswindow.setCameraSize(100,%cam_y);
DotsandCritswindow.setCameraAngle(0);

}

//-----------------------------------------------------------------------------

function destroyDotsandCritswindow()
{
    
if (isObject(DotsandCritswindow))
{
DotsandCritswindow.delete();
}

}

//-----------------------------------------------------------------------------

function destroyDotsandCritsscene()
{

if (isObject(DotsandCritsscene))
{
DotsandCritsscene.delete();
}

}

function setscenetowindow()
{

if (!isObject(DotsandCritsscene))
{
error("Cannot set DotsandCrits Scene to Window as the Scene is invalid.");
return;
}

DotsandCritswindow.setScene(DotsandCritsscene);

DotsandCritswindow.stopCameraMove();
DotsandCritswindow.dismount();
DotsandCritswindow.setViewLimitOff();
DotsandCritswindow.setRenderGroups($allBits);
DotsandCritswindow.setRenderLayers($allBits);
DotsandCritswindow.setObjectInputEventGroupFilter($allBits);
DotsandCritswindow.setObjectInputEventLayerFilter($allBits);
DotsandCritswindow.setLockMouse(true);
DotsandCritswindow.setCameraPosition(0,0);

$resolution=getRes();
%y_times_100=100*$resolution.Y;
%cam_y=%y_times_100/$resolution.X;

DotsandCritswindow.setCameraSize(100,%cam_y);
DotsandCritswindow.setCameraAngle(0);

}

function createDotsandCritsscene()
{

if (isObject(DotsandCritsscene))
{
destroyDotsandCritsscene();
}

new Scene(DotsandCritsscene);
            
if (!isObject(DotsandCritswindow))
{
error("DotsandCrits: Created scene but no window available.");
return;
}
        
setscenetowindow();    
}

function setcustomscene(%scene)
{

if (!isObject(%scene))
{
error("Cannot set DotsandCrits to use an invalid Scene.");
return;
}
   
destroyDotsandCritsscene();

%scene.setName("DotsandCritsscene");    

setscenetowindow();
}

//-----------------------------------------------------------------------------

function DotsandCritsscene::onCollision(%this, %sceneObjectA, %sceneObjectB, %collisionDetails)
{
    if (%sceneObjectA.isMethod(handleCollision))
        %sceneObjectA.handleCollision(%sceneObjectB, %collisionDetails);
    else
        %sceneObjectA.callOnBehaviors(handleCollision, %sceneObjectB, %collisionDetails);

    if (%sceneObjectB.isMethod(handleCollision))
        %sceneObjectB.handleCollision(%sceneObjectA, %collisionDetails);
    else
        %sceneObjectB.callOnBehaviors(handleCollision, %sceneObjectA, %collisionDetails);
}
