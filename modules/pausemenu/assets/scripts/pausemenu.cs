function gui_pausemenu::exitgame()
{
quit();
}

function gui_pausemenu::returntomainmenu()
{
if (ConsoleDialog.isAwake()){Canvas.popDialog(ConsoleDialog);}
//%buttonsound=alxPlay(audio_guibuttonpress);
cancelallschedules();
//alxStop($levelmusic);
Canvas.popDialog(gui_pausemenu);
Canvas.popDialog(gui_skillbar);
unloadskills();
$levelmoduleid.ScopeSet.sudodestroy();
DotsandCritsscene.clear();

AssetDatabase.purgeAssets();

//set camera position to 0 0
if (isObject(scenewindow_player1))
{
scenewindow_player1.setVisible(false);
}
if (isObject(scenewindow_player2))
{
scenewindow_player2.setVisible(false);
}
DotsandCritswindow.dismount();
DotsandCritswindow.setVisible(true);
DotsandCritswindow.setCameraPosition(0,0);
//set skill bar to bottom
%tmpsplitplane=$splitplane;
$playerssplit=0;
$splitplane=1;
repositionskillbar();
$splitplane=%tmpsplitplane;

Canvas.pushDialog(gui_mainmenu);
Canvas.pushDialog(gui_skillbar);
}

function gui_pausemenu::togglemusic()
{
//%buttonsound=alxPlay(audio_guibuttonpress);
if ($cantogglepausemenu)
{
if ($musicon)
{
$musicon=false;
//alxStop($levelmusic);
}
else
{
$musicon=true;
//$levelmusic=alxPlay(audio_levelmusic);
}
}
}

function togglepausemenu()
{
if (ConsoleDialog.isAwake()){Canvas.popDialog(ConsoleDialog);}
if (!gui_pausemenu.isAwake()&&!gui_mainmenu.isAwake()&&$cantogglepausemenu)
{
Canvas.pushDialog(gui_pausemenu);
}
else if (gui_pausemenu.isAwake())
{
Canvas.popDialog(gui_pausemenu);
}
}

function pausemenu::create(%this)
{
DotsandCrits.add(TamlRead("./../gui/pausemenu.gui.taml"));
gui_pausemenu.resize(0,0,$resolution.X,$resolution.Y);
exec("./listmenus.cs");
}

function pausemenu::destroy(%this)
{
if (isObject(gui_pausemenu))
{
if (gui_pausemenu.isAwake())
{
Canvas.popDialog(gui_pausemenu);
}
}
}
