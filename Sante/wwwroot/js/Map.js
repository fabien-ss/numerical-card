function PopupCentrer(IdTerritory) {
    console.log(IdTerritory.toString());
    var top=(screen.height)/2;
    var left=(screen.width)/2;
    window.open("/Territory/Visualisation?IdTerritoire="+IdTerritory, "","top="+top+",left="+left+",width="+left+",height="+top);
}