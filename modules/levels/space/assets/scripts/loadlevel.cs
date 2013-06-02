function space::loadlevel(%this)
{
cancelallschedules();
DotsandCritsscene.clear();

if ($view==0)
{
%this.loadedscene=TamlRead("./../../scenes/topdown.scene.taml");
}
else
{
%this.loadedscene=TamlRead("./../../scenes/sideview.scene.taml");
}

if (!isObject(%this.loadedscene))
{
echo("couldn't read taml");
}

%this.loadedscene.setName("");
setCustomScene(%this.loadedscene);

if ($view==0)
{
DotsandCritsscene.setGravity(0,0);
}
else
{
$levelgravity=-20;
DotsandCritsscene.setGravity(0,$levelgravity);
}

initskills();

DotsandCrits.add(TamlRead("./../gui/score.gui.taml"));
Canvas.pushDialog(gui_spacescore);

}
