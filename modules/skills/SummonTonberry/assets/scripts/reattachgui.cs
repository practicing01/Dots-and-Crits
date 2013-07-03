function class_tonberry::reattachgui(%this,%splitstate)
{

if (!%splitstate)//merge
{

%this.attachGui(%this.handle_attached_gui,DotsandCritswindow,false,"0" SPC -((%this.handle_attached_gui.getExtent().W/2)+50));

}
else//split
{

if (!%this.summoner)//player 0
{

%this.attachGui(%this.handle_attached_gui,scenewindow_player1,false,"0" SPC -((%this.handle_attached_gui.getExtent().W/2)+50));

}
else//player 1
{

%this.attachGui(%this.handle_attached_gui,scenewindow_player2,false,"0" SPC -((%this.handle_attached_gui.getExtent().W/2)+50));

}

}

}
