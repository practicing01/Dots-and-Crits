function DeusExTelum::ass_unload_radar(%this)
{

Canvas.popDialog(%this.gui_radar);

%this.gui_radar.delete();

AssetDatabase.releaseAsset(%this.ass_hollowarrow.getAssetId());

}
