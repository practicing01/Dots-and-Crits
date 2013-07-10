exec("./ontouchdown.cs");

function bitweb::initmouseinput(%this)
{

%this.mousecaptureobj=new SceneObject()
{
size="1 1";
Position="0 0";
class="class_bitwebmousecaptureobj";
BodyType="static";
SceneGroup=2;
parentbitweb=%this;
};
DotsandCritsscene.add(%this.mousecaptureobj);

%this.mousecaptureobj.setUseInputEvents(true);

DotsandCritswindow.addInputListener(%this.mousecaptureobj);

}
